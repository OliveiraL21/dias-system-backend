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
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ClienteModel, ClienteDto>()
                .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoCreate>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoCreateResult>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoUpdate>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoUpdateResult>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoSimple>()
               .ReverseMap();

            CreateMap<StatusModel, StatusDto>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoCreate>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoCreateResult>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoUpdate>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoUpdateResult>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoListagem>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDto>()
               .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoCreate>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoCreateResult>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoUpdate>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDto>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoSimple>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoListagem>()
                .ReverseMap();


            CreateMap<UserModel, UserDto>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoCreate>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoCreateResult>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoUpdate>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoUpdateResult>()
               .ReverseMap();

            CreateMap<OrcamentoHoraDto, OrcamentoHoraModel>()
                .ReverseMap();

            CreateMap<OrcamentoHoraModel, OrcamentoHoraDtoCreate>()
                .ReverseMap();

            CreateMap<OrcamentoHoraModel, OrcamentoHoraDtoCreateResult>()
                .ReverseMap();

            CreateMap<OrcamentoHoraModel, OrcamentoHoraDtoUpdate>()
                .ReverseMap();

            CreateMap<OrcamentoHoraModel, OrcamentoHoraDtoUpdateResult>()
                   .ReverseMap();

            CreateMap<ServicoModel, ServicoDto>()
                .ReverseMap();

            CreateMap<ServicoModel, ServicoDtoCreate>()
                .ReverseMap();

            CreateMap<ServicoModel, ServicoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ServicoModel, ServicoDtoUpdate>()
                .ReverseMap();

            CreateMap<ServicoModel, ServicoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoDto, OrcamentoPorProjetoModel>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoModel, OrcamentoPorProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoModel, OrcamentoPorProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoModel, OrcamentoPorProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoModel, OrcamentoPorProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoDto>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoDtoCreate>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<EmpresaModel, EmpresaDto>()
                .ReverseMap();

            CreateMap<EmpresaModel, EmpresaDtoCreate>()
                .ReverseMap();

            CreateMap<EmpresaModel, EmpresaDtoCreateResult>()
                    .ReverseMap();

            CreateMap<EmpresaModel, EmpresaDtoUpdate>()
                .ReverseMap();

            CreateMap<EmpresaModel, EmpresaDtoUpdateResult>()
                .ReverseMap();


            CreateMap<ProdutoOrcamentoProjetoDto, ProdutoOrcamentoProjetoModel>()
              .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoDtoCreate, ProdutoOrcamentoProjetoModel>()
              .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoDtoUpdate, ProdutoOrcamentoProjetoModel>()
              .ReverseMap();

        }
    }
}
