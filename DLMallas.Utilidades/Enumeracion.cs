using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace DLMallas.Utilidades
{
    public static class Enumeracion
    {
        public static int contenedorSociedad;

        public const string cntstrMallaCertificadoEncabezado = "Se otorga el presente certificado a";
        public const string cntstrMallaCertificadoCuerpo = "por haber aprobado la malla curricular,";
        public const string cntstrMallaCertificadoEncabezadoListaUC = "A continuación se detalla el resultado del colaborador en cada una de las UC cursadas:";

        public class EstadoPosicionLaboral
        {
            public const byte NoHistorial = 0;
            public const byte Actual = 2;
            public const byte Historial = 1;
        }
        public class TipoCosto
        {
            public const int SinInformacion = 0;
            public const int Matricula = 1;
            public const int Viaticos = 2;
            public const int Traslados = 3;
            public const int OtrosCostos = 4;
        }

        public class OrdenTipoCosto
        {
            public const int Relatoria = 1;
            public const int MatriculaOtec = 2;
        }

        public class AccesoDirecto
        {
            public const int Uno = 1;
            public const int Dos = 2;
            public const int Tres = 3;
        }

        public class TipoProveedor
        {
            public const int Todos = 0;
            public const int PersonaProductos = 1;
            public const int SociedadOtec = 2;
            public const int SociedadOtic = 3;
            public const int SociedadProducto = 4;
        }



        public class TipoPublicacion
        {
            public const int Noticia = 1;
        }

        public class HijoMatricula
        {
            public const int Relatoria = 1;
            public const int MatriculaOtec = 2;
        }

        public class TipoEntidad
        {
            public const int Natural = 1;
            public const int Juridica = 2;
        }

        public class EstadoTipoCosto
        {
            public const int Activo = 1;
            public const int NoActivo = 2;
        }

        public class TipoPosicionLaboral
        {
            public const byte NoInformation = 0;
            public const byte Internal = 1;
            public const byte External = 2;
        }

        public class TipoMaterialApoyo
        {
            public const byte NoInformation = 0;
            public const byte Material = 1;
            public const byte Enlace = 2;
            public const byte Scorm = 3;
            public const byte MaterialUnidadCurricular = 4;
            public const byte ScormUnidadCurricular = 5;
        }

        public class TipoObjetoAutoEstudio
        {
            public const byte NoInformation = 0;
            public const byte Scorm = 1;
            public const byte Documento = 2;
            public const byte URL = 3;
            public const byte Video = 4;

        }

        public class Eventos
        {
            public const string RecursoMatriculaFijo = "Matrícula";
            public const string RecursoViaticoFijo = "Viáticos";
            public const string RecursoTrasladoFijo = "Traslados";
            public const string RecursoOtrosFijo = "Otros costos de participantes";
            public const int EstadoTipoServicioMatricula = 1;
            public const int EstadoTipoServicioViatico = 2;
            public const int EstadoTipoServicioTraslado = 3;
            public const int EstadoTipoServicioOtrosCostos = 4;
            public const int EstadoEnPlanificacion = 2;

        }

        public class TipoAudiencias
        {
            public const int Publica = 1;
            public const int TodaOrganizacion = 2;
            public const int OtraAudencia = 3;
        }

        public class EstadoEvento
        {
            public const int EnPlanificacion = 2;
            public const int Planificado = 3;
            public const int EnEjecucion = 4;
            public const int Finalizado = 5;
            public const int Liquidado = 6;
            public const int Anulado = 7;
            public const int Default = 0;
        }

        public class ProximidadVencimiento
        {
            public const int Todas = 1;
            public const int Vencidas = 2;
            public const int Proximos7 = 3;
            public const int Proximos30 = 4;
            public const int Proximos60 = 5;
            public const int Proximos90 = 6;
        }

        public class TipoComunicacionSENCE
        {
            public const int SinInformacion = 1;
            public const int Comunicacion = 2;
            public const int Rectificacion = 3;
        }

        public class EstadoParticipante
        {
            public const int SinInformacion = 0;
            public const int Nominado = 1;
            public const int Matriculado = 2;
            public const int Anulado = 3;
        }

        public enum SituacionFinal
        {
            SININFORMACION = 0,
            APROBADO = 1,
            REPROBADONOTA = 2,
            REPROBADOINASISTENCIA = 3
        }

        public class SituacionFinalCurso
        {
            public const int APROBADO = 1;
            public const int REPROBADONOTA = 2;
            public const int REPROBADOINASISTENCIA = 3;
        }

        public class Perfiles
        {
            public const int Administrador = 1;
            public const int Colaborador = 2;
            public const int JefeDirecto = 3;
            public const int ConsultorRRHH = 4;
            public const int OraganizadorEventos = 5;
            public const int AdministradorEventos = 6;
            public const int Instructor = 7;
            public const int AdministradorDesarrolloCarrera = 8;
        }

        public class Modalidad
        {
            public const int Presencial = 1;
            public const int ELearning = 2;
            public const int ADistancia = 3;
        }

        public class Modulo
        {
            public const int Becas = 1;
            public const int Eventos = 2;
            public const int Presupuesto = 3;
        }

        public class EstadoPresupuesto
        {
            public const byte Vigente = 1;
            public const byte NoVigente = 2;
        }


        public enum Visibilidad
        {
            Todos = 0,
            JefeDirecto = 1
        }


        public class TipoCuentaContable
        {
            public const int GastosGenerales = 1;
            public const int Sence = 2;
            public const int FormaDePago = 3;
            public const int ImpuestoALaRenta = 4;
            public const int Otro = 5;
        }


        public enum EstadoMalla : int
        {
            Activa = 1,
            NoActiva = 2
        }

        public enum TipoAsignacionVersionMalla : int
        {
            Dirigida = 1,
            Automatica = 2
        }

        public enum EstadoVersionMalla : int
        {
            Vigente = 1,
            NoVigente = 2
        }

        public enum EstadoEjecucionVersionMalla : int
        {
            Ejecutada = 1,
            EnEjecucion = 2,
            Proxima = 3
        }

        public enum TipoModalidadesUnidadesCurricularesMalla : int
        {
            Ambos = 0,
            Presencial = 1,
            Elearning = 2,
            PresencialoElearning = 3
        }

        public class EstadoReportesMallas
        {
            public const string Completa = "Completa";

            public const string EnCurso = "En Curso";
            public const string NoIniciadas = "No Iniciadas";
            public const string Cursadas = "UC Cursadas";
            public const string NoCursadas = "UC No Cursadas";
            public const string Aprobadas = "Aprobadas";
            public const string Reprobadas = "Reprobadas";
            public const string NoDisponibles = "No Disponibles";

        }
    }

    public static class Variables
    {
        public static string IdSociedad
        {
            get
            {
                if (HttpContext.Current.Session["IdSociedad"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["IdSociedad"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["IdSociedad"] = value;
            }
        }

        public static string IdPersona
        {
            get
            {
                if (HttpContext.Current.Session["IdPersona"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["IdPersona"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["IdPersona"] = value;
            }
        }
        public static string NombrePersona
        {
            get
            {
                if (HttpContext.Current.Session["NombrePersona"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["NombrePersona"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["NombrePersona"] = value;
            }
        }
        public static string Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["Usuario"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Usuario"] = value;
            }
        }
        public static string MailSoporte
        {
            get
            {
                if (HttpContext.Current.Session["MailSoporte"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["MailSoporte"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["MailSoporte"] = value;
            }
        }
        public static string FonoSoporte
        {
            get
            {
                if (HttpContext.Current.Session["FonoSoporte"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["FonoSoporte"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["FonoSoporte"] = value;
            }
        }
        public static string UrlHcm
        {
            get
            {
                if (HttpContext.Current.Session["UrlHcm"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["UrlHcm"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["UrlHcm"] = value;
            }
        }
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return HttpContext.Current.Session["Login"].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session["Login"] = value;
            }
        }
    }

    public static class Acciones
    {
        public static string serializarObjeto(Object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// Formatea correctamente una cadena determinada para tratarla como RUT
        /// </summary>
        /// <param name="pstrCadenaEntrada">Cadena original, puede estar vacia o con mas elementos</param>
        /// <param name="pboolConPuntos">Si se desea la salida con el formato de puntos ##.###.###-#
        /// Por defecto devuelve el formato de solo el guion final: ########-#</param>
        /// <returns></returns>
        public static string FormatRUT(string pstrCadenaEntrada, bool pboolConPuntos = false)
        {
            string rutentrada = pstrCadenaEntrada;

            if (rutentrada.Length == 9 || rutentrada.Length == 11)
            {
                if (rutentrada.Length == 11)
                {
                    pboolConPuntos = true;
                }
                if (!pboolConPuntos)
                {
                    return rutentrada;

                }
                else
                {

                    rutentrada = rutentrada.Replace(".", "");
                    return rutentrada;
                }
            }

            rutentrada = rutentrada.PadLeft(9, Convert.ToChar("0"));
            var Iu = rutentrada.Substring(0, rutentrada.Length - 1);
            Iu = Regex.Replace(Iu, @"[^0-9\.]", "0", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            Iu = Regex.Replace(Iu, @"[\.]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            Iu = Iu.PadLeft(8, Convert.ToChar("0"));
            Iu = Iu.Substring(0, 8);
            var Dv = rutentrada.Substring(rutentrada.Length - 1, 1);
            Dv = Regex.Replace(Dv, @"[^kK0-9]", "0", RegexOptions.None, TimeSpan.FromSeconds(1.5));

            if (!pboolConPuntos) return Iu + '-' + Dv; ;

            return Iu.Substring(0, 2) + '.' + Iu.Substring(2, 3) + '.' + Iu.Substring(5, 3) + '-' + Dv;
        }

        /// <summary>
        /// Metodo para validar un RUT 
        /// </summary>
        /// <param name="pstrRutFormateado">Codigo RUT correctamente formateado. Solo numeros y [, o -]</param>
        /// <returns></returns>
        public static bool ValidarRut(string pstrRutFormateado)
        {
            bool validacion = false;
            try
            {
                pstrRutFormateado = pstrRutFormateado.ToUpper();
                pstrRutFormateado = pstrRutFormateado.Replace(".", "");
                pstrRutFormateado = pstrRutFormateado.Replace("-", "");
                int rutAux = int.Parse(pstrRutFormateado.Substring(0, pstrRutFormateado.Length - 1));
                char dv = char.Parse(pstrRutFormateado.Substring(pstrRutFormateado.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return validacion;
        }

        public class Paths
        {
            public const string Logo = @"/images/logo.png";
            public const string LogoPrograma = @"/images/imagen_certificado.png";
            public const string PathCssCustom = @"~/Content/";
            public const string Firma = @"/images/firma.png";
        }
    }
}
