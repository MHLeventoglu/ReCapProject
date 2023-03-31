using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    private ICarImageDal _carImageDal;

    public CarImageManager(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }
    
    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
    }
    public IDataResult<CarImage> GetById(int id)
    {
        IResult result = BusinessRules.Run(CheckIfImageExists(id));
        if (result.Success)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        return new ErrorDataResult<CarImage>(Messages.ImageNotExists);
    }

    public IDataResult<List<CarImage>> GetByCarId(int carId)
    {
        IResult result = BusinessRules.Run(CheckIfHadAnImage(carId));
        if (result.Success==true)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == carId));
        }
        
        return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
    }

    public IResult Add(IFormFile file,CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
        if (result.Success==true)
        {
            return new SuccessResult(result.Message);
        }
        carImage.Date = DateTime.Now;
        carImage.ImagePath = FileHelper.Upload(file);
        _carImageDal.Add(carImage);
        return new SuccessResult();
    }

    public IResult Delete(CarImage carImage)
    {
        FileHelper.Delete(carImage.ImagePath!);
        _carImageDal.Delete(carImage);
        return new SuccessResult();    
    }

    public IResult Update(IFormFile file,CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckIfImageExists(carImage.Id));
        if (result==null!)
        {
            return new ErrorResult(result!.Message);
        }
        var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

        carImage.ImagePath = FileHelper.Update(oldPath, file);
        carImage.Date = DateTime.Now;
        _carImageDal.Update(carImage);
        return new SuccessResult();
    }
//several functions are below...
    private IResult CheckIfImageLimitExceeded(int carId)
    {
        var result = _carImageDal.GetAll(id => id.CarId == carId).Count;
        if (result>=5)
        {
            return new SuccessResult(Messages.ImageLimitExceeded);
        }
        return new ErrorResult();
    }

    private IResult CheckIfImageExists(int id)
    {
        var result = _carImageDal.GetAll().Exists(i => i.Id == id);
        if (result)
        {
            return new SuccessResult();
        }
        return new ErrorResult(Messages.ImageNotExists);
    }

    private IResult CheckIfHadAnImage(int carId)
    {
        var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
        if (result>=1)
        {
            return new SuccessResult();
        }
        return new ErrorResult(Messages.ImageNotExists);
    }
    
    private IDataResult<List<CarImage>> GetDefaultImage(int carId)
    {
           
        List<CarImage> carImage = new List<CarImage>();
        carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
        return new SuccessDataResult<List<CarImage>>(carImage);
    }
    
}