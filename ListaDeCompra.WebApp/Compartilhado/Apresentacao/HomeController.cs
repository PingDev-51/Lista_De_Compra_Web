using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.Compartilhado.Apresentacao;

public class HomeController : Controller
{
    [HttpGet]

    public ActionResult Index()
    {
        return View();
    }
}