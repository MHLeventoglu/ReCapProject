using Core.Entities;

namespace Entities.Concrete;

public class Brand : IEntity
{
    public Brand(int brandId, string? brandName)
    {
        BrandId = brandId;
        BrandName = brandName;
    }

    public Brand()
    {
    }

    public int BrandId { get; set; }
    public string? BrandName { get; set; }
}