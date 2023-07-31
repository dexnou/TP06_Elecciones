using Microsoft.AspNetCore.Mvc;

namespace TP06_Elecciones.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() 
    {
        ViewBag.listaPartidos = BD.ListarPartidos();
        return View();
    }
    
    public IActionResult VerDetallePartido(int IdPartido){
        ViewBag.Partido = BD.VerInfoPartido(IdPartido);
        ViewBag.CandidatosPartido = BD.ListarCandidatos(IdPartido);
        return View();
    }

    public IActionResult VerDetalleCandidato(int IdCandidato){
        ViewBag.CandidatosInfo = BD.VerInfoCandidatos(IdCandidato);
        return View();
    }

    public IActionResult AgregarCandidato(int IdPartido){
        ViewBag.IdPartido = IdPartido; 
        return View("AgregarCandidato"); //form
    }

    
    // public IActionResult GuardarCandidato(Candidato can){
    //     BD.AgregarCandidato(can);
    //     ViewBag.Partido = BD.VerInfoPartido(can.IdPartido);
    //     ViewBag.ListarCandidatos = BD.ListarCandidatos(can.IdPartido);
    //     return View("VerDetallePartido", new{IdPartido = can.IdPartido});
    // }
    [HttpPost] public IActionResult GuardarCandidato(Candidato can){
        BD.AgregarCandidato(can);
        return RedirectToAction("VerDetallePartido", new {IdPartido=can.IdPartido});
    }
    public IActionResult EliminarCandidato(int IdCandidato, int IdPartido)
    {
        int RegistrosEliminados = BD.EliminarCandidato(IdCandidato);
        ViewBag.Partido = BD.VerInfoPartido(IdPartido);
        ViewBag.CandidatosPartido = BD.ListarCandidatos(IdPartido);
        return View("VerDetallePartido");
    }

    public IActionResult Elecciones()
    {
        return View("Index");
    }

    IActionResult Creditos()
    {
        return View();
    }
}
