using Nancy;

namespace NancyPlugwise.Modules
{
    public class DefaultModule:NancyModule
    {
         
        public DefaultModule()
        {
            Get["/"] = parameters => View["Default.cshtml"];
        }
    }
}