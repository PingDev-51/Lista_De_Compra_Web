
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompra.WebApp.ModuloCategorias.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ContextoJson>(provider =>
{
    ContextoJson contexto = new ContextoJson();

    contexto.Carregar();

    return contexto;
});

builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    options.ViewLocationFormats.Clear();

    options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

    options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
});

builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();