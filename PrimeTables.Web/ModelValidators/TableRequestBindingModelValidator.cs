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
        public const string TableToLarge = "The specified table is too large.";
    }

    public class TableRequestBindingModelValidator : AbstractValidator<TableRequestBindingModel>
    {
        public TableRequestBindingModelValidator()
        {
            RuleFor(request => request.TableSize)
                .GreaterThan(0).WithMessage(TableRequestBindingModelErrorMessages.TableSizeMustBePositive)
                .LessThan(500).WithMessage(TableRequestBindingModelErrorMessages.TableToLarge);
        }
    }
}