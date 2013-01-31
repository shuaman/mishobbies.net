using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HobbieWS.Dominio;

namespace HobbieWS
{
    [ServiceContract]
    public interface IAdmHobbie
    {
        [OperationContract]
        Hobbie CrearHobbie(string nombre, string descripcion);
        [OperationContract]
        Hobbie ObtenerHobbie(int codigo);
        [OperationContract]
        List<Hobbie> ListarHobbies();
    }

}
