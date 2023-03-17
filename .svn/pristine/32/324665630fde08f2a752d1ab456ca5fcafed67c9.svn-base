$(document).ready(function () {

    /** start - event for tree grid with table grid **/
    initTableToggle();
    $(".rowtoggle").click(function () {
        doToggle(this);
    });
    /** end - event for tree grid with table grid **/


    /** start - check all checkbox **/
    $("#checkall").click(function () {
        $(".check").prop("checked", $("#checkall").is(":checked"));
    });
    /** end - check all checkbox **/


    /** use class _datepicker to generate datepicker on input text element **/
    $("._datepicker").datepicker({
        autoclose: true,
        format: 'dd-mm-yyyy'
    });

    /** use class _monthpicker to generate month picker on input text element **/
    //$("._monthpicker").datepicker({
    //    autoclose: true,
    //    format: 'mm-yyyy',
    //    minViewMode: 'months'
    //});

    /** use class _yearpicker to generate year picker on input text element **/
    //$("._yearpicker").datepicker({
    //    autoclose: true,
    //    format: 'yyyy',
    //    minViewMode: 'years'
    //});
});

/*** Event ***/

/** use class _number-only on input text element to number formatting **/
$("._number-only").keypress(function (event) {
    return isNumberOnly(event);
});


/*** Method ***/
//add by septareosagita@gmail.com // 1 Februari 2017
function CheckIsObject(m) {
    if (typeof m == 'object') {
        try { m = JSON.stringify(m); }
        catch (err) { return false; }
    }

    if (typeof m == 'string') {
        try { m = JSON.parse(m); }
        catch (err) { return false; }
    }

    if (typeof m != 'object') { return false; }
    return true;
}


/** initialize table tree **/
function initTableToggle() 
{
    /** @author  Argyaputri **/
    $(".tb-expand td:first-child").prepend('<span class="rowtoggle rowexpand"><i class="fa fa-minus-square-o fa-fw"></i></span> ');
    $(".tb-collapse td:first-child").prepend('<span class="rowtoggle rowcollapse"><i class="fa fa-plus-square-o fa-fw"></i></span> ');

    var header = $(".tb-collapse");
    header.each(function () {
        $(this).next().toggleClass("hide", "");
    });

}

/** set table tree toggle action 
    param: object parent**/
function setTableToogle(p) 
{
    /** @author  Argyaputri **/
    $(".rowexpand").html('<i class="fa fa-minus-square-o fa-fw"></i> ');
    $(".rowcollapse").html('<i class="fa fa-plus-square-o fa-fw"></i> ');

    $(p).next().toggleClass("hide", "");
}

/** action table tree fo toggle all 
    param: 1 = collapse; 0 = expand; **/
function tableToggleAll(aToggle)
{
    /** @author  Argyaputri **/
    if (aToggle == 1) {
        $("tr.tb-expand").next().toggleClass("hide", "");
        $("tr.tb-expand").addClass("tb-collapse");
        $("tr.tb-expand").removeClass("tb-expand");

        $(".rowtoggle.rowexpand").toggleClass("rowcollapse", "");
        $(".rowtoggle.rowcollapse").removeClass("rowexpand");
    } else {
        $("tr.tb-collapse").next().toggleClass("hide", "");
        $("tr.tb-collapse").addClass("tb-expand");
        $("tr.tb-collapse").removeClass("tb-collapse");

        $(".rowtoggle.rowcollapse").toggleClass("rowexpand", "");
        $(".rowtoggle.rowexpand").removeClass("rowcollapse");
    }

    $(".rowexpand").html('<i class="fa fa-minus-square-o fa-fw"></i> ');
    $(".rowcollapse").html('<i class="fa fa-plus-square-o fa-fw"></i> ');
}

function doToggle(obj) {
    $(obj).toggleClass("rowexpand", "");
    $(obj).toggleClass("rowcollapse", "");

    var p1 = $(obj).parentsUntil("tr");
    var p2 = $(p1).parent();
    $(p2).toggleClass("tb-collapse", "");
    $(p2).toggleClass("tb-expand", "");
    setTableToogle(p2);
}

/**
* desc : Number only format that trigger on pressing keyboard
* 
* @author  Argyaputri
* @date    17 Nov 2014
* @param   {Event} evt
* @use     onkeypress="javascript: isNumberOnly(event);"
*/
function isNumberOnly(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function oncheckall() {
    $("#checkall").click(function () {
        $(".check").prop("checked", $("#checkall").is(":checked"));
    });
}