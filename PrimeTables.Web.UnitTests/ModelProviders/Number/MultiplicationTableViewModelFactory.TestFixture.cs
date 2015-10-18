using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using PrimeTables.Web.ModelProviders.Number;
using PrimeTables.Web.Services.Number;
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
        public void SetUpBase()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
        }

        [TestFixture]
        public class CtorTestFixture : MultiplicationTableViewModelFactoryTestFixture
        {
            [Test]
            public void Ctor_WithNullTableCalculator_ThrowsAnArgumentNullException()
            {
                // Arrange

                // Act
                TestDelegate act = () => new MultiplicationTableViewModelFactory(null, fixture.Create<Dictionary<SequenceType, ISequenceGenerator>>());

                // Assert
                var ex = Assert.Throws<ArgumentNullException>(act);
                Assert.That(ex.ParamName, Is.EqualTo("tableCalculator"));
            }

            [Test]
            public void Ctor_WithNullSequenceGenerators_ThrowsAnArgumentNullException()
            {
                // Arrange

                // Act
                TestDelegate act = () => new MultiplicationTableViewModelFactory(fixture.Create<IMultiplicationTableCalculator>(), null);

                // Assert
                var ex = Assert.Throws<ArgumentNullException>(act);
                Assert.That(ex.ParamName, Is.EqualTo("sequenceGenerators"));
            }

            [Test]
            public void Ctor_WithValidParameters_DoesNotThrowsAnException()
            {
                // Arrange

                // Act
                TestDelegate act = () => new MultiplicationTableViewModelFactory(
                    fixture.Create<IMultiplicationTableCalculator>(),
                    fixture.Create<Dictionary<SequenceType, ISequenceGenerator>>()
                    );

                // Assert
                Assert.DoesNotThrow(act);
            }
        }

        [TestFixture]
        public class CreateTestFixture : MultiplicationTableViewModelFactoryTestFixture
        {
            private Mock<IMultiplicationTableCalculator> tableCalculator;
            private IDictionary<SequenceType, ISequenceGenerator> sequenceGenerators;       

            [SetUp]
            public void SetUp()
            {
                tableCalculator = fixture.Freeze<Mock<IMultiplicationTableCalculator>>();
                
                sequenceGenerators = new Dictionary<SequenceType, ISequenceGenerator>();
                fixture.Inject(sequenceGenerators);
            }

            [TestCase(-1)]
            [TestCase(0)]
            public void Create_WithTableSizeLessThanOrEqualToZero_ThrowsAnArgumentOutOfRangeException(int tableSize)
            {
                // Arrange
                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                TestDelegate act = () => subject.Create(fixture.Create<SequenceType>(), tableSize);

                // Assert
                var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
                Assert.That(ex.ParamName, Is.EqualTo("tableSize"));
                Assert.That(ex.Message, Is.Not.Null);
            }

            [Test]
            public void Create_WhenThereIsNoHandlerForTheSpecifiedSequenceType_ThrowsNotSupportedException()
            {
                // Arrange
                sequenceGenerators.Add(SequenceType.Primes, fixture.Create<ISequenceGenerator>());

                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                TestDelegate act = () => subject.Create(SequenceType.Naturals, fixture.Create<int>());

                // Assert
                var ex = Assert.Throws<NotSupportedException>(act);
                Assert.That(ex.Message, Is.Not.Null);
            }

            [Test]
            public void Create_WhenThereIsAHandlerForTheSpecifiedSequenceType_RetrievesTheSequence()
            {
                // Arrange
                var tableSize = fixture.Create<int>();
                var sequenceType = fixture.Create<SequenceType>();

                var handlerMock = new Mock<ISequenceGenerator>();
                sequenceGenerators.Add(sequenceType, handlerMock.Object);

                tableCalculator.Setup(cal => cal.CreateTable(It.IsAny<IEnumerable<int>>())).Returns(new int[0, 0] { });

                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                subject.Create(sequenceType, tableSize);

                // Assert
                handlerMock.Verify(handler => handler.CreateSequence(tableSize), Times.Once);
            }

            [Test]
            public void Create_WhenThereIsAHandlerForTheSpecifiedSequenceType_UsesItsTableCalculator()
            {
                // Arrange
                var sequenceType = fixture.Create<SequenceType>();
                var expectedSequence = fixture.Create<List<int>>();

                var handlerMock = new Mock<ISequenceGenerator>();
                handlerMock.Setup(handler => handler.CreateSequence(It.IsAny<int>()))
                    .Returns(expectedSequence);
                sequenceGenerators.Add(sequenceType, handlerMock.Object);

                tableCalculator.Setup(cal => cal.CreateTable(expectedSequence)).Returns(new int[0,0]{}).Verifiable();
                
                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                subject.Create(sequenceType, fixture.Create<int>());

                // Assert
                tableCalculator.VerifyAll();
            }

            [Test]
            public void Create_WhenThereIsAHandlerForTheSpecifiedSequenceType_ReturnsAViewModelWithTheCorrectSize()
            {
                // Arrange
                var tableSize = fixture.Create<int>();

                var sequenceType = fixture.Create<SequenceType>();
                var expectedSequence = fixture.Create<List<int>>();

                var handlerMock = new Mock<ISequenceGenerator>();
                handlerMock.Setup(handler => handler.CreateSequence(It.IsAny<int>()))
                    .Returns(expectedSequence);
                sequenceGenerators.Add(sequenceType, handlerMock.Object);

                tableCalculator.Setup(cal => cal.CreateTable(expectedSequence)).Returns(new int[0, 0] { });

                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                var result = subject.Create(sequenceType, tableSize);

                // Assert
                Assert.That(result.TableSize, Is.EqualTo(tableSize));
            }

            [Test]
            public void Create_WhenThereIsAHandlerForTheSpecifiedSequenceType_ReturnsAViewModelWithTheCorrectTable()
            {
                // Arrange
                var expectedTable = new int[1, 1] { { 1 } };

                var sequenceType = fixture.Create<SequenceType>();
                var expectedSequence = fixture.Create<List<int>>();

                var handlerMock = new Mock<ISequenceGenerator>();
                handlerMock.Setup(handler => handler.CreateSequence(It.IsAny<int>()))
                    .Returns(expectedSequence);
                sequenceGenerators.Add(sequenceType, handlerMock.Object);

                tableCalculator.Setup(cal => cal.CreateTable(expectedSequence)).Returns(expectedTable);

                var subject = fixture.Create<MultiplicationTableViewModelFactory>();

                // Act
                var result = subject.Create(sequenceType, fixture.Create<int>());

                // Assert
                Assert.That(result.Table, Is.EqualTo(expectedTable));
            }
        }
    }
}
