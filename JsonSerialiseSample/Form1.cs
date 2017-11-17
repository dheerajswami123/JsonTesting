using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using ServiceStack;

namespace JsonSerialiseSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Employee> listEmployee = new List<Employee>();
        string serialisedString;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Employee emp;
            for(int i=0;i<100000;i++)
            {
                emp = new Employee();
                emp.Address = "Address " + i;
                emp.CreateDate = DateTime.Now;
                emp.Department = "Global Del";
                emp.FirstName = "fn" + 1;
                emp.LastName = "ln" + 1;
                emp.Email = emp.FirstName + "." + emp.LastName + "@microsoft.com";
                emp.EmpId = i;
                emp.Experience = 6;
                emp.ModifiedDate = DateTime.Now;
                emp.Salary = i * 3;
                emp.Serviceyear = 1;
                listEmployee.Add(emp);
            }
        }

        private void btnSer_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            lblRecords.Text = "Records :" + listEmployee.Count;
            
            serialisedString= JsonConvert.SerializeObject(listEmployee);
            
            TimeSpan span = DateTime.Now - dt1;
            int ms = (int)span.TotalMilliseconds;

            lblEndTime.Text = "Time Taken " + ms;
        }

        private void btnDes_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
           
            listEmployee = JsonConvert.DeserializeObject<List<Employee>> (serialisedString);

            TimeSpan span = DateTime.Now - dt1;
            int ms = (int)span.TotalMilliseconds;

            lblDStartTime.Text = "Time Taken:" + ms;
        }

      
        private void btnD_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;

            listEmployee = JSONStream.DeseriliseData(serialisedString);

            TimeSpan span = DateTime.Now - dt1;

          
            int ms = (int)span.TotalMilliseconds;

            label3.Text = "Time Taken:" + ms;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Seri
            DateTime dt1 = DateTime.Now;
            label5.Text = "Records :" + listEmployee.Count;
            serialisedString= ServiceStack.Text.JsonSerializer.SerializeToString(listEmployee);
           // serialisedString = listEmployee.ToJson();     //ServiceStackConversion.Serialise(listEmployee);

            TimeSpan span = DateTime.Now - dt1;
            int ms = (int)span.TotalMilliseconds;

            label6.Text = "Time Taken " + ms;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DES
            DateTime dt1 = DateTime.Now;

            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(serialisedString)))
            {
                var lst = ServiceStack.Text.JsonSerializer.DeserializeFromStream<List<Employee>>(stream);
            }

            //var lst = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Employee>>(serialisedString);
            //var lst = serialisedString.FromJson<List<Employee>>();

            TimeSpan span = DateTime.Now - dt1;


            int ms = (int)span.TotalMilliseconds;

            label4.Text = "Time Taken:" + ms;
        }
    }
}
