using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

#pragma warning disable CS8603
#pragma warning disable CS8767

namespace RazorLibrary.Classes;

/// <summary>
/// services.AddMvc().AddRazorPagesOptions(options => { options.Conventions.Add(new PageRouteTransformerConvention(new SlugingParameterTransformer())); });
/// </summary>
public class SlugingParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value is null) { return null; }
        return Regex.Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}