using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{

    internal class Config
    {
        static string s_config = "configuration";
        public static XElement GetNextOrderIDfromXMLconfig()
            {
            return XMLTools.LoadListFromXMLElement(s_config).Element("NextOrderId");
            }
        public static void SaveNextOrderID(int id)
        {
            XElement root=XMLTools.LoadListFromXMLElement(s_config);
            root.Element("NextOrderItemId").SetValue(id.ToString());
            XMLTools.SaveListToXMLElement(root, s_config);
        }

        public static XElement GetNextOrderItemIDfromXMLconfig()
        {
            return XMLTools.LoadListFromXMLElement(s_config).Element("NextOrderItemId");
        }
        public static void SaveNextOrderItemID(int id)
        {
            XElement root = XMLTools.LoadListFromXMLElement(s_config);
            root.Element("NextOrderItemId").SetValue(id.ToString());
            XMLTools.SaveListToXMLElement(root, s_config);
        }
    }
}
