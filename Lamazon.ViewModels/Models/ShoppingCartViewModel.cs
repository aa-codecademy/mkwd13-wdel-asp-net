using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

        public ShoppingCartViewModel()
        {
            ShoppingCartItems = new List<ShoppingCartItemViewModel>();
        }
    }
}
