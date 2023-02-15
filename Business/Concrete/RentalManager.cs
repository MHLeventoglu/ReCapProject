using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    private IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }
    public IDataResult<List<Rental>> GetAll()
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
    }

    public IDataResult<Rental> GetById(int id)
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.Id == id));
    }

    public IResult Add(Rental rental)
    {
        _rentalDal.Add(rental);
        return new SuccessResult("successfully added");
    }

    public IResult Delete(Rental rental)
    {
        return new SuccessResult("Succesfully deleted");
    }

    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult("Succesfully Updated");
    }
}