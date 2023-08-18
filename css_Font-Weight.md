
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

**Output**

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