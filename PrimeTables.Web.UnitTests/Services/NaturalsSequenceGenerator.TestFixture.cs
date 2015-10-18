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
    public class NaturalsSequenceGeneratorTestFixture
    {
        [TestFixture]
        public class CreateSequenceTestFixture : NaturalsSequenceGeneratorTestFixture
        {
            [Test]
            public void CreateSequence_WhenLengthIsLessThanZero_ShouldThrowAnArgumentOutOfRangeException()
            {
                // Arrange
                var subject = new NaturalsSequenceGenerator();

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
                var subject = new NaturalsSequenceGenerator();

                // Act
                var result = subject.CreateSequence(0);

                // Assert
                CollectionAssert.IsEmpty(result);
            }

            [Test]
            public void CreateSequence_WhenLengthIsOne_ShouldReturnTheNumberOneInACollection()
            {
                // Arrange
                var subject = new NaturalsSequenceGenerator();

                // Act
                var result = subject.CreateSequence(1);

                // Assert
                CollectionAssert.AreEqual(new int[] { 1 }, result);
            }

            [Test]
            public void CreateSequence_WhenLengthIsFive_ShouldReturnTheNumbersOneToFive()
            {
                // Arrange
                var subject = new NaturalsSequenceGenerator();

                // Act
                var result = subject.CreateSequence(5);

                // Assert
                CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, result);
            }
        }
    }
}
