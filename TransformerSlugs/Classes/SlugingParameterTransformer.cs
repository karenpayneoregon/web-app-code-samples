using System.Text.RegularExpressions;
#pragma warning disable CS8603
#pragma warning disable CS8767

namespace TransformerSlugs.Classes;

public class SlugingParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value is null) { return null; }
        return Regex.Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}