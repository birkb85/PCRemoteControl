"use strict";

// Text Input
function textInputKeyup(event) {
    /*let value = event.target.value;*/
    if (event.keyCode == 13) {
        controls.keyboardTextInput(textInput.value);
        textInput.value = "";
    }
    //console.log("Key Up: " + event.keyCode);
}
textInput.onkeyup = textInputKeyup;

// Mouse
function mouseMoveEvent(event) {
    if (event.type === "mousemove" && event.target.id === "content") {
        controls.touchMove(event.clientX, event.clientY);
    }
}
function mouseDownEvent(event) {
    if (event.type === "mousedown" && event.target.id === "content") {
        controls.touchMove(event.clientX, event.clientY);
    }
}
function mouseUpEvent(event) {
    if (event.type === "mouseup") {
        controls.touchEnd();
    }
}
document.addEventListener("mousemove", mouseMoveEvent);
document.addEventListener("mousedown", mouseDownEvent);
document.addEventListener("mouseup", mouseUpEvent);

// Touch
// https://developer.mozilla.org/en-US/docs/Games/Techniques/Control_mechanisms/Mobile_touch
//let touches = 0;
function touchStartHandler(event) {
    //touches++;
    if (event.touches) {
        let x = event.touches[0].pageX;
        let y = event.touches[0].pageY;
        //debugLabel.innerText = "Touch Start: " + touches + ", pos:  x: " + x + ", y: " + y;
        //console.log("Touch Start: " + touches + ", pos:  x: " + x + ", y: " + y);
        controls.touchStart(x, y);
        event.preventDefault();
    }
}
function touchMoveHandler(event) {
    //touches++;
    if (event.touches) {
        let x = event.touches[0].pageX;
        let y = event.touches[0].pageY;
        //debugLabel.innerText = "Touch Move: " + touches + ", pos:  x: " + x + ", y: " + y;
        //console.log("Touch Move: " + touches + ", pos:  x: " + x + ", y: " + y);
        controls.touchMove(x, y);
        event.preventDefault();
    }
}
function touchEndHandler(event) {
    //touches++;
    //debugLabel.innerText = "Touch End: " + touches;
    //console.log("Touch End: " + touches);
    controls.touchEnd();
    event.preventDefault();
}
//function touchCancelHandler(event) {
//    touches++;
//    debugLabel.innerText = "Touch Cancel: " + touches;
//    console.log("Touch Cancel: " + touches);
//    event.preventDefault();
//}
content.addEventListener("touchstart", touchStartHandler, { passive: false });
content.addEventListener("touchmove", touchMoveHandler, { passive: false });
content.addEventListener("touchend", touchEndHandler, { passive: false });
//document.addEventListener("touchcancel", touchCancelHandler, {passive:false});

// Start app after page load
document.addEventListener("DOMContentLoaded", () => {
    window.requestAnimationFrame(appStart);
});
//window.addEventListener('load', () => {
//    window.requestAnimationFrame(appStart);
//});