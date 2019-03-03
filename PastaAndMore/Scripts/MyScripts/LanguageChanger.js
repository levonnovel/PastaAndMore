$(() => {

	$('.lang').on('click', function(e) {
		$.ajax({
			type: "post",
			url: '/MultiLanguage/Change',
			data: { lang: $(this).attr('value') },
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