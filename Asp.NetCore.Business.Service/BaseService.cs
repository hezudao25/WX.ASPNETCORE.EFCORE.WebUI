using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asp.NetCore.Business.Service
{

    /// <summary>
    /// 1.析构函数   实现
    /// </summary>
    public class BaseService : IBaseService
    {
        #region Identity

        /// <summary>
        /// 只允许子类可以访问
        /// </summary>
        protected DbContext Context { get; private set; }

        protected IDbContextFactory _ContextFactory { get; private set; }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="context"></param>
        public BaseService(IDbContextFactory contextFactory)
        {
            _ContextFactory = contextFactory;
        }
        #endregion Identity

        #region Query
        public T Find<T>(int id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class
        {
             Context = _ContextFactory.CreateContext(writeAndRead);
            return this.Context.Set<T>().Find(id);
        }       

        /// <summary>
        /// 这才是合理的做法，上端给条件，这里查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class
        {
            Context = _ContextFactory.CreateContext(writeAndRead);
            return this.Context.Set<T>().Where<T>(funcWhere);
        }
        /// <summary>
        /// 泛型list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="writeAndRead"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(int top, Expression<Func<T, bool>> funcWhere, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class
        {
            Context = _ContextFactory.CreateContext(writeAndRead);
            if (top > 0)
            {
                if (funcWhere is null) return this.Context.Set<T>().Take<T>(top).ToList();
                return this.Context.Set<T>().Where<T>(funcWhere).Take<T>(top).ToList();
            }
            else
            {
                if (funcWhere is null) return this.Context.Set<T>().ToList();
                return this.Context.Set<T>().Where<T>(funcWhere).ToList();
            }
        }
        #endregion

        #region Insert
        /// <summary>
        /// 即使保存  不需要再Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            if (writeAndRead == WriteAndReadEnum.Read)
            {
                throw new Exception("增删改操作不能指向从库~从库只能用作查询用途~~");
            }
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            this.Context.Set<T>().Add(t);
            this.Commit();//写在这里  就不需要单独commit  不写就需要 
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            this.Context.Set<T>().AddRange(tList);
            this.Commit();//一个链接  多个sql
            return tList;
        }
        #endregion

        #region Update
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            if (t == null) throw new Exception("t is null");

            this.Context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            this.Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();//保存 然后重置为UnChanged
        }

        public void Update<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();
        }

        #endregion

        #region Delete
        /// <summary>
        /// 先附加 再删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        /// <summary>
        /// 还可以增加非即时commit版本的，
        /// 做成protected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete<T>(int Id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class
        {
            this.Context = _ContextFactory.CreateContext(writeAndRead);
            foreach (var t in tList)
            {
                this.Context.Set<T>().Attach(t);
            }
            this.Context.Set<T>().RemoveRange(tList);
            this.Commit();
        }
        #endregion

        #region Other
        public void Commit()
        {
            this.Context.SaveChanges();
        }
        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }    
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">
        /// 定义IQueryable类型会先从数据库内查询分页,
        /// 如果定义IEnumerable类型则会先查询所有数据再分页</typeparam>
        /// <param name="result"></param>
        /// <param name="pageCurrent"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageInfo<T> PagingQuery<T>(Expression<Func<T, bool>> funcWhere, int pageCurrent, int pageSize, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class
        {
            
            Context = _ContextFactory.CreateContext(writeAndRead);
            IQueryable<T> result = Context.Set<T>().Where<T>(funcWhere);
          
            PageInfo<T> pageDto = new PageInfo<T>();
            if (pageCurrent < 1)
                pageCurrent = 1;
            var itemIndex = (pageCurrent - 1) * pageSize;

            var pageOfItems = result.Skip(itemIndex).Take(pageSize).ToList();
            var totalItemCount = result.Count();

            //总页数
            pageDto.PageCount = (int)Math.Ceiling(totalItemCount / (pageSize * 1.0));
            pageDto.PageCurrent = pageCurrent;
            pageDto.PageSize = pageSize;
            pageDto.Result = pageOfItems;
            pageDto.RowsCount = totalItemCount;

            return pageDto;
        }
        #endregion
    }
}
