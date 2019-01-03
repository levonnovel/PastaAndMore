$(() => {
	$('#adminLogIn').on('click', () => {
		var obj = { logIn: $('#logIn').val(), password: $('#password').val() }
		console.log(obj);
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'Authorise',
			data: jsonObj,
			contentType: 'application/json; charset=utf-8',
			dataType: "json",
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data, status) {
			//alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			} else {
				$('#invalidLogin').show();
			}
		}

		function errorFunc(data) {
			//window.location.href = "/User/Home";
			//alert(data.responseText);
		}
	})
})