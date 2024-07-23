using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    public required string Username { get; set; }

    //public required string KnownAs { get; set; }

    //public required string Gender { get; set; }


    //// es optional p' q' funcione en [Required]
    //public required DateTime? DateOfBirth { get; set; }

    //public required string City { get; set; }

    //public required string Country { get; set; }


    [StringLength(12, MinimumLength = 4)]
    public required string Password { get; set; }
}
