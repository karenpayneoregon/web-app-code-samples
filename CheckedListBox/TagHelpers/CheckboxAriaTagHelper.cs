namespace CheckedListBox.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("input", Attributes = "asp-for")]
public class CheckboxAriaTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (output.Attributes.TryGetAttribute("type", out var type) &&
            type.Value.ToString() == "checkbox")
        {
            var isChecked = output.Attributes.TryGetAttribute("checked", out var chk);
            output.Attributes.SetAttribute("aria-checked", isChecked);
        }
    }
}
