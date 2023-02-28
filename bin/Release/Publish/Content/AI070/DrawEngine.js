var pathCounter = 0;
var rectCounter = 0;
var circCounter = 0;
var textCounter = 0;
var fieldCounter = 0;
var setCounter = 0;
var imgCounter = 0;

var currentId = '';

var drawJsonTest = function (json) {
	console.time('drawJson');

	console.time('paper.fromJSON');

	var datas = [];
	var els = [];

	paper.fromJSON(json, function (el, data) {
		els.push(el);
		datas.push(data);

		if (data.ft && data.ft.attrs) {
			var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
			el.freeTransform.attrs = data.ft.attrs;
			el.ft = ft;
			el.freeTransform.apply();

			// detect isField
			if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
			else data.isField = false;

			var id = el.type;
			if (el.type == 'text' && data.isField) id = 'field';

			id += '_' + (currentPage + 1) + '_';

			if (el.type == 'path') id += (++pathCounter);
			else if (el.type == 'rect') id += (++rectCounter);
			else if (el.type == 'ellipse') id += (++circCounter);
			else if (el.type == 'set') id += (++setCounter);
			else if (el.type == 'text' && data.isField) id += (++fieldCounter);
			else if (el.type == 'text') id += (++textCounter);
			else if (el.type == 'image') id += (++imgCounter);

			if (data.id != undefined && data.id != null && data.id != '') id = data.id;

			if (el.type == 'text' && data.isField && mode == 'view') {
				if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
					//if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

					//todo: for now let it be
					if (data.partValue != null || data.partValue == '') {
						data.partValue = data.partValue;
						el.attr({
							'text': data.partValue.replace(/\\n/g, "\n")
						});
					}


					var bbox = el.getBBox();
					if (data.mappingType == 'B' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						console.log('before: ' + data.partValue + ' - ' + x + ' - ' + y + ' - ' + width + ' - ' + height);
						generateBarcode(data.partValue, width, height, '', function (data) {
							generateBarcodeCallback(data, x, y, width, height);
						});
					}
					else if (data.mappingType == 'Q' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateQRCode(data.partValue, width, height, '', function (data) {
							generateQRCodeCallback(data, x, y, width, height);
						});
					}
					//else if (data.mappingType == 'C') {
					if (data.pioCrossed) {
						// put diagonal line here                        
						var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
						dLine.id = 'line1';
						dLine.isUnused = true;
						dLine.attr({
							fill: "red",
							opacity: 1,
							stroke: "black",
							'stroke-width': 3
						});
					}
					//}
				}
			}
			else if (el.type == 'image') {
				// detect barcode
				el.data('isBarcode', true);
				el.data('barcodeValue', data.barcodeValue);
			}
			else if (el.type == 'rect' && data.eharigami && mode == 'view') {
				el.attr('opacity', 0.6);
				el.toFront();
				el.ft.updateHandles();
			}

			if (el.type == 'text' && el.data('underline')) {
				$(el.node).css('text-decoration', 'underline');
			}

			$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			el.id = id;

			el.data('eharigami', data.eharigami || false);
			el.data('isField', data.isField || false);
			el.data('field_name', data.fieldName || null);
			el.data('msgnovalue', data.msgNo || null);
			el.data('msgnopos', data.msgNoPos || null);
			el.data('msgnolen', data.msgNoLen || null);
			el.data('constant_character', data.constanCharacter || null);
			el.data('mapping_type', data.mappingType || null);
			el.data('is_pio', data.isPio || false);
			el.data('pio_mapped', data.pioMapped || null);
			el.data('pio_crossed', data.pioCrossed || false);
			el.data('comment', data.comment || null);
			el.data('first', data.first || false);
			el.data('second', data.second || false);
			el.data('criple', data.criple || false);
			el.data('partValue', data.partValue || null);
			el.data('eHarigamiStsD', data.eHarigamiStsD || null);
			el.data('barcodeValue', data.barcodeValue || null);
			el.data('underline', data.underline || false);

			el.click(function (e) {
				setSelectedElement(this);
			});
			el.ft.hideHandles();
		}

		if (el.type == 'image') {
			// detect barcode
			el.data('isBarcode', true);
			el.data('barcodeValue', data.barcodeValue);
		}

		return el;
	});

	for (var i = 0, len = els.length; i < len; i++) {
		var el = els[i];
		var data = datas[i];

		if (el.type == 'text' && el.data('underline')) {
			$(el.node).css('text-decoration', 'underline');
		}
	}

	console.timeEnd('paper.fromJSON');

	console.time('viewMode');

	if (mode == 'view') {
		var bot = paper.bottom;
		var bots = [];
		var rects = [];
		while (bot) {
			if (bot.data('eharigami')) {
				bot.attr('fill-opacity', 0.1);
				bot.attr('stroke-opacity', 1);
				bot.attr('stroke-width', 3);
				bots.push(bot);

				var box = bot.getBBox();
				var rect = paper.rect(box.x, box.y, box.width, box.height);
				rect.id = bot.id + '_box';
				rect.attr({
					fill: bot.attr('fill'),
					opacity: 1,
					stroke: "black",
					'stroke-opacity': 0.1
				});
				bot.data(rect.id, rect);
				rects.push(rect);
			}

			bot = bot.next;
		}

		bots.forEach(function (item) {
			item.toFront();
		});

		rects.forEach(function (item) {
			item.toBack();
		});
	}

	console.timeEnd('viewMode');

	orderShapeList($('#shapeList'));

	console.timeEnd('drawJson');
};

var drawJson = function (json) {
	var els = [];
	var datas = [];

	paper.fromJSON(json, function (el, data) {
		els.push(el);
		datas.push(data);
		//currentId = data.id

		//if (data.ft && data.ft.attrs) {
		//    var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
		//    el.freeTransform.attrs = data.ft.attrs;
		//    el.ft = ft;
		//    el.freeTransform.apply();

		//    // detect isField
		//    if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
		//    else data.isField = false;

		//    var id = el.type;
		//    if (el.type == 'text' && data.isField) id = 'field';

		//    id += '_' + (currentPage + 1) + '_';

		//    if (el.type == 'path') id += (++pathCounter);
		//    else if (el.type == 'rect') id += (++rectCounter);
		//    else if (el.type == 'ellipse') id += (++circCounter);
		//    else if (el.type == 'set') id += (++setCounter);
		//    else if (el.type == 'text' && data.isField) id += (++fieldCounter);
		//    else if (el.type == 'text') id += (++textCounter);
		//    else if (el.type == 'image') id += (++imgCounter);

		//    if (data.id != undefined && data.id != null && data.id != '') {
		//        id = data.id;
		//        var ids = id.split("_");
		//        if (el.type == 'path') pathCounter = parseInt(ids[2]);
		//        else if (el.type == 'rect') rectCounter = parseInt(ids[2]);
		//        else if (el.type == 'ellipse') circCounter = parseInt(ids[2]);
		//        else if (el.type == 'set') setCounter = parseInt(ids[2]);
		//        else if (el.type == 'text' && data.isField) fieldCounter = parseInt(ids[2]);
		//        else if (el.type == 'text') textCounter = parseInt(ids[2]);
		//        else if (el.type == 'image') imgCounter = parseInt(ids[2]);
		//    }

		//    if (el.type == 'text' && data.isField && mode == 'view') {
		//        if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
		//            //if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

		//            //todo: for now let it be
		//            if (data.partValue != null || data.partValue == '') {
		//                data.partValue = data.partValue;
		//                el.attr({
		//                    'text': data.partValue.replace(/\\n/g, "\n")
		//                });
		//            }


		//            var bbox = el.getBBox();
		//            if (data.mappingType == 'B' && !data.isPio) {
		//                var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
		//                var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
		//                var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
		//                var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
		//                //el.hide();
		//                console.log('before: ' + data.partValue + ' - ' + x + ' - ' + y + ' - ' + width + ' - ' + height);
		//                generateBarcode(data.partValue, width, height, '', function (data) {
		//                    generateBarcodeCallback(data, x, y, width, height);
		//                });
		//            }
		//            else if (data.mappingType == 'Q' && !data.isPio) {
		//                var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
		//                var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
		//                var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
		//                var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
		//                //el.hide();
		//                generateQRCode(data.partValue, width, height, '', function (data) {
		//                    generateQRCodeCallback(data, x, y, width, height);
		//                });
		//            }
		//            //else if (data.mappingType == 'C') {
		//            if (data.pioCrossed) {
		//                // put diagonal line here                        
		//                var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
		//                dLine.id = 'line1';
		//                dLine.isUnused = true;
		//                dLine.attr({
		//                    fill: "red",
		//                    opacity: 1,
		//                    stroke: "black",
		//                    'stroke-width': 3
		//                });
		//            }
		//            //}
		//        }
		//    }
		//    else if (el.type == 'image') {
		//        // detect barcode
		//        el.data('isBarcode', true);
		//        el.data('barcodeValue', data.barcodeValue);
		//    }
		//    else if (el.type == 'rect' && data.eharigami && mode == 'view') {
		//        el.attr('opacity', 0.6);
		//        el.toFront();
		//        el.ft.updateHandles();
		//    }

		//    if (el.type == 'text' && el.data('underline')) {
		//        $(el.node).css('text-decoration', 'underline');
		//    }

		//    $("#shapeList").append('<option value="' + id + '">' + id + '</option>');
		//    el.id = id;

		//    el.data('eharigami', data.eharigami || false);
		//    el.data('isField', data.isField || false);
		//    el.data('field_name', data.fieldName || null);
		//    el.data('msgnovalue', data.msgNo || null);
		//    el.data('msgnopos', data.msgNoPos || null);
		//    el.data('msgnolen', data.msgNoLen || null);
		//    el.data('constant_character', data.constanCharacter || null);
		//    el.data('mapping_type', data.mappingType || null);
		//    el.data('is_pio', data.isPio || false);
		//    el.data('pio_mapped', data.pioMapped || null);
		//    el.data('pio_crossed', data.pioCrossed || false);
		//    el.data('comment', data.comment || null);
		//    el.data('first', data.first || false);
		//    el.data('second', data.second || false);
		//    el.data('criple', data.criple || false);
		//    el.data('partValue', data.partValue || null);
		//    el.data('eHarigamiStsD', data.eHarigamiStsD || null);
		//    el.data('barcodeValue', data.barcodeValue || null);
		//    el.data('underline', data.underline || false);

		//    el.click(function (e) {
		//        setSelectedElement(this);
		//    });
		//    el.ft.hideHandles();
		//}

		//if (el.type == 'image') {
		//    // detect barcode
		//    el.data('isBarcode', true);
		//    el.data('barcodeValue', data.barcodeValue);
		//}

		//if (el.type == 'text' && el.data('underline')) {
		//    $(el.node).css('text-decoration', 'underline');
		//}

		return el;
	});

	console.time('looping');

	for (var i = 0, length = els.length; i < length; i++) {
		var el = els[i];
		var data = datas[i];

		currentId = data.id

		console.time('drawing');

		if (data.ft && data.ft.attrs) {
			console.log('Draw #' + (i + 1) + ' of ' + length);
			//var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
			//el.freeTransform.attrs = data.ft.attrs;
			//el.ft = ft;
			//el.freeTransform.apply();

			// detect isField
			if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
			else data.isField = false;

			var id = el.type;
			if (el.type == 'text' && data.isField) id = 'field';

			id += '_' + (currentPage + 1) + '_';

			if (el.type == 'path') id += (++pathCounter);
			else if (el.type == 'rect') id += (++rectCounter);
			else if (el.type == 'ellipse') id += (++circCounter);
			else if (el.type == 'set') id += (++setCounter);
			else if (el.type == 'text' && data.isField) id += (++fieldCounter);
			else if (el.type == 'text') id += (++textCounter);
			else if (el.type == 'image') id += (++imgCounter);

			if (data.id != undefined && data.id != null && data.id != '') {
				id = data.id;
				var ids = id.split("_");
				if (el.type == 'path') pathCounter = pathCounter < parseInt(ids[2]) ? parseInt(ids[2]) : pathCounter;
				else if (el.type == 'rect') rectCounter = rectCounter < parseInt(ids[2]) ? parseInt(ids[2]) : rectCounter;
				else if (el.type == 'ellipse') circCounter = circCounter < parseInt(ids[2]) ? parseInt(ids[2]) : circCounter;
				else if (el.type == 'set') setCounter = setCounter > parseInt(ids[2]) ? parseInt(ids[2]) : setCounter;
				else if (el.type == 'text' && data.isField) fieldCounter = fieldCounter < parseInt(ids[2]) ? parseInt(ids[2]) : fieldCounter;
				else if (el.type == 'text') textCounter = textCounter < parseInt(ids[2]) ? parseInt(ids[2]) : textCounter;
				else if (el.type == 'image') imgCounter = imgCounter < parseInt(ids[2]) ? parseInt(ids[2]) : imgCounter;
			}

			if (el.type == 'text' && data.isField && mode == 'view') {
				if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
					//if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

					//todo: for now let it be
					if (data.partValue != null || data.partValue == '') {
						data.partValue = data.partValue;
						el.attr({
							'text': data.partValue.replace(/\\n/g, "\n")
						});
					}


					var bbox = el.getBBox();
					if (data.mappingType == 'B' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						console.log('before: ' + data.partValue + ' - ' + x + ' - ' + y + ' - ' + width + ' - ' + height);
						generateBarcode(data.partValue, width, height, '', function (data) {
							generateBarcodeCallback(data, x, y, width, height);
						});
					}
					else if (data.mappingType == 'Q' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateQRCode(data.partValue, width, height, '', function (data) {
							generateQRCodeCallback(data, x, y, width, height);
						});
					}
					//else if (data.mappingType == 'C') {
					if (data.pioCrossed) {
						// put diagonal line here                        
						var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
						dLine.id = 'line1';
						dLine.isUnused = true;
						dLine.attr({
							fill: "red",
							opacity: 1,
							stroke: "black",
							'stroke-width': 3
						});
					}
					//}
				}
			}
			else if (el.type == 'image') {
				// detect barcode
				el.data('isBarcode', true);
				el.data('barcodeValue', data.barcodeValue);
			}
			else if (el.type == 'rect' && data.eharigami && mode == 'view') {
				el.attr('opacity', 0.6);
				el.toFront();
				el.ft.updateHandles();
			}

			if (el.type == 'text' && el.data('underline')) {
				$(el.node).css('text-decoration', 'underline');
			}

			$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			el.id = id;

			el.data('eharigami', data.eharigami || false);
			el.data('isField', data.isField || false);
			el.data('field_name', data.fieldName || null);
			el.data('msgnovalue', data.msgNo || null);
			el.data('msgnopos', data.msgNoPos || null);
			el.data('msgnolen', data.msgNoLen || null);
			el.data('constant_character', data.constanCharacter || null);
			el.data('mapping_type', data.mappingType || null);
			el.data('is_pio', data.isPio || false);
			el.data('pio_mapped', data.pioMapped || null);
			el.data('pio_crossed', data.pioCrossed || false);
			el.data('comment', data.comment || null);
			el.data('first', data.first || false);
			el.data('second', data.second || false);
			el.data('criple', data.criple || false);
			el.data('partValue', data.partValue || null);
			el.data('eHarigamiStsD', data.eHarigamiStsD || null);
			el.data('barcodeValue', data.barcodeValue || null);
			el.data('underline', data.underline || false);

			el.attrsdata = data.ft.attrs;

			el.click(function (e) {
				var ft = paper.freeTransform(this).setOpts({ draw: 'bbox' });
				this.freeTransform.attrs = this.attrsdata;
				this.ft = ft;
				this.freeTransform.apply();
				this.isFreeTransform = true;
				setSelectedElement(this);
			});

			//el.ft.hideHandles();
		}

		console.timeEnd('drawing');

		if (el.type == 'image') {
			// detect barcode
			el.data('isBarcode', true);
			el.data('barcodeValue', data.barcodeValue);
		}

		if (el.type == 'text' && el.data('underline')) {
			$(el.node).css('text-decoration', 'underline');
		}
	}

	console.timeEnd('looping');

	if (mode == 'view') {
		var bot = paper.bottom;
		var bots = [];
		var rects = [];
		while (bot) {
			if (bot.data('eharigami')) {
				bot.attr('fill-opacity', 0.1);
				bot.attr('stroke-opacity', 1);
				bot.attr('stroke-width', 3);
				bots.push(bot);

				var box = bot.getBBox();
				var rect = paper.rect(box.x, box.y, box.width, box.height);
				rect.id = bot.id + '_box';
				rect.attr({
					fill: bot.attr('fill'),
					opacity: 1,
					stroke: "black",
					'stroke-opacity': 0.1
				});
				bot.data(rect.id, rect);
				rects.push(rect);
			}

			bot = bot.next;
		}

		bots.forEach(function (item) {
			item.toFront();
		});

		rects.forEach(function (item) {
			item.toBack();
		});
	}

	orderShapeList($('#shapeList'));
};

var drawJsonForShopping = function (json) {
	paper.fromJSON(json, function (el, data) {
		currentId = data.id

		if (data.ft && data.ft.attrs) {
			var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
			el.freeTransform.attrs = data.ft.attrs;
			el.ft = ft;
			el.freeTransform.apply();

			// detect isField
			if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
			else data.isField = false;

			var id = el.type;
			if (el.type == 'text' && data.isField) id = 'field';

			id += '_' + (currentPage + 1) + '_';

			if (el.type == 'path') id += (++pathCounter);
			else if (el.type == 'rect') id += (++rectCounter);
			else if (el.type == 'ellipse') id += (++circCounter);
			else if (el.type == 'set') id += (++setCounter);
			else if (el.type == 'text' && data.isField) id += (++fieldCounter);
			else if (el.type == 'text') id += (++textCounter);
			else if (el.type == 'image') id += (++imgCounter);

			if (data.id != undefined && data.id != null && data.id != '') {
				id = data.id;
				var ids = id.split("_");
				if (el.type == 'path') pathCounter = parseInt(ids[2]);
				else if (el.type == 'rect') rectCounter = parseInt(ids[2]);
				else if (el.type == 'ellipse') circCounter = parseInt(ids[2]);
				else if (el.type == 'set') setCounter = parseInt(ids[2]);
				else if (el.type == 'text' && data.isField) fieldCounter = parseInt(ids[2]);
				else if (el.type == 'text') textCounter = parseInt(ids[2]);
				else if (el.type == 'image') imgCounter = parseInt(ids[2]);
			}

			if (el.type == 'text' && data.isField && mode == 'view') {
				if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
					//if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

					//todo: for now let it be
					if (data.partValue != null || data.partValue == '') {
						data.partValue = data.partValue;
						el.attr({
							'text': data.partValue.replace(/\\n/g, "\n")
						});
					}


					var bbox = el.getBBox();
					if (data.mappingType == 'B' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						console.log('before: ' + data.partValue + ' - ' + x + ' - ' + y + ' - ' + width + ' - ' + height);
						generateBarcode(data.partValue, width, height, '', function (data) {
							generateBarcodeCallback(data, x, y, width, height);
						});
					}
					else if (data.mappingType == 'Q' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateQRCode(data.partValue, width, height, '', function (data) {
							generateQRCodeCallback(data, x, y, width, height);
						});
					}
					//else if (data.mappingType == 'C') {
					if (data.pioCrossed) {
						// put diagonal line here                        
						var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
						dLine.id = 'line1';
						dLine.isUnused = true;
						dLine.attr({
							fill: "red",
							opacity: 1,
							stroke: "black",
                            'stroke-width': 3
						});
					}
					//}
				}
			}
			else if (el.type == 'image') {
				// detect barcode
				el.data('isBarcode', true);
				el.data('barcodeValue', data.barcodeValue);
			}
			else if (el.type == 'rect' && data.eharigami && mode == 'view') {
                el.attr('opacity', 0.6);
				el.toFront();
				el.ft.updateHandles();
			}

			if (el.type == 'text' && el.data('underline')) {
				$(el.node).css('text-decoration', 'underline');
			}

			$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			el.id = id;

			el.data('eharigami', data.eharigami || false);
			el.data('isField', data.isField || false);
			el.data('field_name', data.fieldName || null);
			el.data('msgnovalue', data.msgNo || null);
			el.data('msgnopos', data.msgNoPos || null);
			el.data('msgnolen', data.msgNoLen || null);
			el.data('constant_character', data.constanCharacter || null);
			el.data('mapping_type', data.mappingType || null);
			el.data('is_pio', data.isPio || false);
			el.data('pio_mapped', data.pioMapped || null);
			el.data('pio_crossed', data.pioCrossed || false);
			el.data('comment', data.comment || null);
			el.data('first', data.first || false);
			el.data('second', data.second || false);
			el.data('criple', data.criple || false);
			el.data('partValue', data.partValue || null);
			el.data('eHarigamiStsD', data.eHarigamiStsD || null);
			el.data('barcodeValue', data.barcodeValue || null);
			el.data('underline', data.underline || false);

			el.click(function (e) {
				setSelectedElement(this);
			});
			el.ft.hideHandles();
		}

		if (el.type == 'image') {
			// detect barcode
			el.data('isBarcode', true);
			el.data('barcodeValue', data.barcodeValue);
		}

		if (el.type == 'text' && el.data('underline')) {
			$(el.node).css('text-decoration', 'underline');
		}

		return el;
	});

	if (mode == 'view') {
		var bot = paper.bottom;
		var bots = [];
		var rects = [];
		while (bot) {
			if (bot.data('eharigami')) {
				bot.attr('fill-opacity', 0.1);
				bot.attr('stroke-opacity', 1);
				bot.attr('stroke-width', 3);
				bots.push(bot);

				var box = bot.getBBox();
				var rect = paper.rect(box.x, box.y, box.width, box.height);
				rect.id = bot.id + '_box';
				rect.attr({
					fill: bot.attr('fill'),
					opacity: 1,
					stroke: "black",
                    'stroke-opacity': 0.1
				});
				bot.data(rect.id, rect);
				rects.push(rect);
			}

			bot = bot.next;
		}

		bots.forEach(function (item) {
			item.toFront();
		});

		rects.forEach(function (item) {
			item.toBack();
		});
	}

	orderShapeList($('#shapeList'));
};

var drawJsonSet = function (json) {

	var sets = [];

	paper.fromJSON(json, function (el, data) {
		currentId = data.id

		// Recreate the set using the identifier
		if (!window[data.setName]) window[data.setName] = paper.set();
		if (!sets[data.setName]) sets.push(data.setName);

		if (data.ft && data.ft.attrs) {
			var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
			el.freeTransform.attrs = data.ft.attrs;
			el.ft = ft;
			el.freeTransform.apply();

			// detect isField
			if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
			else data.isField = false;

			var id = el.type;
			if (el.type == 'text' && data.isField) id = 'field';

			id += '_' + (currentPage + 1) + '_';

			if (el.type == 'path') id += (++pathCounter);
			else if (el.type == 'rect') id += (++rectCounter);
			else if (el.type == 'ellipse') id += (++circCounter);
			else if (el.type == 'set') id += (++setCounter);
			else if (el.type == 'text' && data.isField) id += (++fieldCounter);
			else if (el.type == 'text') id += (++textCounter);
			else if (el.type == 'image') id += (++imgCounter);

			//////if (data.id != undefined && data.id != null && data.id != '') id = data.id;

			if (el.type == 'text' && data.isField && mode == 'view') {
				if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
					//if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

					//todo: for now let it be
					if (data.partValue != null || data.partValue == '') {
						data.partValue = data.partValue;
						el.attr({
							'text': data.partValue.replace(/\\n/g, "\n")
						});
					}

					var bbox = el.getBBox();
					if (data.mappingType == 'B' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						console.log('before: ' + data.partValue + ' - ' + x + ' - ' + y + ' - ' + width + ' - ' + height);
						generateBarcode(data.partValue, width, height, '', function (data) {
							generateBarcodeCallback(data, x, y, width, height);
						});
					}
					else if (data.mappingType == 'Q' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateQRCode(data.partValue, width, height, '', function (data) {
							generateQRCodeCallback(data, x, y, width, height);
						});
					}
					//else if (data.mappingType == 'C') {
					if (data.pioCrossed) {
						// put diagonal line here                        
						var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
						dLine.id = 'line1';
						dLine.isUnused = true;
						dLine.attr({
							fill: "red",
							opacity: 1,
							stroke: "black",
							'stroke-width': 3
						});
					}
					//}
				}
			}
			else if (el.type == 'image') {
				// detect barcode
				el.data('isBarcode', true);
				el.data('barcodeValue', data.barcodeValue);
			}
			else if (el.type == 'rect' && data.eharigami && mode == 'view') {
				el.attr('opacity', 0.6);
				el.toFront();
				el.ft.updateHandles();
			}

			if (el.type == 'text' && el.data('underline')) {
				$(el.node).css('text-decoration', 'underline');
			}

			//////$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			el.id = id;

			el.data('eharigami', data.eharigami || false);
			el.data('isField', data.isField || false);
			el.data('field_name', data.fieldName || null);
			el.data('msgnovalue', data.msgNo || null);
			el.data('msgnopos', data.msgNoPos || null);
			el.data('msgnolen', data.msgNoLen || null);
			el.data('constant_character', data.constanCharacter || null);
			el.data('mapping_type', data.mappingType || null);
			el.data('is_pio', data.isPio || false);
			el.data('pio_mapped', data.pioMapped || null);
			el.data('pio_crossed', data.pioCrossed || false);
			el.data('comment', data.comment || null);
			el.data('first', data.first || false);
			el.data('second', data.second || false);
			el.data('criple', data.criple || false);
			el.data('partValue', data.partValue || null);
			el.data('eHarigamiStsD', data.eHarigamiStsD || null);
			el.data('barcodeValue', data.barcodeValue || null);
			el.data('underline', data.underline || false);

			//////el.click(function (e) {
			//////    setSelectedElement(this);
			//////});
			el.ft.hideHandles();
		}

		if (el.type == 'image') {
			// detect barcode
			el.data('isBarcode', true);
			el.data('barcodeValue', data.barcodeValue);
		}

		if (el.type == 'text' && el.data('underline')) {
			$(el.node).css('text-decoration', 'underline');
		}

		// Place each element back into the set
		window[data.setName].push(el);

		return el;
	});

	var ft = paper.freeTransform(window[sets[0]]).setOpts({ draw: 'bbox' });
	window[sets[0]].ft = ft;
	window[sets[0]].freeTransform.apply();
	var curSet = window[sets[0]];
	window[sets[0]].click(function (e) {
		setSelectedElement(curSet);
	});

	var id = 'set';
	id += '_' + (currentPage + 1) + '_';
	id += (++setCounter);
	window[sets[i]].id = id;
	$("#shapeList").append('<option value="' + id + '">' + id + '</option>');

	if (mode == 'view') {
		var bot = paper.bottom;
		var bots = [];
		var rects = [];
		while (bot) {
			if (bot.data('eharigami')) {
				bot.attr('fill-opacity', 0.1);
				bot.attr('stroke-opacity', 1);
				bot.attr('stroke-width', 3);
				bots.push(bot);

				var box = bot.getBBox();
				var rect = paper.rect(box.x, box.y, box.width, box.height);
				rect.id = bot.id + '_box';
				rect.attr({
					fill: bot.attr('fill'),
					opacity: 1,
					stroke: "black",
					'stroke-opacity': 0.1
				});
				bot.data(rect.id, rect);
				rects.push(rect);
			}

			bot = bot.next;
		}

		bots.forEach(function (item) {
			item.toFront();
		});

		rects.forEach(function (item) {
			item.toBack();
		});
	}

	orderShapeList($('#shapeList'));
};

var orderShapeList = function (optionList) {
	// get the select
	var $dd = optionList;
	if ($dd.length > 0) { // make sure we found the select we were looking for

		// save the selected value
		var selectedVal = $dd.val();

		// get the options and loop through them
		var $options = $('option', $dd);
		var arrVals = [];
		$options.each(function () {
			// push each option value and text into an array
			arrVals.push({
				val: $(this).val(),
				text: $(this).text()
			});
		});

		// sort the array by the value (change val to text to sort by text instead)
		arrVals.sort(function (a, b) {
			if (a.text > b.text) {
				return 1;
			}
			else if (a.text == b.text) {
				return 0;
			}
			else {
				return -1;
			}
		});

		// loop through the sorted array and set the text/values to the options
		for (var i = 0, l = arrVals.length; i < l; i++) {
			$($options[i]).val(arrVals[i].val).text(arrVals[i].text);
		}

		// set the selected value back
		$dd.val(selectedVal);
	}
};

//=============================ForBatch============================
var drawJsonForBatch = function (json) {
	paper.fromJSON(json, function (el, data) {
		if (data.ft && data.ft.attrs) {
			var ft = paper.freeTransform(el).setOpts({ draw: 'bbox' });
			el.freeTransform.attrs = data.ft.attrs;
			el.ft = ft;
			el.freeTransform.apply();

			// detect isField
			if (el.id.indexOf('field') !== -1 || el.isField || (el.type == 'text' && data.mappingType != null && data.mappingType != '') || (data.msgNo != null && data.msgNo != '') || (data.constanCharacter != null && data.constanCharacter != '')) data.isField = true;
			else data.isField = false;

			var id = el.type;
			if (el.type == 'text' && data.isField) id = 'field';

			if (el.type == 'path') id += (++pathCounter);
			else if (el.type == 'rect') id += (++rectCounter);
			else if (el.type == 'ellipse') id += (++circCounter);
			else if (el.type == 'set') id += (++setCounter);
			else if (el.type == 'text' && data.isField) id += (++fieldCounter);
			else if (el.type == 'text') id += (++textCounter);
			else if (el.type == 'image') id += (++imgCounter);

			if (data.id != undefined && data.id != null && data.id != '') id = data.id;

			if (el.type == 'text' && data.isField && mode == 'view') {
				if ((data.partValue != null) || (data.mappingType != null && data.mappingType != '')) {
					//if ((data.partValue != null && data.partValue != '') || (data.mappingType != null && data.mappingType != '')) {

					//todo: for now let it be
					if (data.partValue != null || data.partValue == '') {
						data.partValue = data.partValue;
						el.attr({
							'text': data.partValue.replace(/\\n/g, "\n")
						});
					}

					var bbox = el.getBBox();
					if (data.mappingType == 'B' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateBarcode(data.partValue, width, height, window.location.origin + '/Drawing/GenerateBarcode', function (data) {
							generateBarcodeCallback(data, x, y, width, height);
						});
					}
					else if (data.mappingType == 'Q' && !data.isPio) {
						var x = el.matrix.x(el.ft.attrs.x, el.ft.attrs.y);
						var y = el.matrix.y(el.ft.attrs.x, el.ft.attrs.y);
						var width = (el.ft.attrs.center.x + (el.ft.attrs.center.x - el.ft.attrs.x) - el.ft.attrs.x) * el.ft.attrs.scale.x;
						var height = (el.ft.attrs.center.y + (el.ft.attrs.center.y - el.ft.attrs.y) - el.ft.attrs.y) * el.ft.attrs.scale.y;
						//el.hide();
						generateQRCode(data.partValue, width, height, window.location.origin + '/Drawing/GenerateQRCode', function (data) {
							generateQRCodeCallback(data, x, y, width, height);
						});
					}
					//else if (data.mappingType == 'C') {
					if (data.pioCrossed) {
						// put diagonal line here                        
						var dLine = paper.path("M" + bbox.x + ',' + (bbox.y + bbox.height) + ' L' + (bbox.x + bbox.width) + ',' + bbox.y);
						dLine.id = 'line1';
						dLine.isUnused = true;
						dLine.attr({
							fill: "red",
							opacity: 1,
							stroke: "black",
							'stroke-width': 3
						});
					}
					//}
				}
			}
			else if (el.type == 'image') {
				// detect barcode
				el.data('isBarcode', true);
				el.data('barcodeValue', data.barcodeValue);
			}
			else if (el.type == 'rect' && data.eharigami && mode == 'view') {
				el.attr('opacity', 0.6);
				el.toFront();
				el.ft.updateHandles();
			}
			//else if (el.type == 'path'  && mode == 'view') {
			//    el.attr('opacity', 0.6);
			//    el.toFront();
			//    el.ft.updateHandles();
			//}

			if (el.type == 'text' && el.data('underline')) {
				$(el.node).css('text-decoration', 'underline');
			}

			//$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			//el.id = id;
			$("#shapeList").append('<option value="' + id + '">' + id + '</option>');
			el.id = id;

			el.data('eharigami', data.eharigami || false);
			el.data('isField', data.isField || false);
			el.data('field_name', data.fieldName || null);
			el.data('msgnovalue', data.msgNo || null);
			el.data('msgnopos', data.msgNoPos || null);
			el.data('msgnolen', data.msgNoLen || null);
			el.data('constant_character', data.constanCharacter || null);
			el.data('mapping_type', data.mappingType || null);
			el.data('is_pio', data.isPio || false);
			el.data('pio_mapped', data.pioMapped || null);
			el.data('pio_crossed', data.pioCrossed || false);
			el.data('comment', data.comment || null);
			el.data('first', data.first || false);
			el.data('second', data.second || false);
			el.data('criple', data.criple || false);
			el.data('partValue', data.partValue || null);
			el.data('eHarigamiStsD', data.eHarigamiStsD || null);
			el.data('barcodeValue', data.barcodeValue || null);
			el.data('underline', data.underline || false);

			el.click(function (e) {
				setSelectedElement(this);
			});
			el.ft.hideHandles();
		}

		if (el.type == 'image') {
			// detect barcode
			el.data('isBarcode', true);
			el.data('barcodeValue', data.barcodeValue);
		}

		if (el.type == 'text' && el.data('underline')) {
			$(el.node).css('text-decoration', 'underline');
		}

		return el;
	});

	if (mode == 'view') {
		var bot = paper.bottom;
		var bots = [];
		var rects = [];
		while (bot) {
			if (bot.data('eharigami')) {
				bot.attr('fill-opacity', 0.1);
				bot.attr('stroke-opacity', 1);
				bot.attr('stroke-width', 3);
				bots.push(bot);

				var box = bot.getBBox();
				var rect = paper.rect(box.x, box.y, box.width, box.height);
				rect.id = bot.id + '_box';
				rect.attr({
					fill: bot.attr('fill'),
					opacity: 1,
					stroke: "black",
					'stroke-opacity': 0.1
				});
				bot.data(rect.id, rect);
				rects.push(rect);
			}

			bot = bot.next;
		}

		bots.forEach(function (item) {
			item.toFront();
		});

		rects.forEach(function (item) {
			item.toBack();
		});
	}
};

var loadPaper = function (json, isUsingPage, isUsingList, mode) {
	if (json == null) json = pages[currentPage];
	if (json == null || json == '') json = '[]';

	if (isUsingPage) $('#pageNumberDisplay').text('Page ' + (currentPage + 1) + ' of ' + pages.length);
	if (isUsingList) $("#shapeList").children().remove();
	if (mode == undefined || mode == null || mode == '') mode = 'edit';

	pathCounter = 0;
	rectCounter = 0;
	circCounter = 0;
	textCounter = 0;
	fieldCounter = 0;
	setCounter = 0;
	imgCounter = 0;

	var pos = 0;
	paper.clear();
	drawJson(json);
};

var loadPaperForShopping = function (json, isUsingPage, isUsingList, mode) {
	if (json == null) json = pages[currentPage];
	if (json == null || json == '') json = '[]';

	if (isUsingPage) $('#pageNumberDisplay').text('Page ' + (currentPage + 1) + ' of ' + pages.length);
	if (isUsingList) $("#shapeList").children().remove();
	if (mode == undefined || mode == null || mode == '') mode = 'edit';

	pathCounter = 0;
	rectCounter = 0;
	circCounter = 0;
	textCounter = 0;
	fieldCounter = 0;
	setCounter = 0;
	imgCounter = 0;

	var pos = 0;
	paper.clear();
	drawJsonForShopping(json);
};

var loadPaperForBatch = function (json, isUsingPage, isUsingList, mode) {
	if (json == null) json = pages[currentPage];

	if (isUsingPage) $('#pageNumberDisplay').text('Page ' + (currentPage + 1) + ' of ' + pages.length);
	if (isUsingList) $("#shapeList").children().remove();
	if (mode == undefined || mode == null || mode == '') mode = 'edit';

	pathCounter = 0;
	rectCounter = 0;
	circCounter = 0;
	textCounter = 0;
	fieldCounter = 0;
	setCounter = 0;
	imgCounter = 0;

	var pos = 0;
	paper.clear();
	drawJsonForBatch(json);
};
var savePaper = function () {
	setSelectedElement(null);

	var eharigamis = [];
	var isFields = [];
	var fieldnames = [];
	var msgnos = [];
	var msgnoposs = [];
	var msgnolens = [];
	var constancharacters = [];
	var mappingtypes = [];
	var ispios = [];
	var piomappeds = [];
	var piocrosseds = [];
	var comments = [];
	var firsts = [];
	var seconds = [];
	var criples = [];
	var partValues = [];
	var eHarigamiStsDs = [];
	var barcodeValues = [];
	var underlines = [];

	var json = paper.toJSON(function (el, data) {
		data.ft = {};

		if (el.isFreeTransform) {
			if (el.freeTransform != null) {
				data.ft.attrs = el.freeTransform.attrs;
			}
		}
		else data.ft.attrs = el.attrsdata;

		data.id = el.id;
		data.eharigami = el.data('eharigami') || false;
		data.isField = el.data('isField') || false;
		data.fieldName = el.data('field_name') || null;
		data.msgNo = el.data('msgnovalue') || null;
		data.msgNoPos = el.data('msgnopos') || null;
		data.msgNoLen = el.data('msgnolen') || null;
		data.constanCharacter = el.data('constant_character') || null;
		data.mappingType = el.data('mapping_type') || null;
		data.isPio = el.data('is_pio') || false;
		data.pioMapped = el.data('pio_mapped') || null;
		data.pioCrossed = el.data('pio_crossed') || false;
		data.comment = el.data('comment') || null;
		data.first = el.data('first') || false;
		data.second = el.data('second') || false;
		data.criple = el.data('criple') || false;
		data.partValue = el.data('partValue') || null;
		data.eHarigamiStsD = el.data('eHarigamiStsD') || null;
		data.barcodeValue = el.data('barcodeValue') || null;
		data.underline = el.data('underline') || false;

		eharigamis.push(data.eharigami);
		isFields.push(data.isField);
		fieldnames.push(data.fieldName);
		msgnos.push(data.msgNo);
		msgnoposs.push(data.msgNoPos);
		msgnolens.push(data.msgNoLen);
		constancharacters.push(data.constanCharacter);
		mappingtypes.push(data.mappingType);
		ispios.push(data.isPio);
		piomappeds.push(data.pioMapped);
		piocrosseds.push(data.pioCrossed);
		comments.push(data.comment);
		firsts.push(data.first);
		seconds.push(data.second);
		criples.push(data.criple);
		partValues.push(data.partValue);
		eHarigamiStsDs.push(data.eHarigamiStsD);
		barcodeValues.push(data.barcodeValue);
		underlines.push(data.underline);

		return data;
	});

	for (var i = 0, length = eharigamis.length; i < length; i++) {
		json[i].eharigami = eharigamis[i];
		json[i].isField = isFields[i];
		json[i].fieldName = fieldnames[i];
		json[i].msgNo = msgnos[i];
		json[i].msgNoPos = msgnoposs[i];
		json[i].msgNoLen = msgnolens[i];
		json[i].constanCharacter = constancharacters[i];
		json[i].mappingType = mappingtypes[i];
		json[i].isPio = ispios[i];
		json[i].pioMapped = piomappeds[i];
		json[i].pioCrossed = piocrosseds[i];
		json[i].comment = comments[i];
		json[i].first = firsts[i];
		json[i].second = seconds[i];
		json[i].criple = criples[i];
		json[i].partValue = partValues[i];
		json[i].eHarigamiStsD = eHarigamiStsDs[i];
		json[i].barcodeValue = barcodeValues[i];
		json[i].underline = underlines[i];
	}

	return json;
};

var getPaperJson = function (page) {
	var json = null;
	pages[currentPage] = savePaper();
	var lastPage = currentPage;
	setSelectedElement(null);
	//for (var i = 0; i < pages.length; i++) {
	currentPage = page;
	loadPaper(null, true, true);
	json = pages[currentPage];
	//}

	currentPage = lastPage;
	loadPaper(null, true, true);

	return json;
};

var queryString = function (name, url) {
	if (!url) url = window.location.href;
	name = name.replace(/[\[\]]/g, "\\$&");
	var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
	if (!results) return null;
	if (!results[2]) return '';
	return decodeURIComponent(results[2].replace(/\+/g, " "));
};

String.prototype.FixForRaphael = function () {
	// based on http://goo.gl/KZDII strip off all spaces between tags
	var svgXmlNoSpace = this.replace(/>\s+/g, ">").replace(/\s+</g, "<");

	// based on gabelerner added xmlns:xlink="http://www.w3.org/1999/xlink" into svg xlmns
	//var svgXmlFixNamespace = svgXmlNoSpace.replace('xmlns="http://www.w3.org/2000/svg"', 'xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"');

	// based on http://goo.gl/KZDII image's href changed as xlink:href
	var svgXmlFixImage = svgXmlNoSpace.replace(' href="', ' xlink:href="');

	// based on gabelerner image must be under the same domain - no crossside

	return svgXmlFixImage;
};

var printImage = function (paper, canvas, postUrl, callback) {
	var svg = paper.toSVG();
	//svg = '<svg style="overflow: hidden; position: relative;" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="100%" version="1.1" height="100%"><rect transform="matrix(1,0,0,1,0,0)" x="102.81999206542969" y="59.139984130859375" width="321.8199920654297" height="103.63998413085937" rx="0" ry="0" fill="white" stroke="black" opacity="1"></rect><ellipse transform="matrix(1,0,0,1,0,0)" cx="267.8199920654297" cy="166.4099884033203" rx="68.63999938964844" ry="67.27000427246094" fill="white" stroke="black" opacity="1"></ellipse><image transform="matrix(1,0,0,1,-4.54,-6.37)" preserveAspectRatio="none" x="243.72998046875" y="153.67999267578125" width="59.089996337890625" height="40.90997314453125" xlink:href="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAL4AAAB4CAMAAAB7G7gGAAAAY1BMVEX///8AAACbm5u0tLTFxcWGhob8/Pz4+Pjz8/O7u7vg4OCQkJA+Pj6+vr6enp7Kysp0dHSurq5+fn4SEhJLS0tTU1NlZWVgYGA3NzcXFxcICAjR0dEfHx9bW1vt7e0wMDAoKCgtNP+fAAAFdUlEQVR4nO2c6bKrNgyALQgYzL5kIYDD+z9lZXnBOSfntp1pp8tIM0mMbUkfsrzkj4Vg+SelgVEMkIgKBvxYSUUPF9MoH/hUUD9TLwrYhMLCjaoGqOg3wZpWZKhmZIdVvLBGoopRE5Jszth0gV6kkKGikQRrrMcSS1dQYsNyfvpackXNN6wzakZS8pkg7AgNmcywLhEtevf4DbZ1pnN+BZje8GvC752phH5brDHvXtLTDTnm7/hXbOowVCX6t/ite3OgUN1RrX7Dfz6EWkyxz02Uq8hngrAZqTE+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zM+4zP+fxN//gfxAfGnP4OfPDeSRmSLi/6yHQ5/2yY0OSP+Nnn81uFvU4T/VALVYnw0uewG/zkSxzBhzbO1qmj34t8a1Qw+Ni+i2OpcHaY5xi9/wNedFmq1gqXOQpunnEodlkTerUJiSVGV7uyvsir4oadOGrVOeHxSRWUhClTQq/lYL8J5LN7UvC/8SGo2XnTwqT/i/w3i8f96+f/iq7TJXbEoO19UydhX9kmnJUq6Ur1Ms35stevfZL0vf8NXw9hnZeEf11S5kmwiE0KXTegTOunSy+/hK7sQkPirv0wvkpFs2jLdDibvVF7IizIrB0zlR3x7yRfcpWNewANfqWFz8+jlS4Z623TsHry1H/F1fdLLx+Rd1NBojaYL0hjLNE3tJINd6aKllVTOMCrdQlB6w8+gQgs3tzyJNIrMrjWqUWi6DaZHwA/h06mRpnc3qv2In98hDQPRuPUdyWjZxlVrIM/hBdGG8SXrF43K3Zr2xmL84joX1Kfy8fAv2ZMJ2xGHKL2/Av4BZx4ZGw9Yf41fhaAIe9ObldVe6tZRiFpvBGUmB/Jmsqe1b77aOH7BV7Tw4z605zYyvpPYrZfaWMLI5HvAL91Vcj6Gu9tnfsRPYe4uXvtyuiitYkfDUcHeJ5c4Pnlv3iixibHSLvkN3w4N7kUm+fNbCEF+Pcih2XVFs4oi4MtbFCdhRtonww/4+QHTBId75x4PDtLOtIGyxpDh9wgL7uVjbvGltXyhJDblNsTsHZ/SNt8OSU+zyAuyUMwPbb0hK9ac+Cvac52MNDCHRe0zPp5F9qQ6rH/jQrrsa2N8pYqiu1qVLcLPHzCuagDb9wf8Y5MuMo11U9QRvojx71hzzvD8EY3FO/7gkqqCG9Kqg6aVubIwrydp36s98Uk0bLkIk8uaWg9c/wDCfPuQPDb6apklOq6+RT/GN+FzRxwj5ZnKNpxZtILYF+ztOZMOX/p4rUo9JjprlN/wxRNO/Hy0vnWSVXU8+U9x+JJyv4JE4TCNSlLuE/7NrRMBv4JWKcxEZdNnBv3JbiSyX4iCMh2P2sdhwrmLsN51UQQsfu2m7uLnexdl6Bv+k/D1YlaeCrbj2GAh4v1JursbtICfxZ2Efs3FJ7uxuCs16TJOlY39OG7P3oAXdlY2YeXCItWMZLyYX842Ltzqq1USPbt13wQg7dH2DnWvRVj3J79BePzBdpqpk1ifff7JbiwDvLQJYBinvF4slzXeh9kzbHSZp8tNTZeFmsI1zNuv0j+Nbnu2n39AWuEy/Q3fdXK5373vAZ/lBjA/okMPTl2Lj/+KajybmM1VVNcXwNFYXlxq99prFNdzeL5Kgxb2LTrQuKkrckzQaw02HF/xSz+T/hB+Yf681ecCJWuXkZL+1fUuS2Eewn5sDlybDSnuM78Y4QEnEsynbR99a2IZnGbhtrFv+NHCw/KvkN8AzOBNqLjp1VcAAAAASUVORK5CYII=" fill="white" opacity="1" stroke="black"></image></svg>';

	var finalSvg = svg.FixForRaphael();

	var svgDataUrl = 'data:image/svg+xml;charset=utf-8,' + finalSvg;


	//add canvas into body        
	var canvasId = "myCanvas";
	var canvas = document.createElement('canvas');
	canvas.id = canvasId;
	var ctx = canvas.getContext('2d');
	var img = new Image();
	img.onload = function () {
		setTimeout(function () {
			canvas.width = 1200;
			canvas.height = 850;
			ctx.drawImage(img, 0, 0, canvas.width, canvas.height);

			var imageData = ctx.getImagedata(0, 0, canvas.width, canvas.height);

			document.body.appendChild(canvas);

			var dataURL = canvas.toDataURL("image/png");
			console.log(dataURL);
			dataURL = dataURL.replace(/^data:image\/(png|jpg);base64,/, "");

			$.ajax({
				url: postUrl,
				dataType: 'json',
				data: {
					base64ImageString: dataURL
				},
				type: 'POST',
				success: function (data) {
					callback(data);
				}
			});
		}, 2000);
	};

	img.src = svgDataUrl;


	//convert svg to canvas
	//canvg(canvas, finalSvg, {
	//    ignoreMouse: true,
	//    ignoreAnimation: true,
	//    renderCallback: function () {
	//    }
	//});

	//var dataURL = canvas.toDataURL("image/png").replace(/^data:image\/(png|jpg);base64,/, "");

	//var svgDataUrl = 'data:image/svg+xml;charset=utf-8,' + svg;

	//downloadPNGFromAnyImageSrc(svgDataUrl, postUrl, callback);

	//var dataURL = getBase64Image(canvasId, svg);

	//$.ajax({
	//    url: postUrl,
	//    dataType: 'json',
	//    data: {
	//        base64ImageString: dataURL
	//    },
	//    type: 'POST',
	//    success: function (data) {
	//        callback(data);
	//    }
	//});
};

var getBase64Image = function (canvas, svg) {
	var dcanvas = document.getElementById(canvas);
	var dcontext = dcanvas.getContext('2d');
	dcontext.clearRect(0, 0, dcanvas.width, dcanvas.height);

	canvg(dcanvas, svg);

	var canvas_html = document.getElementById(canvas);
	dataURL = canvas_html.toDataURL("image/png").replace(/^data:image\/(png|jpg);base64,/, "");

	return dataURL;
}

function downloadPNGFromAnyImageSrc(src, postUrl, callback) {
	//recreate the image with src recieved
	var img = new Image();

	//A3L
	img.width = 1190;
	img.height = 842;

	//when image loaded (to know width and height)
	img.onload = function () {

		//drow image inside a canvas
		var canvas = convertImageToCanvas(img);
		//get image/png from convas
		var pngImage = convertCanvasToImage(canvas);

		//download
		//var anchor = document.createElement('a');
		//anchor.setAttribute('href', pngImage.src);
		//anchor.setAttribute('download', 'image.png');
		//anchor.click();

		var dataUrl = pngImage.src.replace(/^data:image\/(png|jpg);base64,/, "");

		document.getElementById('myImg').src = pngImage.src;

		afterPrintAction(postUrl, dataUrl, callback);
	};

	img.src = src;
}

function afterPrintAction(postUrl, dataUrl, callback) {
	alert('here --> ' + postUrl);
	alert('data --> ' + dataUrl);
	$.ajax({
		url: postUrl,
		dataType: 'json',
		data: {
			base64ImageString: dataURL
		},
		type: 'POST',
		success: function (data) {
			alert('ajax');
			callback(data);
		}
	});
}

// Converts image to canvas; returns new canvas element
function convertImageToCanvas(image) {
	var canvas = document.createElement("canvas");
	canvas.width = image.width;
	canvas.height = image.height;
	canvas.getContext("2d").drawImage(image, 0, 0);
	return canvas;
}

// Converts canvas to an image
function convertCanvasToImage(canvas) {
	var image = new Image();
	image.src = canvas.toDataURL("image/png");
	//console.log(image.src);
	return image;
}

var generateBarcode = function (value, width, height, postUrl, callback) {
	if (postUrl == null || postUrl == '') postUrl = window.location.origin + '/PIS0109b/GenerateBarcode';
	var prop = {
		value: value,
		width: parseInt(width),
		height: parseInt(height)
	};
	$.ajax({
		url: postUrl,
		dataType: 'json',
		data: prop,
		type: 'POST',
		success: function (data) {
			callback(data);
		}
	});
};

var generateBarcodeCallback = function (data, x, y, w, h) {
	console.log('callback: ' + data + ' - ' + x + ' - ' + y + ' - ' + w + ' - ' + h);
	// draw qrcode
	var element = paper.image('data:image/png;base64,' + data.Base64ImageString, x, y, w, h);
	element.isUnused = true;
	element.attr({
		fill: "white",
		opacity: 1,
		stroke: "black"
	});

	var id = element.type + (++imgCounter);
	element.id = id;
};

var generateQRCode = function (value, width, height, postUrl, callback) {
	if (postUrl == null || postUrl == '') postUrl = window.location.origin + '/PIS0109b/GenerateQRCode';
	var prop = {
		Value: value,
		Width: parseInt(width),
		Height: parseInt(height)
	};
	$.ajax({
		url: postUrl,
		dataType: 'json',
		data: {
			"prop": prop
		},
		type: 'POST',
		success: function (data) {
			callback(data);
		}
	});
};

var generateQRCodeCallback = function (data, x, y, w, h) {
	// draw qrcode
	var element = paper.image('data:image/png;base64,' + data.Base64ImageString, x, y, w, h);
	element.isUnused = true;
	element.attr({
		fill: "white",
		opacity: 1,
		stroke: "black"
	});

	var id = element.type + (++imgCounter);
	element.id = id;
};


/* for undo purpose */
var states = [];

var undo = function () {

};