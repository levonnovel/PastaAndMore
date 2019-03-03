$(() => {

	$('#sendOpinion').on('click', () => {
		alert(1);
		var obj = {
			name: $('#customerName').val(),
			email: $('#customerEmail').val(),
			country: $('#customerCountry').val(),
			comments: $('#customerComments').val(),
		}
		console.log(obj);
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: '/Admin/AddOpinion',
			data: jsonObj,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data, status) {
			alert(data.responseText);
			if (data.success) {
				location.reload();
			}
		}

		function errorFunc() {
			alert('error');
		}
	})
})