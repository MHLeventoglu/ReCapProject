using System.Data.Common;
using Core.Entities;

namespace Entities.Concrete;

public class Car : IEntity
{
    public Car(int carId, int brandId, int colorId, int modelYear, decimal dailyPrice, string? description)
    {
        Id = carId;
        BrandId = brandId;
        ColorId = colorId;
        ModelYear = modelYear;
        DailyPrice = dailyPrice;
        Description = description;
    }

    public Car()
    {
    }
    
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int ModelYear { get; set; }
    public decimal DailyPrice { get; set; }
    public string? Description { get; set; }
}