using NUnit.Framework;
using Ploeh.AutoFixture;
using PrimeTables.Web.ModelValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.TestHelper;
using PrimeTables.Web.Models;

namespace PrimeTables.Web.UnitTests.ModelValidators
{
    [TestFixture]
    public class TableRequestBindingModelValidatorTestFixture
    {
        [Test]
        public void Validator_WhenTableSizeIsLessThanZero_ShouldHaveATableSizeValidationError()
        {
            // Arrange
            var model = new TableRequestBindingModel()
            {
                TableSize = -1
            };
            var subject = new TableRequestBindingModelValidator();

            // Act
            // Assert
            subject.ShouldHaveValidationErrorFor(m => m.TableSize, model);
        }

        [Test]
        public void Validator_WhenTableSizeIsLessThanZero_UsesTheTableSizeMustBePositiveErrorMessage()
        {
            // Arrange
            var model = new TableRequestBindingModel()
            {
                TableSize = -1
            };
            var subject = new TableRequestBindingModelValidator();

            // Act
            var result = subject.Validate(model);

            // Assert
            Assert.That(result.Errors.Single(e => e.PropertyName == "TableSize").ErrorMessage, Is.EqualTo(TableRequestBindingModelErrorMessages.TableSizeMustBePositive));
        }

        [Test]
        public void Validator_WhenTableSizeIsGreaterThan500_ShouldHaveATableSizeValidationError()
        {
            // Arrange
            var model = new TableRequestBindingModel()
            {
                TableSize = 501
            };
            var subject = new TableRequestBindingModelValidator();

            // Act
            // Assert
            subject.ShouldHaveValidationErrorFor(m => m.TableSize, model);
        }

        [Test]
        public void Validator_WhenTableSizeIsGreaterThan500_UsesTheTableTooLargeErrorMessage()
        {
            // Arrange
            var model = new TableRequestBindingModel()
            {
                TableSize = 501
            };
            var subject = new TableRequestBindingModelValidator();

            // Act
            var result = subject.Validate(model);

            // Assert
            Assert.That(result.Errors.Single(e => e.PropertyName == "TableSize").ErrorMessage, Is.EqualTo(TableRequestBindingModelErrorMessages.TableToLarge));
        }

        [Test]
        public void Validator_WhenTableSizeIsGreaterThanZeroAndLessThan500_ShouldNotHaveATableSizeValidationError()
        {
            // Arrange
            var model = new TableRequestBindingModel()
            {
                TableSize = 499
            };
            var subject = new TableRequestBindingModelValidator();

            // Act
            // Assert
            subject.ShouldNotHaveValidationErrorFor(m => m.TableSize, model);
        }

    }
}
