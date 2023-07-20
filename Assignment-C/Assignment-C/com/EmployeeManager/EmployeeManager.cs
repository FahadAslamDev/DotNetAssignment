using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;


namespace Assignment_C.com.EmployeeManager
{
        public interface IEmployee
        {
         string GetAllEmployees();
        }
        public class Employee
        {

            public Employee() { }
            public Employee(int id, string name)
            {
                this.ID = id;
                this.Name = name;
            }

            public int ID { get; set; }
            public string Name { get; set; }


        }
    public class EmployeeManagerClass
    {
        public int f;
        public List<Employee> employees;
        public EmployeeManagerClass()
        {
            employees = new List<Employee>();
            this.employees.Add(new Employee(1, "Fahad Aslam"));
            this.employees.Add(new Employee(2, "Saad Aslam"));
            this.employees.Add(new Employee(3, "Ahmed Raza"));
            this.employees.Add(new Employee(4, "Asad"));

        }
        public virtual string GetAllEmployees()
        {
            var store = new XmlSerializerNamespaces();
            var serializer = new XmlSerializer(employees.GetType());
            var settings = new XmlWriterSettings(); 
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var stream = new StringWriter())
                //using is used to automatically dispose the object when it is not needed anymore
            using (var writer = XmlWriter.Create(stream, settings))
            {   //right not stream object is empty 
                
                serializer.Serialize(writer, employees, store);
                return stream.ToString();////////////////////////;
                //////////////NEWEST///////////
            }
        }
    }
   
}
