using AutoMapper;
using Domain.Entidades;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ClienteModel, ClienteEntity>()
                .ReverseMap();

            CreateMap<StatusModel, StatusEntity>() 
                .ReverseMap();

            CreateMap<TarefaModel, TarefaEntity>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoEntity>()
                .ReverseMap();

            CreateMap<EmpresaModel, EmpresaEntity>()
                .ReverseMap();

            CreateMap<UserModel, UsuarioEntity>()
                .ReverseMap();
            CreateMap<UserModel, CustomIdentityUser>()
                .ReverseMap();

            CreateMap<OrcamentoHoraModel, OrcamentoHoraEntity>()
                .ReverseMap();

            CreateMap<OrcamentoPorProjetoModel, OrcamentoPorProjetoEntity>()
                .ReverseMap();

            CreateMap<ProdutoModel, ProdutoEntity>()
                .ReverseMap();

            CreateMap<ServicoModel, ServicoEntity>()
                .ReverseMap();

            CreateMap<ProdutoOrcamentoProjetoModel, ProdutoOrcamentoProjetoEntity>()
                .ReverseMap();

        }
    }
}
