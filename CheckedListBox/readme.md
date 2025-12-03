# About

Demonstrates creating a `CheckedListBox` for Razor Pages

TODO: Change to work with a database

![Screenshot](assets/screenshot.png)


## Index1

Uses the following JavaScript code to toggle `aria-checked` attribute on list items when clicked will toggle true/false.

```javascript
@section Scripts {
    <script>
        document.addEventListener("DOMContentLoaded", () => {

            document.querySelectorAll("input.js-aria-checkbox[type='checkbox']").forEach(function (cb) {

                    // Set initial aria-checked based on current checked state
                    cb.setAttribute("aria-checked", cb.checked ? "true" : "false");

                    // Update aria-checked whenever the checkbox changes
                    cb.addEventListener("change", function () {
                        this.setAttribute("aria-checked", this.checked ? "true" : "false");
                    });
                });

        });
    </script>
}
```

### CheckboxAriaTagHelper.cs

```csharp
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
```
