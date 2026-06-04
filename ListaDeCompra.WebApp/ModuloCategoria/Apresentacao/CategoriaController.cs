using ListaDeCompra.WebApp.ModuloCategorias.Dominio;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.ModuloCategorias.Apresentacao;

public class CategoriaController : Controller
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public CategoriaController(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        List<ListarCategoriaViewModel> listarVms = categorias.Select(c => new ListarCategoriaViewModel(
            c.Id,
            c.Nome,
            c.Cor
        )).ToList();

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCategoriaViewModel cadastrarVm = new CadastrarCategoriaViewModel(
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        Categoria novaCategoria = new Categoria(
            cadastrarVm.Nome,
            cadastrarVm.Cor
        );

        repositorioCategoria.Cadastrar(novaCategoria);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return RedirectToAction(nameof(Listar));

        EditarCategoriaViewModel editarVm = new EditarCategoriaViewModel(
            id,
            categoria.Nome,
            categoria.Cor
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCategoriaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Categoria categoriaAtualizada = new Categoria(
            editarVm.Nome,
            editarVm.Cor
        );

        repositorioCategoria.Editar(editarVm.Id, categoriaAtualizada);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return RedirectToAction(nameof(Listar));

        ExcluirCategoriaViewModel excluirVm = new ExcluirCategoriaViewModel(
            id,
            categoria.Nome,
            categoria.Cor
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirCategoriaViewModel excluir)
    {
        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(excluir.Id);
        
        if (categoriaSelecionada == null)
            return RedirectToAction(nameof(Listar));

        repositorioCategoria.Excluir(categoriaSelecionada);

        return RedirectToAction(nameof(Listar));
    }
}
