using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AdapterPattern
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public EmployeeModel() { }
        public EmployeeModel(int id, string name, int salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
    }
    public class Operation
    {
        public List<EmployeeModel> employees;
        public Operation()
        {
            employees = new List<EmployeeModel>();
            FillEmployeeList();
        }
        public void FillEmployeeList()
        {
            employees.Add(new EmployeeModel( 100, "Deepak", 10000 ));
            employees.Add(new EmployeeModel( 101, "Rohit", 20000 ));
            employees.Add(new EmployeeModel( 102, "Ram", 30000 ));
            employees.Add(new EmployeeModel( 103, "Dev", 40000 ));
        }

        public void GetXMLList(ref string xml)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<EmployeeModel>));

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this.employees);
                    xml = sww.ToString(); // Your XML
                }
            }
        }
    }
    public interface ITarget
    {
        string GetEmployee();
    }
    public class EmployeeAdapter : Operation, ITarget
    {

        public string GetEmployee()
        {
            var xml = "";
            var op = new Operation();
            op.GetXMLList(ref xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(doc);
            return json;
        }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            var list = new EmployeeAdapter().GetEmployee();
        }
    }
}
