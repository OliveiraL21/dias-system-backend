using AutoMapper;
using Data.Context;
using Domain.Dtos.User;
using Domain.Entidades;
using Domain.Models;
using Domain.Services.Email;
using Domain.Services.ResetaSenha;
using Domain.Services.Usuarios;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
       
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IResetaSenha _resetSenhaService;


        public UsuarioService(IMapper mapper, UserManager<CustomIdentityUser> userManager, IEmailService emailService, IResetaSenha resetSenhaService) 
        {
           _mapper = mapper;
           _userManager = userManager;
           _emailService = emailService;
            _resetSenhaService = resetSenhaService;
        }

        public async Task<Result> ativaUsuario(AtivaRequest request)
        {
            // RECUPERAR O USUARIO PARA A ATIVAÇÃO
            var user =  await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UsuarioId);

            //ATIVANDO O USUÁRIO
            var identityResult = _userManager.ConfirmEmailAsync(user, request.CodigoAtivacao).Result;

            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail($"Erro ao tentar ativar a conta do usuário -  {identityResult.Errors.First().Description}");
        }

        public async Task<Result> solicitarResetSenha(SolicitaRedefinicaoRequest solicitaRedefinicaoRequest)
        {
           return await _resetSenhaService.SolicitaResetSenha(solicitaRedefinicaoRequest);
        }

        public async Task<Result> EfetuarResetSenha(ResetaSenhaRequest request)
        {
            return await _resetSenhaService.EfetuarResetSenhaUsuario(request);
        }

        private async Task<bool> ExisteUsuarioByEmail(string email)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == email);
        }

        private async Task<bool> ExisteUsuarioByUsername(string username)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName == username);
        }

        public  async Task<Result> createUsuarioAsync(UserDtoCreate usuario)
        {
            var model = _mapper.Map<UserModel>(usuario);
            var entity = _mapper.Map<UsuarioEntity>(model);
            CustomIdentityUser user = _mapper.Map<CustomIdentityUser>(entity);

            if (await ExisteUsuarioByEmail(user.Email))
            {
                return Result.Fail("O e-mail escolhido já esta em uso por outro usuário");
            }

            if (await ExisteUsuarioByUsername(user.UserName))
            {
                return Result.Fail("O nome de usuário já esta em uso por outro usuário do sistema");
            }

            Task<IdentityResult> result = _userManager.CreateAsync(user, usuario.Password);
            

            if (result.Result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "regular");

                var code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                var destinatario = new List<Destinatario>
                {
                    new Destinatario { Nome = usuario.username, Email = usuario.Email }
                };

                var encodeCode = HttpUtility.UrlEncode(code);

                //ENVIAR EMAIL

                _emailService.EnviarEmail(destinatario, "Código de ativação", user.Id, user.NormalizedUserName, encodeCode, "Ativar Conta" );
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail($"Erro ao tentar cadastrar o usuário");
        }

        public async Task<UserDto> detaillsUsuario(Guid id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<Result> update(Guid id, UserDtoUpdate usuario)
        {
            var model = _mapper.Map<UserModel>(usuario);
            var entity = _mapper.Map<UsuarioEntity>(model);
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
             

            user.PhoneNumber = !string.IsNullOrEmpty(entity.PhoneNumber) ? entity.PhoneNumber : user.PhoneNumber;
            user.Email = !string.IsNullOrEmpty(entity.Email) ? entity.Email : user.Email;
            user.UserName = user.UserName;
            user.ProfileImageUrl = !string.IsNullOrEmpty(entity.ProfileImageUrl) ? entity.ProfileImageUrl : user.ProfileImageUrl;

            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao tentar atualizar o usuário");
        }

        public async Task<Result> updateProfileImage(string imageUrl, Guid id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            user.ProfileImageUrl = imageUrl;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao tentar salvar imagem de perfil");

            
        }
    }

}
