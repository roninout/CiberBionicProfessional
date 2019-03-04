using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L05_TaskAdd01
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем XML-файл
            XDocument xdoc = new XDocument(new XElement("MyContacts",
                new XElement("Contact",
                    new XAttribute("TelephoneNumber", "(088)154-45-67"),
                    new XElement("Name", "Alexander")),
                new XElement("Contact",
                    new XAttribute("TelephoneNumber", "(099)244-34-67"),
                    new XElement("Name", "Taras"))));
            xdoc.Save("TelephoneBook.xml"); // и сохраняем

            // выводим XML-файл на экран
            XDocument xLoadDoc = XDocument.Load("TelephoneBook.xml");
            foreach (XElement contact in xLoadDoc.Element("MyContacts").Elements("Contact"))
            {
                XAttribute telephoneNumberAttribute = contact.Attribute("TelephoneNumber");
                XElement nameElement = contact.Element("Name");

                if (telephoneNumberAttribute != null && nameElement != null)
                {
                    Console.Write($"Имя: {nameElement.Value, -15}        ");
                    Console.Write($"Телефон: {telephoneNumberAttribute.Value}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
