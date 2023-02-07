﻿using Core.Entities;

namespace Entities.DTOs;

public class CarDetailsDto : IDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? BrandName { get; set; }
    public string? ColorName { get; set; }
}