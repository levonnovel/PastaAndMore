$(() => {
	$('#AddProduct').on('click', () => {
		var obj = {
			name: $('#productName').val(),
			desc: $('#productDesc').val(),
			price: $('#productPrice').val(), 
			path: $('#productImgPath').val(),
			cat: $('#Cats').val()
		}
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
			alert(data.responseText);
			if (data.success) {
				location.reload();
			}
		}

		function errorFunc() {
			alert('error');
		}
	})

	$('#AddCategory').on('click', () => {
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
			alert(data.responseText);
			if (data.success) {
				location.reload();
			}
		}

		function errorFunc() {
			alert('error1');
		}
	})

    console.log($('#table_id'));
    $('#table_id').DataTable();


	$('.updateProduct').on('click', (e) => {
		var product = $(e.target).parent().parent().children();

		var obj = {
			id: $(product[0]).text(),
			name: $(product[1]).text(),
			desc: $(product[2]).text(),
			price: $(product[3]).text(),
			path: $(product[4]).text(),
			catName: $(product[5]).find("select").val()
		}
	
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'UpdateProduct',
			data: jsonObj,
			contentType: 'application/json; charset=utf-8',
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

		function errorFunc(data, status) {
			alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			}
		}
	})

	$('.deleteProduct').on('click', (e) => {
		var product = $(e.target).parent().parent().children();
		var id = $(product[0]).text();
		//var name = $(product[1]).text();
		//var desc = $(product[2]).text();
		//var cat = $(product[3]).text();
		//console.log(name, desc, cat);
		//var obj = { id: id, name: name, desc: desc, catName: cat };
		var obj = { id: id }
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'DeleteProduct',
			data: jsonObj,
			contentType: 'application/json; charset=utf-8',
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

		function errorFunc(data, status) {
			alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			}
		}
	})

	$('.updateCategory').on('click', (e) => {
		var product = $(e.target).parent().parent().children();
		var id = $(product[0]).text();
		var name = $(product[1]).text();
		var desc = $(product[2]).text();
		var obj = { id: id, name: name, desc: desc };
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'UpdateCategory',
			data: jsonObj,
			contentType: 'application/json; charset=utf-8',
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

		function errorFunc(data, status) {
			alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			}
		}
	})

	$('.deleteCategory').on('click', (e) => {
		var product = $(e.target).parent().parent().children();
		var id = $(product[0]).text();
		//var name = $(product[1]).text();
		//var desc = $(product[2]).text();
		//var cat = $(product[3]).text();
		//console.log(name, desc, cat);
		//var obj = { id: id, name: name, desc: desc, catName: cat };
		var obj = { id: id }
		var jsonObj = JSON.stringify(obj);
		console.log(jsonObj);

		$.ajax({
			type: "POST",
			url: 'DeleteCategory',
			data: jsonObj,
			contentType: 'application/json; charset=utf-8',
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

		function errorFunc(data, status) {
			alert(data.responseText);
			if (data.success) {
				location.href = "/Admin/Index";
			}
		}
	})
})

