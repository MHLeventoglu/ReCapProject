using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    public IDataResult<List<User>> GetAll()
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public IDataResult<User> GetById(int id)
    {
        if (DateTime.Now.Hour == 13)
        {
            return new ErrorDataResult<User>(Messages.MaintenanceTime);
        }

        return new SuccessDataResult<User>(_userDal.Get(u=>u.Id == id));
    }

    public IResult Add(User user)
    {
        if (user.FirstName!.Length >= 2)
        {
            _userDal.Add(user);
            return new SuccessResult("successfully added");
        }

        return new ErrorResult("Invalid user name");
    }

    public IResult Delete(User user)
    {
        if (user.Id != null && user.FirstName != null)
        {
            _userDal.Delete(user);
            return new SuccessResult("Succesfully deleted");
        }

        return new ErrorResult("That user doesn't exist");
    }

    public IResult Update(User user)
    {
        if (user.Id != null && user.FirstName != null)
        {
            _userDal.Update(user);
            return new SuccessResult("Succesfully Updated");
        }

        return new ErrorResult("That user doesn't exist");
    }
}