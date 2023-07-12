using System.Data.SqlClient;
using Dapper;

public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    private static List<Candidato> listaCandidato = new List<Candidato>();
    private static List<Partido> listaPartido = new List<Partido>();


    public static void AgregarCandidato(Candidato can){
        string sql = "INSERT INTO Candidato(IdCandidato, IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@pIdCandidato, @pIdPartido, @pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pPostulacion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pIdCandidato = can.IdCandidato, pIdPartido = can.IdPartido, pApellido = can.Apellido, pNombre = can.Nombre, pFechaDeNacimiento = can.FechaNacimiento, pFoto = can.Foto, pPostulacion = can.Postulacion});
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
        // for(int i= 0; i<listaPartido.Count(); i++){
        //     if(listaPartido[i].IdPartido == IdPartido){
        //         return listaPartido[i];
        //     }
        // }
        // return null;
        //Version sql
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
            listaPartido = db.QueryFirstOrDefault<Partido>(sql, new { pIdPartido = IdPartido });
        }
        return listaPartido; 
    }

    public static Candidato VerInfoCandidatos(int IdCandidato){
        for(int i= 0; i<listaCandidato.Count(); i++){
            if(listaCandidato[i].IdCandidato == IdCandidato){
                return listaCandidato[i];
            }
        }
        return null;
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
            string sql = "SELECT * FROM Candidato";
            listaCandidato = db.Query<Candidato>(sql).ToList();
        }
        return listaCandidato;
    }
}