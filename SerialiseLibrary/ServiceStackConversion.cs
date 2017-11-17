using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;

namespace SerialiseLibrary
{
   public static class ServiceStackConversion
    {

        public static string Serialise(List<Employee> employees)
        {

            string data = employees.ToJson();
            return data;
        }
        public static List<Employee> DeSerialise(string data)
        {

            List<Employee> empList = new List<Employee>();
            empList = data.FromJson<List<Employee>>();
            return empList;
        }
    }
}
