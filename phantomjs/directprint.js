var page = require('webpage').create();
var system = require('system');

if (system.args.length < 2) {
    console.log('Try to pass some args when invoking this script');
    phantom.exit();
}
else {
    var address = system.args[1];
    address = address.replace(/@/gi,"&");
    page.open(address, function (status) {
        if (status !== 'success') {
            console.log('Unable to access network');
        } else {
            var ua = page.evaluate(function () {
                var btn = document.getElementById('btnExport');
                btn.click();
                return btn.id;
            });
            console.log(ua);
        }

        // to allow page processing the request
        setTimeout(function () {
            phantom.exit();
        }, 5000);
    });
}