using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasinService64.Dtos
{
    public class QueryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
