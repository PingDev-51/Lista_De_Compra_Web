using System;
using System.Globalization;
using ListaDeCompra.WebApp.Compartilhado.Dominio.Base;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompra.WebApp.ModuloProdutos;

public class Produto : EntidadeBase<Produto>
{
    public Categoria Categoria { get; set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public string UnidadeMedida { get; private set; }

    public Produto()
    {
    }

    public Produto(string nome, decimal preco, Categoria categoria, string unidadeMedida)
    {
        Nome = nome;
        Preco = preco;
        this.Categoria = categoria;
        UnidadeMedida = unidadeMedida;
    }

    public override void AtualizarDados(Produto entidadeAtualizada)
    {
        Produto produtoAtualizado = entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Preco = produtoAtualizado.Preco;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length == 1 || Nome.Length > 100)
            erros.Add("O Campo \"Nome\" deve conter no entre 1 e 100 caracteres.;");

        if (string.IsNullOrWhiteSpace(Categoria.Id))
            erros.Add("O Campo \"Categoria\" é obrigatório.;");

        else if (UnidadeMedida != "kg" && UnidadeMedida != "unidade" && UnidadeMedida != "litro" && UnidadeMedida != "caixa")

            erros.Add("O Campo \"Unidade de Medida\" deve conter uma seleção permitida (kg, unidade, litro, caixa);");

        return erros;

    }

   
}
