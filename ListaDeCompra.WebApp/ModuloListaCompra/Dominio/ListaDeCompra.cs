using System;
using ListaDeCompra.WebApp.Compartilhado.Dominio.Base;
using ListaDeCompra.WebApp.ModuloItens.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos;

namespace ListaDeCompra.WebApp.ModuloLista.Dominio;

public class ListaCompra : EntidadeBase<ListaCompra>
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; }
    public Status StatusDaLista { get; set; }
    public List<Itens> Item { get; set; } = new List<Itens>();
    public decimal TotalGasto
    {
        get
        {
            decimal totalGasto = 0;

            foreach (Itens item in Item)
                totalGasto += item.PrecoTotal;

            return totalGasto;
        }
    }

    public ListaCompra() { }

    public ListaCompra(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;

        Abrir();
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        Itens item = new Itens(produto, quantidade);

        Item.Add(item);
    }

    public bool RemoverItem(string idItem)
    {
        foreach (Itens item in Item)
        {
            if (item.Id == idItem)
            {
                Item.Remove(item);
                return true;
            }
        }

        return false;
    }


    public void Abrir()
    {
        StatusDaLista = Status.Aberta;
    }

    public void Concluir()
    {
        StatusDaLista = Status.Concluida;
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
