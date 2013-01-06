using Nancy;

namespace NancyPlugwise.Modules
{
    public class PlugwiseModulesModule: NancyModule
    {
        public PlugwiseModulesModule(Services.PlugwiseModulesService plugwiseModulesService)
        {
            Get["/modules"] = parameters =>
                {
                    var modules = new Model.PlugwiseModulesModel() {Modules = plugwiseModulesService.FindAll()};
                    return View[modules];
                };
            Get["/modules/{Id}"] = parameters =>
            {
                var module = plugwiseModulesService.FindById(parameters.Id.ToString());
                return View[module];
            };
        }
    }
}