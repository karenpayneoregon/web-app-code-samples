# About

- Detect if a [browser in a mobile device](https://stackoverflow.com/questions/14942081/detect-if-a-browser-in-a-mobile-device-ios-android-phone-tablet-is-used) (iOS/Android phone/tablet) is used


- [Source](https://stackoverflow.com/a/7354648/5509738) for below

```css
@media (min-width:320px)  { /* smartphones, iPhone, portrait 480x320 phones */ }
@media (min-width:481px)  { /* portrait e-readers (Nook/Kindle), smaller tablets @ 600 or @ 640 wide. */ }
@media (min-width:641px)  { /* portrait tablets, portrait iPad, landscape e-readers, landscape 800x480 or 854x480 phones */ }
@media (min-width:961px)  { /* tablet, landscape iPad, lo-res laptops ands desktops */ }
@media (min-width:1025px) { /* big landscape tablets, laptops, and desktops */ }
@media (min-width:1281px) { /* hi-res laptops and desktops */ }
```

- [debugging piece of code](https://stackoverflow.com/a/19473877/5509738) right after your media query

```css
@media only screen and (min-width: 769px) and (max-width: 1281px) { 
  /* for 10 inches tablet screens */
  body::before {
    content: "tablet to some desktop media query (769 > 1281) fired";
    font-weight: bold;
    display: block;
    text-align: center;
    background: rgba(255, 255, 0, 0.9); /* Semi-transparent yellow */
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    z-index: 99;
  }
} 
```

 1. Extra small devices (phones, up to 480px) 
 2. Small devices (tablets, 768px and up) 
 3. Medium devices (big landscape tablets, laptops, and
    desktops, 992px and up) 
 4. Large devices (large desktops, 1200px and  up)  
 5. portrait e-readers (Nook/Kindle), smaller tablets -    min-width:481px 
 6. portrait tablets, portrait iPad, landscape e-readers   - min-width:641px 
 7. tablet, landscape iPad, lo-res laptops - min-width:961px
 8. HTC One   	device-width: 360px device-height: 640px    -webkit-device-pixel-ratio: 3
 9. Samsung Galaxy S2   	device-width: 320px device-height: 534px -webkit-device-pixel-ratio: 1.5     (min--moz-device-pixel-ratio: 1.5), (-o-min-device-pixel-ratio:
    3/2), (min-device-pixel-ratio: 1.5  
 10. Samsung Galaxy S3 	device-width: 320px device-height: 640px    -webkit-device-pixel-ratio: 2  (min--moz-device-pixel-ratio: 2),     - Older Firefox browsers (prior to Firefox 16) -  
 11. Samsung Galaxy S4  device-width: 320px device-height: 640px   -webkit-device-pixel-ratio: 3  
 12. LG Nexus 4  device-width: 384px device-height: 592px -webkit-device-pixel-ratio: 2  
 13. Asus Nexus 7   device-width: 601px device-height: 906px
    -webkit-min-device-pixel-ratio: 1.331) and (-webkit-max-device-pixel-ratio: 1.332)
 14. iPad 1 and 2, iPad Mini   device-width: 768px device-height: 1024px   -webkit-device-pixel-ratio: 1  
 15. iPad 3 and 4 device-width: 768px device-height: 1024px -webkit-device-pixel-ratio: 2) 
 16. iPhone 3G  device-width: 320px device-height: 480px   -webkit-device-pixel-ratio: 1) 
 17. iPhone 4  	device-width: 320px device-height: 480px -webkit-device-pixel-ratio: 2) 
 18. iPhone 5   device-width: 320px device-height: 568px -webkit-device-pixel-ratio: 2)