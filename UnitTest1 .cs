using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine(DAL.UserInfo.Instance.UserCheck("Admin"));
        }
        public void TestMethod2()
        {
            Model.UserInfo user = new Model.UserInfo { userName = "Guest", passWord = "sql.123", type = "����Ա" };
            Console.WriteLine(DAL.UserInfo.Instance.Add(user));
            Console.WriteLine(JsonConvert.SerializeObject(DAL.UserInfo.Instance.GetAll()));
            user.qq = "104512708";
            Console.WriteLine(DAL.UserInfo.Instance.Update(user));
            var model = DAL.UserInfo.Instance.GetModel("Guest");
            Console.WriteLine(JsonConvert.SerializeObject(model));
            Console.WriteLine(DAL.UserInfo.Instance.Delete("Guest"));
            var page = DAL.UserInfo.Instance.GetPage(new Model.Page{ pageIndex = 2, pageSize = 2 });
            Console.WriteLine(JsonConvert.SerializeObject(Page));
            Console.WriteLine(DAL.UserInfo.Instance.GetCount());

        }
    }
}
