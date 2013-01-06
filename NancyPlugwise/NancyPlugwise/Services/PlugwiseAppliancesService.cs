using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NancyPlugwise.Model;

namespace NancyPlugwise.Services
{
    public class PlugwiseAppliancesService
    {
        public IList<PlugwiseApplianceModel> FindAll()
        {
            var xml = XDocument.Load("http://localhost:8080/xml/appliances.xml");

            var q = from b in xml.Descendants("Appliance")
            select new PlugwiseApplianceModel 
            {
                Name = b.Attribute("Name")==null?"":b.Attribute("Name").Value,
                Id = b.Attribute("Id") == null ? "" : b.Attribute("Id").Value,
                TotalUsage = b.Attribute("TotalUsage") == null ? "" : b.Attribute("TotalUsage").Value,
                Type = b.Attribute("Type") == null ? "" : b.Attribute("Type").Value,
                PowerUsage = b.Attribute("PowerUsage") == null ? "" : b.Attribute("PowerUsage").Value,
                PowerState = b.Attribute("PowerState") == null ? "" : b.Attribute("PowerState").Value,
                Image = b.Attribute("Image") == null ? "" : b.Attribute("Image").Value,
                Module = b.Attribute("Module") == null ? "" : b.Attribute("Module").Value                   
            };
            return q.ToList();
        }
    }
}