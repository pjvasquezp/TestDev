using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PJ.BusinessEntity
{
    public class Timbrado
    {
        public int NumDoc { get; set; }
        public DateTime FechaTimbrado { get; set; }
        public string GuidTimbrado { get; set; }
        public XmlDocument Xmltimbrado { get; set; }
    }
}
