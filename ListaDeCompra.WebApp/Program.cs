
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompra.WebApp.ModuloCategorias.Infra;
using ListaDeCompra.WebApp.ModuloItens.Dominio;
using ListaDeCompra.WebApp.ModuloItens.Infra;
using ListaDeCompra.WebApp.ModuloLista.Dominio;
using ListaDeCompra.WebApp.ModuloLista.Infra;
using ListaDeCompra.WebApp.ModuloProdutos.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos.Infra;

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
builder.Services.AddScoped<IRepositorioProduto, RepositorioProdutoEmArquivo>();
builder.Services.AddScoped<IRepositorioListaDeCompra, RepositorioListaDeCompraEmArquivo>();
builder.Services.AddScoped<IRepositorioItens, RepositorioItensEmArquivo>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();