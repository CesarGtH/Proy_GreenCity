using Proy_GreenCity.DOMAIN.Core.DTO;
using Proy_GreenCity.DOMAIN.Core.Entities;
using Proy_GreenCity.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy_GreenCity.DOMAIN.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTService _jwtService;
        public UserService(IUsuariosRepository usuariosRepository, IJWTService jwtService)
        {
            _usuariosRepository = usuariosRepository;
            _jwtService = jwtService;
        }



        public async Task<UsuariosResponseAuthDTO> SignIn(string email, string pwd)
        {
            var usuarios = await _usuariosRepository.SignIn(email, pwd);
            if (usuarios == null)
                return null;

            //TODO: implementar token & email
            var token = _jwtService.GenerateJWToken(usuarios);
            var sendEmail = false;

            var usuariosResponseAuth = new UsuariosResponseAuthDTO()
            {
                Id = usuarios.Id,
                Email = email,
                Nombre = usuarios.Nombre,
                Token = token,
                IsEmailSent = sendEmail,
            };
            return usuariosResponseAuth;
        }

        public async Task<bool> Insert(Usuarios usuarios)
        {
            return await _usuariosRepository.Insert(usuarios);
        }
    }
}
