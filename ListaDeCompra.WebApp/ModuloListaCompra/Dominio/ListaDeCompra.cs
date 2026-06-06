using System;
using ListaDeCompra.WebApp.Compartilhado.Dominio.Base;

namespace ListaDeCompra.WebApp.ModuloLista.Dominio;

public class ListaCompra : EntidadeBase<ListaCompra>
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public Status StatusDaLista { get; set; }

    // public List<ItemListaCompras> Itens { get; set; } = new List<ItemListaCompras>();
    // public decimal TotalGasto
    // {
    //     get
    //     {
    //         decimal totalGasto = 0;

    //         foreach (ItemListaCompras item in Itens)
    //             totalGasto += item.Preco;

    //         return totalGasto;
    //     }
    // }

    public ListaCompra() { }

    public ListaCompra(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;

        Abrir();
    }

    public void Abrir()
    {
        StatusDaLista = Status.Aberta;
    }

    public void Concluir()
    {
        StatusDaLista = Status.Concluida;
    }

    // public void AdicionarItem(Produto produto, int quantidade)
    // {
    //     ItemListaCompras item = new ItemListaCompras(produto, quantidade);

    //     Itens.Add(item);
    // }

    public bool RemoverItem(string idItem)
    {
        // foreach (ItemListaCompras item in Itens)
        // {
        //     if (item.Id == idItem)
        //     {
        //         Itens.Remove(item);
        //         return true;
        //     }
        // }

        return false;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo Nome deve conter entre 3 e 100 caracteres.");

        return erros;
    }

    public override void AtualizarDados(ListaCompra entidadeAtualizada)
    {
        ListaCompra listaAtualizada = (ListaCompra)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        StatusDaLista = listaAtualizada.StatusDaLista;
    }
}
