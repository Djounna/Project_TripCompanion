// En construction

function WeatherFetch(lat, lon) {
    console.log(lat); console.log(lon);
    $.ajax({
        url: "https://localhost:7160/Travel/WeatherMap",
        type: "get",
        dataType: "html",
        beforeSend: function (x) {
        },
        data: { lat: lat, lon : lon },
        success: function (result) {
            console.log(result);
            const data = JSON.parse(result);
            console.log(data);
            $('#temperature').html(data.temp);
            $('#humidity').html(data.hum);
        }
    });
}