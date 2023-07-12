using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Application.DTOs.RequestDTO
{
    public record LoginDTO (string Username, string Password);
}
