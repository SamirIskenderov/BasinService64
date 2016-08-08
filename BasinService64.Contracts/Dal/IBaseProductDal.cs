using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasinService64.Dtos;

namespace BasinService64.Contracts.Dal
{
    public interface IBaseProductDal
    {
        List<BaseProduct> GetProducts(BaseFilter filter, out int numberOfPages);
    }
}
