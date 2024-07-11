"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
	connection.start().then(function () {
		// alert('Connected to dashboardHub');

		InvokeProducts();
		InvokeNurseRequests();

	}).catch(function (err) {
		return console.error(err.toString());
	});
});

// Product
function InvokeProducts() {
	debugger;
	connection.invoke("SendProducts").catch(function (err) {
		return console.error(err.toString());
	});
}


connection.on("ReceivedProducts", function (products) {
	BindProductsToGrid(products);
});

function BindProductsToGrid(products) {
	$('#tblProduct tbody').empty();

	var tr;
	$.each(products, function (index, product) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${product.name}</td>`);
		tr.append(`<td>${product.category}</td>`);
		tr.append(`<td>${product.price}</td>`);
		tr.append(`<td><a href="View/${product.Id}></a></td>`);
		$('#tblProduct').append(tr);
	});
}

// NurseRequest
function InvokeNurseRequests() {
	debugger;
	connection.invoke("SendNurseRequests").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedNurseRequests", function (nurseRequests) {
	BindNurseRequestsToGrid(nurseRequests);
});

function BindNurseRequestsToGrid(nurseRequests) {
	$('#tblNurseRequest').empty();

	var tr;
	$.each(nurseRequests, function (index, nurseRequest) {
		tr = $('<tr/>');
		tr.append(`<td>${(index +1)}</td>`);
		tr.append(`<td>${nurseRequest.qn}</td>`);
		tr.append(`<td>${nurseRequest.qnName}</td>`);
		tr.append(`<td>${nurseRequest.startPoint}</td>`);
		tr.append(`<td>${nurseRequest.endPoint}</td>`);
		tr.append(`<td>${nurseRequest.patientType}</td>`);
		tr.append(`<td>${nurseRequest.poterFname}</td>`);
		tr.append(`<td>${nurseRequest.materialType}</td>`);
		tr.append(`<td>${nurseRequest.urentType}</td>`);
		tr.append(`<td>${nurseRequest.remark}</td>`);
		$('#tblNurseRequest').append(tr);
	});
}


// var backgroundColors = [
// 	'rgba(255, 99, 132, 0.2)',
// 	'rgba(54, 162, 235, 0.2)',
// 	'rgba(255, 206, 86, 0.2)',
// 	'rgba(75, 192, 192, 0.2)',
// 	'rgba(153, 102, 255, 0.2)',
// 	'rgba(255, 159, 64, 0.2)'
// ];
// var borderColors = [
// 	'rgba(255, 99, 132, 1)',
// 	'rgba(54, 162, 235, 1)',
// 	'rgba(255, 206, 86, 1)',
// 	'rgba(75, 192, 192, 1)',
// 	'rgba(153, 102, 255, 1)',
// 	'rgba(255, 159, 64, 1)'
// ];