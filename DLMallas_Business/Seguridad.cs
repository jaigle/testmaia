using DLMallas.Business.Dto;
using DLMallas.Utilidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSLib;

namespace DLMallas.Business
{
    public class Seguridad
    {
        public List<DtoPagina> ObtenerMenu(string idSociedad, string nombre)
        {
            WebService ws = new WebService("Seguridad", "obtenerMenu");
            ws.AddParameter("IdSociedad", idSociedad);
            ws.AddParameter("Nombre", nombre);
            var obj = ws.Invoke();

            string json = JsonConvert.SerializeObject(obj);
            List<DtoPagina> list = JsonConvert.DeserializeObject<List<DtoPagina>>(json);

            return list;
        }

        public string ObtenerParametroAplicacion(string idSociedad, string nombre)
        {
            WebService ws = new WebService("Seguridad", "obtenerParametroAplicacion");
            ws.AddParameter("IdSociedad", idSociedad);
            ws.AddParameter("Nombre", nombre);
            var obj = ws.Invoke();

            string json = JsonConvert.SerializeObject(obj);
            List<DtoValor> list = JsonConvert.DeserializeObject<List<DtoValor>>(json);

            return list.First().Valor;
        }

        public void ActualizarVariablesSistemafake(string idSociedad, string usuario, string idPersona)
        {
            Variables.IdSociedad = idSociedad;
            Variables.FonoSoporte = "222222222";
            Variables.MailSoporte = "a@a";
            Variables.UrlHcm = "http://Localhost:4443";
            Variables.Login = "Login.aspx";
            Variables.IdPersona = idPersona;
            Variables.Usuario = usuario;
            Variables.NombrePersona = "Fake Administrador";
        }


        public void ActualizarVariablesSistema(string idSociedad, string usuario, string idPersona)
        {
            //Si la sociedad es distinta de la sesión, actualizamos los parametros
            if (idSociedad != Variables.IdSociedad)
            {
                Variables.IdSociedad = idSociedad;
                Variables.FonoSoporte = this.ObtenerParametroAplicacion(idSociedad, "FonoSoporte");
                Variables.MailSoporte = this.ObtenerParametroAplicacion(idSociedad, "MailSoporte");
                Variables.UrlHcm = this.ObtenerParametroAplicacion(idSociedad, "UrlHcm");
                Variables.Login = this.ObtenerParametroAplicacion(idSociedad, "Login");
            }


            if (idPersona != Variables.IdPersona)
            {
                Variables.IdPersona = idPersona;
                Variables.Usuario = usuario;
                var personaSvc = new Persona();
                var persona = personaSvc.GetPersonaPorId(Variables.IdSociedad, idPersona);
                Variables.NombrePersona = persona.Nombre;
            }

        }
    }
}
