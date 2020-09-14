$(function() {

    $('#cardnumber').on("keyup", function () {



        if ($.payform.validateCardNumber(cardNumber.val()) == false) {
            $("#Card-Error").show()
            visa.removeClass("noFilter");
            mastercard.removeClass("noFilter");

        } else {
            $("#Card-Error").hide()
        }

        debugger;


        if ($.payform.parseCardType(cardNumber.val()) == 'visa') {
            visa.addClass("noFilter");
            mastercard.removeClass("noFilter");

        }
        else if ($.payform.parseCardType(cardNumber.val()) == 'mastercard') {
    
            mastercard.addClass("noFilter");
            visa.removeClass("noFilter");


        }
    });


    $(".mb-btn").on("click", function (e) {
        $(".card-validate").hide();
        visa.removeClass("noFilter");
        mastercard.removeClass("noFilter");
        $(this).addClass("noFilter");

    });


    visa.on("click", function (e) {
        $(".card-validate").show();

        $(".mb-btn").removeClass("noFilter");
        mastercard.removeClass("noFilter");
        visa.addClass("noFilter");
    });

    mastercard.on("click", function (e) {
        $(".card-validate").show();

        $(".mb-btn").removeClass("noFilter");
        visa.removeClass("noFilter");
        mastercard.addClass("noFilter");
    });

    // Use the payform library to format and validate
    // the payment fields.



});
