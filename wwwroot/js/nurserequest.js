// "use strict";

// var connection = new signalR.HubConnectionBuilder().withUrl("/nurseRequestHub").build();

// $(function () {
// 	connection.start().then(function () {
// 		// alert('Connected to dashboardHub');

// 		InvokeNurseRequests();

// 	}).catch(function (err) {
// 		return console.error(err.toString());
// 	});
// });

// // NurseRequest
// function InvokeNurseRequests() {
// 	debugger;
// 	connection.invoke("SendNurseRequests").catch(function (err) {
// 		return console.error(err.toString());
// 	});
// }

// connection.on("ReceivedNurseRequests", function (nurseRequests) {
// 	BindNurseRequestsToGrid(nurseRequests);
// });

// function BindNurseRequestsToGrid(nurseRequests) {
// 	$('#tblNurseRequest tbody').empty();

// 	var tr;
// 	$.each(nurseRequests, function (index, nurseRequest) {
// 		tr = $('<tr/>');
// 		tr.append(`<td>${(index + 1)}</td>`);
// 		tr.append(`<td>${nurseRequest.Department}</td>`);
// 		tr.append(`<td>${nurseRequest.Remark}</td>`);
// 		tr.append(`<td>${nurseRequest.QN}</td>`);
// 		$('#tblProduct').append(tr);
// 	});
// } 