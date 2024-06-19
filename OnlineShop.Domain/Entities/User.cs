using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }


    public ICollection<Order> Orders { get; set; }
}
