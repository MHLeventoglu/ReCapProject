using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    private ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }
    public IDataResult<List<Customer>> GetAll()
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
    }

    public IDataResult<Customer> GetById(int id)
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id == id));
    }

    public IResult Add(Customer customer)
    {
        if (customer.UserId != null)
        {
            _customerDal.Add(customer);
            return new SuccessResult("successfully added");
        }

        return new ErrorResult("Invalid user name");
    }

    public IResult Delete(Customer customer)
    {
        if (customer.Id != null)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Succesfully deleted");
        }

        return new ErrorResult("That customer doesn't exist");
    }

    public IResult Update(Customer customer)
    {
        if (customer.Id != null)
        {
            _customerDal.Update(customer);
            return new SuccessResult("Succesfully Updated");
        }

        return new ErrorResult("That customer doesn't exist");
    }
}