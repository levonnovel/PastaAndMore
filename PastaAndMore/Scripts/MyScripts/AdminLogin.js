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

// Get the input field
var input = document.getElementById("password");

// Execute a function when the user releases a key on the keyboard
input.addEventListener("keyup", function (event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        // Trigger the button element with a click
        document.getElementById("adminLogIn").click();
    }
});