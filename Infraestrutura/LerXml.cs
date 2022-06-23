using System;
using System.Xml;

namespace Infraestrutura
{
    public class LerXml
    {
        XmlDocument xmlDocument = new XmlDocument();
        public XmlNodeList quantidadeList;
        public XmlNodeList nomeProdList;
        public XmlNodeList unitarioList;
        public XmlNodeList tipoItemList;
        public XmlNodeList idItem;
        public XmlNodeList valortotalList;
        /*responsavel pela leitura de xml*/
        public void AbrirXMl(string nomeXml)
        {


            xmlDocument.Load(nomeXml);

            nomeProdList = xmlDocument.GetElementsByTagName("xProd");
            quantidadeList = xmlDocument.GetElementsByTagName("qCom");
            unitarioList = xmlDocument.GetElementsByTagName("vUnCom");
            valortotalList = xmlDocument.GetElementsByTagName("vProd");
            tipoItemList = xmlDocument.GetElementsByTagName("uCom");

        }
    }
}
