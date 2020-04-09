using Asp.NetCore.EFCore.Models;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            EFCoreContext context = new EFCoreContext();
            context.Database.EnsureDeleted();//删除数据库
            context.Database.EnsureCreated(); //新建数据库

            //Assert.Pass();
        }
    }
}