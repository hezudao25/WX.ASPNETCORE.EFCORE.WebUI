using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using System;

namespace Asp.NetCore.Business.Service
{
    public class CompanyUserService : BaseService, ICompanyUserService
    {

        public CompanyUserService(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

        /// <summary>
        /// 如果遇到这种个性化的操作 我建议大家所有操作都选择主库
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteCompanyAndUser(int companyId)
        { 
            //var context= _ContextFactory.CreateContext(WriteAndReadEnum.Write);
            //context.Company.Remove();
            ////修改
            ////查询一下
            return true;
        }
    }
}
