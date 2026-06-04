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
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

//     [HttpPost]
//     public ActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
//     {
//         if (!ModelState.IsValid)
//             return View(cadastrarVm);

//         Categoria novaCategoria = new Categoria(
//             cadastrarVm.Nome,
//             cadastrarVm.Categoria,
//             cadastrarVm.Preco,
//             CadastrarProdutoViewModel

//         );

//         repositorioCategoria.Cadastrar(novaCategoria);

//         return RedirectToAction(nameof(Listar));
//     }

//     [HttpGet]
//     public ActionResult Editar(string id)
//     {
//         Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

//         if (categoria == null)
//             return RedirectToAction(nameof(Listar));

//         EditarCategoriaViewModel editarVm = new EditarCategoriaViewModel(
//             id,
//             categoria.Nome,
//             categoria.Cor
//         );

//         return View(editarVm);
//     }

//     [HttpPost]
//     public ActionResult Editar(EditarCategoriaViewModel editarVm)
//     {
//         if (!ModelState.IsValid)
//             return View(editarVm);

//         Categoria categoriaAtualizada = new Categoria(
//             editarVm.Nome,
//             editarVm.Cor
//         );

//         repositorioCategoria.Editar(editarVm.Id, categoriaAtualizada);

//         return RedirectToAction(nameof(Listar));
//     }

//     [HttpGet]
//     public ActionResult Excluir(string id)
//     {
//         Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

//         if (categoria == null)
//             return RedirectToAction(nameof(Listar));

//         ExcluirCategoriaViewModel excluirVm = new ExcluirCategoriaViewModel(
//             id,
//             categoria.Nome,
//             categoria.Cor
//         );

//         return View(excluirVm);
//     }

//     [HttpPost]
//     public ActionResult Excluir(ExcluirCategoriaViewModel excluir)
//     {
//         Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(excluir.Id);

//         if (categoriaSelecionada == null)
//             return RedirectToAction(nameof(Listar));

//         repositorioCategoria.Excluir(categoriaSelecionada);

//         return RedirectToAction(nameof(Listar));
//     }

    private List<OpcaoCategoriaViewModel> SelecionarCaixas()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        return categorias
            .Select(categoria => new OpcaoCategoriaViewModel(categoria.Id, categoria.Nome)) // talvez apenas "categoria.Nome" seja melhor
            .ToList();
    }
    }
