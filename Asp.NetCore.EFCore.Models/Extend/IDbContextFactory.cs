using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    public interface IDbContextFactory
    {
        public EFCoreAllContext CreateContext(WriteAndReadEnum writeAndRead);
    }
}
