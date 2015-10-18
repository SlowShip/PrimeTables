using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Web.UnitTests.ModelProviders.Number
{
    [TestFixture]
    public class MultiplicationTableViewModelFactoryTestFixture
    {
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [TestFixture]
        public class CreateTestFixture : MultiplicationTableViewModelFactoryTestFixture
        {

        }
    }
}
