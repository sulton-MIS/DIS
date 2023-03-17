
	// START TOGGLE
    var _height = 0; var change_height = false; var _disabled_button = '';
    $(document).ready(function () {
        slide_down_content();
        //_height = $("div.panel.panel-default > div.panel-body > form div:first-child").height();
        _height = $("#searchForm").innerHeight();
    });
    function slide_down_content() {
        //init
        if(_disabled_button == ''){ _disabled_button = '#search_gr'; } 
        if ($("button#ark_slide_down").length > 0) { $("#ark_slide_down").remove(); }
        var curr = '', next = '', new_height = 0;
        var target = 'div.panel.panel-default > div.panel-body > form div:first-child';
        //var target = '#searchForm';
        var html_button =
            "<div style='position: absolute; z-index: 9; top: -13px; left:0; width: 100%; text-align: right; border-right: 20px solid transparent;'>" +
                "<button style='border: none; border-radius: 50%; outline: 0;' id='ark_slide_down' type='button' class='btn-sm btn-primary'><span class='fa'></span></button>" +
            "</div>";
        $("div.panel.panel-default").prepend(html_button);
        if ($("div.panel.panel-default > div.panel-body > form div:first-child").is(":visible")) { curr = 'fa-angle-double-down'; next = 'fa-angle-double-up'; } else { curr = 'fa-angle-double-up'; next = 'fa-angle-double-down'; }
        $("button#ark_slide_down span").removeClass(curr).addClass(next);

        $("#AddFormPopup button#ark_slide_down, #Detail_ManifestNo button#ark_slide_down, #UploadVerification_Popup button#ark_slide_down").remove();
        $("button#ark_slide_down").click(function () {
            if ($("button#ark_slide_down span").hasClass('fa-angle-double-down') == false) { curr = 'fa-angle-double-up'; next = 'fa-angle-double-down'; } else { curr = 'fa-angle-double-down'; next = 'fa-angle-double-up'; }
            $("button#ark_slide_down span").removeClass(curr).addClass(next);
            if ($("div#tScrollBody").length > 0) {
                if ($(target).is(":visible")) {
                    new_height = $("div#tScrollBody").height() + _height + 30; $(target).hide(); change_height = true; $(_disabled_button).attr('disabled', 'disabled');
                } else {
                    new_height = $("div#tScrollBody").height() - _height - 30; $(target).show(); change_height = false; $(_disabled_button).removeAttr('disabled');
                }
                $("div#tScrollBody").height(new_height + 'px');
            }
        });

        $("#GridTable").bind("DOMSubtreeModified",function(){
        });
    }

    function _call_slide() {
        if (change_height == true) {
            var target = 'div.panel.panel-default > div.panel-body > form div:first-child';
            if ($(target).is(":hidden")) {
                new_height = $("div#tScrollBody").height() + _height + 30;
                $("div#tScrollBody").height(new_height + 'px');
            }
        }
    }

    function disable_button(selector) { _disabled_button = selector; }
    // END TOGGLE