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

    [HttpGet]
    public ActionResult Editar(string id)
    {
        ListaCompra? lista = repositorioListaDeCompra.SelecionarPorId(id);

        if (lista == null)
            return RedirectToAction(nameof(Listar));

        EditarListaDeCompraViewModel editarListaVm = new EditarListaDeCompraViewModel(
            id,
            lista.Nome,
            lista.DataCriacao
        );

        return View(editarListaVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarListaDeCompraViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        ListaCompra listaAtualizada = new ListaCompra(
            editarVm.Nome
        );

        repositorioListaDeCompra.Editar(editarVm.Id, listaAtualizada);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Concluir(string id)
    {
        ListaCompra? lista = repositorioListaDeCompra.SelecionarPorId(id);

        if (lista == null)
            return RedirectToAction(nameof(Listar));

        EditarListaDeCompraViewModel editarListaVm = new EditarListaDeCompraViewModel(
            id,
            lista.Nome,
            lista.DataCriacao
        );

        return View(editarListaVm);
    }

    [HttpPost]
    public ActionResult Concluir(ConcluirListaViewModel concluirVm)
    {
        if (!ModelState.IsValid)
            return View(concluirVm);

        ListaCompra listaAtualizada = new ListaCompra(
            concluirVm.Nome
        );

        repositorioListaDeCompra.Editar(concluirVm.Id, listaAtualizada);

        listaAtualizada.Concluir();

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
