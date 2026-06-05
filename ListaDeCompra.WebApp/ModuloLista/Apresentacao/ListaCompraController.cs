using System;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompra.WebApp.ModuloLista.Apresentacao;

public class ListaCompraController : Controller
{
    public ActionResult Listar()
    {
        return View();
    }
}
