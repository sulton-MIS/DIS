$(document).ready(function () {

    var t = 20; // отступ
    var l = 20; // отступ
    var currentSelection = null;
    var error_life = 10000;
    var max_width = 8192;
    var max_height = 8192;
    var max_rows = 32;
    var max_cols = 32;
    var max_start_selection = {
        width: 168,
        height: 105
    }
    var headerAndFooterHeight = 46;

    var mouseX = 0;
    var mouseY = 0;
    var ias;
    var currentAction = 'resize';

    function process_resize() {
        if (!$('#width').val() || $('#width').val() < 1) {
            error('Incorrect width', function () {
                $('#width').focus()
            })
            return false;
        } else if ($('#width').val() > max_width) {
            error('Width limit exceeded. <br />Maximum size: ' + max_width + ' x ' + max_height, function () {
                $('#width').focus()
            })
            return false;
        } else if (!$('#height').val() || $('#height').val() < 1) {
            error('Incorrect height.', function () {
                $('#height').focus()
            })
            return false;
        } else if ($('#height').val() > max_height) {
            error('Height limit exceeded. <br />Maximum size: ' + max_width + ' x ' + max_height, function () {
                $('#height').focus()
            })
            return false;
        }

        window.location.href = '/convert?width=' + parseInt($('#width').val()) + '&height=' + parseInt($('#height').val()) + '&format=' + $('#format').val();
        return true;
    }

    function process_split() {
        if (!$('#row').val() || $('#row').val() < 1) {
            error('Incorrect rows number', function () {
                $('#row').focus()
            });
            return false;
        } else if ($('#row').val() > max_rows) {
            error('Rows limit exceeded. <br />Maximum size: ' + max_rows + ' x ' + max_cols, function () {
                $('#row').focus()
            })
            return false;
        } else if (!$('#col').val() || $('#col').val() < 1) {
            error('Incorrect columns number.', function () {
                $('#col').focus()
            });
            return false;
        } else if ($('#col').val() > max_cols) {
            error('Columns limit exceeded. Maximum size: ' + max_rows + ' x ' + max_cols, function () {
                $('#col').focus()
            })
            return false;
        }

        window.location.href = '/split?row=' + parseInt($('#row').val()) + '&column=' + parseInt($('#col').val()) + '&format=' + $('#format').val();
        return true;
    }

    function process_crop() {
        if (!$('#x1').val().length || $('#x1').val() > width || $('#x1').val() < 0) {
            error('Incorrect left value', function () {
                $('#x1').focus()
            });
            return false;
        } else if (!$('#y1').val().length || $('#y1').val() > height || $('#y1').val() < 0) {
            error('Incorrect top value', function () {
                $('#y1').focus()
            })
            return false;
        } else if (!$('#w').val().length || parseInt($('#w').val()) + parseInt($('#x1').val()) > width || parseInt($('#w').val()) < 1) {
            error('Incorrect width value', function () {
                $('#w').focus()
            })
            return false;
        } else if (!$('#h').val().length || parseInt($('#h').val()) + parseInt($('#y1').val()) > height || parseInt($('#h').val()) < 1) {
            error('Incorrect height value', function () {
                $('#h').focus()
            })
            return false;
        }

        window.location.href = '/crop?left=' + parseInt($('#x1').val()) + '&top=' + parseInt($('#y1').val()) + '&width=' + parseInt($('#w').val()) + '&height=' + parseInt($('#h').val()) + '&format=' + $('#format').val();
        return true;
    }

    function moveSelection() {
        var x_offset = 60;
        var y_offset = 60;
        if (mouseX + x_offset > $(window).width()) {
            $('#content').scrollLeft($('#content').scrollLeft() + 30);
            ias.update();
        }
        if (mouseY + y_offset > $(window).height()) {
            $('#content').scrollTop($('#content').scrollTop() + 30);
            ias.update();
        }
        //if (mouseX - x_offset < 0) $('#content').scrollLeft($('#content').scrollLeft() - 30);
        //if (mouseY - y_offset < $('#content').offset().top) $('#content').scrollTop($('#content').scrollTop() - 30);
    }

    function preview(img, selection) {
        if (!selection.width || !selection.height) return;

        var max_wraper_height = 126;
        var max_wraper_width = 234;
        var ratio = max_wraper_width / max_wraper_height;
        var selectionRatio = selection.width / selection.height;

        if (ratio < selectionRatio) {
            var scale = max_wraper_width / selection.width;
            var prev_height = max_wraper_width / selectionRatio;
            $('#prew_wraper').css({height: prev_height, marginTop: -(prev_height / 2), marginLeft: -(max_wraper_width / 2), width: max_wraper_width});
        } else {
            var scale = max_wraper_height / selection.height;
            var prev_width = max_wraper_height * selectionRatio;
            $('#prew_wraper').css({width: prev_width, marginLeft: -(prev_width / 2), marginTop: -(max_wraper_height / 2), height: max_wraper_height});
        }

        if ($('#prew_image').length) {
            $('#prew_image').css({
                width: scale * width,
                height: scale * height,
                marginLeft: -(scale * selection.x1),
                marginTop: -(scale * selection.y1)
            });
        }

        $('#x1').val(selection.x1);
        $('#y1').val(selection.y1);
        $('#w').val(selection.width);
        $('#h').val(selection.height);

        currentSelection = selection;
    }

    function updateSelection() {
        if (!/\d+/.test($('#x1').val()) || parseInt($('#x1').val()) > width || !/\d+/.test($('#y1').val()) || parseInt($('#y1').val()) > height || !/\d+/.test($('#w').val()) || (parseInt($('#w').val()) + parseInt($('#x1').val())) > width || !/\d+/.test($('#h').val()) || (parseInt($('#h').val()) + parseInt($('#y1').val())) > height
            ) ias.setOptions({ hide: true });
        else {
            ias.setSelection(parseInt($('#x1').val()), parseInt($('#y1').val()), parseInt($('#w').val()) + parseInt($('#x1').val()), parseInt($('#h').val()) + parseInt($('#y1').val()), true);
            ias.setOptions({ show: true, hide: false });
            preview(img, ias.getSelection());
        }
    }

    $('#x1, #y1, #w, #h').blur(updateSelection).keyup(updateSelection);

    $(document).mousemove(function (e) {
        mouseX = e.pageX;
        mouseY = e.pageY;
    });

    function canculate_sizes() {
        //debugger
        if ($('#ratio').attr('checked')) {
            if ($(this).attr('id') == 'width') {
                if (!$('#width').val()) return;
                size = parseInt($('#width').val() / ratio);
                $('#height').val(size);
            }
            else {
                if (!$('#height').val()) return;
                size = parseInt($('#height').val() * ratio);
                $('#width').val(size);
            }
        }
    }

    $('#width').val(width);
    $('#height').val(height);
    $('#width, #height').blur(canculate_sizes).keyup(canculate_sizes);
    $('#ratio').change(function () {
        $('#width').trigger('keyup');
    })

    $(window).resize(updateContentHeight);

    var img = new Image();
    var mainImg;
    var content = $('#content');

    // просчитываем размер превью
    function updateContentHeight() {
        var h = $(window).height() - $('#toolbar').height() - headerAndFooterHeight;
        content.height(h);
        if (mainImg) {
            mainImg.css({margin: '0 auto'});
            updateMainImageSizes();
        }

        if ($('#full_image').length) {
            if (mainImg.height() < h) mainImg.css('margin-top', (h - mainImg.height()) / 2);
        }
    }

    // пересчитываем размеры изображения
    function updateMainImageSizes() {
        if (currentAction != 'resize') {
            mainImg.css({height: height, width: width});
        } else {
            if (content.height() < height || content.width() < width) {
                if (content.height() / mainImg.height() > content.width() / mainImg.width()) {
                    mainImg.width(content.width());
                    mainImg.height(content.width() / ratio);
                } else {
                    mainImg.height(content.height());
                    mainImg.width(Math.floor(content.height() * ratio));
                }
            }
        }
        updateGridElSize();
    }

    // накладывание сетки при сплите
    function showGrig(x, y) {
        //debugger
        $('.grid-h-el').remove();
        var grid = $('.grid');
        for (var i = 0; i < y; i++) grid.append($('<div class="grid-h-el"></div>'));
        grid.find('.grid-h-el').each(function () {
            for (var i = 0; i < x; i++) $(this).append($('<div class="grid-v-el"></div>'));
        });
        //debugger
        mainImg.append(grid);
        updateGridElSize();
    }

    function updateGridElSize() {
        //debugger
        $('.grid').width(0).height(0);
        var rowsNum = $('.grid-h-el').length
        var colsNum = $('.grid-v-el').length / rowsNum;
        var elWidth = Math.floor(mainImg.width() / colsNum);
        var elHeight = Math.floor(mainImg.height() / rowsNum);
        $('.grid-h-el').height(elHeight);
        $('.grid-v-el').width(elWidth);
        $('.grid').width(elWidth * colsNum).height(elHeight * rowsNum);
    }

    $('#row, #col').keyup(function () {
        //debugger
        showGrig($('#col').val(), $('#row').val())
    });

    img.onload = function () {
        //debugger
        mainImg = $('<div id="full_image" unselectable="on" selectable="false" onfocus="this.blur()" oncontextmenu="return false" style="position: relative; width: ' + img.width + 'px; height: ' + img.height + 'px">\
                        <img src="' + img.src + '" style="width: 100%; height: 100%; display: block;"/><div class="grid"><div class="lb"></div><div class="tb"></div></div></div>');
        $('#content').html(mainImg);
        $('#prew_wraper').html('<img src="' + img.src + '" alt="preview" id="prew_image" />');
        ias = $('#full_image').imgAreaSelect({handles: true, fadeSpeed: 200, onSelectChange: moveSelection, onSelectEnd: preview, instance: true, disable: true, fadeSpeed: 0, keys: { arrows: 15, ctrl: 5, shift: 'resize'}, parent: $('#full_image').parent()  });
        $('#content div:not(#full_image)').bind('contextmenu rightclick', function (e) {
            e.preventDefault();
            ias.setOptions({ hide: true });
            return false;
        });
        updateContentHeight();
    }
    img.src = '/preview.png';

    function setActiveTab(tabIndex) {
        currentAction = tabIndex;
        $('#toolbar > div').hide();
        $('#toolbar #' + tabIndex).show();
        $('#nav li').removeClass('current');
        $('#nav a[rel="' + tabIndex + '"]').parent().addClass('current');
        $('#toolbar_button input').val(tabIndex + ' image');
        $('.grid').hide();
        if (currentAction == 'split') {
            $('.grid').show();
            showGrig($('#col').val(), $('#row').val())
        }
    }

    $('#processButton').click(function () {
        switch (currentAction) {
            case 'resize':
                process_resize();
                break;
            case 'split':
                process_split();
                break;
            case 'crop':
                process_crop();
                break;
        }
    });

    // смена раздела
    $('#nav a').click(function () {
        setActiveTab($(this).attr('rel'));
        updateContentHeight();

        if (this.rel != "crop") {
            // прячем выделение если операция не кроп
            ias.setOptions({ hide: true, disable: true });
            ias.update();
        } else {
            // если есть пользовательское выделение ставим его
            if (currentSelection != null) {
                ias.setSelection(currentSelection.x1, currentSelection.y1, currentSelection.x2, currentSelection.y2, true);
            }
            // в противном случае рассчитываем область для выделения
            else {
                if ((max_start_selection.width + l) > width) {
                    max_start_selection.width = parseInt(width / 2);
                    l = parseInt(width / 6);
                }
                if ((max_start_selection.heigth + t) > height) {
                    max_start_selection.height = parseInt(height / 2);
                    t = parseInt(height / 6);
                }
                ias.setSelection(l, t, max_start_selection.width + l, max_start_selection.height + t, true);
            }

            ias.setOptions({ show: true, hide: false, disable: false });
            preview('', ias.getSelection());
        }


        return false;
    });

    $('input[type="text"]').onlyDigits();
    setActiveTab('resize');
    updateContentHeight();
});