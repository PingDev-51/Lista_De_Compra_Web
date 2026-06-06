using System;
using ListaDeCompra.WebApp.ModuloLista.Dominio;

namespace ListaDeCompra.WebApp.ModuloLista.Apresentacao;

public record ListarListaDeCompraViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao,
    string StatusListaDeCompra
);

public record CadastrarListaDeCompraViewModel(
    string Nome,
    DateTime DataCriacao
);

public record EditarListaDeCompraViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao
);

public record ConcluirListaViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao
);

public record ExcluirListaViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao
);
