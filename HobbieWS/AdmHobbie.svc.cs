using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HobbieWS.Dominio;
using HobbieWS.Persistencia;

namespace HobbieWS
{

    public class AdmHobbie : IAdmHobbie
    {
        private HobbieDAO hobbieDAO = null;
         
        private HobbieDAO HobbieDAO
        {
            get
            {
                if (hobbieDAO == null)
                    hobbieDAO = new HobbieDAO();
                return hobbieDAO;
            }
        }


        public Hobbie CrearHobbie(string nombre, string descripcion)
        {
            Hobbie hobbieCreado = null;
            int registro=0;  
            List<Hobbie> ListaHobbie=ListarHobbies();

            if (ListaHobbie.Count > 0)
            {
                for (int i = 0; i < ListaHobbie.Count; i++)
                {
                    if (ListaHobbie[i].Nombre == nombre)
                    {
                        registro = 1;
                        break;
                    }

                }

                if (registro == 0)
                {
                    
                    Hobbie hobbieACrear = new Hobbie()
                    {
                        Nombre = nombre,
                        Descripcion = descripcion

                    };
                    hobbieCreado=HobbieDAO.Crear(hobbieACrear);

                }
                else
                {
                    hobbieCreado = null;
                }
         
            }

            return hobbieCreado;
           
        }

        public Hobbie ObtenerHobbie(int codigo)
        {
            return HobbieDAO.Obtener(codigo);
        }

        public List<Hobbie> ListarHobbies()
        {
            return HobbieDAO.ListarTodos().ToList();
        }


    }
}
