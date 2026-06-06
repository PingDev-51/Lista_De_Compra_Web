using System;
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloItens.Dominio;

namespace ListaDeCompra.WebApp.ModuloItens.Infra;

public class RepositorioItensEmArquivo : RepositorioBaseEmArquivo<Itens>, IRepositorioItens
{
    public RepositorioItensEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Itens> CarregarRegistros()
    {
        throw new NotImplementedException();
    }
}
