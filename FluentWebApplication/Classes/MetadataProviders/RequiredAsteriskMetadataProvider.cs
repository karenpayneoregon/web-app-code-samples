using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.ComponentModel.DataAnnotations;

namespace FluentWebApplication.Classes.MetadataProviders;

public sealed class RequiredAsteriskMetadataProvider : IDisplayMetadataProvider
{
    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        if (context.Key.MetadataKind != ModelMetadataKind.Property)
            return;

        // Skip collection/indexer (table header) scenarios
        if (context.Key.Name!.Contains('[')) return;

        var attrs = context.Attributes;

        bool hasRequired = attrs.Any(x =>
        {
            if (x is RequiredAttribute) return true;
            return x.GetType().FullName == "System.Runtime.CompilerServices.RequiredMemberAttribute";
        });

        if (!hasRequired) return;

        // Respect existing display names
        var original = context.DisplayMetadata.DisplayName?.Invoke() ?? context.Key.Name;

        context.DisplayMetadata.DisplayName = () => $"{original} *";
    }
}