﻿"use strict";

// Get elements
const header = document.getElementById("header");
const content = document.getElementById("content");
const footer = document.getElementById("footer");

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
    }
}