using Domain.Entidades;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public interface ILoginService
    {
        public Task<ResultToken> Login(LoginRequest login);
        public Task<bool> VerificaSenha(string username, string password);
        public Task<bool> UsuarioExiste(string username);
    }
}
