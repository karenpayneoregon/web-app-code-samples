namespace TransformerSlugs.Classes;

#pragma warning disable CS8603, CS8767
public class SlugParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value) => value?.ToString()!.ToSlug();
}