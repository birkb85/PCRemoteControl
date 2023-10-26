﻿"use strict";

class Controls {
    constructor() {
        this.hasUpdate = false;

        this.mouseDown = false;

        this.mouseX = 0;
        this.mouseY = 0;
        this.mouseOldX = 0;
        this.mouseOldY = 0;

        this.mouseMoveX = 0;
        this.mouseMoveY = 0;

        this.mouseLeftClicked = false;
        this.mouseRightClicked = false;

        this.touchStartTime = Date.now();
        this.touchStartMouseX = 0;
        this.touchStartMouseY = 0;
        this.touchClickTimeout = 400;
        this.touchClickDist = 20;

        this.keyboardText = "";
        this.keyboardBackspaceClicked = false;
        this.keyboardEnterClicked = false;
        this.keyboardLeftArrowClicked = false;
        this.keyboardRightArrowClicked = false;
        this.keyboardPlayPauseClicked = false;
        this.keyboardVolumeMuteClicked = false;
        this.keyboardVolumeDownClicked = false;
        this.keyboardVolumeUpClicked = false;
    }

    touchStart(x, y) {
        this.mouseDown = true;

        textInput.blur();

        this.mouseX = Math.round(x);
        this.mouseY = Math.round(y);
        this.mouseOldX = this.mouseX;
        this.mouseOldY = this.mouseY;

        this.touchStartTime = Date.now();
        this.touchStartMouseX = this.mouseX;
        this.touchStartMouseY = this.mouseY;

        this.hasUpdate = true;
    }

    touchMove(x, y) {
        this.mouseX = Math.round(x);
        this.mouseY = Math.round(y);
        this.mouseMoveX += this.mouseX - this.mouseOldX;
        this.mouseMoveY += this.mouseY - this.mouseOldY;
        this.mouseOldX = this.mouseX;
        this.mouseOldY = this.mouseY;

        this.hasUpdate = true;
    }

    touchEnd() {
        this.mouseDown = false;

        if (Date.now() - this.touchStartTime < this.touchClickTimeout &&
            Math.abs(this.mouseX - this.touchStartMouseX) < this.touchClickDist &&
            Math.abs(this.mouseY - this.touchStartMouseY) < this.touchClickDist) {
            this.mouseLeftClicked = true;
        }

        this.hasUpdate = true;
    }

    mouseLeftClick() {
        this.mouseLeftClicked = true;
        this.hasUpdate = true;
    }

    mouseRightClick() {
        this.mouseRightClicked = true;
        this.hasUpdate = true;
    }

    keyboardTextInput(text) {
        this.keyboardText += text;
        this.hasUpdate = true;
    }

    keyboardBackspaceClick() {
        this.keyboardBackspaceClicked = true;
        this.hasUpdate = true;
    }

    keyboardEnterClick() {
        this.keyboardEnterClicked = true;
        this.hasUpdate = true;
    }

    keyboardLeftArrowClick() {
        this.keyboardLeftArrowClicked = true;
        this.hasUpdate = true;
    }

    keyboardRightArrowClick() {
        this.keyboardRightArrowClicked = true;
        this.hasUpdate = true;
    }

    keyboardPlayPauseClick() {
        this.keyboardPlayPauseClicked = true;
        this.hasUpdate = true;
    }

    keyboardVolumeMuteClick() {
        this.keyboardVolumeMuteClicked = true;
        this.hasUpdate = true;
    }

    keyboardVolumeDownClick() {
        this.keyboardVolumeDownClicked = true;
        this.hasUpdate = true;
    }

    keyboardVolumeUpClick() {
        this.keyboardVolumeUpClicked = true;
        this.hasUpdate = true;
    }
}