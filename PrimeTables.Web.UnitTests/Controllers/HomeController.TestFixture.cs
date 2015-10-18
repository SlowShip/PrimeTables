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
using PrimeTables.Web.Models;
using Moq;
using PrimeTables.Web.ModelProviders.Number;

namespace PrimeTables.Web.UnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTestFixture
    {
        private IFixture fixture;
        private Mock<IMultiplicationTableViewModelFactory> viewModelFactory;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new MvcControllerCustomization());

            viewModelFactory = fixture.Freeze<Mock<IMultiplicationTableViewModelFactory>>();
        }

        [TestFixture]
        public class IndexTestFixture : HomeControllerTestFixture
        {
            private void VerifyModelHasDefaultValues(MultiplicationTableViewModel model)
            {
                Assert.That(model.TableSize, Is.Null);
                Assert.That(model.Table, Is.Null);
            }

            [Test]
            public void Index_WithNoRequestModel_ReturnsAViewResult()
            {
                // Arrange
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }

            [Test]
            public void Index_WithNoRequestModel_ReturnsADefaultViewModel()
            {
                // Arrange
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index() as ViewResult;

                // Assert
                var model = result.Model;
                Assert.That(model, Is.InstanceOf<MultiplicationTableViewModel>());
                VerifyModelHasDefaultValues((MultiplicationTableViewModel)model);
            }

            [Test]
            public void Index_WithNoRequestModel_ShouldNotUseTheViewModelFactory()
            {
                // Arrange
                var subject = fixture.Create<HomeController>();

                // Act
                subject.Index();

                // Assert
                viewModelFactory.Verify(fact => fact.Create(It.IsAny<SequenceType>(), It.IsAny<int>()), Times.Never());
            }

            [Test]
            public void Index_WhenTheModelStateIsInvalid_ReturnsAViewModelResult()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = fixture.Create<int>() };
                var subject = fixture.Create<HomeController>();
                subject.ModelState.AddModelError(fixture.Create<string>(), fixture.Create<string>());

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }

            [Test]
            public void Index_WhenTheModelStateIsInvalid_ReturnsAViewModelWithTheCorrectTableSize()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = fixture.Create<int>() };
                var subject = fixture.Create<HomeController>();
                subject.ModelState.AddModelError(fixture.Create<string>(), fixture.Create<string>());

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                var model = result.Model as MultiplicationTableViewModel;
                Assert.NotNull(model);
                Assert.That(model.TableSize, Is.EqualTo(req.TableSize));
            }

            [Test]
            public void Index_WhenTheModelStateIsInvalid_ShouldNotUseTheViewModelFactory()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = fixture.Create<int>() };
                var subject = fixture.Create<HomeController>();
                subject.ModelState.AddModelError(fixture.Create<string>(), fixture.Create<string>());

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                viewModelFactory.Verify(fact => fact.Create(It.IsAny<SequenceType>(), It.IsAny<int>()), Times.Never());
            }

            [TestCase(0)]
            [TestCase(20)]
            public void Index_WithSpecifiedTableSize_ReturnAViewResult(int tableSize)
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = tableSize };
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }

            [Test]
            public void Index_WithSpecifiedTableSizeOfZero_ReturnsADefaultViewModel()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = 0 };
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                var model = result.Model;
                Assert.That(model, Is.InstanceOf<MultiplicationTableViewModel>());
                VerifyModelHasDefaultValues((MultiplicationTableViewModel)model);
            }

            [Test]
            public void Index_WithSpecifiedTableSizeOfZero_ShouldNotUseTheViewModelFactory()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = 0 };
                var subject = fixture.Create<HomeController>();

                // Act
                subject.Index(req);

                // Assert
                viewModelFactory.Verify(fact => fact.Create(It.IsAny<SequenceType>(), It.IsAny<int>()), Times.Never());
            }

            [Test]
            public void Index_WithSpecifiedTableSizeGtZero_RequestsAPrimeNumberMultipicationTable()
            {
                // Arrange
                var req = new TableRequestBindingModel() { TableSize = fixture.Create<int>() };
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                viewModelFactory.Verify(fact => fact.Create(SequenceType.Primes, It.IsAny<int>()), Times.Once);
            }

            [Test]
            public void Index_WithSpecifiedTableSizeGtZero_RequestsTheSpecifiedTableSize()
            {
                // Arrange
                var tableSize = fixture.Create<int>();

                var req = new TableRequestBindingModel() { TableSize = tableSize };
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                viewModelFactory.Verify(fact => fact.Create(It.IsAny<SequenceType>(), tableSize), Times.Once);
            }

            [Test]
            public void Index_WithSpecifiedTableSizeGtZero_ShouldUseAViewModelCreatedByTheViewModelFactory()
            {
                // Arrange
                var expected = fixture.Create<MultiplicationTableViewModel>();   
                viewModelFactory.Setup(fact => fact.Create(It.IsAny<SequenceType>(), It.IsAny<int>()))
                    .Returns(expected);

                var req = new TableRequestBindingModel() { TableSize = fixture.Create<int>() };
                var subject = fixture.Create<HomeController>();

                // Act
                var result = subject.Index(req) as ViewResult;

                // Assert
                Assert.That(result.Model, Is.EqualTo(expected));
            }
        }
    }
}
