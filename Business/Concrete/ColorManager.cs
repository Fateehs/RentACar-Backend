using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constrants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect(10)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        [CacheAspect(10)]
        public IDataResult<Color> GetColorById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
    }
}
