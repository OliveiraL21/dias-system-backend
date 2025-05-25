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
        Result ativaUsuario(AtivaRequest request);
        Result solicitarResetSenha(SolicitaRedefinicaoRequest solicitaRedefinicaoRequest);
        Result EfetuarResetSenha(ResetaSenhaRequest request);
        Result createUsuario(UserDtoCreate usuario);
        Result update(UserDtoUpdate usuario);
        UserDto detaillsUsuario(Guid id);
        Result updateProfileImage(string imageUrl, int id);
    }
}
