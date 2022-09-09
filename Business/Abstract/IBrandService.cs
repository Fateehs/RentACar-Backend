using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetBrandById(int brandId);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
