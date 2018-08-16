using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
namespace DLMallas.App_Start
{
    public static class IIdentityExtensions
    {
        public static int GetIdSociedad(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;

            if (ci == null || !ci.HasClaim(c => c.Type == "urn:digital-learning/id-sociedad"))
            {
                throw new InvalidOperationException("No se encontró el claim " + "urn:digital-learning/id-sociedad");
            }

            return int.Parse(ci.FindFirstValue("urn:digital-learning/id-sociedad"));
        }

        public static string GetRolesString(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;

            if (ci == null || !ci.HasClaim(c => c.Type == "urn:digital-learning/id-sociedad"))
            {
                throw new InvalidOperationException("No se encontró el claim " + "urn:digital-learning/id-sociedad");
            }

            return string.Join(", ", ci.FindAll(ClaimTypes.Role).Select(c => c.Value));
        }
    }
}