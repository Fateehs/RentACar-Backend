using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        // *** CRUD OPERATIONS ***

        public IResult Add(Rental rental)
        {
            var result = RulesForAdding(rental);

            if (!result.Success)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalSuccessful);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        // *** GET METHODS ***

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();

            return new SuccessDataResult<List<Rental>>(result, Messages.Listed);
        }

        public IDataResult<List<RentalDetailDTO>> GetDetails()
        {
            var result = _rentalDal.GetDetails();

            return new SuccessDataResult<List<RentalDetailDTO>>(result, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(r => r.RentalId == rentalId);

            return new SuccessDataResult<Rental>(result, Messages.Geted);
        }

        // *** BUSINESS RULES ***

        public IResult RulesForAdding(Rental rental)
        {
            return BusinessRules.Run(

                CheckIfThisCarHasBeenReturned(rental),

                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(rental),

                CheckIfRentDateIsBeforeToday(rental.RentDate),

                CheckIfReturnDateIsBeforeRentDate(rental.ReturnDate, rental.RentDate),

                CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(rental));
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.ThisCarHasNotBeenReturnedYet);
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && (r.RentDate.Date == rental.RentDate.Date
            || (r.RentDate.Date < rental.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRentDateIsBeforeToday(DateTime rentDate)
        {
            if (rentDate.Date < DateTime.Now.Date)
            {
                return new ErrorResult(Messages.RentalDateCannotBeBeforeToday);
            }
            return new SuccessResult();
        }

        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.ReturnDateCannotBeEarlierThanRentDate);
                }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && rental.ReturnDate == null && r.RentDate.Date > rental.RentDate);
            if (result.Any())
            {
                return new ErrorResult(Messages.ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate);
            }
            return new SuccessResult();
        }
    }
}
