using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class PagedResultViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int TotalDisplayRecords { get; set; }

        public object ToTableData()
        {
            return new
            {
                iTotalRecords = TotalRecords,
                iTotalDisplayRecoreds = TotalDisplayRecords,
                aaData = Items
            };
        }
    }
}
