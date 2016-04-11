using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeopleManager
{
    public class Staff
    {
        List<Person> staffMembers;
        public List<Person> StaffMembers
        {
            get { return staffMembers; }
            //set { staffMembers = value; }
        }
        string XMLName;
        public Staff(string XMLName)
        {
            staffMembers = new List<Person>();
            this.XMLName = XMLName;
        }

        public void XMLOpen()
        {
            /* *
             * This method can do two thigs:
             *  -if the XMLName.xml exists, it parses the content into the staffMembers list
             *  -if the XMLName.xml does not exist, than it generates the file with the given name
             *   and puts a default testUser into the file
             * */
            if (File.Exists(XMLName + ".xml"))
            {
                XDocument xmlFile = XDocument.Load(XMLName + ".xml");
                foreach (XElement element in xmlFile.Descendants("person"))
                {
                    staffMembers.Add(new Person { Name = element.Element("name").Value, Hours = int.Parse(element.Element("hours").Value) });
                }
            }
            else
            {
                XDocument xmlFile = new XDocument();
                xmlFile.Add(new XElement("people"));
                var temp = new XElement
                    (
                        "person",
                        new XElement("name", "testUser"),
                        new XElement("hours", 99)
                    );
                xmlFile.Element("people").Add(temp);
                xmlFile.Save(XMLName + ".xml");
            }
        }

        public void XMLSave()
        {
            /* *
             * This method rewrites the XMLName.xml file with the content of the staffMembers list
             * */
            XDocument xmlFile = new XDocument();
            xmlFile.Add(new XElement("people"));
            foreach (Person person in staffMembers)
            {
                var temp = new XElement
                    (
                        "person",
                        new XElement("name", person.Name),
                        new XElement("hours", person.Hours)
                    );
                xmlFile.Element("people").Add(temp);
            }
            xmlFile.Save(XMLName + ".xml");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public override string ToString()
        {
            return (this.Name + " \t " + this.Hours);
        }
    }
}
