using System.Collections.Generic;
using System.Globalization;
using Bogus;
using DLMallas.Business.Dto.Certificado;

namespace DLMallas.Business.Extencions
{
    static public class DtoCertificadoExtention
    {
        public static DtoCertificado Faker(this DtoCertificado item, string id)
        {
            return new Faker<DtoCertificado>("es")
                .StrictMode(true)
                .RuleFor(r => r.Id, f => id)
                .RuleFor(r => r.Cuerpo, f => DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoCuerpo)
                .RuleFor(r => r.Encabezado, f => DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoEncabezado)
                .RuleFor(r => r.EncabezadoListaUC, f => DLMallas.Utilidades.Enumeracion.cntstrMallaCertificadoEncabezadoListaUC)
                .RuleFor(r => r.IdSociedad, f => f.Random.Number(1, 30).ToString())
                .RuleFor(r => r.RutaCertificado, f => f.Name.JobDescriptor())
                .RuleFor(r => r.RutaFirma, f => f.Name.JobDescriptor())
                .RuleFor(r => r.RutaLogo, f => f.Name.JobDescriptor());
        }

        public static List<DtoCertificado> Fake(this List<DtoCertificado> list, string id)
        {
            list.Add(new DtoCertificado().Faker(id));
            return list;
        }

    }
}