using Domain.Dtos.User;
using Domain.Entidades;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<Result> ativaUsuario(AtivaRequest request);
        Task<Result> solicitarResetSenha(SolicitaRedefinicaoRequest solicitaRedefinicaoRequest);
        Task<Result> EfetuarResetSenha(ResetaSenhaRequest request);
        Task<Result> createUsuarioAsync(UserDtoCreate usuario);
        Result update(Guid id, UserDtoUpdate usuario);
        UserDto detaillsUsuario(Guid id);
        Task<Result> updateProfileImage(string imageUrl, Guid id);
    }
}
