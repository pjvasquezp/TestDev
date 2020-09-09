using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WS_PJ_TEST.Clases;

namespace WS_PJ_TEST
{
    /// <summary>
    /// Summary description for ws_pj
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ws_pj : System.Web.Services.WebService
    {
        
        [WebMethod]
        public Auto CargarAuto(String Marca, String Modelo, String Tipo, int Year, string Color)
        {
            Auto MiAuto = new Auto();

            MiAuto.Marca = Marca;
            MiAuto.Modelo = Modelo;
            MiAuto.Tipo = Tipo;
            MiAuto.Color = Color;
            MiAuto.year = Year;

            return MiAuto;
        }
    }
}
