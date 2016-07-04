using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfExamen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection Conn = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Alumnos");

        public List<Alumnos> Alumnos()
        {
            List<Alumnos> LstAlumnos = new List<Alumnos>();
            {
                Conn.Open();
                SqlCommand Cmd = new SqlCommand("GetAlumnos", Conn);
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int Item = 0; Item < dt.Rows.Count; Item++)
                    {
                        Alumnos Alumno = new Alumnos();
                        Alumno.IdAlumno = int.Parse(dt.Rows[Item]["IdAlumno"].ToString());
                        Alumno.Alumno = dt.Rows[Item]["Alumno"].ToString();
                        LstAlumnos.Add(Alumno);
                    }
                }
                Conn.Close();
            }
            return LstAlumnos;
        }

    }
}
