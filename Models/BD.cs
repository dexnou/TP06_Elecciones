using System.Data.SqlClient;
using Dapper;

public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    private static List<Candidato> listaCandidato = new List<Candidato>();
    private static List<Partido> listaPartido = new List<Partido>();


    public static void AgregarCandidato(Candidato can){
        string sql = "INSERT INTO Candidato(IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pIdPartido = can.IdPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
        }
    }

    public static int EliminarCandidato(int IdCandidato){
        int RegistrosEliminados = 0;
        string sql = "DELETE FROM Candidato WHERE IdCandidato = @pCandidato";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosEliminados = db.Execute(sql, new {Candidato = IdCandidato});
        }
        return RegistrosEliminados; 
    }

    public static Partido VerInfoPartido(int IdPartido){  
        Partido partido;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
             string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
             partido = db.QueryFirstOrDefault<Partido>(sql, new { pIdPartido = IdPartido });
        }
        return partido; 
    }
    
    public static Candidato VerInfoCandidatos(int IdCandidato){
        Candidato candidato;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @pIdCandidato";
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new { pIdCandidato = IdCandidato });
        }
        return candidato; 
    }
    public static List<Partido> ListarPartidos(){
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            listaPartido = db.Query<Partido>(sql).ToList(); 
        }
        return listaPartido; 
    }

    public static List<Candidato> ListarCandidatos(int IdPartido){
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidato WHERE IdPartido = @pIdPartido";
            listaCandidato = db.Query<Candidato>(sql, new{ pIdPartido = IdPartido }).ToList();
        }
        return listaCandidato;
    }
}