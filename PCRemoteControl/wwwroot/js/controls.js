"use strict";

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

        this.leftClicked = false;
        this.rightClicked = false;

        this.touchStartTime = Date.now();
        this.touchStartMouseX = 0;
        this.touchStartMouseY = 0;
        this.touchClickTimeout = 400;
        this.touchClickDist = 20;
    }

    touchStart(x, y) {
        this.mouseDown = true;

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
            this.leftClicked = true;
        }

        this.hasUpdate = true;
    }

    leftClick() {
        this.leftClicked = true;
        this.hasUpdate = true;
    }

    rightClick() {
        this.rightClicked = true;
        this.hasUpdate = true;
    }
}