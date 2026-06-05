using System;
using ListaDeCompra.WebApp.ModuloLista.Dominio;

namespace ListaDeCompra.WebApp.ModuloLista.Apresentacao;

public record ListarListaDeCompraViewModel(
    string Nome,
    DateTime DataCriacao,
    string Status
);

