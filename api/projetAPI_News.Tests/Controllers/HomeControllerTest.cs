using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projetAPI_News;
using projetAPI_News.Controllers;

namespace projetAPI_News.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disposer
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Affirmer
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
