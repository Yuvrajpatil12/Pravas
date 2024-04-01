
function PayMerchant() {

    var objToSend = {
        "merchantId": "PGTESTPAYUAT",
        "merchantTransactionId": "MT7850590068188104",
        "merchantUserId": "MUID123",
        "amount": 10000,
        "redirectUrl": "https://webhook.site/redirect-url",
        "redirectMode": "REDIRECT",
        "callbackUrl": "https://webhook.site/callback-url",
        "mobileNumber": "9999999999",
        "paymentInstrument": {
            "type": "PAY_PAGE"
        }
    };

    $.ajax({
        url: '/api/Pay/PayAPI',
        //data: { "merchantId": PGTESTPAYUAT, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },
        data: JSON.stringify(objToSend),
        type: "POST",
        processData: false,
        contentType: 'application/json',
        async: true,
        //type: "POST",
        //contentType: '',//application/x-www-form-urlencoded; charset=UTF-8 contentType: "application/json; charset=utf-8",
        //dataType: "json",
        //cache: false,
        success: function (data) {

            if (data.isSuccess) {

            }
            else if (!data.isSuccess) {

            }
        },
        complete: function () {
            setTimeout(function () {
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
            }, 300);
            console.log(xhr.error().statusText);
        }
    });
}