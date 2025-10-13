using FluentValidation;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.ViewModelValidators
{
    public class ProductCategoryViewModelValidator : AbstractValidator<ProductCategoryViewModel>
    {
        public ProductCategoryViewModelValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Cannot insert category without name. Please enter name");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name must contain maximum 30 characters");
        }
    }
}
