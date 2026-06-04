using System.ComponentModel.DataAnnotations;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompra.WebApp.ModuloProdutos.Apresentacao;

public record OpcaoCategoriaViewModel(
    string Id,
    string Nome
);

public record ListarProdutoViewModel(
    string Id,
    string Categoria,
    string Nome,
    decimal Preco,
    string UnidadeMedida
);

//    public Categoria Categoria { get; set; }
//     public string Nome { get; private set; }
//     public int Preco { get; private set; }
//     public string UnidadeMedida { get; private set; }

public record CadastrarProdutoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")] //faltando as validações (irei fazer apos o feriadão)
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string Categoria,

    [Required(ErrorMessage = "O campo \"Preco\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string Preco,

    [Required(ErrorMessage = "O campo \"Unidade Medida\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string UnidadeMedida

);

public record EditarProdutoViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")] //faltando as validações (irei fazer apos o feriadão)
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string Categoria,

    [Required(ErrorMessage = "O campo \"Preco\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string Preco,

    [Required(ErrorMessage = "O campo \"Unidade Medida\" deve ser preenchido.")] //faltando as validações (irei fazer apos o feriadão)
    string UnidadeMedida

);

public record ExcluirProdutoViewModel(
    string Id,
   string Categoria,
    string Nome,
    decimal Preco,
    string UnidadeMedida
);