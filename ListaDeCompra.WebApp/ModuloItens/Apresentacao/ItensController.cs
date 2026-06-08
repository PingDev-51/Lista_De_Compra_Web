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
    public ActionResult Cadastrar()
    {
        CadastrarItensViewModel cadastrarVm = new CadastrarItensViewModel(
            string.Empty,
            0,
            SelecionarProduto()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarItensViewModel cadastrarVm)
    {
        Produto? produtoSelecionado = repositorioProduto.SelecionarPorId(cadastrarVm.ProdutoId);

        if (produtoSelecionado == null)
            ModelState.AddModelError(nameof(cadastrarVm.ProdutoId), "Selecione um Produto valido");

        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Produto = SelecionarProduto()
            });

        Itens novoitem = new Itens(
            produtoSelecionado!,
            cadastrarVm.Quantidade
        );

        repositorioItens.Cadastrar(novoitem);

        return RedirectToAction(nameof(Listar)); //analizar Consertar erro de cadastro
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


    [HttpGet]
    public ActionResult AdicionarALista()
    {
        AdiocionarAListaViewModel adicionarVm = new AdiocionarAListaViewModel(
            string.Empty,
            SelecionarLista()
        );

        return View(adicionarVm);
    }

    [HttpPost]
    public ActionResult AdicionarALista(AdiocionarAListaViewModel adicionarVm)
    {
        ListaCompra? listaSelecionada = repositorioListaDeCompra.SelecionarPorId(adicionarVm.ListaId);

        if (listaSelecionada == null)
            ModelState.AddModelError(nameof(adicionarVm.ListaId), "Selecione uma Lista valido");

        if (!ModelState.IsValid)
            return View(adicionarVm with
            {
                Lista = SelecionarLista()
            });

        Itens novoItem = new Itens(
            listaSelecionada!
        );

        repositorioItens.Cadastrar(novoItem);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoProdutoViewModel> SelecionarProduto()
    {
        return repositorioProduto.SelecionarTodos().Select(p => new OpcaoProdutoViewModel(p.Id, p.Nome)).ToList();
    }

    private List<OpcaoListaViewModel> SelecionarLista()
    {
        return repositorioListaDeCompra.SelecionarTodos().Select(l => new OpcaoListaViewModel(l.Id, l.Nome)).ToList();
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