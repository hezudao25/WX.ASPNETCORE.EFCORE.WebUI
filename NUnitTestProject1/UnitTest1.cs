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
            context.Database.EnsureDeleted();//ɾ�����ݿ�
            context.Database.EnsureCreated(); //�½����ݿ�

            //Assert.Pass();
        }
    }
}