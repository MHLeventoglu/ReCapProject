using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager:IColorService
{
    private IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }
    public IDataResult<List<Color>> GetAll()
    {
        if (DateTime.Now.Hour==11)
        {
            return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
    }

    public IDataResult<Color> GetById(int id)
    {
        if (DateTime.Now.Hour==11)
        {
            return new ErrorDataResult<Color>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<Color>(_colorDal.Get(c=>c.Id == id));
    }

    public IResult Add(Color color)
    {
        if (color.ColorName!.Length >= 2)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        return new ErrorResult(Messages.InvalidColorName);
    }

    public IResult Delete(Color color)
    {
        if (color.ColorName != null) 
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        return new ErrorResult(Messages.ColorDoesNotExist);
    }
    public IResult Update(Color color)
    {
        if (color.ColorName != null) 
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        return new ErrorResult(Messages.ColorDoesNotExist);

    }
}