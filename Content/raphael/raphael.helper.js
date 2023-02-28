(function (R) {
    var cloneSet; // to cache set cloning function for optimisation

    /**
     * Clones Raphael element from one paper to another
     *
     * @param {Paper} targetPaper is the paper to which this element
     * has to be cloned
     *
     * @return RaphaelElement
     */
    R.el.cloneToPaper = function (targetPaper) {
        return (!this.removed &&
            targetPaper[this.type]().attr(this.attr()));
    };

    /**
     * Clones Raphael Set from one paper to another
     *
     * @param {Paper} targetPaper is the paper to which this element
     * has to be cloned
     *
     * @return RaphaelSet
     */
    R.st.cloneToPaper = function (targetPaper) {
        targetPaper.setStart();
        this.forEach(cloneSet || (cloneSet = function (el) {
            el.cloneToPaper(targetPaper);
        }));
        return targetPaper.setFinish();
    };
}(Raphael));

(function () {

    var shapeToObject = function (shape, arr) {
        if (shape.type == "set") {
            var aSet = shape;
            shape.forEach(function (shape) {
                shapeToObject(shape, arr)
            });
            return;
        }
        else {
            var obj = shape.attr();
            obj["type"] = shape.type;
            arr.push(obj);
        }
    };
    /**
    * @return an array on objects as described in Paper.add()
    */
    Raphael.el.writeToObject = function () {
        var a = [];
        shapeToObject(this, a);
        return a;
    };
    /**
    * @return an json string with structure described in Paper.add()
    */
    Raphael.el.writeToString = function () {
        var a = this.writeToObject();
        var sb = [];
        for (var i = 0; i < a.length; i++) {
            var shapeDesc = a[i], sb2 = [];
            sb2.push('"type":' + "\"" + shapeDesc.type + "\"");
            for (var attrName in shapeDesc) {
                val = (shapeDesc[attrName] + "").replace(/\"/g, "\\\"");
                sb2.push('"' + attrName + '":"' + val + "\"");
            }
            var s = "{" + sb2.join(",") + "}";
            if (i < a.length - 1)
                s += ","
            sb.push(s);
        }
        return sb.join(",")
    };
    Raphael.st.writeToObject = function () {
        var a = [];
        this.forEach(function (shape) {
            a = a.concat(shape.writeToObject());
        });
        return a;
    };
    /**
    * @return a json object just like expected by paper.add
    */
    Raphael.st.writeToString = function () {
        var a = [];
        this.forEach(function (shape) {
            a = a.concat(shape.writeToString());
        });
        return "[" + a.join(",") + "]";
    };
    /**
    * @return a json object just like expected by paper.add
    */
    Raphael.fn.writeToObject = function () {
        var a = [];
        this.forEach(function (shape) {
            a = a.concat(shape.writeToObject());
        });
        return a;
    };
    /**
    * @return a json object just like expected by paper.add
    */
    Raphael.fn.writeToString = function () {
        var a = [];
        this.forEach(function (shape) {
            a = a.concat(shape.writeToString());
        });
        return "[" + a.join(",") + "]";
    };
})();