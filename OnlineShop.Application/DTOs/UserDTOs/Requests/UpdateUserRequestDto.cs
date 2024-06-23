namespace OnlineShop.Application.DTOs.UserDTOs.Requests;

public class UpdateUserRequestDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}