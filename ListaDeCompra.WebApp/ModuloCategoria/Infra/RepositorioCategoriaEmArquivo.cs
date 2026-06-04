
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompra.WebApp.ModuloCategorias.Infra;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Categoria> CarregarRegistros()
    {
        return contexto.Categorias;
    }
}
