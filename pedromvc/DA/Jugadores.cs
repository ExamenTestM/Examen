using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class Jugadores
    {
        static SqlConnection con = new SqlConnection("Data Source=LAP_MAFTEC_01\\SQLEXPRESS;Initial Catalog=pedro;Integrated Security=True");

        public static void Insert(string nombre, int edad)
        {
            using (SqlCommand cmd = new SqlCommand("InsertJugadores", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = edad;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void Update(int id, string nombre , int edad)
        {
            using (SqlCommand cmd = new SqlCommand("UpdateJugadores", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = edad;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        
        public static void Delete(int id)
        {
            using (SqlCommand cmd = new SqlCommand("EliminarJugadores", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // mefalta llenarunatabla
        public static List<ET.Jugadores> GetConsulta()
        {
            DataSet da = new DataSet();
            List<ET.Jugadores> listaJugadores = new List<ET.Jugadores>();
            using (SqlCommand cmd = new SqlCommand("ListaJugadores", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                
                //cmd.ExecuteReader();
                sqlda.Fill(da);
                con.Close();
            }

            foreach(DataRow r in da.Tables[0].Rows)
            {
                listaJugadores.Add(new ET.Jugadores(int.Parse(r["IdJugador"].ToString()) , r["nombre"].ToString(),int.Parse( r["edad"].ToString())));
            }
            return listaJugadores;
        }

        public static List<ET.Jugadores> GetConsultabyId(int id)
        {
            DataSet da = new DataSet();
            List<ET.Jugadores> listaJugadores = new List<ET.Jugadores>();
            using (SqlCommand cmd = new SqlCommand("getJugadorById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

                //cmd.ExecuteReader();
                sqlda.Fill(da);
                con.Close();
            }

            foreach (DataRow r in da.Tables[0].Rows)
            {
                listaJugadores.Add(new ET.Jugadores(int.Parse(r["IdJugador"].ToString()), r["nombre"].ToString(), int.Parse(r["edad"].ToString())));
            }
            return listaJugadores;
        }


    }
}
