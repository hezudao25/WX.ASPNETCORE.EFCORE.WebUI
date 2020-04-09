using System;

namespace Asp.NetCore.Business.Interface
{
    /// <summary>
    /// 可以做一些个性化的操作
    /// </summary>
    public interface ICompanyUserService : IBaseService
    {

        bool DeleteCompanyAndUser(int companyId);
      
        //void Add();

        //void Delete();

        //void Update();

        //void Find();
    }
}
