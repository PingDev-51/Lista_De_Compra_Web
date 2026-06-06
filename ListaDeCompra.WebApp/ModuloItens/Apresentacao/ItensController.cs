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
            return View(produtoSelecionado);

        if (!ModelState.IsValid)
            return View(cadastrarVm with
            {
                Produto = SelecionarProduto()
            });

        Itens novoitem = new Itens(
            produtoSelecionado,
            cadastrarVm.Quantidade
        );

        repositorioItens.Cadastrar(novoitem);

        return View(novoitem); //analizar
    }

    public List<OpcaoProdutoViewModel> SelecionarProduto()
    {
        return repositorioProduto.SelecionarTodos().Select(a => new OpcaoProdutoViewModel(a.Id, a.Nome)).ToList();
    }

}
