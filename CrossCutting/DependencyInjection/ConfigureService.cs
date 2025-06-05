using Domain.Services.Clientes;
using Domain.Services.Dashboard;
using Domain.Services.Email;
using Domain.Services.Login;
using Domain.Services.Projetos;
using Domain.Services.ResetaSenha;
using Domain.Services.Tarefas;
using Domain.Services.Usuarios;
using Microsoft.Extensions.DependencyInjection;
using Services.Clientes;
using Services.DashBoard;
using Services.Email;
using Services.Login;
using Services.Projetos;
using Services.ResetSenha;
using Services.StatusService;
using Services.Tarefas;
using Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IProjetoService, ProjetoService>();
            serviceCollection.AddTransient<StatusService, StatusService>();
            serviceCollection.AddTransient<ITarefaService, TarefaService>();
            serviceCollection.AddTransient<IDashboardService, DashboardService>();
        }

        public static void ConfigureServicesUserAplication(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUsuarioService, UsuarioService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<ITokenService, TokenService>();
            serviceCollection.AddTransient<ILogoutService, LogoutService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddTransient<IResetaSenha, ResetaSenhaService>();
        }
    }
}
