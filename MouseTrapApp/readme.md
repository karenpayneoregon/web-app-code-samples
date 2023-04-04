# About MouseTrap


Mousetrap is a standalone library to create hot-keys

:open_book: [documentation](https://craig.is/killing/mice)

See `wwwroot/js/Application,js`

Page setup

```html
@section Scripts
    {
    <script>
        $(document).ready(function (e) {
            $Application.setKeys();
        });
        window.addEventListener('beforeunload', (event) => {
            $Application.removeKeys();
        });
    </script>
}
```

