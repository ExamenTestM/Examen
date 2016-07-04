using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfExamen
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Alumnos> Alumnos();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.

    [DataContract]
    public class Alumnos
    {
        int _IdAlumno;
        string _Alumno;
        [DataMember]
        public int IdAlumno
        {
            get
            {
                return _IdAlumno;
            }

            set
            {
                _IdAlumno = value;
            }
        }
        [DataMember]
        public string Alumno
        {
            get
            {
                return _Alumno;
            }

            set
            {
                _Alumno = value;
            }
        }
    }
}
