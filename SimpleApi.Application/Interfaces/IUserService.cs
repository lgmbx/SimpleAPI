using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.DTOs.ResponseDTO;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<BaseApiResponse<UserResponseDTO>> RegisterUser(UserRequestDTO request);

        Task<BaseApiResponse<User>> Login(LoginDTO request);
    }
}
