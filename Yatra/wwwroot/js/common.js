// JavaScript Document

$(document).ready(function (e) {
    //loadView.dashboard();
    //loadView.createAcc();	
    numberOnly();
    numberAndAlphabetsOnly();
    upiIDOnly();
    numberHypenSpaceOnly();
});
var loadView = {
    dashboard: function () {
        $(".nav-sidebar .nav-link").click(function () {
            $('#dashboard').load("dashboard.html");
        });
    },
    createAcc: function () {
        $(".nav-sidebar .nav-link").click(function () {
            $('#createAccount').load("create-account.html");
        });
    }
}

function SubmitCreateAccount() {
    var inputMassage = "";
    var valid = true;

    var txtfullname = $("input[name='txtfullname']").val();
    var txtusername = $("input[name='txtusername']").val();
    var userTypeRole = $("select[name='userTypeRole']").val();
    var txtPassword = $("input[name='txtPassword']").val().trim();

    if (txtfullname == "") {
        inputMassage += __Fullname + "<br />";
        valid = false;
    }
    if (txtusername == "") {
        inputMassage += __Username + "<br />";
        valid = false;
    }
    if (userTypeRole == "") {
        inputMassage += __userTypeRole + "<br />";
        valid = false;
    }
    if (txtPassword == "") {
        inputMassage += __Password;
        valid = false;
    }
    if (valid) {
        alert("Action Here");
    }
    else {
        showBSAlert(__warnCaption, inputMassage, __DANGER);
    }
    return valid;
}

function showDrDetails() {
    BootstrapDialog.show({
        id: "divDrInfo",
        title: "Doctor Information",
        size: BootstrapDialog.SIZE_WIDE,
        message: function () {
            var $message = $('<div id="divDrInfoInner" class="pTB10-LR05"></div>');
            var html = '<div class="body">';
            html += '<div class="row">';
            html += '<div class="col-md-6">';
            //html += '   <label for="input-1">' + __emailAddress + '</label>:';
            html += '   <label for="input-1">Doctor Name</label>: XYZ';
            html += '</div>';
            html += '<div class="col-md-6">';
            html += '   <label for="input-1">Doctor Details</label>: XYZ';
            html += '</div>';
            html += '<div>&nbsp;</div>';
            html += '</div>';
            html += '</div>';
            $message.append(html);
            return $message;
        },
        closeByBackdrop: true,
        closable: true,
        buttons: [
            {
                label: __msglogRegClose,
                cssClass: 'btn-default',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            }/*, {
				label: __msglogRegSubmit,
				cssClass: 'btn-primary',
				id: 'btnFPsubmit',
				action: function (dialog) {
					//alert("Forgor Password");
				}
			}*/
        ],
        onshown: function (dialogRef) {
            //
        }
    });
}

function SubmitDoctorDataCollection() {
    var inputMassage = "";
    var valid = true;

    var txtDoctorName = $("input[name='txtDoctorName']").val();
    var txtSBUCode = $("input[name='txtSBUCode']").val();
    var txtQualification = $("select[name='txtQualification']").val();
    var txtPracticePlace = $("input[name='txtPracticePlace']").val();
    var txtDOB = $("input[name='txtDOB']").val();
    var txtDOA = $("input[name='txtDOA']").val();

    if (txtDoctorName == "") {
        inputMassage += __drName + "<br />";
        valid = false;
    }
    if (txtSBUCode == "") {
        inputMassage += __drSUBCode + "<br />";
        valid = false;
    }
    if (txtQualification == "") {
        inputMassage += __drQualification + "<br />";
        valid = false;
    }
    if (txtPracticePlace == "") {
        inputMassage += __drPracticePlace + "<br />";
        valid = false;
    }
    if (txtDOB == "") {
        inputMassage += __drDateOfBirth + "<br />";
        valid = false;
    }
    if (txtDOA == "") {
        inputMassage += __drDOA;
        valid = false;
    }
    if (valid) {
        alert("Action Here");
    }
    else {
        showBSAlert(__warnCaption, inputMassage, __DANGER);
    }
    return valid;
}
$(document).ready(function () {
    /**/
});

// Append The Html Returned From This Method to your div which has class=box
// Start Loaders
function getLoader() {
    return $("#scriptLoader").html();
}
function removeLoader(selector) {
    $(selector).find(".overlay, .loading-img").remove();
}
function getLoaderSmall() {
    return $("#scriptLoaderSmall").html();
}
function removeLoaderSmall(selector) {
    $(selector).find(".overlay, .loading-img-small").remove();
}

/* function SubmitForm(formName) {
    $("#" + formName).submit();
} */
function SubmitFormWritePres(formName, hdnId, val) {
    if (hdnId) {
        $("#" + hdnId).val(val);
    }
    $("#" + formName).submit();
}

// End Loaders
var loginSocial = {
    showFP: function () {
        BootstrapDialog.show({
            id: "divFPpopup",
            title: __forgotPassword,
            message: function () {
                var $message = $('<div id="divForgotPwd" class="pTB10-LR05"></div>');
                var html = '<div class="body">';
                html += '<div class="">';
                html += '<div class="input_holder">';
                html += '   <label for="input-1">' + __emailAddress + '</label>:';
                html += '       <input id="txtUsername" maxlength="100" type="text" class="input__field input__field--haruki form-control" />';
                html += '</div>';
                html += '<div>&nbsp;</div>';
                html += '</div>';
                html += '</div>';
                $message.append(html);
                return $message;
            },
            closeByBackdrop: false,
            closable: false,
            buttons: [
                {
                    label: __msglogRegClose,
                    cssClass: 'btn-default',
                    action: function (dialogItself) {
                        dialogItself.close();
                    }
                }, {
                    label: __msglogRegSubmit,
                    cssClass: 'btn-primary',
                    id: 'btnFPsubmit',
                    action: function (dialog) {
                        alert("Forgor Password");
                    }
                }
            ],
            onshown: function (dialogRef) {
                $("#txtUsername").val($("#UserName").val())//.focus();
            }
        });
    }
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

function getAlert(message, type, hasIcon) {
    var i = "danger";
    var c = "ban";
    switch (type.toLowerCase()) {
        case "error":
        case "failure":
        case "danger":
            c = "danger";
            i = "ban"
            break;
        case "info":
            c = i = "info";
            break;
        case "warning":
            c = i = "warning";
            break;
        case "success":
            c = "success";
            i = "check";
            break;
        default:
            c = "danger";
            i = "ban"
            break;
    }

    var html = $("#scriptAlert").text();
    if (hasIcon)
        html = html.replace("<!--", "").replace("-->", "").replace("[[ICON]]", i);
    html = html.replace("[[CLASS]]", c).replace("[[MESSAGE]]", message);

    return html;
}


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}



// convert Formdata to object
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function CopyText(result) {
    var textArea = document.createElement("textarea");
    textArea.value = result;

    // Avoid scrolling to bottom
    textArea.style.top = "0";
    textArea.style.left = "0";
    textArea.style.position = "fixed";

    document.body.appendChild(textArea);
    textArea.focus();
    textArea.select();

    document.execCommand("copy");
    document.body.removeChild(textArea);
}

function closeAlertDismissable() {
    $(".alert-dismissable").find("button.close").click(function () {
        $(".alert-dismissable").remove();
    });
}

function numberOnly() {
    $('.numberonly').keypress(function (e) {
        var charCode = (e.which) ? e.which : e.keyCode;
        /*if (String.fromCharCode(charCode).match(/[^0-9]/g)) {
            return false;
        }*/
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
    });
}
function numberAndAlphabetsOnly() {
    $('.numberAndAlphabetsOnly').keypress(function (e) {
        var keyCode = e.keyCode || e.which;
        //Regex for Valid Characters i.e. Alphabets and Numbers.
        var regex = /^[A-Za-z0-9]+$/;

        //Validate TextBox value against the Regex.
        var isValid = regex.test(String.fromCharCode(keyCode));
        if (!isValid) {
            return false;
        }
    });
}

function upiIDOnly() {
    $('.upiIDOnly').keypress(function (e) {       
        var keyCode = e.keyCode || e.which;
        //Regex for Valid Characters i.e. Alphabets and Numbers.
        //var regex = /^[0-9A-Za-z.-]{2,256}@[A-Za-z]{2,64}$/;
        var regex = /^[0-9A-Za-z.-@]+$/;

        //Validate TextBox value against the Regex.
        var isValid = regex.test(String.fromCharCode(keyCode));
        if (!isValid) {
            return false;
        }
    });
}

function numberHypenSpaceOnly() {
    $('.numberHypenSpaceOnly').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && String.fromCharCode(e.which) != '-' && String.fromCharCode(e.which) != ' ' && (e.which < 48 || e.which > 57)) {
            //display error message            
            return false;
        }
    });
}

var customToolbar = {
    fontSizes: ['8', '9', '10', '11', '12', '14', '16', '18', '20', '22', '26', '28', '36', '48', '56', '72'],
    fontSizeUnits: ['px', 'pt'],
    toolbar: [
        ['style', ['bold', 'italic', 'underline', 'clear', 'hr']],
        ['fontname', ['fontname']],
        ['fontsize', ['fontsize', 'fontsizeunit']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['color', ['color']],
        ['para', ['ul', 'ol', 'paragraph']],
        ['table', ['table']],
        ['insert', ['link', 'picture', 'video']],
        ['height', ['height']],
        ['undo', ['undo']],
        ['redo', ['redo']],
        //['help', ['help']]
        ['view', ['fullscreen', 'codeview']] //'help'
    ],
    callbacks: {
        onKeydown: function (e) {
            var t = e.currentTarget.innerText;
            if (t.trim().length >= 2500) {
                //delete keys, arrow keys, copy, cut, select all
                if (e.keyCode != 8 && !(e.keyCode >= 37 && e.keyCode <= 40) && e.keyCode != 46 && !(e.keyCode == 88 && e.ctrlKey) && !(e.keyCode == 67 && e.ctrlKey) && !(e.keyCode == 65 && e.ctrlKey))
                    e.preventDefault();
            }
        },
        onKeyup: function (e) {
            var t = e.currentTarget.innerText;
            $('#maxContentPost').text(2500 - t.trim().length);
        },
        onPaste: function (e) {
            var t = e.currentTarget.innerText;
            var bufferText = ((e.originalEvent || e).clipboardData || window.clipboardData).getData('Text');
            e.preventDefault();
            var maxPaste = bufferText.length;
            if (t.length + bufferText.length > 2500) {
                maxPaste = 2500 - t.length;
            }
            if (maxPaste > 0) {
                document.execCommand('insertText', false, bufferText.substring(0, maxPaste));
            }
            $('#maxContentPost').text(2500 - t.length);
        }
    }
}
