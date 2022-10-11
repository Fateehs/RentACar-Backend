using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
    }
}
