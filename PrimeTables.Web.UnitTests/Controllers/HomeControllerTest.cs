using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PrimeTables.Web;
using PrimeTables.Web.Controllers;
using NUnit.Framework;
using Ploeh.AutoFixture.AutoMoq;
using PrimeTables.Web.UnitTests.Setup.Autofixture.Customizations;
using Ploeh.AutoFixture;

namespace PrimeTables.Web.UnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTestFixture
    {
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new MvcControllerCustomization());
        }

        [Test]
        public void Index_ShouldReturnAViewResult()
        {
            // Arrange
            var subject = fixture.Create<HomeController>();

            // Act
            var result = subject.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
