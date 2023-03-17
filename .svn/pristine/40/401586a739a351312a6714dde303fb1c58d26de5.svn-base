/************************************************************************************************
 * Program History : 
 * 
 * Project Name     : TRAINING PLAINING & REGISTRATION ONLINE
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)
 * Function Id      : AI070
 * Function Name    : AI070
 * Function Group   : Main JS
 * Program Id       : AI070
 * Program Name     : AI070 Main JS
 * Program Type     : JavaScript
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Arri
 * Version          : 01.00.00
 * Creation Date    : 05/11/2015 14:45:40
 * 
 * Update history   Re-fix date         Person in charge            Description 
 * update by :      2017-01-17          Septareosagita@gmail.com    common kan message & type

 * Copyright(C) 2015 - . All Rights Reserved                                                                                              
 *************************************************************************************************/

var MsgInfo = 'info';
var MsgConfirm = 'confirm';
var MsgConfirmAction = 'confirmWithAction';
var MsgError = 'error'; 


var AI070 = AI070 || {};

AI070.Elements = {
    $w: $(window)
    , $d: $(document)
    , $b: null
};

AI070.Constants = {
    AjaxStatus: {
        SUCCESS: "success"
        , ERROR: "error"
        , CONFIRM: "confirm"
    }
};

AI070.Components = {
    /*
        $elements: The table element that contains checkboxes
        $button: Button to active if there is any checkbox selected
        opts: Other options
    */

    CheckBox: function ($elements, $button, opts) {
        if (!$elements || ($elements.length == 0)) return;

        $elements.find("input[type='checkbox']").each(function (i, element) {
            $(this).on('change', function (e) {
                if (isButtonAvailable($button)) {
                    if (isAnyCheckBoxSelected($elements)) {
                        $button.removeAttr('disabled');
                    }
                    else {
                        $button.attr('disabled', 'disabled');
                    }
                }
            });
        });

        function isAnyCheckBoxSelected($element) {
            var returnValue = false;
            $elements.find("input[type='checkbox']").each(function (i, element) {
                if ($(this).is(":checked")) {
                    returnValue = true;
                }
            });
            return returnValue;
        }

        function isButtonAvailable($button) {
            if (!$button || ($button.length == 0)) {
                return false;
            }
            else {
                return true;
            }
        }
    }

    /*
        $elements: The table element that contains checkboxes
        $button: Button to select all checkbox 
    */
    , SelectAllCheckBox: function ($elements, $button) {
        $button.on('click', function (e) {
            if ($button.is(":checked")) {
               return $elements.prop('checked', true);
            } else {
               return $elements.prop('checked', false);
            }
        });
    }

    /*
        Close button and go to default page.
        $elements: The close button element.
        opts: Other options
            - Message: Close message
            - Url: The URL to redirect
    */
    , CloseButton: function ($element, opts) {
        if (!$element || ($element.length == 0)) return;

        var defaults = {
            message: "Are you sure want to close and go back to home page?"
            , url: "Home"
        };

        var settings = $.extend({}, defaults, opts);
        $element.on('click', function (event) {
            bootbox.confirm(settings.message, function (result) {
                if (result == true)
                    window.location = settings.url;
            });
        });
    }

    /*
        Select element in html,
        Contain functions to check or update select component.
    */
    , Select: {
        /*
            update the options in the select element HTML.
            $element: The select html element.
            option_list: The array of options, contains value and text on its object.
                e.g. [{value: "f", text: "First Option"}]
            remove_first_item: If true, the first option will be removed.
        */
        UpdateOptions: function ($element, option_list, remove_first_item) {
            if (!$element || ($element.length == 0)) return;

            var option_query = "option:gt(0)";
            if (remove_first_item) {
                option_query = "option";
            }

            $element.find(option_query).each(function () {
                $(this).remove();
            });

            $.each(option_list, function (k, v) {
                $element.append($("<option></option>")
                .attr("value", v.value)
                .text(v.text));
            });
        }
        
        /*
            Remove options in the select element HTML.
            $element: The select html element.
            remove_first_item: If true, the first options will be removed.
        */
        , RemoveOptions: function ($element, remove_first_item) {
            if (!$element || ($element.length == 0)) return;

            var option_query = "option:gt(0)";
            if (remove_first_item) {
                option_query = "option";
            }

            $element.find(option_query).each(function () {
                $(this).remove();
            });
        }
    }

    /*
        Input Text element in html,
        Contain functions to check or update select component.
    */
    , InputText: {
        /*
            update the value in the input text element HTML.
            $element: The input text html element.
            value: The value of input text.
        */
        UpdateValue: function ($element, value) {
            if (!$element || ($element.length == 0)) return;

            $element.attr("value", value);
        }
    }

    /*
        Loading screen componet. Display loading modal dialog.
    */
    , LoadingScreen: {
        /*
            Open our dialog
            @param message Custom message
            @param options Custom options:
                           options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
                           options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
        */
        Show: function (message, options) {
            WaitingDialog.show(message, options);
            //AI070.Element.$b.removeClass('modal-open');
        }

        //Close dialog
        , Hide: function () {
            WaitingDialog.hide();
            AI070.Components.LoadingScreen.UpdateProgressBar();
        }

        //Update the progress bar.
        , UpdateProgressBar: function (progress) {
            if (progress && progress <= 100 && progress >= 0) {
                AI070.Elements.$b.find(".modal-dialog").find(".progress-bar").css("width", (progress + "%"));
            }
            else {
                AI070.Elements.$b.find(".modal-dialog").find(".progress-bar").css("width", ("100%"));
            }
        }
    }

    , LoadingHyperlink: function ($elements) {
        if (!$elements || ($elements.length == 0)) return;

        $elements.on('click', function (event) {
            var message = "Loading <b>" + $(this).text() + "</b>. <br/><br/>Please wait...";
            AI070.Components.LoadingScreen.Show(message);
            window.location = $(this).attr('href');
        });
    }
}

function setEnableDisable(obj, mode) {
    objEnable = $(obj).find('input, textarea, select');
    $.each(objEnable, function () {
        if ($(this).attr('type') != 'hidden' && $(this).attr('type') != 'button' && $(this).attr('type') != 'checkbox') {
            $(this).attr('readonly', 'true');
        }
    });

    objEnable = $(obj).find('input[class~=' + mode + '], textarea[class~=' + mode + ']');
    $.each(objEnable, function () {
        $(this).removeAttr('readonly');
    });

    //if (mode == 'add-mode') {
    objEnable = $(obj).find('td[class~=' + mode + ']');
    $.each(objEnable, function () {
        $(this).show();
    });
    //}
    //else {
        //objEnable = $(obj).find('td');
        //$.each(objEnable, function () {
        //    if ($(this).attr('type') != 'hidden' && $(this).attr('type') != 'button' && $(this).attr('type') != 'checkbox') {
        //        $(this).hide();
        //    }
        //});

        //objEnable = $(obj).find('td div[class~=' + mode + ']');
        //$.each(objEnable, function () {
        //    $(this).show();
        //});

        //objEnable = $(obj).find('td[class~=' + mode + ']');
        //$.each(objEnable, function () {
        //    $(this).show();
        //});
    //}

    //Start Disable All Button
    objButtons = $('.main-btn').find('button');
    $.each(objButtons, function () {
        $(this).hide();
    });
    //End Disable All Button

    //Start Enable Mode Button
    objButtons = $('.main-btn').find('button[class~="' + mode + '"]');
    $.each(objButtons, function () {
        $(this).show();
    });
    //End Enable Mode Button

    var objLinks = [];
    //Start Disable All Link
    objLinks = $('.row').find('a');
    $.each(objLinks, function () {
        if ($(this).data("tooltipset")) {
            $(this).tooltip('close');
        }
        //$(this).attr('onclick', 'return false');
        $(this).css({ "pointer-events": "none", "cursor": "default" });
    });
    //End Disable All Link

    //Start Enabled Mode Link
    stElm = null;
    var stElm = 'a[class~="' + mode + '"]';
    objLinks = $(obj).find(stElm);
    $.each(objLinks, function () {
        //$(this).removeAttr("onclick");
        $(this).removeAttr("style");
    });
    //End Enabled Mode Link
}

function setRowValue(fromRow, toRow, fOprMode) {
    var toChild = $(toRow).children();
    var i = 0;
    var text = null, option = null, optionValue = null;

    $.each($(fromRow).children(), function () {
        var elementChild = $(toChild[i]).children();
        if (elementChild.length == 0) {
            $(toChild[i]).html($(this).html())
        } else if ($(elementChild[0]).attr('class') != undefined && $(elementChild[0]).attr('class').indexOf('textbox') > -1) {
            $(elementChild[0]).val($(this).text().trim());
            if (fOprMode == 'edit-mode' && $(elementChild[0]).attr('eEdit') == undefined) {
                $(elementChild[0]).hide();
                $(toChild[i]).prepend($(this).text());
            }
        } else if ($(elementChild[0]).attr('class') != undefined && $(elementChild[0]).attr('class').indexOf('textarea') > -1) {
            $(elementChild[0]).val($(this).html().trim());
            if (fOprMode == '.edit-mode' && $(elementChild[0]).attr('eEdit') == undefined) {
                $(elementChild[0]).hide();
                $(toChild[i]).prepend($(this).text());
            }
        } else if ($(elementChild[0]).attr('type') != undefined && $(elementChild[0]).attr('type') == 'hidden') {
            $(elementChild[0]).val($(this).text().trim());
            $(toChild[i]).prepend($(this).text());
        } else if ($(elementChild[0]).attr('name') != undefined && $(elementChild[0]).attr('name') == 'STDComboText') {
            var text = $(this).text().trim();
            $(elementChild[0]).find("option").each(function () {
                if ($(this).text() == text) $(this).attr("selected", "selected");
            })
            if (fOprMode == 'edit-mode' && $(elementChild[0]).attr('eEdit') == undefined) {
                $(elementChild[0]).hide();
                $(toChild[i]).prepend($(this).text());
            }
        } else if ($($(this).children())[0].checked != undefined) {
            $(elementChild[0])[0].attr("checked", $($(this).children())[0].checked);
            $(elementChild[0])[0].trigger('change');
            //if (fOprMode == '.edit-mode' && $(elementChild[0])[0].attr('eEdit') == undefined) {
            //    $(elementChild[0]).hide();
            //    $(toChild[i]).prepend($(this).text());
            //}
        }
        else {

        }

        i++;
    });
}

/* Function get message */
function getMessage(messageID, messageParam, messageType, isReload) {
    var url = 'CSTDMessage/Message';
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        traditional: true,
        url: url,
        data: JSON.stringify({
            msgID: messageID,
            msgParam: messageParam
        }),
        success: function (result) {
            showMessage(messageType, result, isReload);
        }
    });
}

function isReloaded(action) {
    if (action) {
        window.location.reload();
    }
}

function showMessage(messageType, result, isReload)
{
    if (messageType == 'info') {
        bootbox.dialog({
            title: '<div class="close" style="opacity: 1 !important; margin-top: -7px;"><span aria-hidden="true"><img src="Content/Bootstrap/img/information.png" class="modal-icon" /></span></div><h4 class="modal-title" id="popup-title">Message</h4>',
            message: result,
            closeButton: false,
            buttons: {
                main: {
                    label: "OK",
                    className: "btn-primary",
                    callback: function () {
                        isReloaded(isReload);
                    }
                }
            }
        });
    } else if (messageType == 'confirm') {
        bootbox.dialog({
            title: '<div class="close" style="opacity: 1 !important; margin-top: -7px;"><span aria-hidden="true"><img src="Content/Bootstrap/img/question.png" class="modal-icon" /></span></div><h4 class="modal-title" id="popup-title">Message</h4>',
            message: result,
            closeButton: false,
            buttons: {
                success: {
                    label: "Yes",
                    className: "btn-success",
                    callback: function () {
                        isReloaded(isReload);
                    }
                },
                danger: {
                    label: "No",
                    className: "btn-danger",
                    callback: function () {

                    }
                }
            }
        });
    }
    else if (messageType == 'confirmWithAction') {
        bootbox.dialog({
            title: '<div class="close" style="opacity: 1 !important; margin-top: -7px;"><span aria-hidden="true"><img src="Content/Bootstrap/img/question.png" class="modal-icon" /></span></div><h4 class="modal-title" id="popup-title">Message</h4>',
            message: result,
            closeButton: false,
            buttons: {
                success: {
                    label: "Yes",
                    className: "btn-success",
                    callback: function () {
                        return isReload();
                    }
                },
                danger: {
                    label: "No",
                    className: "btn-danger",
                    callback: function () {

                    }
                }
            }
        });
    }
    else if (messageType == 'error') {
        bootbox.dialog({
            title: '<div class="close" style="opacity: 1 !important; margin-top: -7px;"><span aria-hidden="true"><img src="Content/Bootstrap/img/Error.png" class="modal-icon" /></span></div><h4 class="modal-title" id="popup-title">Message</h4>',
            message: result,
            closeButton: false,
            buttons: {
                main: {
                    label: "OK",
                    className: "btn-primary",
                    callback: function () {
                        isReloaded(isReload);
                    }
                }
            }
        });
    }
}

function toggleFullScreen(elem) {
    if ((document.fullScreenElement !== undefined && document.fullScreenElement === null) || (document.msFullscreenElement !== undefined && document.msFullscreenElement === null) || (document.mozFullScreen !== undefined && !document.mozFullScreen) || (document.webkitIsFullScreen !== undefined && !document.webkitIsFullScreen)) {
        if (elem.requestFullScreen) {
            elem.requestFullScreen();
        } else if (elem.mozRequestFullScreen) {
            elem.mozRequestFullScreen();
        } else if (elem.webkitRequestFullScreen) {
            elem.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
        } else if (elem.msRequestFullscreen) {
            elem.msRequestFullscreen();
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        }
    }
}

/* End */

/*
    Consolidate the JavaScript function for each page in here.
    Put the page/controller name.
    Example: AI070.Page.ScheduleMoniAI070ing
*/
AI070.Page = AI070.Page || {};

$(document).ready(function () {
    AI070.Elements.$b = AI070.Elements.$d.find('body');
    AI070.Components.LoadingHyperlink(AI070.Elements.$b.find('a.load-with-progress'));
});

function openwindow(url) {
    var sw = screen.availWidth;
    var sh = screen.availHeight

    var w = 0.3 * sw;
    var h = sh;

    var win = window.open(url, 'PIS0108a', 'scrollbar=yes,menubar=no,width=' + w + ',height=' + h + ',resizeable=yes,toolbar=no,directories=no,titlebar=no,location=no,status=no');
    win.resizeTo(w, h);
    win.moveTo(sw - w, 0);
    win.focus();
}
