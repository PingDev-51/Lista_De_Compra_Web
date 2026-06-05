using System;
using ListaDeCompra.WebApp.ModuloLista.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.ModuloLista.Apresentacao;

public class ListaCompraController : Controller
{
    IRepositorioListaDeCompra repositorioListaDeCompra;
    public ListaCompraController(IRepositorioListaDeCompra repositorioListaDeCompra)
    {
        this.repositorioListaDeCompra = repositorioListaDeCompra;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListaCompra> listaDeCompra = repositorioListaDeCompra.SelecionarTodos();

        return View(MapearListas(listaDeCompra));
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarListaDeCompraViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        ListaCompra novaLista = new ListaCompra(
            cadastrarVm.Nome
        );

        novaLista.Abrir();

        repositorioListaDeCompra.Cadastrar(novaLista);



        return RedirectToAction(nameof(Listar));
    }

    private List<ListarListaDeCompraViewModel> MapearListas(List<ListaCompra> listaDeCompras)
    {
        List<ListarListaDeCompraViewModel> listarVms = listaDeCompras.Select(l => new ListarListaDeCompraViewModel(
            l.Id,
            l.Nome,
            l.DataCriacao,
            FormatarStatus(l.StatusDaLista)
        )).ToList();

        return listarVms;
    }

    private string FormatarStatus(Status status)
    {
        switch (status)
        {
            case Status.Concluida: return "Concluída";
            default: return "Aberto";
        }
    }

}
