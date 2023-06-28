using System.Data.SqlClient;
using Dapper;

public static class BD{
    public static string AgregarCandidato(Candidato can){
        Candidato newCandidato = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Candidato(Nombre) VALUES (@pCandidato) ";
            newCandidato = db.QueryFirstOrDefault<Candidato>(sql, new{pCandidato = can});
        }
        
    }

    public static int EliminarCandidato(int IdCandidato){

    }

    static int VerInfoPartido(int IdPartido){

    }

    static int VerInfoCandidatos(int IdCandidato){

    }
    static List<Partido> ListarPartidos(){
        List<Partido> listaPartidos = new List<Partido>();


        
        return 
    }

    static List<Candidato> ListarCandidatos(int IdPartido){
        
    }
}