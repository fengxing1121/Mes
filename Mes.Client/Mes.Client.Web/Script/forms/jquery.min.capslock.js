(function(root) {
    var capslock = {
        detect: function(e) {
            var valueCapsLock = e.keyCode ? e.keyCode : e.which; // Caps Lock　是否打开 
            var valueShift = e.shiftKey ? e.shiftKey : ((valueCapsLock == 16) ? true : false); // shift键是否按住

            if (((valueCapsLock >= 65 && valueCapsLock <= 90) && !valueShift) // Caps Lock 打开，并且 shift键没有按住 
                || ((valueCapsLock >= 97 && valueCapsLock <= 122) && valueShift)) { // Caps Lock 打开，并且按住 shift键 
                return true;
            }
            else {
                return false;
            }
        }
    };

    if (typeof define === 'function' && define.cmd) {
    	define(function(require, exports, module) {
    		module.exports = capslock;
    	});
    }
    else {
    	root.capslock = capslock;
    }
})(window);
