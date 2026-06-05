using System;
using ListaDeCompra.WebApp.Arquivos.Infra;
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloLista.Dominio;

namespace ListaDeCompra.WebApp.ModuloLista.Infra;

public class RepositorioListaDeCompraEmArquivo : RepositorioBaseEmArquivo<ListaCompra>, IRepositorio<ListaCompra>, IRepositorioListaDeCompra
{
    public RepositorioListaDeCompraEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<ListaCompra> CarregarRegistros()
    {
        return contexto.ListaDeCompras;
    }
}
