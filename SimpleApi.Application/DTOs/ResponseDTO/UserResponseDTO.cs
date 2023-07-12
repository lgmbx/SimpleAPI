using SimpleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Application.DTOs.ResponseDTO
{
    public class UserResponseDTO
    {
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
