using System.Globalization;

namespace Projeto_Web_Lh_Pets_versão_1;

public class Program
{
    public static void Main(string[] args)
    {
        // Formato brasileiro (R$) para os valores monetários
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // Rota "/" : versão inicial do projeto
        app.MapGet("/", () => "LH Pets - Protótipo 1");

        // Habilita os arquivos estáticos da pasta wwwroot
        app.UseStaticFiles();

        // Rota "/index" : redireciona para a página index.html do front-end
        app.MapGet("/index", (HttpContext contexto) =>
        {
            contexto.Response.Redirect("index.html", false);
        });

        // Instancia a classe Banco, que carrega os clientes do banco de dados "vendas"
        Banco dba = new Banco();

        // Rota "/listaClientes" : exibe a lista de clientes vinda do banco
        app.MapGet("/listaClientes", (HttpContext contexto) =>
        {
            contexto.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
