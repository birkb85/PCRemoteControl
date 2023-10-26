// SignalR:
// https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-7.0&tabs=visual-studio

"use strict";

// Server Events
const CONTROLHUB_MOUSE_MOVE = "MouseMove";
const CONTROLHUB_MOUSE_LEFT_CLICK = "MouseLeftClick";
const CONTROLHUB_MOUSE_RIGHT_CLICK = "MouseRightClick";
const CONTROLHUB_MOUSE_SCROLL_VERTICAL = "MouseScrollVertical";
const CONTROLHUB_MOUSE_SCROLL_HORIZONTAL = "MouseScrollHorizontal";

class ControlHub {
    constructor() {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/controlhub")
            .configureLogging(signalR.LogLevel.Warning) // Trace, Information, Warning, Error
            .build();

        this.connection.onclose(async () => {
            await this.connectionStart();
        });
    }

    async connectionStart() {
        try {
            await this.connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(this.connectionStart, 5000);
        }
    };

    mouseMove(amountX, amountY) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_MOVE, amountX, amountY).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }

    mouseLeftClick() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_LEFT_CLICK).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }

    mouseRightClick() {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_RIGHT_CLICK).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }

    mouseScrollVertical(amount) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_SCROLL_VERTICAL, amount).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }

    mouseScrollHorizontal(amount) {
        if (this.connection.state === signalR.HubConnectionState.Connected) {
            this.connection.invoke(CONTROLHUB_MOUSE_SCROLL_HORIZONTAL, amount).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
}