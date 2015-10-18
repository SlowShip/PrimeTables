using FluentValidation.Attributes;
using PrimeTables.Web.ModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Models
{
    [Validator(typeof(TableRequestBindingModelValidator))]
    public class TableRequestBindingModel
    {
        public int TableSize { get; set; }
    }
}