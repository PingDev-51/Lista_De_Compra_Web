using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompra.WebApp.ModuloProdutos.Dominio;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.ModuloProdutos.Apresentacao;

public class ProdutoController : Controller
{
    private readonly IRepositorioProduto repositorioProduto;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ProdutoController(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        List<ListarProdutoViewModel> listarVms = produtos.Select(p => new ListarProdutoViewModel(
            p.Id,
            p.Categoria.Nome,
            p.Nome,
            p.Preco,
            p.UnidadeMedida
        )).ToList();

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarProdutoViewModel cadastrarVm = new CadastrarProdutoViewModel(
            string.Empty,
            string.Empty,
            0,
            string.Empty,
            SelecionarCategorias()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
    {
        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(cadastrarVm.CategoriaId);

        if (categoriaSelecionada == null)
            ModelState.AddModelError(nameof(cadastrarVm.CategoriaId), "Selecione uma Categoria válida.");


        Produto novoProduto = new Produto(
            cadastrarVm.Nome,
            cadastrarVm.Preco,
            categoriaSelecionada!,
            cadastrarVm.UnidadeMedida
        );

        repositorioProduto.Cadastrar(novoProduto);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Produto? produto = repositorioProduto.SelecionarPorId(id);

        if (produto == null)
            return RedirectToAction(nameof(Listar));

        EditarProdutoViewModel editarVm = new EditarProdutoViewModel(
            id,
            produto.Nome,
            produto.Categoria.Id,
            produto.Preco,
            produto.UnidadeMedida,
            SelecionarCategorias()
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarProdutoViewModel editarVm)
    {
        Produto? produto = repositorioProduto.SelecionarPorId(editarVm.Id);
        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(editarVm.CategoriaId);

        if (produto == null)
            return RedirectToAction(nameof(Listar));

        if (categoriaSelecionada == null)
            ModelState.AddModelError(nameof(editarVm.CategoriaId), "Selecione uma Categoria válida.");


        Produto produtoAtualizado = new Produto(
            editarVm.Nome,
            editarVm.Preco,
            categoriaSelecionada!,
            editarVm.UnidadeMedida
        );

        repositorioProduto.Editar(editarVm.Id, produtoAtualizado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Produto? produto = repositorioProduto.SelecionarPorId(id);

        if (produto == null)
            return RedirectToAction(nameof(Listar));

        ExcluirProdutoViewModel excluirVm = new ExcluirProdutoViewModel(
            id,
            produto.Categoria.Nome,
            produto.Nome,
            produto.Preco,
            produto.UnidadeMedida
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirProdutoViewModel excluirVm)
    {
        Produto? produto = repositorioProduto.SelecionarPorId(excluirVm.Id);

        if (produto == null)
            return RedirectToAction(nameof(Listar));

        repositorioProduto.Excluir(produto);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoCategoriaViewModel> SelecionarCategorias()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        return categorias
            .Select(categoria => new OpcaoCategoriaViewModel(categoria.Id, categoria.Nome)) // talvez apenas "categoria.Nome" seja melhor
            .ToList();
    }
}