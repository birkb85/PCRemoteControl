"use strict";

// Text Input
function textInputKeyup(event) {
    /*let value = event.target.value;*/

    if (event.keyCode == 8) {
        // Backspace
        controls.keyboardBackspaceClick();
    } else if (event.keyCode == 13) {
        // Enter
        controls.keyboardEnterClick();
    } else {
        controls.keyboardTextInput(event.target.value);
        textInput.value = "";
    }

    //console.log("Key Up: " + event.keyCode);
}
textInput.onkeyup = textInputKeyup;

// Mouse
function mouseDownEvent(event) {
    if (event.type === "mousedown") {
        if (event.target.id === "touchpad") {
            controls.touchStart(event.clientX, event.clientY, true);
        } else if (event.target.id === "scrollpad") {
            controls.touchStart(event.clientX, event.clientY, false);
        }
    }
}
function mouseMoveEvent(event) {
    if (event.type === "mousemove") {
        controls.touchMove(event.clientX, event.clientY);
    }
}
function mouseUpEvent(event) {
    if (event.type === "mouseup") {
        controls.touchEnd();
    }
}
document.addEventListener("mousedown", mouseDownEvent);
document.addEventListener("mousemove", mouseMoveEvent);
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
        controls.touchStart(x, y, true);
        event.preventDefault();
    }
}
function scrollStartHandler(event) {
    //touches++;
    if (event.touches) {
        let x = event.touches[0].pageX;
        let y = event.touches[0].pageY;
        //debugLabel.innerText = "Touch Start: " + touches + ", pos:  x: " + x + ", y: " + y;
        //console.log("Touch Start: " + touches + ", pos:  x: " + x + ", y: " + y);
        controls.touchStart(x, y, false);
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
touchpad.addEventListener("touchstart", touchStartHandler, { passive: false });
touchpad.addEventListener("touchmove", touchMoveHandler, { passive: false });
touchpad.addEventListener("touchend", touchEndHandler, { passive: false });
//document.addEventListener("touchcancel", touchCancelHandler, {passive:false});
scrollpad.addEventListener("touchstart", scrollStartHandler, { passive: false });
scrollpad.addEventListener("touchmove", touchMoveHandler, { passive: false });
scrollpad.addEventListener("touchend", touchEndHandler, { passive: false });
//document.addEventListener("touchcancel", touchCancelHandler, {passive:false});

// Start app after page load
document.addEventListener("DOMContentLoaded", () => {
    window.requestAnimationFrame(appStart);
});
//window.addEventListener('load', () => {
//    window.requestAnimationFrame(appStart);
//});