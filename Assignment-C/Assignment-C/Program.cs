using Assignment_C.com.EmployeeAdapter;
using Assignment_C.com.EmployeeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Assignment_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployee emp = new EmployeeAdapter();
            string value = emp.GetAllEmployees();
            Console.WriteLine(value);
            Console.ReadLine();
        }



    }
}
