
using Domain.Entidades;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.ResetaSenha
{
    public interface IResetaSenha
    {
        Task<Result> SolicitaResetSenha(SolicitaRedefinicaoRequest redefinicaoRequest);
        Task<Result> EfetuarResetSenhaUsuario(ResetaSenhaRequest resetSenha);
    }
}
