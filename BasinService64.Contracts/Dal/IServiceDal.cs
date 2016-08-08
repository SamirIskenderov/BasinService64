using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasinService64.Dtos;

namespace BasinService64.Contracts.Dal
{
    public interface IServiceDal
    {
        void Add(Service service);

        void Delete(int ID);

        bool Modify(Service service);

        Service Get(int id);
    }
}
