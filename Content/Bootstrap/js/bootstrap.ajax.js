var BSAjax = {};
!function ($) {
    BSAjax.errorContext = {
        title: 'Warning',
        getTitle : function(exceptionData){
            switch (exceptionData.category){
                case 0: //Error
                    return "Warning";
                case 1: //Warning
                    return "Warning";
                case 2: //Info
                    return "Information";
                case 3: //Success
                    return "Success";
                default:
                    return this.title;
            }
            return this.title;
        },
        exceptionTemplate: { ajaxreport: false, message: '', error: '', category: 0, sourceurl: '' },
        currentException: null,
        isException: function (exceptionData) {
            if (!exceptionData || typeof (exceptionData) != "object")
                return false;
            var data = $.extend({}, this.exceptionTemplate, exceptionData);
            this.currentException = data;
            return data.ajaxreport;
        },
        message: function (exceptionData, addClose) {
        var divError = $("<div>").addClass("alert").addClass("alert-ajax");
        if (this.isException(exceptionData)) {
            switch (exceptionData.category) {
                case 0: //Error
                    divError.addClass("alert-danger");
                    break;
                case 1: //Warning
                    divError.addClass("alert-warning");
                    break;
                case 2: //Info
                    divError.addClass("alert-info");
                    break;
                case 3: //Success
                    divError.addClass("alert-success");
                    break;
                default:
                    divError.addClass("alert-danger");
                    break;
            }
                
            var msg = "";
            if(addClose)
                msg = '<button type="button" class="close" onclick="$(this).parents(\'.alert\').fadeOut()">x</button>';                 
            msg += "<div class='validation-summary-errors'>" + 
                        exceptionData.message + 
                        '<div class="alert-exception-detail" style="display:none"> <br/>' +
                            exceptionData.error +
                        '</div>' + 
                  "</div>";

            divError.html(msg);
        }
        return divError;
    },
    };

    /*
    Usage:
    new BSAjax.errorValidation({validateType: 1, resultType: 1});
    Result
    - will popUp on any throw exception
    - will popUp when any result

    Usage:
    new BSAjax.errorValidation({validateType: 1, resultType: 0, resultCtrl: "#idControl"});
    Result
    - will popUp on any throw exception
    - will replace html element for resultCtrl (#idControl)
    */
    BSAjax.errorValidation = function (options) {
        this.Options = {
            data: null,
            validateType: 1,
            validateCtrl: null,
            resultReplace: 0,
            resultType: 0,
            resultCtrl: null,
            beforeSuccess: function (data) { return true; },
            onSuccess: function () { },
            onAlert: function () { }
        };
        this.Options = $.extend({}, this.Options, options);

        if (!BSAjax.errorContext.isException(this.Options.data)) {
            if (!this.Options.beforeSuccess(this.Options.data))
                return;
            $(this.Options.validateCtrl).html("");
            if (this.Options.resultType == 0) {
                if(this.Options.resultReplace == 0){
                    $(this.Options.resultCtrl)
                        .html(this.Options.data)
                        .fadeIn('normal');
                }
                else{
                    $(this.Options.resultCtrl)
                        .replaceWith(this.Options.data)
                        .fadeIn('normal');
                }
            }
            else {
                var notifOption = { dialog: this.Options.data };
                notifOption.isTemporary = $(this.Options.resultCtrl).length <= 0;
                if (!notifOption.isTemporary)
                    notifOption.scopeId = this.Options.resultCtrl;
                new BSAjax.Notification(notifOption);
            }
            $(this.Options.resultCtrl).reunobtrusive();
            $.validator.unobtrusive.parse($(this.Options.validateCtrl));
            this.Options.onSuccess();
        }
        else if ($(this.Options.validateCtrl).length <= 0) {
            this.Options.onAlert();
            new BSAjax.Notification({ title: BSAjax.errorContext.getTitle(this.Options.data), message: BSAjax.errorContext.message(this.Options.data, false) });
        }
        else if (this.Options.validateType == 1) {
            this.Options.onAlert();
            new BSAjax.Notification({
                scopeId: this.Options.validateCtrl,
                isTemporary: false,
                title: BSAjax.errorContext.getTitle(this.Options.data),
                message: BSAjax.errorContext.message(this.Options.data, false)
            });

        }
        else {
            this.Options.onAlert();
            $(this.Options.validateCtrl)
                .html(BSAjax.errorContext.message(this.Options.data, true))
                .fadeIn();
        }

    };

    /*
    Usage: 
    new BSAjax.Notification({dialog : object});
    will pop as dialog result
    Usage: 
    new BSAjax.Notification({type: 1, message: 'ask something?'});
    will pop as message result to confirm
        
    */
    BSAjax.Notification = function (options) {
        this.Options = {
            scopeId: 'notif-',
            runOnInitialize: true,
            isTemporary: true,
            parentId: "body",
            title: null,
            type: 0, //type 0 = notification, 1 for confirm
            size: 0, //size 1 = will user modal-lg
            scopeTitle: null,
            dialog: null,
            message: '',
            textOK: 'OK',
            textCancel: 'Cancel',
            onStartUp: function () { },
            onExecute: function () { },
            onOK: function () { },
            onCancel: function () { }
        };
        this.Options.scopeId += this.Options.parentId + Math.floor((Math.random() * 100) + 1);
        this.Options = $.extend({}, this.Options, options);
        //default title
        if (!this.Options.title)
            this.Options.title = this.Options.type == 0 ? 'Notification' : 'Confirmation';

        if (this.Options.scopeTitle)
            this.Options.title += ' for ' + this.Options.scopeTitle;


        this.GetModalDialog = function () {
            if (this.Options.dialog)
                return this.Options.dialog;

            var dialog = $(['<div class="modal-dialog modal-xl">',
                        '<div class="modal-content">',
                            '<div class="modal-header">',
                                '<h4 class="modal-title">',
                                   this.Options.title,
                                '</h4>',
                            '</div>',
                            '<div class="modal-body">',
                            '</div>',
                            '<div class="modal-footer">',
                                '<button type="button" class="btn btn-primary notif-ok">',
                                    this.Options.textOK,
                                '</button>',
                                this.Options.type == 0 ? '' : '<button type="button" class="btn btn-primary notif-cancel">' + this.Options.textCancel + '</button>',
                            '</div>',
                        '</div>',
                      '</div>',
                    ].join(''));
            dialog.find(".modal-body").html(this.Options.message);
            if(this.Options.size == 1)
                dialog.addClass("modal-lg");
            
            return dialog;
        };

        this.GetModalElement = function () {
            return $(['<div class="modal fade" id="' + this.Options.scopeId + '" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">',
                      '</div>',
                    ].join('')).html(this.GetModalDialog());
        };

        this.DefaultDialog = function () {
            var dialog = $(this.GetModalElement());
            $(this.Options.parentId).append(dialog);
            var $that = this;
            dialog.find(".notif-ok").off("click").on("click", function (e) {
                dialog.modal("hide");
                $that.Options.onOK();
                $that.Options.onExecute();
            });

            dialog.find(".notif-cancel").off("click").on("click", function (e) {
                dialog.modal("hide");
                $that.Options.onCancel();
                $that.Options.onExecute();
            });
            return dialog;
        };

        var dialog = $(this.Options.scopeId);
        if (dialog.length <= 0)
            dialog = this.DefaultDialog(dialog);
        else
            dialog.html(this.GetModalDialog());

        if (this.Options.isTemporary) {
            dialog.on('hide.bs.modal', function () {
                $(this).removeData().remove();
            });
        }

        this.Show = function () {
            //Modal notification
            dialog.modal({ backdrop: 'static' });
            this.Options.onStartUp();
        }

        this.GetElement = function(){
            return dialog;
        }

        if (this.Options.runOnInitialize)
            this.Show();
        
    }
    /*
    Usage:
    var req = new BSAjax.AjaxRequest(
    { 
    ajaxOption: new BSAjax.AjaxOptions({validateType: 1,resultType: 1,}) 
    });
    req.Request("url", { field1 : 'value', field2 : 'value'});
    */
    BSAjax.AjaxRequest = function (options) {
        this.Options = {
            method: 'get',
            beforeSend: function (xhr, settings) { },
            ajaxOption: new BSAjax.AjaxOptions()
        };
        this.Options = $.extend({}, this.Options, options);
        var $that = this;

        this.Request = function (url, params) {
            $.ajax({
                url: url,
                type: $that.Options.method,
                data: params,
                beforeSend: function (xhr, settings) {
                    $that.Options.ajaxOption.OnBegin(xhr, settings);
                    $that.Options.beforeSend(xhr, settings);    
                }
            }).done(function (data, status, xhr) {
                if (!data)
                    return;
                $that.Options.ajaxOption.OnSuccess(data, status, xhr);
            }).fail(function (xhr, status, error) {
                $that.Options.ajaxOption.OnFailure(xhr, status, error);
            });
        };
    }

    BSAjax.AjaxProgress = {
        enabledProgress: true,
        alwaysPlace: true,
        position: 0,
        progressBar : null,
        getDefaultElement : function(){
            return $("<div>").addClass("progress").addClass("progress-striped").addClass("active")
                    .append(
                        $("<div>").addClass("progress-bar")
                            .attr("role", "progressbar")
                            .attr("aria-valuenow", "0")
                            .attr("aria-valuemin", "0")
                            .attr("aria-valuemax", "0")
                            .css("width", "100%")
                            .html("0%")            
                    );
        },
        place: function(result){
            if(result){
                if(this.position == 0)
                    $(result).prepend(this.progressBar);    
                else
                    this.progressBar.insertBefore(result);
            }
        },
        init: function(result){
            if(!this.enabledProgress)
                return;
            if($(this.progressBar).length <= 0){
                this.progressBar = this.getDefaultElement();                
                //this.place(result);
            }
            //if(this.alwaysPlace)
                this.place(result);
                        
            this.progressBar.css("display", "block").css("opacity", "1")
                .find(".progress-bar")
                //.attr("aria-valuenow", 0)
                .width("100%")
                .html("Loading...");            
        },
        onProgress: function(percentComplete){  
            if(!this.progressBar)
                return;          

            this.progressBar.find(".progress-bar")                
                .html("Loading..." + percentComplete + "%")
                //.attr("aria-valuenow", percentComplete);
                //.width(percentComplete + "%");
        },
        onComplete: function(){
            if(!this.progressBar)
                    return;
            this.progressBar.find(".progress-bar")                
                .html("Completed")
                .attr("aria-valuenow", 100)
                .width("100%");
            this.progressBar.fadeOut();
        }
    };

    BSAjax.AjaxOptions = function (options) {
        this.Options = {
            onBegin: function () { return true; },
            onFail: function (xhr) { return true; },
            initxhr: true       
            //required errorValidation options
        };
        this.Options = $.extend({}, this.Options, options);
        this.Options.ajaxProgress = $.extend({}, BSAjax.AjaxProgress, this.Options.ajaxProgress);
        var $that = this;

        this.OnBegin = function (settings) {
            if ($that.Options.validateType == 0)
                $($that.Options.validateCtrl).html("").fadeOut();
            $that.Options.ajaxProgress.init($that.Options.resultCtrl);  
            if(settings && $that.Options.initxhr){
                settings.xhr = function() {
                    var xhr = $.ajaxSettings.xhr();
//                    if(xhr.upload){
//                        xhr.upload.addEventListener("progress", function(event){
//                            var percent = 0;
//                            var position = event.loaded || event.position; /*event.position is deprecated*/
//                            var total = event.total;
//                            if (event.lengthComputable) {
//                                percent = Math.ceil(position / total * 100);
//                            }
//                            $that.OnProgress(percent);
//                        });
//                    }

                    xhr.addEventListener("progress", function(event){
                        var percent = 0;
                        var position = event.loaded || event.position; /*event.position is deprecated*/
                        var total = event.total;
                        if (event.lengthComputable) {
                            percent = Math.ceil(position / total * 100);
                        }
                        $that.OnProgress(percent);
                    });
                    return xhr;
                }
            }
           return $that.Options.onBegin(settings);
        };

        this.OnProgress = function(precentComplete){
            $that.Options.ajaxProgress.onProgress(precentComplete);
            return precentComplete;
        };

        this.OnSuccess = function (data, status, xhr) {            
            $that.Options.ajaxProgress.onComplete();
            $($that.Options.validateCtrl).html("").fadeOut();
            $that.Options.data = data;
            new BSAjax.errorValidation($that.Options);
        };

        this.OnFailure = function (xhr, status, error) {
           var goAhead = $that.Options.onFail(xhr);
           if(!goAhead)
                return false;
           var notif = new BSAjax.Notification({ title : error, message : xhr.responseText, size: 1 });
           $.each(notif.GetElement().find("table"), function(i, table){
                var clone =  $("<div style='overflow:scroll'>").html($(table).clone());               
                $(table).replaceWith(clone);
           });
           return true;
        };
    }

    //Required Jquery.form.js
    BSAjax.UploadForm = function (options) {
        this.Options = {
            form: '',
            ajaxOption: new BSAjax.AjaxOptions()
            //required errorValidation options
        };
        this.Options = $.extend({}, this.Options, options);

        var $that = this;
        $that.Options.onSuccess = function () {
            if ($($that.Options.form).length > 0)
                $($that.Options.form)[0].reset();

            if (typeof (options.onSuccess) == 'function')
                options.onSuccess();
        };

        $($that.Options.form).ajaxForm({
            beforeSend: function (xhr, settings) {
                $that.Options.ajaxOption.initxhr = false;
                return $that.Options.ajaxOption.OnBegin(settings);
            },
            uploadProgress: function (event, position, total, percentComplete) {
                 $that.Options.ajaxOption.OnProgress(percentComplete);
            },
            success: function (data, status, xhr) {       
                $that.Options.ajaxOption.OnSuccess(data, xhr.status, xhr);
            },
            complete: function (xhr) {                
            },
            error : $that.Options.ajaxOption.OnFailure
            
        });
    }

    BSAjax.DateFormat = {
        dateOptions : {
            dates: {
                months: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                monthsShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
            }
        },
        formatPart : function(formater){
            var separator = formater.match(/[.\/\-\s\:].*?/g),
				    parts = formater.split(/\W+/);
            if (!separator || !parts || parts.length === 0) {
                throw new Error("Invalid date format.");
            }
            var format = { separator: separator, parts: parts };
            return format;
        },
        dateToString: function(date, format){              
              function getSeparator(format, part, separators){
                 var index = format.indexOf(part);
                 if(index == -1)
                    return "";
                 var c = format[index + part.length];
                 if(separators.indexOf(c) != -1)
                    return c;
                 return "";
              }

              var formater = this.formatPart(format);
              var result = "";
              for (var i = 0, cnt = formater.parts.length; i < cnt; i++) {
                var seperator = getSeparator(format, formater.parts[i], formater.separator);
                switch (formater.parts[i]) {
                    case 'dd':
                    case 'd':
                        result += date.getDate() + seperator;
                        break;
                    case 'MM':
                    case 'M':
                        result += date.getMonth() + seperator;
                        break;
                    case 'MMM':
                        result += this.dateOptions.dates.monthsShort[date.getMonth() - 1] + seperator;
                        break;
                    case 'MMMM':
                        result += this.dateOptions.dates.months[date.getMonth() - 1] + seperator;
                        break;
                    case 'yy':
                        result += (date.getFullYear() + "").substr(2,2) + seperator;
                        break;
                    case 'yyyy':
                        result += date.getFullYear() + seperator;
                        break;
                    case 'hh':
                        result += date.getHours() + seperator;
                        break;
                    case 'mm':
                        result += date.getMinutes() + seperator;
                        break;
                    case 'ss':
                        result += date.getSeconds() + seperator;
                        break;
                    case 'ttt':
                        result += date.getMilliseconds() + seperator;
                        break;
                }
            }
            return result;
        }        

    };
    
    BSAjax.ParseDate = function (options) {
        this.DateOptions = {
            value: '',
            format: null,
            dates: BSAjax.DateFormat.dateOptions.dates
        };
        this.DateOptions = $.extend({}, this.DateOptions, options);
        if (!this.DateOptions.format || this.DateOptions.format == '') {
            var parser = Date.parse(this.DateOptions.value);
            if (parser != NaN)
                return new Date(parser);
            else
                return null;
        }

        //get parts
        this.parse = function (){
            //get Formated
            var format = BSAjax.DateFormat.formatPart(this.DateOptions.format);

            var parts = this.DateOptions.value.split(/\W+/),
				date = new Date(),
				val;
            date.setHours(0);
            date.setMinutes(0);
            date.setSeconds(0);
            date.setMilliseconds(0);
            date.setDate(1);
            if (parts.length === format.parts.length) {
                var year = date.getFullYear(), day = date.getDate(), month = date.getMonth();
                for (var i = 0, cnt = format.parts.length; i < cnt; i++) {
                    val = parseInt(parts[i], 10) || 1;
                    switch (format.parts[i]) {
                        case 'dd':
                        case 'd':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            date.setDate(val);
                            break;
                        case 'MM':
                        case 'M':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            month = val - 1;
                            date.setMonth(val - 1);
                            break;
                        case 'MMM':
                            month = this.DateOptions.dates.monthsShort.indexOf(parts[i]);
                            date.setMonth(month);
                            break;
                        case 'MMMM':
                            month = this.DateOptions.dates.months.indexOf(parts[i]);
                            date.setMonth(month);
                            break;
                        case 'yy':
                        case 'YY':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            year = 2000 + val;
                            date.setFullYear(2000 + val);
                            break;
                        case 'yyyy':
                        case 'YYYY':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            year = val;
                            date.setFullYear(val);
                            break;
                        case 'hh':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            date.setHours(val);
                            break;
                        case 'mm':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            date.setMinutes(val);
                            break;
                        case 'ss':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            date.setSeconds(val);
                            break;
                        case 'ttt':
                            if(!/^\d+$/.test(parts[i]))
                                return NaN;
                            date.setMilliseconds(val);
                            break;
                        default:
                            return NaN;
                            break;
                    }
                }
                return date;
            }
            return NaN;
        };

        this.GetResult = function() {
            return this.parse();
        };

        this.IsValid = function(){
            var date = NaN;
            try {
                date = this.parse();
            } catch (e) {
                return false;
            }
            if(date) return true;
            return false;
        }
    };

    BSAjax.TableSelection = function (options) {
        this.TableOptions = {
            table: '',
            selectItemName: 'cbSelectItem',
            selectAllName: 'cbSelectAll',
            allowMultipleSelect: true,
            allowRowSelect: false,
            type: 'checkbox',
            onlyRowSelection: false,
            enabledDblClick: true
        };
        this.TableOptions = $.extend({}, this.TableOptions, options);
        this.$el = $(this.TableOptions.table);
        var $that = this;
        var DEFAULT_EVENT = {
            onCheckAll: function () {
                $that.$el.find("tbody tr").addClass('selected')
                   .find("input:enabled[name=" + $that.TableOptions.selectItemName + "]")
                        .prop('checked', true);
            },
            onUncheckAll: function (excludeIndex) {
                $that.$el.find("tbody tr").removeClass('selected');
                var cbSelectItems = $that.$el.find("tbody tr input[name=" + $that.TableOptions.selectItemName + "]");

                $.each(cbSelectItems, function (index, value) {
                    var item = $(value);
                    if (item.data('index') != excludeIndex)
                        item.prop('checked', false);
                });
            },
            onCheck: function (item) {
                item.addClass('selected');
            },
            onUnCheck: function (item) {
                item.removeClass('selected');
                $that.$el.find("thead input[name=" + $that.TableOptions.selectAllName + "]").prop('checked', false);
            }      
        };

        this.trigger = function (el, name) {
            var args = Array.prototype.slice.call(arguments, 2);
            name += '.table.bsajax';
            $that.$el.trigger($.Event(name), args);
        };

        if (!this.TableOptions.onlyRowSelection) {
            // init SelectAll  
            var cbSelectAll = $that.$el.find("thead input[name=" + this.TableOptions.selectAllName + "]");
            if (cbSelectAll.length <= 0) {
                var headerRowCount = $that.$el.find("thead tr").length;
                var newCol = $that.$el.find("thead tr:eq(0)").prepend('<td></td>').find("td:eq(0)");
                if (headerRowCount > 1)
                    newCol.attr('rowspan', headerRowCount);
            }
            if (this.TableOptions.allowMultipleSelect) {

                if (cbSelectAll.length <= 0 && this.TableOptions.type == 'checkbox')
                    cbSelectAll = newCol.append('<input name="' + this.TableOptions.selectAllName + '"  type="' + this.TableOptions.type + '" />')
                              .find("input");

                cbSelectAll.off('click').on('click', function () {
                    if ($(this).prop('checked')) {
                        DEFAULT_EVENT.onCheckAll();
                        $that.trigger($that.$el, 'check-all');
                    }
                    else {
                        DEFAULT_EVENT.onUncheckAll(-1);
                        $that.trigger($that.$el, 'uncheck-all');
                    }
                });
            }



            //init SelectItem
            var cbSelectItem = $that.$el.find("tbody input[name=" + this.TableOptions.selectItemName + "]");
            if (cbSelectItem.length <= 0) {
                var newCol = $that.$el.find("tbody tr").prepend('<td></td>').find("td:eq(0)");
                cbSelectItem = newCol.append('<input name="' + this.TableOptions.selectItemName + '" type="' + this.TableOptions.type + '" />')
                .find("input");
            }
            $.each(cbSelectItem, function (index, value) {
                var item = $(value);
                item.data('index', index);
            });

            cbSelectItem.off('click').on('click', function () {
                var item = $(this);
                var row = item.parents("tr");
                if (item.prop('checked')) {
                    if (!$that.TableOptions.allowMultipleSelect)
                        DEFAULT_EVENT.onUncheckAll(item.data("index"));
                    DEFAULT_EVENT.onCheck(row);
                    $that.trigger($that.$el, 'check', item, row);
                }
                else {
                    DEFAULT_EVENT.onUnCheck(row);
                    $that.trigger($that.$el, 'uncheck', item, row);
                }
            });
        }

        //init row selection
        if (this.TableOptions.allowRowSelect || this.TableOptions.onlyRowSelection) {
            var rows = $that.$el.find("tbody tr");
            $.each(rows, function (index, value) {
                var item = $(value);
                item.css("cursor", "pointer");
                item.data('index', index);
            });
            if (!this.TableOptions.enabledDblClick) {
                rows.find("td").off("click").on("click", function () {
                    var item = $(this);
                    if (!$that.TableOptions.allowMultipleSelect)
                        DEFAULT_EVENT.onUncheckAll(item.data("index"));
                    DEFAULT_EVENT.onCheck(item);
                    $that.trigger($that.$el, 'click-row');
                });
            }
            else {
                rows.off("dblclick").on("dblclick", function () {
                    var item = $(this);
                    if (!$that.TableOptions.allowMultipleSelect)
                        DEFAULT_EVENT.onUncheckAll(item.data("index"));
                    DEFAULT_EVENT.onCheck(item);
                    $that.trigger($that.$el, 'dbl-click-row');
                });
            }
        }

        $.each($that.$el, function (index, value) {
            value.getSelected = function(){
                return $that.$el.find("tbody tr td input[name='" + $that.TableOptions.selectItemName + "']:checked");
            };  
        });
        return $that.$el;
    };

    BSAjax.Json = {
        parseDate : function(obj){
            var pattern = /Date\(([^)]+)\)/;
            var result = pattern.exec(obj);
            var dt = null;
            if(result && result.length > 1)
                dt = new Date(parseInt(result[1]));
            else{
                var tick = Date.parse(obj);
                if(tick && tick != NaN)
                    dt = new Date(tick); 
            }
                
            return dt;
        }
    };

    BSAjax.ValidateForm = function(options){
        options = $.extend({}, { form : "#", cancelSubmit : false}, options);
        var $form = $(options.form);
        $form.removeData('validator');
        $form.removeData('unobtrusiveValidation');     
        if(options.cancelSubmit)
            return true;
        $.validator.unobtrusive.parse($form); 
        return $form.validate().form();
    };

    //extend JQuery function
    // on Submit validation
    $.fn.submitValidation = function (options) {
        options = $.extend({}, $.fn.submitValidation.defaults, options);
        $(this).off("click").on("click", function (e) {
            var isValid = false;
            var $form = $(options.form);
            try {
                options.onBegin();
                $(options.alert).fadeOut();                
                if($form.length <= 0)
                    $form = $(this).parents("form"); 
                if(!options.cancelSubmit)
                    options.cancelSubmit = $(this).hasClass("cancel");
                isValid = BSAjax.ValidateForm(options);
            } catch (ex) {
                var a = ex;
            }
            if (!isValid) {                                                              
                e.preventDefault();
                if (options.alertType == 0)
                    $(options.alert).fadeIn();
                else
                    $(options.alert).modal();

                if ($(options.alert).length > 0)
                    $(options.alert)[0].focus();
                options.onInValid();
            }
            else {
                options.onValid();
            }
        });

        $(options.alertClose).off("click").on("click", function () {
            if (options.alertType == 0)
                $(options.alert).fadeOut();
            else
                $(options.alert).modal("hide");
        });
    };
    $.fn.submitValidation.defaults = { 
        alert: '.alert', 
        alertType: 0, 
        alertClose: '.alert-close', 
        cancelSubmit: false,
        form: null, 
        onBegin: function () { }, 
        onValid: function () { }, 
        onInValid: function () { } 
    };

    //Extend validation
    //Date Compare validation
    function monthDiff(d1, d2) {
        var months;
        months = (d2.getFullYear() - d1.getFullYear()) * 12;
        months -= d1.getMonth();
        months += d2.getMonth();
        return months <= 0 ? 0 : months;
    }

    function days_between(date1, date2) {

        // The number of milliseconds in one day
        var ONE_DAY = 1000 * 60 * 60 * 24;

        // Convert both dates to milliseconds
        var date1_ms = date1.getTime();
        var date2_ms = date2.getTime();

        // Calculate the difference in milliseconds
        var difference_ms = date1_ms - date2_ms;

        // Convert back to days and return
        return Math.round(difference_ms / ONE_DAY);

    }
    $.validator.addMethod("datetimeformat", function (value, element, params) {
        if(value == '')
            return true;
        date = new BSAjax.ParseDate({ value : value, format : params.format}); 
        return date.IsValid();
    });
    $.validator.unobtrusive.adapters.add('datetimeformat', ['format'],
    function (options) {
        options.rules['datetimeformat'] = options.params;
        options.messages['datetimeformat'] = options.message;
    });
    $.validator.addMethod("datecompare", function (value, element, params) {
        var $form = $(element).parents("form");
        var parts = element.name.split(".");
        var prefix = "";
        for (var i = 0; i < parts.length - 1; i++) {
            prefix = parts[i] + ".";
        }

        if (params.other.split(".").length > 0)
            prefix = "";

        var startdatevalue = $form.find('input[name="' + prefix + params.other + '"]').val();

        if (!value || !startdatevalue) return true;

        var startDate = BSAjax.ParseDate({ value: startdatevalue, format: params.format }); //Date.parse(startdatevalue);
        var valueDate = BSAjax.ParseDate({ value: value, format: params.format });  //Date.parse(value);

        switch (params.type) {
            case "0": //Day
                var range = days_between(valueDate, startDate);
                return range >= params.range;
            case "1": //Month
                var range = monthDiff(startDate, valueDate);
                return range >= params.range;
            case "2": //Year
                var range = valueDate.getFullYear() - startDate.getFullYear();
                return range >= params.range;
            default:
                break;
        }

        return true;
    });
    $.validator.unobtrusive.adapters.add('datecompare',
        ['other', 'format', 'range', 'type'],
        function (options) {
            options.rules['datecompare'] = options.params;
            options.messages['datecompare'] = options.message;
        });
} (jQuery);