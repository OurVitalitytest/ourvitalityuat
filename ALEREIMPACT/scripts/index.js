// config
var d1 = 200;
var d2 = 100;
var height = 600;
var delay = 300;
var xindent = 40;
var yindent = 100;

var subr = 70;
var subd = 50;
var subf = 5;
var subdf = 1.2;

Math.sign = function (x) {
  return x > 0 ? 1 : x < 0 ? -1 : 0;
};

$(function() {
    var container = $("#bubbles");
    var bubbles = container.children();
    container.select = function(num) {
        var t = delay;
     
        if (num === undefined) {
            //  num = Math.round(bubbles.length / 2);
            num = 0;
            t = 0;
        }
        var length = bubbles.length;
        var c = Math.max(num, length - num - 1);
        var middle = height / 2;
        var df = Math.PI / 2 / c;
        var dy = (middle - yindent) / c;
        bubbles.each(function(i) {
            var q = i - num;
            var d = q === 0 ? d1 : d2;
            var x = xindent * Math.cos(df * q);
            var y = middle + dy * q + (yindent - dy) * Math.sign(q) - d / 2;
            $(this).stop().animate({
                width: d,
                height: d,
                left: x,
                top: y
            }, t);
        });
        if (container.num !== undefined) {
            $(bubbles[container.num]).children().stop().animate({
                opacity: 0
            }, t);
        }
        $(bubbles[num]).children().stop().animate({
            opacity: 1
        }, t);
        container.num = num;
    }
    bubbles.each(function() {
        this.hitTest = function(x, y) {
            var r = this.offsetWidth / 2;
            var dx = this.offsetLeft + r - x;
            var dy = this.offsetTop + r - y;
            return (dx * dx + dy * dy < r * r);
        }
        var pr = subr / d1 * 100;
        var pd = subd / d1 * 100;
        $(this).children().each(function(i) {
            var x = pr * Math.cos(subf + subdf * i) + 50 - pd / 2;
            var y = -pr * Math.sin(subf + subdf * i) + 50 - pd / 2;
            $(this).css({
                width: pd + "%",
                height: pd + "%",
                top: y + "%",
                left: x + "%"
            });
        });
    });
    container.click(function(e) {
 
    
        var offset = container.offset();
        var x = e.pageX - offset.left;
        var y = e.pageY - offset.top;
        var i;
        for (i = bubbles.length - 1; i >= 0; i--) {

            if (bubbles[i].hitTest(x, y)) {
                if (i === container.num) {
                    alert($(e.target).data("href"));
                } else {
                    container.select(i);

                }
                return;
            }
        }
    });
    container.css({
        width: xindent + d1 + "px",
        height: height + "px"
    });
    bubbles.children().css({
        opacity: 0
    });
    container.select();
});
