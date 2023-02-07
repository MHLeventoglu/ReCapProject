using Core.Entities;

namespace Entities.Concrete;

public class Color : IEntity
{
    public Color(int colorId, string? colorName)
    {
        ColorId = colorId;
        ColorName = colorName;
    }

    public Color()
    {
        
    }
    public int ColorId { get; set; }
    public string? ColorName { get; set; }
}