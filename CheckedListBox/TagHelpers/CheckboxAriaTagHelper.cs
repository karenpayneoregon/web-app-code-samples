namespace CheckedListBox.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

/// <summary>
/// A custom <see cref="TagHelper"/> that enhances checkbox input elements with accessibility attributes.
/// </summary>
/// <remarks>
/// This tag helper automatically adds the <c>aria-checked</c> attribute to checkbox input elements
/// based on their <c>checked</c> state, improving accessibility for assistive technologies.
///
/// Make sure to import this tag helper in _ViewImports.cshtml file:
/// </remarks>
[HtmlTargetElement("input", Attributes = "asp-for")]
public class CheckboxAriaTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!output.Attributes.TryGetAttribute("type", out var type) || type.Value.ToString() != "checkbox") return;
        
        var isChecked = output.Attributes.TryGetAttribute("checked", out var chk);
        output.Attributes.SetAttribute("aria-checked", isChecked);
    }
}
