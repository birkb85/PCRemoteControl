"use strict";

// Window resize
function setButtonLarge(element) {
    element.classList.remove('btn-sm');
    element.classList.add('btn-lg');
}
function setButtonMedium(element) {
    element.classList.remove('btn-sm');
    element.classList.remove('btn-lg');
}
function setButtonSmall(element) {
    element.classList.add('btn-sm');
    element.classList.remove('btn-lg');
}
function onResize(width) {
    if (width >= 360) {
        setButtonLarge(leftArrowButton);
        setButtonLarge(rightArrowButton);
        setButtonLarge(playPauseButton);
        setButtonLarge(volumeMuteButton);
        setButtonLarge(volumeDownButton);
        setButtonLarge(volumeUpButton);
    } else if (width >= 324) {
        setButtonMedium(leftArrowButton);
        setButtonMedium(rightArrowButton);
        setButtonLarge(playPauseButton);
        setButtonMedium(volumeMuteButton);
        setButtonLarge(volumeDownButton);
        setButtonLarge(volumeUpButton);
    } else if (width >= 284) {
        setButtonMedium(leftArrowButton);
        setButtonMedium(rightArrowButton);
        setButtonMedium(playPauseButton);
        setButtonMedium(volumeMuteButton);
        setButtonMedium(volumeDownButton);
        setButtonMedium(volumeUpButton);
    } else if (width >= 254) {
        setButtonSmall(leftArrowButton);
        setButtonSmall(rightArrowButton);
        setButtonMedium(playPauseButton);
        setButtonSmall(volumeMuteButton);
        setButtonMedium(volumeDownButton);
        setButtonMedium(volumeUpButton);
    } else {
        setButtonSmall(leftArrowButton);
        setButtonSmall(rightArrowButton);
        setButtonSmall(playPauseButton);
        setButtonSmall(volumeMuteButton);
        setButtonSmall(volumeDownButton);
        setButtonSmall(volumeUpButton);
    }
}
function reportWindowSize() {
    let width = header.clientWidth; //window.innerWidth;
    let height = header.clientHeight; //window.innerHeight;
    onResize(width);
    //console.log("Event App Size: W: " + width + ", H: " + height);
    //touchpad.innerText = "Event App Size: W: " + width + ", H: " + height;
}
try {
    const observer = new ResizeObserver((entries) => {
        const entry = entries.find((entry) => entry.target === header);
        let width = entry.contentBoxSize[0].inlineSize; //entry.devicePixelContentBoxSize[0].inlineSize;
        let height = entry.contentBoxSize[0].blockSize; //entry.devicePixelContentBoxSize[0].blockSize;
        onResize(width);
        //console.log("Observer App Size: W: " + width + ", H: " + height);
        //touchpad.innerText = "Observer App Size: W: " + width + ", H: " + height;
    });
    observer.observe(header, { box: "device-pixel-content-box" });
} catch (error) {
    console.warn("Fallback to window resize event. ResizeObserver Error: " + error);
    usingObserver = false;
    window.addEventListener("resize", reportWindowSize);
    reportWindowSize();
}

// Text Input
function textInputKeyup(event) {
    /*let value = event.target.value;*/

    if (event.keyCode == 8) {
        // Backspace
        controls.keyboardBackspaceClick();
    } else if (event.keyCode == 13) {
        // Enter
        controls.keyboardEnterClick();
        textInput.value = "";
    } else {
        //controls.keyboardTextInput(event.target.value);
        controls.keyboardTextInput(event.key);
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