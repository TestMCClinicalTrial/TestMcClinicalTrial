var clinic = {
	getPublisherDetails: function () {
		$.ajax({
			url: "/download/details?publisherKey=" + $("#Publishers").val(),
			//data: JSON.stringify({ "publisherKey": $("#Publishers").val() }),
			type: "GET",
			beforeSend: function (data)
			{
				$(".downloadHist").html("Loading....");
			},
			success: function (data)
			{
				console.log("Update Down Hist" + data);
				$(".downloadHist").html(data);
			}

		})
	}
}

$(document).ready(function () {
	$("#Publishers").on("change", function () {
		clinic.getPublisherDetails();
	});
});