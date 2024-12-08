using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementProject.Data.Interfaces;
using TaskManagementProject.Data.UnitOfWorks;
using TaskManagementProject.Domain.Dto;
using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Domain.Interfaces;
using TaskManagementProject.Infrastructure.AutoMapper;
using TaskManagementProject.Infrastructure.Interfaces;
using TaskManagementProject.Service.Interfaces;
using TaskManagementProject.Service.Services.Base;

namespace TaskManagementProject.Service.Services
{
    public class UserService : ServiceBase, IUserService<t_UserDto, t_User>
    {

        private readonly IConfiguration _configuration;
      private readonly IPasswordHasher _passwordHasher;
        
        public UserService(IUnitOfWork unitOfWork, ITaskManagementProjectMapper mapper, IHttpContextAccessor httpContext, IPasswordHasher passwordHasher,IConfiguration configuration) : base(unitOfWork, mapper, httpContext)
        {
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<t_User> ValidateUserAsync(string username, string password)
        {
            // Kullanıcıyı kullanıcı adına göre veritabanında arıyoruz
            var user = await _unitOfWork.UserRepository.GetByAsync(u => u.Username == username);

            if (user == null)
            {
                return null; // Kullanıcı bulunamadı
            }

            // Şifreyi doğruluyoruz
            var isPasswordValid = _passwordHasher.VerifyPassword(password, user.Password);

            if (!isPasswordValid)
            {
                return null; // Şifre yanlış
            }

            // Kullanıcıyı geri döndürüyoruz
            return user;
        }


        public string GenerateJwtToken(t_User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // user.Id buraya ekleniyor
        new Claim(ClaimTypes.Name, user.Username)
    };

            var key = new SymmetricSecurityKey(secretKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<t_UserDto> AddAsync(t_UserDto dto)
        {

            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }


            if (!string.IsNullOrEmpty(dto.Password))
            {
                dto.Password = _passwordHasher.HashPassword(dto.Password);
            }

            var userEntity = new t_User()
            {
                Name = dto.Name,
                Username = dto.Username,
                Password = dto.Password,
                CreatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.UserRepository.AddAsync(userEntity);
            await _unitOfWork.CommitChangesAsync();

            var resultDto = _mapper.Map<t_UserDto>(userEntity);

            return resultDto;
        }

        public async Task<bool> DeleteByAsync(t_UserDto dto)
        {
            var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(dto.Id);

            if (userEntity == null)
            {
                throw new KeyNotFoundException($"User  {dto} was not found.");

            }

            await _unitOfWork.UserRepository.DeleteByIdAsync(userEntity.Id);
           var result = await _unitOfWork.CommitChangesAsync();

            return result > 0;
        }

        public async Task<ICollection<t_UserDto>> GetAllAsync(Func<IEntity, bool> filter = null)
        {
            
                var users = await _unitOfWork.UserRepository.GetAllAsync();
                var UserDtos = _mapper.Map<ICollection<t_UserDto>>(users);
                return UserDtos;
            

        }

        public async Task<t_UserDto> GetByIdAsync(int id)
        {
            var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }

            // Entity'den DTO'ya dönüşüm yapılıyor (Mapper kullanıyorsanız)
            var userDto = _mapper.Map<t_UserDto>(userEntity);

            return userDto;
        }

        public async Task<t_UserDto> UpdateAsync(t_UserDto dto)
        {
            var userEntity = await _unitOfWork.UserRepository.GetByIdAsync(dto.Id);

            if (userEntity == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (!string.IsNullOrEmpty(dto.Password))
            {
                userEntity.Password = _passwordHasher.HashPassword(dto.Password);
            }

            userEntity.Username = dto.Username;
            userEntity.Name = dto.Name;

            await _unitOfWork.UserRepository.UpdateAsync(userEntity);
            await _unitOfWork.CommitChangesAsync();

            var resultDto = _mapper.Map<t_UserDto>(userEntity);

            return resultDto;
        }
    }
}
