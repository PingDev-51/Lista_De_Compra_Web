using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ListaDeCompra.WebApp.ModuloItens.Apresentacao;

public record ListarItensViewModel(
    string Id,
    string Produto,
    int Quantidade,
    decimal PrecoTotal
);


public record CadastrarItensViewModel(

    [Required(ErrorMessage = "O campo \"Produto\" deve ser preenchido.")]
    string ProdutoId,

    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
    int Quantidade,

    [ValidateNever]
    List<OpcaoProdutoViewModel> Produto
);

public record ExcluirItensViewModel(
    string Id,
    List<OpcaoProdutoViewModel> Produto,
    int Quantidade,
    decimal PrecoTotal
);

public record AdiocionarAListaViewModel(
    //validar
    string ListaId,

    List<OpcaoListaViewModel> Lista
);

public record OpcaoListaViewModel(
    string Id,
    string Nome
);

public record OpcaoProdutoViewModel(
    string Id,
    string Nome
);