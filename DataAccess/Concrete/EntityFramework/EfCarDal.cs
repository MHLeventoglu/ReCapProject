using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car,DataBaseContext>,ICarDal
{
    public List<CarDetailsDto> GetCarDetails()
    {
        using (DataBaseContext context = new DataBaseContext())
        {
            var result = from p in context.Cars
                                           join b in context.Brands on p.BrandId equals b.BrandId
                                           join c in context.Colors on p.ColorId equals c.ColorId 
                                           orderby p.Id
                
                select new CarDetailsDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    BrandName = b.BrandName,
                    ColorName = c.ColorName
                };
            return result.ToList();
        }
    }
}