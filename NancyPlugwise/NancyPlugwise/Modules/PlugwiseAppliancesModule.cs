using Nancy;

namespace NancyPlugwise.Modules
{
    public class PlugwiseAppliancesModule: NancyModule
    {
        public PlugwiseAppliancesModule(Services.PlugwiseAppliancesService plugwiseAppliancesService)
        {
            Get["/appliances"] = parameters =>
                {
                    var appliances = new Model.PlugwiseAppliancesModel() {Appliances = plugwiseAppliancesService.FindAll()};
                    return View[appliances];
                };
        }
    }
}