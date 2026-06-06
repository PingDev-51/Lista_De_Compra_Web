using System;
using System.Security.Cryptography;
using ListaDeCompra.WebApp.Compartilhado.Dominio.Base;
using ListaDeCompra.WebApp.ModuloProdutos;

namespace ListaDeCompra.WebApp.ModuloItens.Dominio;

public class Itens : EntidadeBase<Itens>
{
    public Produto Produto { get; set; } = null;
    public int Quantidade { get; set; }
    public decimal PrecoTotal
    {
        get
        {
            return Produto.Preco * Quantidade;
        }
    }

    public Itens()
    {
    }

    public Itens(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Produto == null)
            erros.Add("O campo Produto é obrigatório.;");
        if (Quantidade <= 0)
            erros.Add("A quantidade deve ser um número positivo.;");

        return erros;
    }

    public override void AtualizarDados(Itens entidadeAtualizada)
    {
        Itens itemAtualizado = (Itens)entidadeAtualizada;

        Produto = itemAtualizado.Produto;
        Quantidade = itemAtualizado.Quantidade;
    }
}