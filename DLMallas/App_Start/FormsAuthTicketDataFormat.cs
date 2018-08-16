using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web.Security;
using DLMallas.Business;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebGrease.Configuration;

namespace DLMallas.App_Start
{
    public class FormsAuthTicketDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            return FormsAuthentication.Encrypt(new FormsAuthenticationTicket(data.Identity.Name, false, -1));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var ticket = FormsAuthentication.Decrypt(protectedText);
            var identity = new FormsIdentity(ticket);
            if (!string.IsNullOrWhiteSpace(ticket.UserData))
            {
                var roles = ticket.UserData.Split(',');

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

            }

            BuildPersonIdentity(identity);

            return new AuthenticationTicket(identity, new AuthenticationProperties());
        }

        private void BuildPersonIdentity(FormsIdentity identity)
        {
            // separar id y dv
            //var rut = identity.GetUserName();
            //var split = rut.Split('-');
            //var id = split[0];
            //var dv = split[1];

            var parts = identity.GetUserName();
            var split = parts.Split('|');
            var user = split[0];
            var idPersona = split[1];
            var idSociedad = split[2];

            // cargar persona
            var personaBl = new Persona();
            
             var persona = personaBl.GetPersonaPorId(idSociedad, idPersona);

            var nombre = "SIN NOMBRE";
            //var idSociedad = "";
            if (persona != null)
            {
                // crear claims
                nombre =
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                        string.Format("{0} {1}", persona.Nombre, persona.Nombre)
                            .ToLower());
            }
            
            // tiene claim nombre?
            var nameClaim = identity.FindFirst(ClaimsIdentity.DefaultNameClaimType);
            if (nameClaim != null)
            {
                identity.RemoveClaim(nameClaim);
            }

            // nombre
            //identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, nombre));

            // id
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user));

            // idSociedad
            identity.AddClaim(new Claim("urn:digital-learning/id-sociedad", idSociedad));
        }
    }
}