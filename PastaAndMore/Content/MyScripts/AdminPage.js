$(() => {
	$('#Add').on('click', () => {
		var obj = { product: $('#productName').val(), desc: $('#productDesc').val(), cat: $('#Cats').val()}
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
})

