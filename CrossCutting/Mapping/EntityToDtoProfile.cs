using AutoMapper;
using Domain.Dtos.cliente;
using Domain.Dtos.Empresa;
using Domain.Dtos.Orcamentos.PorHora;
using Domain.Dtos.Orcamentos.PorProjeto;
using Domain.Dtos.Produto;
using Domain.Dtos.ProdutoOrcamento;
using Domain.Dtos.projeto;
using Domain.Dtos.Servico;
using Domain.Dtos.status;
using Domain.Dtos.tarefas;
using Domain.Dtos.User;
using Domain.Entidades;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ClienteEntity, ClienteDto>()
                .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoCreate>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoCreateResult>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoUpdate>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoUpdateResult>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoSimple>()
               .ReverseMap();

            CreateMap<StatusEntity, StatusDto>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoCreate>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoCreateResult>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoUpdate>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoUpdateResult>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoListagem>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDto>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoCreate>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoCreateResult>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoUpdate>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoUpdateResult>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaProjetoDtoListagem>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDto>()
            .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoSimple>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoListagem>()
                .ReverseMap();

            CreateMap<UsuarioEntity, UserDto>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoCreate>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoCreateResult>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoUpdate>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoUpdateResult>()
               .ReverseMap();

            CreateMap<CustomIdentityUser, UsuarioEntity>()
                .ReverseMap();

            CreateMap<CustomIdentityUser, UserDto>()
                .ReverseMap();

            CreateMap<CustomIdentityUser, UserDtoCreate>()
               .ReverseMap();


            CreateMap<CustomIdentityUser, UserDtoCreateResult>()
               .ReverseMap();


            CreateMap<CustomIdentityUser, UserDtoUpdate>()
               .ReverseMap();


            CreateMap<CustomIdentityUser, UserDtoUpdateResult>()
               .ReverseMap();

            CreateMap<OrcamentoHoraDto, OrcamentoHoraEntity>()
              .ReverseMap();

            CreateMap<OrcamentoHoraEntity, OrcamentoHoraDtoCreate>()
                .ReverseMap();

            CreateMap<OrcamentoHoraEntity, OrcamentoHoraDtoCreateResult>()
                .ReverseMap();

            CreateMap<OrcamentoHoraEntity, OrcamentoHoraDtoUpdate>()
                .ReverseMap();

            CreateMap<OrcamentoHoraEntity, OrcamentoHoraDtoUpdateResult>()
                   .ReverseMap();

            CreateMap<ServicoEntity, ServicoDto>()
                .ReverseMap();

            CreateMap<ServicoEntity, ServicoDtoCreate>()
                .ReverseMap();

            CreateMap<ServicoEntity, ServicoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ServicoEntity, ServicoDtoUpdate>()
                .ReverseMap();

            CreateMap<ServicoEntity, ServicoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoDto, OrcamentoPorProjetoEntity>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoEntity, OrcamentoPorProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoEntity, OrcamentoPorProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoEntity, OrcamentoPorProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoEntity, OrcamentoPorProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProdutoEntity, ProdutoDto>()
                .ReverseMap();

            CreateMap<ProdutoEntity, ProdutoDtoCreate>()
                .ReverseMap();

            CreateMap<ProdutoEntity, ProdutoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProdutoEntity, ProdutoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProdutoEntity, ProdutoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<EmpresaEntity, EmpresaDto>()
                .ReverseMap();

            CreateMap<EmpresaEntity, EmpresaDtoCreate>()
                .ReverseMap();

            CreateMap<EmpresaEntity, EmpresaDtoCreateResult>()
                    .ReverseMap();

            CreateMap<EmpresaEntity, EmpresaDtoUpdate>()
                .ReverseMap();

            CreateMap<EmpresaEntity, EmpresaDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoEntity, ProdutoOrcamentoProjetoDto>()
                .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoEntity, ProdutoOrcamentoProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoEntity, ProdutoOrcamentoProjetoDtoUpdate>()
                .ReverseMap();

        }
    }
}
