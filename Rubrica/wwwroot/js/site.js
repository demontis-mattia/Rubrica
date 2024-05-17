$(document).ready(function () {
    $('[id^=contatto-]').submit(function (event) {
        var email = $('#email').val();
        var phone = $('#phone').val();

        if (!isValidEmail(email) && email.length > 0) {
            alert("L'email inserita non è valida.");
            event.preventDefault();
            return;
        }

        if (!isValidPhoneNumber(phone) && phone.length > 0) {
            alert("Il numero di telefono inserito non è valido.");
            event.preventDefault();
            return;
        }
    });

    function isValidEmail(email) {
        var emailRegex = /^\S+@\S+\.\S+$/;
        return emailRegex.test(email);
    }

    function isValidPhoneNumber(phone) {
        var phoneRegex = /^\d{10}$/;
        return phoneRegex.test(phone);
    }
});