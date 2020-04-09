using Asp.NetCore.Business.Interface;
using Asp.NetCore.EFCore.Models.Extend;
using System;

namespace Asp.NetCore.Business.Service
{
    public class UserService : BaseService,IUserService
    {

        public UserService(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

        //public void Add()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Find()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
