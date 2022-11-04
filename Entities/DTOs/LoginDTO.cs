using Core.Entities;

namespace Entities.DTOs
{
    public class LoginDTO : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
