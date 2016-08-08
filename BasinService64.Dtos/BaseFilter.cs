using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasinService64.Dtos
{
    public class BaseFilter
    {
        public int NumberOfEntries { get; set; }

        public int PageNumber { get; set; }

        public int? ID { get; set; }

        public string Title { get; set; }
    }
}
