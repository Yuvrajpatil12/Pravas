
function SubmitForm(formName) {
    var msg = "";
    var isValid = true;

    if (formName == "frmUpdateUser") {

        if ($("#Build").val().trim() == "") {
            msg = msg + "\n" + "Build Field Is Required";
            isValid = false;
        }

    }

    if (formName == "frmQuery") {
        if ($("#Querytextarea").val().trim() == "") {
            msg = msg + "\n" + "Text Field Is Required";
            isValid = false;
        }

        var reg = /<(.|\n)*?>/g;
        if (reg.test($('#Querytextarea').val()) == true) {
            msg = msg + "\n" + "HTML Tag are not allowed";
            isValid = false;
        }

        var specialChars = "select";
        var totalWords = $('#Querytextarea').val();
        var firstWord = totalWords.replace(/ .*/, '');

        //var str = $('#Search').val();
        if (firstWord == specialChars) {
            msg = msg + "\n" + "SELECT Query are not allowed";
            isValid = false;
        }
       
     
    }

    if (formName == "frmSearchQuery") {

        var reg = /<(.|\n)*?>/g;

        if (reg.test($('.Query-Box').val()) == true) {
            msg = msg + "\n" + "HTML Tag are not allowed";           
            isValid = false;
        }

        if ($("#Search").val().trim() == "") {
            msg = msg + "\n" + "Text Field Is Required";
            isValid = false;
        }  

        var specialChars = "select * from";
        var str = $('#Search').val();
        if (str === specialChars){
            msg = msg + "\n" + "SELECT * From Query are not allowed";
            isValid = false;
        }

                  
    }

    if (isValid) {
        if (formName == "frmUpdateUser") {
            SaveAppUpdate();
            fnModeClick();
            fnModeOnOffClick();
        }

        if (formName == "frmQuery") {
            SaveQuery("frmQuery");         

        }
        if (formName == "frmSearchQuery") {
            search("frmSearchQuery");

        }       
    }
    else if (msg != "") {
        showBSAlert(__requiredCaption, msg, __DANGER);
    }
    msg = "";


}

function SaveAppUpdate() {   

    $("#divLoader").append(getLoader());
    var fdata = new FormData();
    $('#frmUpdateUser input').each(function () {
        if ($(this).attr('id') != undefined) {
            fdata.append($(this).attr('id'), $(this).val());
        }
    });
    
        $.ajax({
            url: window.location.origin + '/AppUpdate/SaveAppUpdate',
            data: fdata,
            type: "POST",
            processData: false,
            contentType: false,  
            success: function (data) {
                if (data.isSuccess) {

                   
                    BootstrapDialog.show({
                        id: "divSaveClass",
                        title: __SUCCESS,
                        type: getDialogType(__SUCCESS),
                        message: function () {
                            var $message = $('<div id="divSaveClassInner"></div>');
                            $message.append(data.message);
                            return $message;
                        },
                        closeByBackdrop: false,
                        buttons: [{
                            label: __ok,
                            cssClass: 'btn btn-primary',
                            action: function (dialog) {
                                location.href = "/AppUpdate/Index";
                            }
                        }]
                    });
                }
                else if (!data.isSuccess) {
                    showBSAlert(data.messageCaption, data.message, __error);
                }
            },

            complete: function () {
                setTimeout(function () {
                    removeLoader("#divLoader");
                }, 300);
            },
            error: function (xhr, ajaxOptions, thrownError) {               
                setTimeout(function () {                    
                }, 300);
                console.log(xhr.error().statusText);
            }

        });
    
}

function ValidateEvaluation() {
    var msg = "";
    var isValid = true;
    var DomainID = 0;
    if (isValid = true) {
        isValid = true;
    }
    else {
        $('#frmUpdateUser select').each(function () {
            if ($(this).attr('id') != undefined) {
                var ddSelectID = $(this).attr('id');

                if (ddSelectID.split('_')[1] != DomainID) {
                    DomainID = ddSelectID.split('_')[1];
                    if ($('select#' + $(this).attr('id') + ' option:selected').val() == "") {
                        msg = msg + "\n" + "Please select remarks for all topics in " + $("#lnkCollapse" + DomainID).text();
                        isValid = false;
                    }
                }
            }
        });
    }

    if (msg != "") {
        showBSAlert(__requiredCaption, msg, __DANGER);
    }
    msg = "";
    return isValid;
}


//function SubmitForm(formName) {
//    var msg = "";
//    var isValid = true;

//    if (formName == "frmUpdateUser") {

//        if ($("#Build").val().trim() == "") {
//            msg = msg + "\n" + "Build Field Is Required";
//            isValid = false;
//        }

//    }

//    if (isValid) {
//        if (formName == "frmUpdateUser") {
//            SaveAppUpdate();
//            fnModeClick();
//            fnModeOnOffClick();
//        }
//    }

//    else if (msg != "") {
//        showBSAlert(__requiredCaption, msg, __DANGER);
//    }
//    msg = "";


//}

function fnModeOnOffClick(e) {
    $("#hdnIsUpdate").val($('input[name="UpdateMode"]:checked').val())
}
function fnModeClick(e) {
    $("#hdnAppType").val($('input[name="UserMode"]:checked').val())
}

function fnCheckOnOff() {
    if ($("#hdnIsUpdate").val() == "0")
        $("#OFF").prop("checked", true)
    else if ($("#hdnIsUpdate").val() == "1")
        $("#ON").prop("checked", true)
}


function fnCheckDeviceMode() {
    if ($("#hdnAppType").val() == "1")
        $("#UserAndroid").prop("checked", true)
    else if ($("#hdnAppType").val() == "2")
        $("#UserIphone").prop("checked", true)
}

//QueryController Operation Start Here

function SaveQuery() {

    var fdata = new FormData();

    $('#frmQuery textarea').each(function () {
        if ($(this).attr('id') != undefined) {
            fdata.append($(this).attr('id'), $('textarea#' + $(this).attr('id')).val());
        }
    });

    $.ajax({
        url: window.location.origin + '/Query/SaveQuery',
        data: fdata,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.isSuccess) {


                BootstrapDialog.show({
                    id: "divSaveClass",
                    title: __SUCCESS,
                    type: getDialogType(__SUCCESS),
                    message: function () {
                        var $message = $('<div id="divSaveClassInner"></div>');
                        $message.append(data.message);
                        return $message;
                        console.log("data : " + data.val);
                    },
                    closeByBackdrop: false,
                    buttons: [{
                        label: __ok,
                        cssClass: 'btn btn-primary',
                        action: function (dialog) {
                            location.href = "/Query/Index";
                        }
                    }]
                });
            }

            else if (!data.isSuccess) {
                showBSAlert(data.messageCaption, data.message, __error);
            }
        },

        complete: function () {
            setTimeout(function () {
                removeLoader("#divLoader");
            }, 300);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            setTimeout(function () {
            }, 300);
            console.log(xhr.error().statusText);
        }

    });
}


function search() {

   
    var json_data = $('#frmSearchQuery').serializeObject();
    var dataObj = new Object();
    dataObj.Search = $("#Search").val()

    
    $("#divLoader").append(getLoader());
    $.ajax({
        url: window.location.origin + '/Query/SqlTableList?query=' + dataObj.Search,
        data: {},
        type: "POST",      
    //    async:false,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        success: function (result) {
            removeLoader("#divLoader");
            if (result != null) {
                $("#dvCommon").empty();
                $("#dvCommon").html(result);
                if ($(window).width() > 768)
                    $("#Search").focus();
            }
            setArrow();            
            $("#ddlColumns").val(selectValue);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}



function CallEnter(objEvent, obj) {
    if (objEvent) {
        if (objEvent.which || objEvent.keyCode) {
            if ((objEvent.which == 13) || (objEvent.keyCode == 13)) {
                $("#" + obj).click();
                return false;
            }
        }
    }
    else
        return true;
}



