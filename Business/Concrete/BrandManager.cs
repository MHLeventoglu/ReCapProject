using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager:IBrandService
{
    private IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }
    public IDataResult<List<Brand>> GetAll()
    {
        if (DateTime.Now.Hour==11)
        {
            return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
        }
        return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
    }

    public IDataResult<Brand> Get(int id)
    {
        if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == id));
    }

    public IResult Add(Brand brand)
    {
        if (brand.BrandName!.Length >= 2)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        return new ErrorResult(Messages.InvalidBrandName);
    }

    public IResult Delete(Brand brand)
    {
        if (brand.BrandName != null) 
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
        return new ErrorResult(Messages.BranDoesNotExist);
    }

    public IResult Update(Brand brand)
    {
        if (brand.BrandName != null) 
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        return new ErrorResult(Messages.BranDoesNotExist);

    }
}