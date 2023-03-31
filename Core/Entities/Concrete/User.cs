using Core.Entities;

namespace Core.Entities.Concrete;

public class User : IEntity
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool Status { get; set; }
    
    public User(int userId, string firstName, string lastName, string email, string password)
    {
        Id = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public User()
    {
        
    }
}