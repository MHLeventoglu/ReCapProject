using Core.Entities;

namespace Entities.Concrete;

public class Brand : IEntity
{
    public Brand(int brandId, string? brandName)
    {
        Id = brandId;
        BrandName = brandName;
    }

    public Brand()
    {
    }

    public int Id { get; set; }
    public string? BrandName { get; set; }
}