using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }


        [ValidationAspect(typeof(FVPaymentValidator))]
        public IResult Pay(Payment payment)
        {
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        [ValidationAspect(typeof(FVPaymentValidator))]
        public IResult Add(Payment payment)
        {
            var result = BusinessRules.Run(CheckIfThisCardIsAlreadySavedForThisCustomer(payment));

            if (!result.Success) return result;

            _paymentDal.Add(payment);

            return new SuccessResult(Messages.PaymentInformationSuccessfullySaved);
        }

        [ValidationAspect(typeof(FVPaymentValidator))]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);

            return new SuccessResult(Messages.PaymentUpdated);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);

            return new SuccessResult(Messages.PaymentDeleted);
        }

        [CacheAspect(10)]
        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();

            return new SuccessDataResult<List<Payment>>(result, Messages.Listed);
        }

        [CacheAspect(10)]
        public IDataResult<Payment> GetById(int paymentId)
        {
            var result = _paymentDal.Get(p => p.PaymentId == paymentId);

            return new SuccessDataResult<Payment>(result, Messages.Geted);
        }

        [CacheAspect(10)]
        public IDataResult<List<Payment>> GetAllByCustomerId(int customerId)
        {
            var result = _paymentDal.GetAll(p => p.CustomerId == customerId);

            return new SuccessDataResult<List<Payment>>(result, Messages.Listed);
        }

        public IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment)
        {
            var result = _paymentDal.Get(p => p.CustomerId == payment.CustomerId && p.CardNumber == payment.CardNumber);

            if (result != null) return new ErrorResult(Messages.ThisCardIsAlreadyRegisteredForThisCustomer);

            return new SuccessResult();
        }
    }
}
