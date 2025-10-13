using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class ProductsDatatableRequestViewModel : DatatableRequestViewModel
    {
        public int? CategoryId { get; set; }
    }
}
