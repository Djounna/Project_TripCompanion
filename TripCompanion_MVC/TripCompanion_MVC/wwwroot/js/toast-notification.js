// ToastR Script

$(document).ready(function () {
    var message = $("#message").text();
    if (message !== "") {
        if (message.includes("Info", 0)) {
            toastr.info(message, "Information");
        }
        else if (message.includes("Success", 0)) {
            toastr.success(message, "Success");
        }

        else if (message.includes("Warning", 0)) {
            toastr.warning(message, "Warning");
        }

        else if (message.includes("Error", 0)) {
            toastr.error(message, "Error");
        }
    }

});