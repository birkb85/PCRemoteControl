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
    }

    touchStart(x, y) {
        this.mouseDown = true;

        this.mouseX = Math.round(x);
        this.mouseY = Math.round(y);
        this.mouseOldX = this.mouseX;
        this.mouseOldY = this.mouseY;

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