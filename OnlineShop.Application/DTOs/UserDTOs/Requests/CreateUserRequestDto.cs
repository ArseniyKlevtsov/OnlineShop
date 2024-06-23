namespace OnlineShop.Application.DTOs.UserDTOs.Requests;
public class CreateUserRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}