using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class DatatableRequestViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public DatatableSearchViewModel search {get; set;} 
        public List<DatatableColumnViewModel> columns { get; set; }
        public List<DatatableOrderViewModel> order { get; set; }

        public string sortColumn
        {
            get
            {
                if(order?.Count > 0 && columns?.Count > 0 && columns.Count > order[0].column)
                {
                    return columns[order[0].column.Value].name;
                }
                return null;
            }
        }

        public bool isAscending
        {
            get
            {
                if(order?.Count > 0 && columns?.Count > 0 && columns.Count > order[0].column)
                {
                    return order[0].dir.ToUpper() != "DESC";
                }
                return true;
            }
        }

    }

    public class DatatableOrderViewModel
    {
        public int? column { get; set; }
        public string dir { get; set; }
    }

    public class DatatableColumnViewModel
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DatatableSearchViewModel search { get; set; }
    }

    public class DatatableSearchViewModel
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }
}
