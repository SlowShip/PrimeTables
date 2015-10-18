using NUnit.Framework;
using PrimeTables.Web.Services.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Web.UnitTests.Services
{
    [TestFixture]
    public class MultiplicationTableCalculatorTestFixture
    {
        [TestFixture]
        public class CreateTable : MultiplicationTableCalculatorTestFixture
        {
            [Test]
            public void CreateTable_WhenFactorsAreNull_ShouldThrowAnArgumentNullException()
            {
                // Arrange
                var subject = new MultiplicationTableCalculator();

                // Act
                TestDelegate act = () => subject.CreateTable(null);

                // Assert
                var ex = Assert.Throws<ArgumentNullException>(act);
                Assert.That(ex.ParamName, Is.EqualTo("factors"));
            }

            [Test]
            public void CreateTable_WhenFactorsAreNotNull_ReturnsATableWhoseTopRowIsTheListOfFactors()
            {
                // Arrange
                var factors = Enumerable.Range(1, 5).ToArray();

                var subject = new MultiplicationTableCalculator();

                // Act
                var result = subject.CreateTable(factors);

                // Assert
                for(int col = 1; col <= 5; col++)
                {
                    Assert.That(result[0, col], Is.EqualTo(factors[col - 1]));
                }
            }

            [Test]
            public void CreateTable_WhenFactorsAreNotNull_ReturnsATableWhoseFirstColumnIsTheListOfFactors()
            {
                // Arrange
                var factors = Enumerable.Range(1, 5).ToArray();

                var subject = new MultiplicationTableCalculator();

                // Act
                var result = subject.CreateTable(factors);

                // Assert
                for (int row = 1; row <= 5; row++)
                {
                    Assert.That(result[row, 0], Is.EqualTo(factors[row - 1]));
                }
            }

            [Test]
            public void CreateTable_WhenFactorsAreNotNull_ReturnsATableWhoseOtherValuesAreTheProductOfTheTopRowAndTheFirstColumn()
            {
                // Arrange
                var factors = Enumerable.Range(1, 5).ToArray();

                var subject = new MultiplicationTableCalculator();

                // Act
                var result = subject.CreateTable(factors);

                // Assert
                for (int col = 1; col <= 5; col++)
                {
                    for (int row = 1; row <= 5; row++)
                    {
                        var expected = result[0, col] * result[row, 0];
                        Assert.That(result[row, col], Is.EqualTo(expected));
                    }
                }
            }
        }
    }
}
