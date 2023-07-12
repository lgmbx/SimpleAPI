using SimpleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Application.DTOs.RequestDTO
{
    public record UserRequestDTO(string Username, string Password, Role Role);
    
}
