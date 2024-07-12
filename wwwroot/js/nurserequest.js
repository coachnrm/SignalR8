// "use strict";

// var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

// $(function () {
//  	connection.start().then(function () {
// 		 alert('Connected to dashboardHub');

//  		InvokeNurseRequests();

//  	}).catch(function (err) {
//  		return console.error(err.toString());
//  	});
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
// 	$('#tblNurseRequest').empty();

// 	var tr;
// 	$.each(nurseRequests, function (index, nurseRequest) {
// 		tr = $('<tr/>');
// 		tr.append(`<td>${(index +1)}</td>`);
// 		tr.append(`<td>${nurseRequest.qn}</td>`);
// 		tr.append(`<td>${nurseRequest.qnName}</td>`);
// 		tr.append(`<td>${nurseRequest.startPoint}</td>`);
// 		tr.append(`<td>${nurseRequest.endPoint}</td>`);
// 		tr.append(`<td>${nurseRequest.patientType}</td>`);
// 		tr.append(`<td>${nurseRequest.poterFname}</td>`);
// 		tr.append(`<td>${nurseRequest.materialType}</td>`);
// 		tr.append(`<td>${nurseRequest.urentType}</td>`);
// 		tr.append(`<td>${nurseRequest.remark}</td>`);
// 		$('#tblNurseRequest').append(tr);
// 	});
// }