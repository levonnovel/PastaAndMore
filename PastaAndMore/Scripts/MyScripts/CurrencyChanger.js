$(() => {

	$('.currency').on('click', (e) => {
		$.ajax({
			type: "post",
			url: '/Currency/Change',
			data: { currency: $(e.target).text() },
			contenttype: 'application/json; charset=utf-8',
			datatype: "json",
			success: successfunc,
		});
		function successfunc(data) {
			//alert(data.responseText);
			if (data.success) {
				location.reload();
			}
		}
	})
})