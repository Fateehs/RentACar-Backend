using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(Payment payment);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int paymentId);
        IDataResult<List<Payment>> GetAllByCustomerId(int customerId);
        IResult CheckIfThisCardIsAlreadySavedForThisCustomer(Payment payment);
    }
}
