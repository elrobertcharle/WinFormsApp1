using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{
    public class CustomXmlTextWriter : XmlTextWriter
    {
        public CustomXmlTextWriter(string fileName)
            : base(fileName, Encoding.UTF8)
        {
            this.Formatting = Formatting.Indented;
        }

        public override void WriteEndElement()
        {
            this.WriteFullEndElement();
        }
    }
}
