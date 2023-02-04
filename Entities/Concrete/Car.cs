using System.Data.Common;
using Entities.Abstract;

namespace Entities.Concrete;

public class Car : IEntity
{
    public Car(int id, int brandId, int colorId, int modelYear, decimal dailyPrice, string? description)
    {
        Id = id;
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