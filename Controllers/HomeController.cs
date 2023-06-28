using Microsoft.AspNetCore.Mvc;

namespace TP06_Elecciones.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.listaPartidos = List<Partido> 
        return View();

    }
    
    public IActionResult VerDetallePedido(int IdPartido){

        return View("Detalle")
    }
}
