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


    public ItensController(IRepositorioItens repositorioItens, IRepositorioProduto repositorioProduto)
    {
        this.repositorioItens = repositorioItens;
        this.repositorioProduto = repositorioProduto;

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


    public List<OpcaoProdutoViewModel> SelecionarProduto()
    {
        return repositorioProduto.SelecionarTodos().Select(a => new OpcaoProdutoViewModel(a.Id, a.Nome)).ToList();
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Itens? item = repositorioItens.SelecionarPorId(id);

        if (item == null)
            return RedirectToAction(nameof(Listar));

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