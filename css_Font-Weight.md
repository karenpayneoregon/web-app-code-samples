
https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight

## Accessibility concerns

People experiencing low vision conditions may have difficulty reading text set with a font-weight value of 100 (Thin/Hairline) or 200 (Extra Light), especially if the font has a low contrast color ratio.

```html
<div class="mt-5">
    <p style="font-weight: 100">Good day to you</p>
    <p style="font-weight: 200">Good day to you</p>
    <p style="font-weight: 400">Good day to you</p>
    <p style="font-weight: 500">Good day to you</p>
    <p style="font-weight: 600">Good day to you</p>
    <p style="font-weight: 700">Good day to you</p>
    <p style="font-weight: 800">Good day to you</p>
    <p style="font-weight: 900">Good day to you</p>
</div>
```

<div style='margin-top:4em'>
<h1>Output</h1>
</div>
<div>
    <p style="font-weight: 100">Good day to you</p>
    <p style="font-weight: 200">Good day to you</p>
    <p style="font-weight: 400">Good day to you</p>
    <p style="font-weight: 500">Good day to you</p>
    <p style="font-weight: 600">Good day to you</p>
    <p style="font-weight: 700">Good day to you</p>
    <p style="font-weight: 800">Good day to you</p>
    <p style="font-weight: 900">Good day to you</p>
</div>


<table>
  <thead>
    <tr>
      <th>Value</th>
      <th>Common weight name</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>100</td>
      <td>Thin (Hairline)</td>
    </tr>
    <tr>
      <td>200</td>
      <td>Extra Light (Ultra Light)</td>
    </tr>
    <tr>
      <td>300</td>
      <td>Light</td>
    </tr>
    <tr>
      <td>400</td>
      <td>Normal (Regular)</td>
    </tr>
    <tr>
      <td>500</td>
      <td>Medium</td>
    </tr>
    <tr>
      <td>600</td>
      <td>Semi Bold (Demi Bold)</td>
    </tr>
    <tr>
      <td>700</td>
      <td>Bold</td>
    </tr>
    <tr>
      <td>800</td>
      <td>Extra Bold (Ultra Bold)</td>
    </tr>
    <tr>
      <td>900</td>
      <td>Black (Heavy)</td>
    </tr>
    <tr>
      <td>950</td>
      <td><a href="https://docs.microsoft.com/dotnet/api/system.windows.fontweights?view=netframework-4.8#remarks" class="external" target="_blank">Extra Black (Ultra Black)</a></td>
    </tr>
  </tbody>
</table>
