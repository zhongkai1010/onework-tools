using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace dynamic_asp_net_core.Server
{
    public class DynamicWebApiConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                Type type1 = typeof(UserApplication);
                Type type2 = controller.ControllerType;
                if (type1 == type2)
                {
                    Console.WriteLine(controller.ControllerName);
                    controller.ApiExplorer.IsVisible = true;
                    foreach (var action in controller.Actions)
                    {
                        action.ApiExplorer.IsVisible = true;
                        if (action.Selectors.Any())
                        {
                            if (action.Selectors[0].AttributeRouteModel == null)
                            {
                                string url = $"{controller.ControllerName}/{action.ActionName}".Replace("//", "/");
                                RouteAttribute routeAttribute = new RouteAttribute(url);
                                AttributeRouteModel attributeRouteModel = new AttributeRouteModel(routeAttribute);
                                action.Selectors[0].AttributeRouteModel = attributeRouteModel;
                            }

                            action.Selectors[0].ActionConstraints.Add(new HttpMethodActionConstraint(new []{ "Get" }));

                            action.Selectors[0].EndpointMetadata.Add(new HttpGetAttribute());
                        }
                    }
                }
            }
        }
    }
}
