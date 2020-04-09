using Asp.NetCore.EFCore.Models.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Asp.NetCore.Business.Interface
{
    public interface IBaseService 
    {
        #region Query
        /// <summary>
        /// 根据id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;
       
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;

        #endregion

        #region Add
        /// <summary>
        /// 新增数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回带主键的实体</returns>
        T Insert<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;

        /// <summary>
        /// 新增数据，即时Commit
        /// 多条sql 一个连接，事务插入
        /// </summary>
        /// <param name="tList"></param>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;
        #endregion

        #region Update
        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Update<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;

        /// <summary>
        /// 更新数据，即时Commit
        /// </summary>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// 根据主键删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete<T>(int Id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;

        /// <su+mary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <param name="t"></param>
        void Delete<T>(T t, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;

        /// <summary>
        /// 删除数据，即时Commit
        /// </summary>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Write) where T : class;
        #endregion

        #region Other
        /// <summary>
        /// 立即保存全部修改
        /// 把增/删的savechange给放到这里，是为了保证事务的
        /// </summary>
        void Commit();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="writeAndRead"></param>
        /// <returns></returns>
        IEnumerable<T> GetList<T>(int top, Expression<Func<T, bool>> funcWhere, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;

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
        PageInfo<T> PagingQuery<T>(Expression<Func<T, bool>> funcWhere, int pageCurrent, int pageSize, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;
        #endregion
    }
}
