"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

console.log("SignalR connection created.");

connection.on("ReceiveDeleteNotification", function (pointId) {
    console.log(`Received delete notification for point ID: ${pointId}`);
    const row = document.querySelector(`tr[data-point-id='${pointId}']`);
    if (row) {
        row.remove(); // Remove the row from the table
        console.log(`Removed row for point ID: ${pointId}`);
    } else {
        console.log(`No row found for point ID: ${pointId}`);
    }
});

connection.start()
    .then(() => console.log("SignalR connection started."))
    .catch(function (err) {
        console.error("Error starting SignalR connection:", err.toString());
    });