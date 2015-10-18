using NUnit.Framework;
using PrimeTables.Web.Services.Number;
using PrimeTables.Web.UnitTests.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables.Web.UnitTests.Services
{
    [TestFixture]
    public class PrimesSequenceGeneratorTestFixture
    {
        [TestFixture]
        public class CreateSequenceTestFixture : PrimesSequenceGeneratorTestFixture
        {
            [Test]
            public void CreateSequence_WhenLengthIsLessThanZero_ShouldThrowAnArgumentOutOfRangeException()
            {
                // Arrange
                var subject = new PrimesSequenceGenerator();

                // Act
                TestDelegate act = () => subject.CreateSequence(-1);

                // Assert
                var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
                Assert.That(ex.ParamName, Is.EqualTo("length"));
                Assert.That(ex.Message, Is.Not.Null);
            }

            [Test]
            public void CreateSequence_WhenLengthIsZero_ShouldReturnAnEmptyCollection()
            {
                // Arrange
                var subject = new PrimesSequenceGenerator();

                // Act
                var result = subject.CreateSequence(0);

                // Assert
                CollectionAssert.IsEmpty(result);
            }

            [Test]
            public void CreateSequence_WhenLengthIsOne_ShouldReturnTheNumberTwoInACollection()
            {
                // Arrange
                var subject = new PrimesSequenceGenerator();

                // Act
                var result = subject.CreateSequence(1);

                // Assert
                CollectionAssert.AreEqual(new int[] { 2 }, result);
            }

            [Test]
            public void CreateSequence_WhenLengthIsFive_ShouldReturnTheFirstFivePrimes()
            {
                // Arrange
                var subject = new PrimesSequenceGenerator();

                // Act
                var result = subject.CreateSequence(5);

                // Assert
                CollectionAssert.AreEqual(new int[] { 2, 3, 5, 7, 11 }, result);
            }

            [Test]
            public void CreateSequence_WhenLengthIs1000_ShouldReturnTheFirst1000Primes()
            {
                // Arrange
                var subject = new PrimesSequenceGenerator();

                // Act
                var result = subject.CreateSequence(1000);

                // Assert
                CollectionAssert.AreEqual(Primes.FirstThousand, result);
            }
        }
    }
}
