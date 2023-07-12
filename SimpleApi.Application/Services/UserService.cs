using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.DTOs.ResponseDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Interfaces;
using BCrypt.Net;
using SimpleApi.Domain.Entities;

namespace SimpleApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<BaseApiResponse<UserResponseDTO>> RegisterUser(UserRequestDTO request)
        {
            
            var baseResponse = new BaseApiResponse<UserResponseDTO>();

            var userExists = await userRepository.GetAsync(x => x.Username == request.Username);

            if (userExists.Any())
            {
                baseResponse.AddErrors("User already exists");
                return baseResponse;
            }

            var user = new User()
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role
            };

            userRepository.Add(user);
            await unitOfWork.Commit();

            var response = new UserResponseDTO()
            {
                Username = user.Username,
                Role = user.Role
            };

            baseResponse.Response = response;
            
            return baseResponse;
        }

        public async Task<BaseApiResponse<User>> Login(LoginDTO request)
        {
            var baseResponse = new BaseApiResponse<User>();

            var user = await userRepository.GetSingleAsync(x => x.Username == request.Username);

            if(user == null)
            {
                baseResponse.AddErrors("Invalid username or password");
                return baseResponse;
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                baseResponse.AddErrors("Invalid username or password");
                return baseResponse;
            }

            baseResponse.Response = user;

            return baseResponse;
        }
    }
}
