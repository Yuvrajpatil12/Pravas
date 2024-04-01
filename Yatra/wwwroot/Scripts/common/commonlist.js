/// <reference path="../js/global.js" />

function changeStatus(obj, id, action, type) {

    if (obj) {
        //BootstrapDialog.confirm(__confirmMessage, function (result) {
        //    if (result) {
        $("#divLoader").append(getLoader());
        $.ajax({
            url: changeStatusUrl,
            data: { "ID": id, "StatusID": action, "type": type },
            type: "POST",
            cache: false,
            //contentType: "application/json; charset=utf-8",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            dataType: "json",
            success: function (data) {
               
                if (data != null) {
                    removeLoader("#divLoader");
                    if (data.isSuccess) {
                        if (data.message != "")
                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                        var onclick = "changeStatus(this,'" + id + "','0')";
                        if (action == '0') {
                            onclick = "changeStatus(this,'" + id + "','1')";
                        }
                        $(obj).attr("onclick", "");
                        $(obj).attr("data-toggle", "");
                        $(obj).removeAttr("data-original-title");
                        $(obj).attr("onclick", onclick);
                        $(obj).siblings().attr("title", "");
                        $(obj).siblings().attr("data-toggle", "tooltip");
                        $(obj).siblings().attr("class", "btn_tbl_icons");

                        if (action == '1') {
                            $(obj).attr("class", "btn_tbl_icons btn_tbl_unlock");
                            $(obj).attr("data-original-title", __deActivate);
                            //$(obj).children().attr("class", "fa fa-unlock");
                            $(obj).children().attr("src", "/images/btn_tbl_unlock.svg");
                            //$(obj).next().hide();
                        }
                        else {
                            if ($(obj).attr("id") == "DeActive") {
                                //$(obj).prev().hide();
                            }
                            $(obj).attr("class", "btn_tbl_icons btn_tbl_lock");
                            $(obj).attr("data-original-title", __activate);
                            //$(obj).children().attr("class", "fa fa-lock");
                            $(obj).children().attr("src", "/images/btn_tbl_lock.svg");
                        }
                        $('[data-toggle="tooltip"]').tooltip();
                    }
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                removeLoader("#divLoader");
            }
        });
        //    }
        //});
    }
}
function changePromoteStatus(id, PromoteStatus) {

    $("#divLoader").append(getLoader());
    $.ajax({
        url: window.location.origin + '/api/StudentDetails/PromoteStudent?ID=' + id + '&PromoteStatus=' + PromoteStatus,
        data: {},//{ "ID": id, "PromoteStatus": PromoteStatus },
        type: "POST",
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                removeLoader("#divLoader");
                if (data.isSuccess) {
                    if (data.message != "")
                        showBSAlert(data.messageCaption, data.message, __SUCCESS);
                    location.reload();
                }
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}


function search(query, sortColumn, sortOrder, page, size, flag, ISLOAD, lsttype) {
    $("#divLoader").append(getLoader());
    $.ajax({
        url: searchUrl,
        //data: JSON.stringify({ query: query, sortColumn: sortColumn, sortOrder: sortOrder, page: page, size: size, flag: flag, ISLOAD: ISLOAD, ListType: lsttype }),
        data: { "query": query, "sortColumn": sortColumn, "sortOrder": sortOrder, "page": page, "size": size, "flag": flag, "ISLOAD": ISLOAD, "ListType": lsttype },
        type: "POST",
        cache: false,
        //contentType: "application/json; charset=utf-8",
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
            //resizeListView('ddlColumns', 'tblList');
            $("#ddlColumns").val(selectValue);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}



function OnchangeStatus(obj, id, action) {

    if (obj) {
        //BootstrapDialog.confirm(__confirmMessage, function (result) {
        //    if (result) {
        $("#divLoader").append(getLoader());
        $.ajax({
            url: changeStatusUrl,
            data: { "ID": id, "StatusID": action },
            type: "POST",
            cache: false,
            //contentType: "application/json; charset=utf-8",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            dataType: "json",
            success: function (data) {
                if (data != null) {
                    removeLoader("#divLoader");
                    if (data.isSuccess) {
                        if (data.message != "")
                            showBSAlert(data.messageCaption, data.message, __SUCCESS);
                        var onclick = "OnchangeStatus(this,'" + id + "','0')";
                        if (action == '0') {
                            onclick = "OnchangeStatus(this,'" + id + "','1')";
                        }
                        $(obj).attr("onclick", "");
                        $(obj).attr("data-toggle", "");
                        $(obj).removeAttr("data-original-title");
                        $(obj).attr("onclick", onclick);
                        $(obj).siblings().attr("title", "");
                        $(obj).siblings().attr("data-toggle", "tooltip");
                        $(obj).siblings().attr("class", "btn_tbl_icons");

                        if (action == '1') {
                            $(obj).attr("class", "btn_tbl_icons btn_tbl_unlock");
                            $(obj).attr("data-original-title", __deActivate);
                            //$(obj).children().attr("class", "fa fa-unlock");
                            $(obj).children().attr("src", "/images/btn_tbl_unlock.svg");
                            //$(obj).next().hide();
                        }
                        else {
                            if ($(obj).attr("id") == "DeActive") {
                                //$(obj).prev().hide();
                            }
                            $(obj).attr("class", "btn_tbl_icons btn_tbl_lock");
                            $(obj).attr("data-original-title", __activate);
                            //$(obj).children().attr("class", "fa fa-lock");
                            $(obj).children().attr("src", "/images/btn_tbl_lock.svg");
                        }
                        $('[data-toggle="tooltip"]').tooltip();
                    }
                }
                location.reload();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                removeLoader("#divLoader");
            }
        });
        //    }
        //});
    }
}