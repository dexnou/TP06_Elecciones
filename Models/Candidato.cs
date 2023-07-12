using System.Data.SqlClient;
using Dapper;

public class Candidato{
    public int IdCandidato{get;set;}
    public int IdPartido{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string Foto{get;set;}
    public string Postulacion{get;set;}

public Candidato(){
    
}
    public Candidato(int idpart, string apelli, string nom, DateTime fechanaci, string ft, string postu){
        IdPartido = idpart;
        Apellido = apelli;
        Nombre = nom;
        FechaNacimiento = fechanaci;
        Foto = ft;
        Postulacion = postu;
    }
}