using Core.Entities;

namespace Entities.Concrete;

public class Color : IEntity
{
    public Color(int colorId, string? colorName)
    {
        Id = colorId;
        ColorName = colorName;
    }

    public Color()
    {
        
    }
    public int Id { get; set; }
    public string? ColorName { get; set; }
}