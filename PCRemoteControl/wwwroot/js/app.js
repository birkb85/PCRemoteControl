"use strict";

// Get elements
const header = document.getElementById("header");
const content = document.getElementById("content");
const footer = document.getElementById("footer");
const textInput = document.getElementById("textInput");

// Time passed
let timeStampOld = 0;
let timePassed = 0; // Time passed in millis

const controlHub = new ControlHub();
const controls = new Controls();

async function appStart(timeStamp) {
    console.log("App Starting.");

    await controlHub.connectionStart();

    window.requestAnimationFrame(appLoop);
    console.log("App Started.");
}

function appLoop(timeStamp) {
    // Time passed
    timePassed = timeStamp - timeStampOld;
    timeStampOld = timeStamp;

    appUpdate();

    window.requestAnimationFrame(appLoop);
}

function appUpdate() {
    // Update Controls
    if (controls.hasUpdate) {
        controls.hasUpdate = false;

        if (controls.mouseMoveX < 0 || controls.mouseMoveX > 0 ||
            controls.mouseMoveY < 0 || controls.mouseMoveY > 0) {
            controlHub.mouseMove(controls.mouseMoveX, controls.mouseMoveY);
            controls.mouseMoveX = 0;
            controls.mouseMoveY = 0;
        }

        if (controls.mouseLeftClicked) {
            controlHub.mouseLeftClick();
            controls.mouseLeftClicked = false;
        }

        if (controls.mouseRightClicked) {
            controlHub.mouseRightClick();
            controls.mouseRightClicked = false;
        }

        if (controls.keyboardText !== "") {
            controlHub.keyboard(controls.keyboardText);
            controls.keyboardText = "";
        }

        if (controls.keyboardBackspaceClicked) {
            controlHub.keyboardBackspace();
            controls.keyboardBackspaceClicked = false;
        }

        if (controls.keyboardEnterClicked) {
            controlHub.keyboardEnter();
            controls.keyboardEnterClicked = false;
        }

        if (controls.keyboardLeftArrowClicked) {
            controlHub.keyboardLeftArrow();
            controls.keyboardLeftArrowClicked = false;
        }

        if (controls.keyboardRightArrowClicked) {
            controlHub.keyboardRightArrow();
            controls.keyboardRightArrowClicked = false;
        }

        if (controls.keyboardPlayPauseClicked) {
            controlHub.keyboardPlayPause();
            controls.keyboardPlayPauseClicked = false;
        }

        if (controls.keyboardVolumeMuteClicked) {
            controlHub.keyboardVolumeMute();
            controls.keyboardVolumeMuteClicked = false;
        }

        if (controls.keyboardVolumeDownClicked) {
            controlHub.keyboardVolumeDown();
            controls.keyboardVolumeDownClicked = false;
        }

        if (controls.keyboardVolumeUpClicked) {
            controlHub.keyboardVolumeUp();
            controls.keyboardVolumeUpClicked = false;
        }
    }
}