
function SubmitLogin() {

    var url = "";
    var flag = !0;
    var username = $("#txtUserName").val().trim();
    if ((username == "")) {
        $("#divLoginMsg div.alert").remove();
        $("#errorMsg").append(getAlert(__msglogRegEmailAddressRequired, "danger", false));
    }
    else if ($("#txtPassword").val().trim() == "") {
        $("#divLoginMsg div.alert").remove();
        $("#errorMsg").append(getAlert(__msglogRegPassword, "danger", false));
    }
    else {
        $("#divLoginMsg").append(getLoader());
        DoLogin(username, $("#txtPassword").val().trim(), "", false, false)
    }
    closeAlertDismissable();
};

function DoLogin(username, password, queryString, isRemember, autologin) {
    $.ajax({
        url: '/Users/Login',
        //data: $("#frmLogin").serialize(), //Works with name same in form as param name
        data: { "username": username, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },
        //data: JSON.stringify({ username: username, password: password, queryString: queryString, isRemember: isRemember, autologin: autologin }),//Does'nt work,
        type: "POST",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',//contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        success: function (data) {
            
            if ($("#divLoginMsg"))
                $("#divLoginMsg div.alert").remove();
            removeLoader("#divLoginMsg");
            if (data.isSuccess) {
                localStorage.setItem("logout", 0);
                if (data.returnUrl != null && data.returnUrl != undefined)
                    window.location.href = data.returnUrl;
            }
            else if (!data.isSuccess) {
                $("#divLoginBox").removeClass("box");
                $("#divLoginMsg div.alert").remove();
                $("#errorMsg").append(getAlert(__msglogRegInvalidEmailAddressPass, data.jsonMessageType, false));

                $("#txtPassword").val('');
                $("#txtUserName").val('').focus();
            }
        },
        complete: function () {
            setTimeout(function () { //code added by Vikas
                removeLoader("#divLoginMsg");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#divLoginBox").removeClass("box");
            setTimeout(function () { //code added by Vikas
                removeLoader("#divLoginMsg");
            }, 300);
            console.log(xhr.error().statusText);
            alert(xhr.error().statusText);
        }
    });
}
//function DoLogin(username, password, queryString, isRemember, autologin) {
//    $.ajax({
//        url: '/Users/Login',
//        //data: $("#frmLogin").serialize(), //Works with name same in form as param name
//        data: { "username": username, "password": password, "queryString": queryString, "isRemember": isRemember, "autologin": autologin },
//        //data: JSON.stringify({ username: username, password: password, queryString: queryString, isRemember: isRemember, autologin: autologin }),//Does'nt work,
//        type: "POST",
//        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',//contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        cache: false,
//        success: function (data) {
//            if ($("#divLoginMsg"))
//                $("#divLoginMsg div.alert").remove();
//            removeLoader("#divLoginMsg");
//            if (data.isSuccess) {
//                localStorage.setItem("logout", 0);
//                if (data.returnUrl != null && data.returnUrl != undefined)
//                    window.location.href = data.returnUrl;
//            }
//            else if (!data.isSuccess) {
//                $("#divLoginBox").removeClass("box");
//                $("#divLoginMsg div.alert").remove();
//                $("#errorMsg").append(getAlert(__msglogRegInvalidEmailAddressPass, data.jsonMessageType, false));

//                $("#txtPassword").val('');
//                $("#txtUserName").val('').focus();
//            }
//        },
//        complete: function () {
//            setTimeout(function () { //code added by Vikas
//                removeLoader("#divLoginMsg");
//            }, 300);
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            $("#divLoginBox").removeClass("box");
//            setTimeout(function () { //code added by Vikas
//                removeLoader("#divLoginMsg");
//            }, 300);
//          //  console.log(xhr.error().statusText);
//        }
//    });
//}

function showFP(_type) {
    if (_type == 'FPLink') {
        BootstrapDialog.show({
            id: "divFP",
            title: "Forgot Password",
            size: BootstrapDialog.SIZE_NORMAL,
            message: function () {
                var $message = $('<div id="divForgotPwd" class="pTB10-LR05"></div>');
                var html = '<div class="body">';
                html += '   <div class="">';
                html += '       <div class="input_holder">';
                html += '           <label for="input-1">Email Address</label>:';
                html += '           <div id="errorMsgFP"></div>';
                html += '           <input onkeydown="CallEnter(event, \'btnFPsubmit\')" id="txtUsername" maxlength="100" type="text" class="input__field input__field--haruki form-control" />'; //onkeydown="CallEnter(event, \'btnFPsubmit\')"
                html += '       </div>';
                html += '       <div>&nbsp;</div>';
                html += '   </div>';
                html += '</div>';
                $message.append(html);
                return $message;
            },
            closeByBackdrop: false,
            closable: false,
            buttons: [
                {
                    label: 'Close',
                    cssClass: 'btn btn-default',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }, {
                    label: 'Submit',
                    cssClass: 'btn btn-primary',
                    id: 'btnFPsubmit',
                    action: function (dialog) {

                        if ($.trim($("#txtUsername").val()) != "") {                            
                            var email = $("#txtUsername").val();
                            if (email.indexOf("@") != -1) {
                                $("#btnFPsubmit").css({ "opacity": "0.5", "cursor": "not-allowed" });
                                $("#btnFPsubmit").prop("disabled", "true");
                                $.ajax({
                                    url: "/api/UserAPI/ForgotPassword?UserName=" + $.trim($("#txtUsername").val() + "&loginMode=cms"),
                                    //data: JSON.stringify({ username: $.trim($("#txtUsername").val()) }),
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    //dataType: "json",
                                    success: function (result) {
                                        removeLoader("#divForgotPwd");
                                        if (result != null) {
                                            $(".modal-content").attr('class', 'modal-content');
                                            $("#errorMsgFP").append(getAlert('Email Sent!', "success", false));
                                        }
                                    },
                                    complete: function () {
                                        setTimeout(function () { //code added by Vikas
                                            removeLoader(".modal-content");
                                            removeLoader("#divForgotPwd");
                                            $('#divFP').modal('toggle');                                            
                                        }, 300);
                                    },
                                    error: function (xhr, ajaxOptions, thrownError) {
                                        dialog.close();
                                        console.log(xhr.error().statusText);
                                        removeLoader("#divForgotPwd");
                                    }
                                });
                                
                            }
                            else {
                                $("#errorMsgFP").append(getAlert('Invalid Email Address', "warning", false));
                            }
                        }
                        else {
                            $("#divForgotPwd div.alert").remove();
                            $("#errorMsgFP").append(getAlert('Registered Email Address Required', "danger", false));
                        }
                    }
                }
            ],
            onshown: function (dialogRef) {
                //
            }
        });
    }
}
