using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDTO>> GetDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetDetails(c => c.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDTO>>(result, Messages.Listed);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDTO>> GetDetailsByColorId(int colorId)
        {
            var result = _carDal.GetDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDTO>>(result, Messages.Listed);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);
            return new SuccessDataResult<Car>(result, Messages.Geted);
        }

        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<CarDetailDTO> GetDetailById(int carId)
        {
            var result = _carDal.GetDetail(c => c.CarId == carId);
            return new SuccessDataResult<CarDetailDTO>(result, Messages.Geted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        [CacheAspect(10)]
        //[SecuredOperation("user,moderator,admin")]
        public IDataResult<List<CarDetailDTO>> GetDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetDetails());
        }


    }
}
