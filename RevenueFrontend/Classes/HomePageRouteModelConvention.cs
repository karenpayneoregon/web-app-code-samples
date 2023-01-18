using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApplication1.Classes;

/// <summary>
/// Map ViewCategories as the home page
/// </summary>
public class HomePageRouteModelConvention : IPageRouteModelConvention
{
    public void Apply(PageRouteModel model)
    {
        if (model.RelativePath == "/Pages/Index.cshtml")
        {
            var currentHomePage = model.Selectors.Single(s => s.AttributeRouteModel!.Template == string.Empty);
            model.Selectors.Remove(currentHomePage);
        }

        if (model.RelativePath == "/Pages/ViewCategories.cshtml")
        {
            model.Selectors.Add(new SelectorModel()
            {
                AttributeRouteModel = new AttributeRouteModel
                {
                    Template = string.Empty
                }
            });
        }
    }
}