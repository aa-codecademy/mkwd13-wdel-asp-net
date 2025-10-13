using FluentValidation;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.ViewModelValidators
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        { 
        
             RuleFor(x=>x.Name).NotEmpty().WithMessage("Please enter the name of the product");
             RuleFor(x => x.Name).MaximumLength(10).WithMessage("Name can contain maximum 10 characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter description for the product!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Please enter url for the image path of the product");
            RuleFor(x => x.ProductCategoryId).NotEmpty().WithMessage("Please select category for the product");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Please enter price for the product");
            RuleFor(x => x.Price).LessThan(1000000).WithMessage("Please enter value less than 1000000");

            RuleFor(x => x.DiscountPercentage).InclusiveBetween(0, 100);
        }
    }
}
