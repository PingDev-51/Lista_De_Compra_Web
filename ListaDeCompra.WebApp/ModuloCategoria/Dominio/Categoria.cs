using System;
using ListaDeCompra.WebApp.Compartilhado.Dominio.Base;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; set; }
    public string Cor { get; set; }

    public Categoria()
    {
    }
    
    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }

    public override void AtualizarDados(Categoria entidadeAtualizada)
    {
        Categoria categoriaAtualizada = entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length == 0 || Nome.Length > 50)
            erros.Add("O Campo \"Nome\" deve conter no entre 0 e 50 caracteres.;");

        if (string.IsNullOrWhiteSpace(Cor))
            erros.Add( "O Campo \"Cor\" deve conter no entre 0 e 50 caracteres.;");

        else if (Cor != "Vermelho" && Cor != "Azul" && Cor != "Verde" && Cor != "Branco")
            erros.Add("O Campo \"Cor\" deve conter uma selecao permitida (Vermelho, Azul, Verde, Branco);");

        return erros;
    }
}