using FluentValidation;
using PrimeTables.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.ModelValidators
{
    public static class TableRequestBindingModelErrorMessages
    {
        public const string TableSizeMustBePositive = "The table size must be positive.";
        public const string TableToLarge = "The specified table is too large. Tables must be smaller than 500 X 500";
    }

    public class TableRequestBindingModelValidator : AbstractValidator<TableRequestBindingModel>
    {
        public TableRequestBindingModelValidator()
        {
            RuleFor(request => request.TableSize)
                .GreaterThanOrEqualTo(0).WithMessage(TableRequestBindingModelErrorMessages.TableSizeMustBePositive)
                .LessThanOrEqualTo(500).WithMessage(TableRequestBindingModelErrorMessages.TableToLarge);
        }
    }
}