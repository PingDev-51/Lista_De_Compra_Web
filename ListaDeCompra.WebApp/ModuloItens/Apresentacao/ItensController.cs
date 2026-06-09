using System;
using ListaDeCompra.WebApp.ModuloItens.Dominio;
using ListaDeCompra.WebApp.ModuloLista.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos;
using ListaDeCompra.WebApp.ModuloProdutos.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.ModuloItens.Apresentacao;

public class ItensController : Controller
{
    IRepositorioItens repositorioItens;
    IRepositorioProduto repositorioProduto;
    IRepositorioListaDeCompra repositorioListaDeCompra;


    public ItensController(
        IRepositorioItens repositorioItens,
        IRepositorioProduto repositorioProduto,
        IRepositorioListaDeCompra repositorioListaDeCompra)
    {
        this.repositorioItens = repositorioItens;
        this.repositorioProduto = repositorioProduto;
        this.repositorioListaDeCompra = repositorioListaDeCompra;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Itens> itens = repositorioItens.SelecionarTodos();

        return View(MapearItens(itens));
    }

    [HttpGet]
    public ActionResult Cadastrar(string listaId)
    {
        CadastrarItensViewModel cadastrarVm = new CadastrarItensViewModel(
            string.Empty,
            0,
            listaId,
            SelecionarProduto()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarItensViewModel cadastrarVm)
    {
        Produto? produtoSelecionado =
            repositorioProduto.SelecionarPorId(cadastrarVm.ProdutoId);

        if (produtoSelecionado == null)
            ModelState.AddModelError(nameof(cadastrarVm.ProdutoId),
                "Selecione um Produto válido");

        ListaCompra? listaSelecionada =
            repositorioListaDeCompra.SelecionarPorId(cadastrarVm.ListaId);

        if (listaSelecionada == null)
            ModelState.AddModelError(nameof(cadastrarVm.ListaId),
                "Lista inválida");

        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Produto = SelecionarProduto()
            });

        listaSelecionada!.AdicionarItem(
            produtoSelecionado!,
            cadastrarVm.Quantidade
        );

        repositorioListaDeCompra.Editar(
            listaSelecionada.Id,
            listaSelecionada
        );

        return RedirectToAction("Listar", "ListaCompra");
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Itens? item = repositorioItens.SelecionarPorId(id);

        if (item == null)
            return RedirectToAction(nameof(Listar));

        ExcluirItensViewModel excluirVm = new ExcluirItensViewModel(
            item.Id,
            SelecionarProduto(),
            item.Quantidade,
            item.PrecoTotal
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirItensViewModel excluirVm)
    {
        Itens? item = repositorioItens.SelecionarPorId(excluirVm.Id);

        if (item != null)
            repositorioItens.Excluir(item);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoProdutoViewModel> SelecionarProduto()
    {
        return repositorioProduto.SelecionarTodos().Select(p => new OpcaoProdutoViewModel(p.Id, p.Nome)).ToList();
    }

    private List<ListarItensViewModel> MapearItens(List<Itens> itens)
    {
        List<ListarItensViewModel> listarVms = itens.Select(i => new ListarItensViewModel(
           i.Id,
           i.Produto.Nome,
           i.Quantidade,
           i.PrecoTotal
       )).ToList();

        return listarVms;
    }
}