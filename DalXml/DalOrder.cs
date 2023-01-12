using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal class DalOrder : IOrder
    {
        
        const string s_Orders = "orders"; //Linq to XML

        static DO.Order? createOrderfromXElement(XElement s)
        {
            return new DO.Order()
            {
                ID = s.ToIntNullable("ID") ?? throw new DO.DlNoFindException("id"), //fix to: DalXmlFormatException(id)),
                CustomerName= (string?)s.Element("CustomerName"),
                CustomerAdress = (string?)s.Element("CustomerAdress"),
                CustomerEmail = (string?)s.Element("CustomerEmail"),
               
                DeliveryDate = s.ToDateTimeNullable("DeliveryDate"),
                ShipDate = s.ToDateTimeNullable("ShipDate"),
                OrderDate = s.ToDateTimeNullable("OrderDate"),
               
            };
        }
        public int Add(Order item)
        {
            XElement orderRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

            XElement? stud = (from st in orderRootElem.Elements()
                              where st.ToIntNullable("ID") == item.ID //where (int?)st.Element("ID") == doStudent.ID
                              select st).FirstOrDefault();
            if (stud != null)
                throw new Exception("id already exist"); // fix to: throw new DalMissingIdException(id);
            item.ID = (int)Config.GetNextOrderIDfromXMLconfig();
            XElement studentElem = new XElement("Student",
                                       new XElement("ID", item.ID),
                                       new XElement("CustomerName", item.CustomerName),
                                       new XElement("CustomerAdress", item.CustomerAdress),
                                       new XElement("CustomerEmail", item.CustomerEmail),
                                       new XElement("DeliveryDate", item.DeliveryDate),
                                       new XElement("ShipDate", item.ShipDate),
                                       new XElement("OrderDate", item.OrderDate)
                                       );
            

            orderRootElem.Add(studentElem);

            Config.SaveNextOrderID(item.ID + 1);

            XMLTools.SaveListToXMLElement(orderRootElem, s_Orders);

            return item.ID; ;
        }

        public void Delete(int id)
        {
            XElement orderRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

            XElement? stud = (from st in orderRootElem.Elements()
                              where (int?)st.Element("ID") == id
                              select st).FirstOrDefault() ?? throw new Exception("missing id"); // fix to: throw new DalMissingIdException(id);

            stud.Remove(); //<==>   Remove stud from studentsRootElem

            XMLTools.SaveListToXMLElement(orderRootElem, s_Orders);
        }

        public IEnumerable<Order?> GetAll(Func<Order?, bool>? filter = null)
        {
            XElement? orderRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

            //return studentsRootElem.Elements().Select(s => createStudentfromXElement(s)).Where(filter);

            if (filter != null)
            {
                return from s in orderRootElem.Elements()
                       let doStud = createOrderfromXElement(s)
                       where filter(doStud)
                       select (DO.Order?)doStud;
            }
            else
            {
                return from s in orderRootElem.Elements()
                       select createOrderfromXElement(s);
            }
        }

        public Order GetById(int id)
        {
            XElement orderRootElem = XMLTools.LoadListFromXMLElement(s_Orders);

            return (from s in orderRootElem?.Elements()
                    where s.ToIntNullable("ID") == id
                    select (DO.Order?)createOrderfromXElement(s)).FirstOrDefault()
                    ?? throw new Exception("missing id");
        }

        public void Update(Order item)
        {
            Delete(item.ID);
            Add(item);
        }
    }
}
