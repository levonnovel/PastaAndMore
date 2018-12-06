$(() => {
	$('#AddProd').on('click', () => {
		var obj = { product: $('#productName').val(), desc: $('#productDesc').val(), cat: $('#Cats').val() }
		console.log(obj);
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'AddProduct',
			data: jsonObj,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data, status) {
			alert(data);
		}

		function errorFunc() {
			alert('error');
		}
	})

	$('#AddCat').on('click', () => {
		var obj = { name: $('#catName').val(), desc: $('#catDesc').val() }
		console.log(obj);
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'AddCategory',
			data: jsonObj,
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: successFunc,
			error: errorFunc
		});

		function successFunc(data, status) {
			alert(data);
		}

		function errorFunc() {
			alert('error1');
		}
	})

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
			alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			}
		}

		function errorFunc(data) {
			//window.location.href = "/User/Home";
			//alert(data.responseText);
		}
	})
})

