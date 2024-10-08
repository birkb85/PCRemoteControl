﻿// SignalR:
// https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-7.0&tabs=visual-studio

"use strict";

// Server Events
const CONTROLHUB_MOUSE_MOVE = "MouseMove";
const CONTROLHUB_MOUSE_LEFT_CLICK = "MouseLeftClick";
const CONTROLHUB_MOUSE_RIGHT_CLICK = "MouseRightClick";
const CONTROLHUB_MOUSE_SCROLL_VERTICAL = "MouseScrollVertical";
const CONTROLHUB_MOUSE_SCROLL_HORIZONTAL = "MouseScrollHorizontal";
const CONTROLHUB_KEYBOARD = "Keyboard";
const CONTROLHUB_KEYBOARD_BACKSPACE = "KeyboardBackspace";
const CONTROLHUB_KEYBOARD_ENTER = "KeyboardEnter";
const CONTROLHUB_KEYBOARD_LEFT_ARROW = "KeyboardLeftArrow";
const CONTROLHUB_KEYBOARD_RIGHT_ARROW = "KeyboardRightArrow";
const CONTROLHUB_KEYBOARD_PLAY_PAUSE = "KeyboardPlayPause";
const CONTROLHUB_KEYBOARD_VOLUME_MUTE = "KeyboardVolumeMute";
const CONTROLHUB_KEYBOARD_VOLUME_DOWN = "KeyboardVolumeDown";
const CONTROLHUB_KEYBOARD_VOLUME_UP = "KeyboardVolumeUp";
const CONTROLHUB_KEYBOARD_ESCAPE = "KeyboardEscape";

class ControlHub {
    constructor() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/controlhub")
            .configureLogging(signalR.LogLevel.Warning) // Trace, Information, Warning, Error
            .build();

        this.connection.onclose(async () => {
            console.log("SignalR Connection Closed.");
            //await this.connectionStart();
        });
    }

    async connectionStart() {
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            //setTimeout(this.connectionStart, 5000);
        }
    };

    async mouseMove(amountX, amountY) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_MOVE, amountX, amountY).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async mouseLeftClick() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_LEFT_CLICK).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async mouseRightClick() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_RIGHT_CLICK).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async mouseScrollVertical(amount) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_SCROLL_VERTICAL, amount).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async mouseScrollHorizontal(amount) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_SCROLL_HORIZONTAL, amount).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboard(text) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD, text).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardBackspace() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_BACKSPACE).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardEnter() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_ENTER).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardLeftArrow() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_LEFT_ARROW).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardRightArrow() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_RIGHT_ARROW).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardPlayPause() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_PLAY_PAUSE).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardVolumeMute() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_VOLUME_MUTE).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardVolumeDown() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_VOLUME_DOWN).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardVolumeUp() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_VOLUME_UP).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }

    async keyboardEscape() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_KEYBOARD_ESCAPE).catch(function (err) {
                return console.error(err.toString());
            });
        } else if (this.connection.state === signalR.HubConnectionState.Disconnected) {
            await this.connectionStart();
        }
    }
}