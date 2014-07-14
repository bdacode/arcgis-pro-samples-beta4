using ArcGIS.Desktop.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UCSamples.InsertIntoContextMenu
{
    public class CIMViewerViewModel : ViewModelBase
    {
        private string _xml;
        public string Xml 
        { 
            get {return FormatXml(_xml);}
            set { SetProperty(ref _xml, value, () => Xml); }
        }

        private string FormatXml(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var stringBuilder = new StringBuilder();
            var xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            doc.Save(XmlWriter.Create(stringBuilder, xmlWriterSettings));
            return stringBuilder.ToString();
        }
    }
}
