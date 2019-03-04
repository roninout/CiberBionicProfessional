using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L05_Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            // выводим XML-файл на экран
            XDocument xLoadDoc = XDocument.Load("TelephoneBook.xml");
            foreach (XElement contact in xLoadDoc.Element("MyContacts").Elements("Contact"))
            {
                XAttribute telephoneNumberAttribute = contact.Attribute("TelephoneNumber");

                if (telephoneNumberAttribute != null)
                    Console.WriteLine($"Телефон: {telephoneNumberAttribute.Value}");
            }
            Console.ReadKey();
        }
    }
}
