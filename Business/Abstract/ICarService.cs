using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetDetails();
        IDataResult<CarDetailDTO> GetDetailById(int carId);
        IDataResult<List<CarDetailDTO>> GetDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDTO>> GetDetailsByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
