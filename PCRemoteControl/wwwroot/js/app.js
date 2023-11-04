"use strict";

// Get elements
const header = document.getElementById("header");
const leftArrowButton = document.getElementById("leftArrowButton");
const rightArrowButton = document.getElementById("rightArrowButton");
const playPauseButton = document.getElementById("playPauseButton");
const volumeMuteButton = document.getElementById("volumeMuteButton");
const volumeDownButton = document.getElementById("volumeDownButton");
const volumeUpButton = document.getElementById("volumeUpButton");
const content = document.getElementById("content");
const footer = document.getElementById("footer");
const textInput = document.getElementById("textInput");
const touchpad = document.getElementById("touchpad");
const scrollpad = document.getElementById("scrollpad");

// Window Resize
let usingObserver = true;

// Time passed
let timeStampOld = 0;
let timePassed = 0; // Time passed in millis

const controlHub = new ControlHub();
const controls = new Controls();

async function appStart(timeStamp) {
    console.log("App Starting.");

    await controlHub.connectionStart();

    if (!usingObserver) {
        reportWindowSize(); // As fallback for observer report after loading stuff.
    }

    window.requestAnimationFrame(appLoop);
    console.log("App Started.");
}

async function appLoop(timeStamp) {
    // Time passed
    timePassed = timeStamp - timeStampOld;
    timeStampOld = timeStamp;

    await appUpdate();

    window.requestAnimationFrame(appLoop);
}

async function appUpdate() {
    // Update Controls
    if (controls.hasUpdate) {
        controls.hasUpdate = false;

        if (controls.isTouchpad) {
            if (controls.mouseMoveX < 0 || controls.mouseMoveX > 0 ||
                controls.mouseMoveY < 0 || controls.mouseMoveY > 0) {
                await controlHub.mouseMove(controls.mouseMoveX, controls.mouseMoveY);
                controls.mouseMoveX = 0;
                controls.mouseMoveY = 0;
            }
        } else {
            if (controls.mouseMoveY < 0 || controls.mouseMoveY > 0) {
                await controlHub.mouseScrollVertical(Math.round(controls.mouseMoveY));
                controls.scrollTrail = controls.mouseMoveY;
                controls.mouseMoveY = 0;
            }
        }

        if (!controls.mouseDown && (controls.scrollTrail < -1 || controls.scrollTrail > 1)) {
            await controlHub.mouseScrollVertical(Math.round(controls.scrollTrail));
            controls.scrollTrail = controls.scrollTrail * 0.95;
            controls.hasUpdate = true;
        }

        if (controls.mouseLeftClicked) {
            await controlHub.mouseLeftClick();
            controls.mouseLeftClicked = false;
        }

        if (controls.mouseRightClicked) {
            await controlHub.mouseRightClick();
            controls.mouseRightClicked = false;
        }

        if (controls.keyboardText !== "") {
            await controlHub.keyboard(controls.keyboardText);
            controls.keyboardText = "";
        }

        if (controls.keyboardBackspaceClicked) {
            await controlHub.keyboardBackspace();
            controls.keyboardBackspaceClicked = false;
        }

        if (controls.keyboardEnterClicked) {
            await controlHub.keyboardEnter();
            controls.keyboardEnterClicked = false;
        }

        if (controls.keyboardLeftArrowClicked) {
            await controlHub.keyboardLeftArrow();
            controls.keyboardLeftArrowClicked = false;
        }

        if (controls.keyboardRightArrowClicked) {
            await controlHub.keyboardRightArrow();
            controls.keyboardRightArrowClicked = false;
        }

        if (controls.keyboardPlayPauseClicked) {
            await controlHub.keyboardPlayPause();
            controls.keyboardPlayPauseClicked = false;
        }

        if (controls.keyboardVolumeMuteClicked) {
            await controlHub.keyboardVolumeMute();
            controls.keyboardVolumeMuteClicked = false;
        }

        if (controls.keyboardVolumeDownClicked) {
            await controlHub.keyboardVolumeDown();
            controls.keyboardVolumeDownClicked = false;
        }

        if (controls.keyboardVolumeUpClicked) {
            await controlHub.keyboardVolumeUp();
            controls.keyboardVolumeUpClicked = false;
        }

        if (controls.keyboardEscapeClicked) {
            await controlHub.keyboardEscape();
            controls.keyboardEscapeClicked = false;
        }
    }
}

function clearTextInput() {
    textInput.value = "";
}