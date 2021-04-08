function getRealEstateAgents(hasGarden) {

    $.ajax({
        type: "POST",
        beforeSend: function () {
        },
        url: "/RealEstateAgent/GetRealEstateAgents",
        //data hardcoded for most params for now. Only hasGarden is accessible from UI at this point
        data: { "top": 10, "city": "Amsterdam", "type": "koop", "hasGarden": hasGarden,"isForSale":true },
        success: function (data) {
            $("#agentsTable").html('');
            $("#agentsTable").html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert('Failed to retrieve data.');
        }
    });
}

