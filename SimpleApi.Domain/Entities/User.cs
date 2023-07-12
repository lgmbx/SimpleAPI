using SimpleApi.Domain.Enums;

namespace SimpleApi.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; } 
    }
}
