"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("ChatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (ComponentID, message) {
    var li = document.createElement("li");

    document.getElementById("messagesList").appendChild(li);
    li.textContent = `ID: ${ComponentID} ||| Text:${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    
    var ComponentID = document.getElementById("counter").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", ComponentID, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});