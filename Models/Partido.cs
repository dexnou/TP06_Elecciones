using System.Data.SqlClient;
using Dapper;
public class Partido{
    public int IdPartido{get;set;}
    public string Nombre{get;set;}
    public string Logo {get;set;}
    public string SitioWeb{get;set;}
    public DateTime FechaFundacion{get;set;}
    public int CantidadDiputados{get;set;}
    public int CantidadSenadores{get;set;}

public Partido(){
    
}
    public Partido(string nomb, string sweb, DateTime fechafund, int cantDiputados, int cantSenadores, string log){
        Nombre = nomb; 
        Logo = log;
        SitioWeb = sweb; 
        FechaFundacion = fechafund; 
        CantidadDiputados = cantDiputados; 
        CantidadSenadores = cantSenadores; 
    }
}