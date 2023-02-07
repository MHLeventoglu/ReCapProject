using Business.Abstract;
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
    public List<Brand> GetAll()
    {
        return _brandDal.GetAll();
    }

    public Brand Get(int id)
    {
        return _brandDal.Get(b => b.BrandId == id);
    }

    public void Add(Brand brand)
    {
        if (brand.BrandName!.Length >= 2)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Brand successfully added");
        }
        else
        {
            Console.WriteLine("Brand name could Not be shorter than 2 chars");
        }
    }

    public void Delete(Brand brand)
    {
        if (brand.BrandName != null) 
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Brand successfully deleted");
        }
        else
        {
            Console.WriteLine("Brand you tried to delete does not exists");
        }
    }

    public void Update(Brand brand)
    {
        if (brand.BrandName != null) 
        {
            _brandDal.Update(brand);
            Console.WriteLine("Brand successfully updated");
        }
        else
        {
            Console.WriteLine("Brand you tried to update does not exists");
        }
    }
}