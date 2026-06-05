using System;
using ListaDeCompra.WebApp.Arquivos.Infra.Arquivos;
using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos.Dominio;

namespace ListaDeCompra.WebApp.ModuloProdutos.Infra;

public class RepositorioProdutoEmArquivo : RepositorioBaseEmArquivo<Produto>, IRepositorioProduto
{
    public RepositorioProdutoEmArquivo(ContextoJson contexto) : base(contexto) { }

    protected override List<Produto> CarregarRegistros()
    {
        return contexto.Produtos;
    }
}