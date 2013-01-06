using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NancyPlugwise.Model;

namespace NancyPlugwise.Services
{
    public class PlugwiseModulesService
    {
        public IList<PlugwiseModuleModel> FindAll()
        {
            var xml = XDocument.Load("http://localhost:8080/xml/modules.xml");

            var q = from b in xml.Descendants("Module")
            select new PlugwiseModuleModel 
            {
                Name = b.Attribute("Name")==null?"":b.Attribute("Name").Value,
                Id = b.Attribute("Id") == null ? "" : b.Attribute("Id").Value,
                Mac = b.Attribute("MAC") == null ? "" : b.Attribute("MAC").Value,
                Type = b.Attribute("Type") == null ? "" : b.Attribute("Type").Value,
                PowerUsage = b.Attribute("PowerUsage") == null ? "" : b.Attribute("PowerUsage").Value,
                RelayState = b.Attribute("RelayState") == null ? "" : b.Attribute("RelayState").Value,
                Appliance = b.Attribute("Appliance") == null ? "" : b.Attribute("Appliance").Value                   
            };
            return q.ToList();
        }

        public PlugwiseModuleModel FindById(string moduleId)
        {
            var xml = XDocument.Load("http://localhost:8080/xml/module.xml?moduleid=" + moduleId);

            var q = from b in xml.Descendants("Module")
                    select new PlugwiseModuleModel
                    {
                        Name = b.Attribute("Name") == null ? "" : b.Attribute("Name").Value,
                        Id = b.Attribute("Id") == null ? "" : b.Attribute("Id").Value,
                        Mac = b.Attribute("MAC") == null ? "" : b.Attribute("MAC").Value,
                        Type = b.Attribute("Type") == null ? "" : b.Attribute("Type").Value,
                        PowerUsage = b.Attribute("PowerUsage") == null ? "" : b.Attribute("PowerUsage").Value,
                        RelayState = b.Attribute("RelayState") == null ? "" : b.Attribute("RelayState").Value,
                        Appliance = b.Attribute("Appliance") == null ? "" : b.Attribute("Appliance").Value
                    };
            return q.FirstOrDefault();
        }
    }
}