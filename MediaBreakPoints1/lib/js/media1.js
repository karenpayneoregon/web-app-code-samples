function getFontSize() {
    const para1 = document.getElementById('p1');
    const style = window.getComputedStyle(para1, null).getPropertyValue('font-size');
    const fontSize = parseFloat(style);
    console.log(fontSize);
}

function displayWindowSize() {
    // Get width and height of the window excluding scrollbars
    var w = document.documentElement.clientWidth;
    var h = document.documentElement.clientHeight;

    // Display result inside a div element
    document.getElementById("result").innerHTML = `Width: ${w}, Height: ${h}`;
}