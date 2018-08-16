/**
 * @name Uploader.js
 * @author Jiang
 * @create	2012-12-20
 * @version 0.1
 * @description	The Annouse funtion for HTML5/FLASH/FORM upload method. The
 * 	function will autoly to choose the property method to ajust to client
 *  Browswer. This js function mainly borrow from youku.com's uploader.min.js
 *  and try to re-create it for fullfiting my requirement. 
 * @example
 * 		1. new Stream();
 * 		2. var cfg = {
 * 				extFilters : [".txt", ".gz"],
 * 				fileFieldName : "FileData"
 * 			};
 * 		   new Stream(cfg);
 */ 
(function(){
	var Provider, nIdCount = 0, aOtherBrowsers = ["Maxthon", "SE 2.X", "QQBrowser"],
		nZero = 0, sOneSpace = " ", sLBrace = "{", sRBrace = "}",
		ga = /(~-(\d+)-~)/g, rLBrace = /\{LBRACE\}/g, rRBrace = /\{RBRACE\}/g,
		ea = {
			"&" : "&amp;",
			"<" : "&lt;",
			">" : "&gt;",
			'"' : "&quot;",
			"'" : "&#x27;",
			"/" : "&#x2F;",
			"`" : "&#x60;"
		}, pa = Array.isArray && /\{\s*\[(?:native code|function)\]\s*\}/i.test(Array.isArray)
			? Array.isArray
			: function(a) {return "array" === fToString(a)},
		sStreamMessagerId = "i_stream_message_container",
		sCellFileTemplate = '<b class="stream-uploading-ico"></b>' +
					'<div class="stream-file-name"><strong></strong></div>' +
					'<div class="stream-process">' +
					'	<a class="stream-cancel" href="javascript:void(0)">\u5220\u9664</a>' +
					'	<span class="stream-process-bar"><span style="width: 0%;"></span></span>' +
					'	<span class="stream-percent">0%</span>' +
					'</div>' +
					'<div class="stream-cell-infos">' +
					'	<span class="stream-cell-info">\u901f\u5ea6\uff1a<em class="stream-speed"></em></span>' +
					'	<span class="stream-cell-info">\u5df2\u4e0a\u4f20\uff1a<em class="stream-uploaded"></em></span>' +
					'	<span class="stream-cell-info">\u5269\u4f59\u65f6\u95f4\uff1a<em class="stream-remain-time"></em></span>' +
					'</div>',
		sTotalContainer = '<div id="#totalContainerId#" class="stream-total-tips">' +
			'	\u4e0a\u4f20\u603b\u8fdb\u5ea6\uff1a<span class="stream-process-bar"><span style="width: 0%;"></span></span>' +
			'	<span class="stream-percent">0%</span>\uff0c\u5df2\u4e0a\u4f20<strong class="_stream-total-uploaded">&nbsp;</strong>' +
			'	\uff0c\u603b\u6587\u4ef6\u5927\u5c0f<strong class="_stream-total-size">&nbsp;</strong>' +
			'</div>',
		sFilesContainer	= '<div class="stream-files-scroll" style="height: #filesQueueHeight#px;"><ul id="#filesContainerId#"></ul></div>';
	
	function fGenerateId(prefix) {
		var b = (new Date).getTime() + "_01v_" + ++nIdCount;
		return prefix ? prefix + "_" + b : b;
	}
	function fGetRandom() {
		return (new Date).getTime().toString().substring(8);
	}
	function fExtend(a, b){
		var c = 2 < arguments.length ? [arguments[2]] : null;
		return function(){
			var d = "string" === typeof a ? b[a] : a,e=c ? [arguments[0]].concat(c) : arguments;
			return d.apply(b||d, e);
		};
	}
	
	function fAddEventListener(a, b, c) {
		a.addEventListener ? a.addEventListener(b, c, !1) : a.attachEvent ? a
				.attachEvent("on" + b, c) : a["on" + b] = c;
	}
	
	function fRemoveEventListener(a, b, c) {
		a.removeEventListener ? a.removeEventListener(b, c, !1) : a.detachEvent
				? a.detachEvent("on" + b, c)
				: a["on" + b] = null;
	}
	
	function fToString(a) {
		var b = {
			"undefined" : "undefined",
			number : "number",
			"boolean" : "boolean",
			string : "string",
			"[object Function]" : "function",
			"[object RegExp]" : "regexp",
			"[object Array]" : "array",
			"[object Date]" : "date",
			"[object Error]" : "error"
		};
		return b[typeof a] || b[Object.prototype.toString.call(a)] || (a ? "object" : "null");
	}
	
	function fAddVars(json, url, c) {
		var _array = [], _sep = "&", f = function(json, c) {
			var e = url ? /\[\]$/.test(url) ? url : url + "[" + c + "]" : c;
			"undefined" != e && "undefined" != c
				&& _array.push("object" === typeof json
							? fAddVars(json, e, !0)
							: "[object Function]" === Object.prototype.toString.call(json)
								? encodeURIComponent(e) + "=" + encodeURIComponent(json())
								: encodeURIComponent(e) + "=" + encodeURIComponent(json))
		};
		if (!c && url)
			_sep = /\?/.test(url) ? /\?$/.test(url) ? "" : "&" : "?",
			_array.push(url),
			_array.push(fAddVars(json));
		else if ("[object Array]" === Object.prototype.toString.call(json)
				&& "undefined" != typeof json)
			for (var g = 0, c = json.length; g < c; ++g)
				f(json[g], g);
		else if ("undefined" != typeof json && null !== json && "object" === typeof json)
			for (g in json)
				f(json[g], g);
		else
			_array.push(encodeURIComponent(url) + "=" + encodeURIComponent(json));
		return _array.join(_sep).replace(/^&/, "").replace(/%20/g, "+")
	}
	
	function fMergeJson(base, extend) {
		var result = {};
		for (var attr in base)
			result[attr] = base[attr];
		for (var attr in extend)
			result[attr] = extend[attr];
		return result;
	}
	
	function fAddClass(element, klass) {
		fHasClass(element, klass) || (element.className += " " + klass);
	}
	
	function fHasClass(element, klass) {
		return RegExp("(^| )" + klass + "( |$)").test(element.className);
	}
	
	function fRemoveClass(element, klass) {
		element.className = element.className.replace(RegExp("(^| )" + klass + "( |$)"), " ")
				.replace(/^\s+|\s+$/g, "");
	}
	
	function fContains(container, klass) {
		if (!container)
			return [];
		if (container.querySelectorAll)
			return container.querySelectorAll("." + klass);
		for (var c = [], eles = container.getElementsByTagName("*"), e = eles.length, f = 0; f < e; f++)
			fHasClass(eles[f], klass) && c.push(eles[f]);
		return c;
	}
	
	function fCreateContentEle(content) {
		var b = document.createElement("div");
		b.innerHTML = content;
		content = b.childNodes;
		return content[0].parentNode.removeChild(content[0]);
	}
	
	function fShowMessage(msg, warning) {
		var o = document.getElementById(sStreamMessagerId);
		o && (o.innerHTML += "<br>" + (!!warning ? ("<span style='color:red;'>" + msg + "</span>"): msg)) && (o.scrollTop = o.scrollHeight);
	}
	
	function fMessage(msg, VarVals, c, d) {
		for (var nLIndex, nRIndex, sepIndex, argName, secondVar, s = [], _argName, length = msg.length;;) {
			nLIndex = msg.lastIndexOf(sLBrace, length);
			if (0 > nLIndex)
				break;
			nRIndex = msg.indexOf(sRBrace, nLIndex);
			if (nLIndex + 1 >= nRIndex)
				break;
			argName = _argName = msg.substring(nLIndex + 1, nRIndex);
			secondVar = null;
			sepIndex = argName.indexOf(sOneSpace);
			-1 < sepIndex && (secondVar = argName.substring(sepIndex + 1), argName = argName.substring(0, sepIndex));
			sepIndex = VarVals[argName];
			c && (sepIndex = c(argName, sepIndex, secondVar));
			"undefined" === typeof sepIndex && (sepIndex = "~-" + s.length + "-~", s.push(_argName));
			msg = msg.substring(0, nLIndex) + sepIndex + msg.substring(nRIndex + 1);
			d || (length = nLIndex - 1);
		}
		return msg.replace(ga, function(msg, VarVals, c) {
					return sLBrace + s[parseInt(c, 10)] + sRBrace
				}).replace(rLBrace, sLBrace).replace(rRBrace, sRBrace);
	}
	
	function fIsObjOrFun(a, b) {
		var c = typeof a;
		return a && ("object" === c || !b && ("function" === c || "function" === fToString(a))) || !1;
	}
	function fIsNumber(val) {
		return "number" === typeof val && isFinite(val);
	}
	function fIsArray(val) {
		return "array" === fToString(val);
	}
	function fGetStyle(el,name) { 
		if (window.getComputedStyle)
			return window.getComputedStyle(el, null)[name];
		else
			return el.currentStyle[name]; 
	}
	function fGetWidth(el) { 
		var val = el.offsetWidth, which = ['Left', 'Right']; 
		// display is none 
		if(val === 0) return 0; 

		for(var i = 0, a; a = which[i++];) { 
			val -= parseFloat(fGetStyle(el, "border" + a + "Width") ) || 0; 
			val -= parseFloat(fGetStyle(el, "padding" + a) ) || 0; 
		} 
		return val + 'px'; 
	}
	function fGetHeight(el) { 
		var val = el.offsetHeight, which = ['Top', 'Bottom']; 
		// display is none 
		if(val === 0) return 0;

		for(var i = 0, a; a = which[i++];) { 
			val -= parseFloat(fGetStyle(el, "border" + a + "Width") ) || 0; 
			val -= parseFloat(fGetStyle(el, "padding" + a) ) || 0; 
		} 
		return val + 'px'; 
	}
		
	/**
	 * This function is for registering the function(s) on its prototype.
	 * @hostPrototype	which is its host prototype.
	 * @funs	functions, such as{aa:function(){}, bb:function(){}}
	 * @forseReg	boolean: when the @hostPrototype don't have the function, then register it.
	 * 		true: do it, ignore the @hostPrototype whether has it.
	 * 		false: when not have it so that register it.
	 */
	function fRegFuns(hostPrototype, funs, forseReg, d) {
		var e, f, g;
		if (!hostPrototype || !funs)
			return hostPrototype || {};
		if (d)
			for (e = 0, g = d.length; e < g; ++e)
				f = d[e], Object.prototype.hasOwnProperty.call(funs, f)	&& (forseReg || !(f in hostPrototype)) && (hostPrototype[f] = funs[f]);
		else {
			for (f in funs)
				Object.prototype.hasOwnProperty.call(funs, f) && (forseReg || !(f in hostPrototype)) && (hostPrototype[f] = funs[f]);
			({valueOf : 0}).propertyIsEnumerable("valueOf")	|| fRegFuns(hostPrototype, funs, forseReg, "hasOwnProperty,isPrototypeOf,propertyIsEnumerable,toString,toLocaleString,valueOf".split(","));
		}
		return hostPrototype;
	}
	
	function fRegEvents() {
		fRegFuns(this.constructor.prototype, {
					publish : function(a) {
						this._evts[a] || (this._evts[a] = null);
					},
					on : function(a, b, c) {
						var d = this._evts;
						d[a] = {};
						d[a].type = a;
						this.name && (d[a].type = this.name + ":" + a);
						d[a].fn = function() {
							b.apply(c, arguments);
						};
					},
					after : function(a, b, c) {
						this.on(a, b, c);
					},
					fire : function(a) {
						var b = this._evts[a];
						if (b) {
							var c = {target : this,	type : b.type},
								d = Array.prototype.slice.call(arguments, 1);
							if (fIsObjOrFun(d[0]))
								for (var e in c)
									d[0][e]	? d[0]["_" + e] = c[e] : d[0][e] = c[e];
							else
								d[0] = c;
							"function" === fToString(b.fn) && b.fn.apply(this, d);
						}
					},
					detach : function(a) {
						delete this._evts[a];
					}
				}, !1);
		this._evts = {};
	}
	
	
	function Parent(args) {
		fRegEvents.call(this);
		this._isApplySuperClass || fRegFuns(this.constructor.prototype, Parent.prototype, !1);
		if (args) {
			for (var field in args)
				this.set(field, args[field]);
		}
		"function" === typeof this.initializer && this.initializer.apply(this, arguments);
	}
	Parent.prototype = {
		_isApplySuperClass : !0,
		initializer : function() {
		},
		get : function(key) {
			return this.config[key];
		},
		set : function(key, val) {
			var c;
			key && "undefined" !== typeof val && key in this.config	&& (this.config[key] = val, c = key + "Change", this._evt && c in this._evt.events && this.fire(c));
		}
	};
	
	function SWFReference(a, b, c) {
		fRegEvents.call(this);
		var d = this._id = fGenerateId("uploader-swf"), c = c || {}, e = ((c.version || sFlashVersion) + "").split("."),
			e = SWFReference.isFlashVersionAtLeast(parseInt(e[0], 10), parseInt(e[1], 10), parseInt(e[2], 10)),
			f = SWFReference.isFlashVersionAtLeast(8, 0, 0) && !e && c.useExpressInstall,
			g = f ? sFlashDownload : b, 
			b = "<object ", h = "&SWFId=" + d + "&callback=" + sFlashEventHandler + "&allowedDomain=" + document.location.hostname;
		SWFReference._instances[d] = this;
		if (a && (e || f) && g) {
			b += 'id="' + d + '" ';
			b = Browser.ie ? b + ('classid="' + sIEFlashClassId + '" ') : b
					+ ('type="' + sShockwaveFlash + '" data="' + g + '" ');
			b += 'width="100%" height="100%">';
			Browser.ie && (b += '<param name="movie" value="' + g + '"/>');
			for (var j in c.fixedAttributes)
				oa.hasOwnProperty(j)
						&& (b += '<param name="' + j + '" value="' + c.fixedAttributes[j] + '"/>');
			for (var s in c.flashVars)
				j = c.flashVars[s], "string" === typeof j
						&& (h += "&" + s + "=" + encodeURIComponent(j));
			h && (b += '<param name="flashVars" value="' + h + '"/>');
			a.innerHTML = b + "</object>";
			this.swf = document.getElementById(d);
		} else
			this.publish("wrongflashversion", {fireOnce : !0}), this.fire("wrongflashversion", {type : "wrongflashversion"});
	}
	
	SWFReference.getFlashVersion = function() {
		return "" + Browser.flashMajor + "." + ("" + Browser.flashMinor) + "." + ("" + Browser.flashRev);
	};
	SWFReference.isFlashVersionAtLeast = function(a, b, c) {return true;
		/*var d = parseInt(Browser.flashMajor, 10), e = parseInt(Browser.flashMinor, 10), f = parseInt(
				Browser.flashRev, 10), a = parseInt(a || 0, 10), b = parseInt(b || 0,
				10), c = parseInt(c || 0, 10);
		return a === d ? b === e ? c <= f : b < e : a < d;*/
	};
	SWFReference._instances = SWFReference._instances || {};
	SWFReference.eventHandler = function(a, b) {SWFReference._instances[a]._eventHandler(b);};
	SWFReference.prototype = {
		initializer : function() {},
		_eventHandler : function(a) {
			"swfReady" === a.type ? (this.publish("swfReady", {fireOnce : !0}), this.fire("swfReady", a))
								: "log" !== a.type && this.fire(a.type, a);
		},
		callSWF : function(a, b) {
			b || (b = []);
			return this.swf[a] ? this.swf[a].apply(this.swf, b) : null;
		},
		toString : function() {return "SWF " + this._id;}
	};
	SWFReference.prototype.constructor = SWFReference;
	
	function SWFProvider(a) {
		this.swfContainerId = fGenerateId("uploader");
		this.queue = this.swfReference = null;
		this.buttonState = "up";
		this.config = {
			enabled : !0,
			multipleFiles : !0,
			buttonClassNames : {
				hover : "uploader-button-hover",
				active : "uploader-button-active",
				disabled : "uploader-button-disabled",
				focus : "uploader-button-selected"
			},
			containerClassNames : {hover : "uphotBg"},
			fileFilters : a.fileFilters,
			fileFieldName : "FileData",
			simLimit : 1,
			retryCount : 3,
			postVarsPerFile : {},
			swfURL : "/swf/FlashUploader.swf",
			uploadURL : "/fd"
		};
		Parent.apply(this, arguments);
	}
	SWFProvider.prototype = {
		constructor : SWFProvider,
		name : "uploader",
		buttonState : "up",
		swfContainerId : null,
		swfReference : null,
		queue : null,
		initializer : function() {
			this.publish("fileselect");
			this.publish("uploadstart");
			this.publish("fileuploadstart");
			this.publish("uploadprogress");
			this.publish("totaluploadprogress");
			this.publish("uploadcomplete");
			this.publish("alluploadscomplete");
			this.publish("uploaderror");
			this.publish("mouseenter");
			this.publish("mouseleave");
			this.publish("mousedown");
			this.publish("mouseup");
			this.publish("click");
		},
		render : function(a) {
			a && (this.renderUI(a), this.bindUI());
		},
		renderUI : function(a) {
			this.contentBox = a;
			this.contentBox.style.position = "relative";
			var b = fCreateContentEle("<div id='" + this.swfContainerId + "' style='position:absolute;top:0px; left: 0px; margin: 0; padding: 0; border: 0; width:100%; height:100%'></div>");
			b.style.width = a.offsetWidth + "px";
			b.style.height = a.offsetHeight + "px";
			this.contentBox.appendChild(b);
			this.swfReference = new SWFReference(b, this.get("swfURL"), {
						version : "10.0.45",
						fixedAttributes : {
							wmode : "transparent",
							allowScriptAccess : "always",
							allowNetworking : "all",
							scale : "noscale"
						}
					});
		},
		bindUI : function() {
			this.setMultipleFiles();
			this.setFileFilters();
			this.triggerEnabled();
			this.swfReference.on("swfReady", function() {
				this.setMultipleFiles();
				this.setFileFilters();
				this.triggerEnabled();
				this.after("multipleFilesChange", this.setMultipleFiles, this);
				this.after("fileFiltersChange", this.setFileFilters, this);
				this.after("enabledChange", this.triggerEnabled, this);
			}, this);
			this.swfReference.on("fileselect", this.updateFileList, this);
			this.swfReference.on("mouseenter", function() {this.setContainerClass("hover", !0);}, this);
			this.swfReference.on("mouseleave", function() {this.setContainerClass("hover", !1);}, this);
		},
		destroy : function() {
			this.swfReference.detach("fileselect", this.updateFileList, this);
			this.swfReference.detach("mouseenter", function() {this.setContainerClass("hover", !0);}, this);
			this.swfReference.detach("mouseleave", function() {this.setContainerClass("hover", !1);}, this);
			if (this.contentBox) {
				while (this.contentBox.firstChild) {
					var oldNode = this.contentBox.removeChild(this.contentBox.firstChild);
					oldNode = null;
				}
			}
			this.swfReference = null;
		},
		setContainerClass : function(a, b) {
			b ? fAddClass(this.contentBox, this.get("containerClassNames")[a]) : fRemoveClass(
					this.contentBox, this.get("containerClassNames")[a]);
		},
		setFileFilters : function() {
			this.swfReference && 0 < this.get("fileFilters").length
					&& this.swfReference.callSWF("setFileFilters", [[{description: "\u81ea\u5b9a\u4e49\u6587\u4ef6", extensions: "*" + this.get("fileFilters").join(";*"), macType: "*" + this.get("fileFilters").join(";*")}]]);
		},
		setMultipleFiles : function() {
			this.swfReference && this.swfReference.callSWF("setAllowMultipleFiles", [this.get("multipleFiles")]);
		},
		triggerEnabled : function() {
			this.get("enabled")
					? (this.swfReference.callSWF("enable"), this.swfReference.swf.setAttribute("aria-disabled", "false"))
					: (this.swfReference.callSWF("disable"), this.swfReference.swf.setAttribute("aria-disabled", "true"))
		},
		updateFileList : function(a) {
			this.swfReference.swf.focus();
			for (var a = a.fileList, b = [], c = this.swfReference, d = 0; d < a.length; d++) {
				var e = {};
				e.id = a[d].fileId;
				e.name = a[d].fileReference.name;
				e.size = a[d].fileReference.size;
				e.type = a[d].fileReference.type;
				e.dateCreated = a[d].fileReference.creationDate;
				e.dateModified = a[d].fileReference.modificationDate;
				e.uploader = c;
				b.push(new SWFUploader(e));
			}
			0 < b.length && this.fire("fileselect", {fileList : b});
		},
		uploadEventHandler : function(a) {
			switch (a.type) {
				case "executor:uploadstart" :
					this.fire("fileuploadstart", a);
					break;
				case "executor:uploadprogress" :
					this.fire("uploadprogress", a);
					break;
				case "uploaderqueue:totaluploadprogress" :
					this.fire("totaluploadprogress", a);
					break;
				case "executor:uploadcomplete" :
					this.fire("uploadcomplete", a);
					break;
				case "uploaderqueue:alluploadscomplete" :
					this.queue = null;
					this.fire("alluploadscomplete", a);
					break;
				case "executor:uploaderror" :
				case "uploaderqueue:uploaderror" :
					this.fire("uploaderror", a);
					break;
				case "executor:uploadcancel" :
				case "uploaderqueue:uploadcancel" :
					this.fire("uploadcancel", a);
			}
		},
		upload : function(uploader, url, postVars) {
			var url = url || this.get("uploadURL"), postVars = fMergeJson(postVars, this.get("postVarsPerFile")), id = uploader.id,
				postVars = postVars.hasOwnProperty(id) ? postVars[id] : postVars;
			uploader instanceof SWFUploader
					&& (uploader.on("uploadstart", this.uploadEventHandler, this),
						uploader.on("uploadprogress", this.uploadEventHandler, this),
						uploader.on("uploadcomplete", this.uploadEventHandler, this),
						uploader.on("uploaderror", this.uploadEventHandler, this),
						uploader.on("uploadcancel", this.uploadEventHandler, this),
						uploader.startUpload(url, postVars, this.get("fileFieldName")));
		}
	};
	
	function SWFUploader(a) {
		this.bytesSpeed = this.bytesPrevLoaded = 0;
		this.bytesSpeeds = [];
		this.preTime = this.remainTime = 0;
		this.config = {
			id : "",
			name : "",
			size : "",
			type : "",
			dateCreated : "",
			dateModified : "",
			uploader : ""
		};
		Parent.apply(this, arguments);
	}	
	SWFUploader.prototype = {
		constructor : SWFUploader,
		name : "executor",
		initializer : function() {
			this.id = fGenerateId("file");
		},
		swfEventHandler : function(a) {
			if (a.id === this.get("id"))
				switch (a.type) {
					case "uploadstart" :
						this.fire("uploadstart", {uploader : this.get("uploader")});
						break;
					case "uploadprogress" :
						var b = (new Date).getTime(), c = (b - this.preTime) / 1E3, d = 0;
						if (1 <= c || 0 == this.bytesPrevLoaded) {
							this.bytesSpeed = Math.round((a.bytesLoaded - this.bytesPrevLoaded) / c);
							this.bytesPrevLoaded = a.bytesLoaded;
							this.preTime = b;
							5 < this.bytesSpeeds.length && this.bytesSpeeds.shift();
							this.bytesSpeeds.push(this.bytesSpeed);
							for (b = 0; b < this.bytesSpeeds.length; b++)
								d += this.bytesSpeeds[b];
							this.bytesSpeed = Math.round(d / this.bytesSpeeds.length);
							this.remainTime = Math.ceil((a.bytesTotal - a.bytesLoaded) / this.bytesSpeed);
						}
						this.fire("uploadprogress", {
									originEvent : a,
									bytesLoaded : a.bytesLoaded,
									bytesSpeed : this.bytesSpeed,
									bytesTotal : a.bytesTotal,
									remainTime : this.remainTime,
									percentLoaded : Math.min(100, Math.round(1E4 * a.bytesLoaded / a.bytesTotal) / 100)
								});
						break;
					case "uploadcomplete" :
						this.fire("uploadfinished", {originEvent : a});
						break;
					case "uploadcompletedata" :
						this.fire("uploadcomplete", {
									originEvent : a,
									data : a.data
								});
						break;
					case "uploadcancel" :
						this.fire("uploadcancel", {originEvent : a});
						break;
					case "uploaderror" :
						this.fire("uploaderror", {
									originEvent : a,
									status : a.status,
									statusText : a.message,
									source : a.source
								});
				}
		},
		startUpload : function(url, postVars, fileFieldName) {
			if (this.get("uploader")) {
				var uploader = this.get("uploader"), fileFieldName = fileFieldName || "FileData", id = this.get("id"), postVars = postVars || null;
				uploader.on("uploadstart", this.swfEventHandler, this);
				uploader.on("uploadprogress", this.swfEventHandler, this);
				uploader.on("uploadcomplete", this.swfEventHandler, this);
				uploader.on("uploadcompletedata", this.swfEventHandler, this);
				uploader.on("uploaderror", this.swfEventHandler, this);
				this.remainTime = this.bytesSpeed = this.bytesPrevLoaded = 0;
				this.bytesSpeeds = [];
				if (!this.preTime)
					this.preTime = (new Date).getTime();
				uploader.callSWF("upload", [id, url, postVars, fileFieldName]);
			}
		},
		cancelUpload : function() {
			this.get("uploader") 
				&& (this.get("uploader").callSWF("cancel", [this.get("id")]), this.fire("uploadcancel"));
		}
	};
	
	function StreamProvider(a) {
		this.buttonBinding = this.queue = this.fileInputField = null;
		this.config = {
			enabled : !0,
			multipleFiles : !0,
			dragAndDropArea : "",
			dragAndDropTips : "",
			fileFilters : a.fileFilters,
			fileFieldName : "FileData",
			simLimit : 1,
			retryCount : 3,
			postVarsPerFile : {},
			uploadURL : "/upload"
		};
		Parent.apply(this, arguments);
	}
	StreamProvider.prototype = {
		constructor : StreamProvider,
		name : "stream_provider",
		initializer: function(){
			this.publish("fileselect");
			this.publish("uploadstart");
			this.publish("fileuploadstart");
			this.publish("uploadprogress");
			this.publish("totaluploadprogress");
			this.publish("uploadcomplete");
			this.publish("alluploadscomplete");
			this.publish("uploaderror");
			this.publish("dragenter");
			this.publish("dragover");
			this.publish("dragleave");
			this.publish("drop");
		},
		render : function(a) {
			a && (this.renderUI(a), this.bindUI());
		},
		renderUI : function(a) {
			this.contentBox = a;
			this.fileInputField = fCreateContentEle("<input type='file' style='visibility:hidden;width:0px;height:0px;opacity:0;position:absolute;left:-1000px;'>");
			this.get("dragAndDropArea") && !this.get("dragAndDropArea").nodeType && this.set("dragAndDropArea", document.getElementById(this.get("dragAndDropArea"))); 
			bDraggable && this.get("dragAndDropArea") && (fAddClass(this.get("dragAndDropArea"), 'stream-browse-drag-files-area'), this.get("dragAndDropArea").appendChild(fCreateContentEle(this.get("dragAndDropTips"))));
		},
		bindUI : function() {
			this.bindSelectButton();
			this.setMultipleFiles();
			this.setFileFilters();
			this.bindDropArea();
			this.triggerEnabled();
			this.after("multipleFilesChange", this.setMultipleFiles, this);
			this.after("fileFiltersChange", this.setFileFilters, this);
			this.after("enabledChange", this.triggerEnabled, this);
			this.after("dragAndDropAreaChange", this.bindDropArea, this);
			fAddEventListener(this.fileInputField, "change", fExtend(this.updateFileList, this));
		},
		bindDropArea : function() {
			var a = this.get("dragAndDropArea");
			this.dropBinding = fExtend(this.dragEventHandler, this);
			null !== a	&& (fAddEventListener(a, "drop", this.dropBinding),
							fAddEventListener(a, "dragenter", this.dropBinding),
							fAddEventListener(a, "dragover", this.dropBinding),
							fAddEventListener(a, "dragleave", this.dropBinding));
		},
		destroy : function() {
			this.buttonBinding = fExtend(this.openFileSelectDialog, this);
			fRemoveEventListener(this.contentBox, "click", this.buttonBinding);
			fRemoveEventListener(this.fileInputField, "change", fExtend(this.updateFileList, this));
			this.detach("multipleFilesChange", this.setMultipleFiles, this);
			this.detach("fileFiltersChange", this.setFileFilters, this);
			this.detach("enabledChange", this.triggerEnabled, this);
			this.detach("dragAndDropAreaChange", this.bindDropArea, this);

			var a = this.get("dragAndDropArea");
			null !== a && this.dropBinding != null && (fRemoveEventListener(a, "drop", this.dropBinding),
						fRemoveEventListener(a, "dragenter", this.dropBinding),
						fRemoveEventListener(a, "dragover", this.dropBinding),
						fRemoveEventListener(a, "dragleave", this.dropBinding));
			this.fileInputField = null;
			this.buttonBinding = null;
			this.dropBinding = null;
		},
		dragEventHandler : function(evt) {
			evt = evt || window.event;
			evt.preventDefault ? evt.preventDefault() : evt.returnValue = !1;
			evt.stopPropagation ? evt.stopPropagation() : evt.cancelBubble = !0;
			switch (evt.type) {
				case "dragenter" :
					this.fire("dragenter");
					break;
				case "dragover" :
					this.fire("dragover");
					break;
				case "dragleave" :
					this.fire("dragleave");
					break;
				case "drop" :
					var callback = function(files, self) {
						for (var list = [], c = 0; c < files.length; c++)
							list.push(new StreamUploader(files[c]));
						0 < list.length && self.fire("fileselect", {fileList : list});
					};
					if (bFolder) {
						var items = evt.dataTransfer.items;
						if (items.length && items[items.length - 1]) {
							var entry = items[items.length - 1].webkitGetAsEntry() || items[items.length - 1].getAsEntry();
							entry && this.traverseFileTree(entry.filesystem.root, callback);
						}
					} else {
						var files = evt.dataTransfer.files;
						if (evt.MOZ_SOURCE_MOUSE) {
							for (var list = [], c = 0; c < files.length; c++)
								files[c].size > 0 && list.push(files[c]);
							files = list;
						}
						callback(files, this);
					}
					this.fire("drop");
			}
		},
		traverseFileTree : function (directory, callback) {
			callback.pending || (callback.pending = 0);
			callback.files || (callback.files = []);
			callback.pending++;
			var self = this, relativePath = directory.fullPath.replace(/^\//, "").replace(/(.+?)\/?$/, "$1/"), reader = directory.createReader();
			reader.readEntries(function(entries) {
				callback.pending--;
				if (!entries.length) {
					fShowMessage("\u5FFD\u7565\u7A7A\u6587\u4EF6\u5939\uFF1A`" + relativePath + directory.name + "`", true);
				} else {
					for (var i = 0; i < entries.length; i++) {
						var entry = entries[i];
						if (entry.isFile) {
							callback.pending++;
							entry.file(function(f) {
								f.RelativePath = relativePath + f.name; /** self define argument */
								callback.files.push(f);
								(--callback.pending === 0) && callback(callback.files, self);
							});
							continue;
						}
						self.traverseFileTree(entry, callback);
					}
				}
				(callback.pending === 0) && callback(callback.files, self);
			});
		},
		rebindFileField : function() {
			this.fileInputField = fCreateContentEle("<input type='file' style='visibility:hidden;width:0px;height:0px;opacity:0;position:absolute;left:-1000px;'>");
			this.get("dragAndDropArea") && !this.get("dragAndDropArea").nodeType && this.set("dragAndDropArea", document.getElementById(this.get("dragAndDropArea"))); 
			bDraggable && (fAddClass(this.get("dragAndDropArea"), 'stream-browse-drag-files-area'));
			this.setMultipleFiles();
			this.setFileFilters();
			fAddEventListener(this.fileInputField, "change", fExtend(this.updateFileList, this));
		},
		bindSelectButton : function() {
			this.buttonBinding = fExtend(this.openFileSelectDialog, this);
			fAddEventListener(this.contentBox, "click", this.buttonBinding);
		},
		setMultipleFiles : function() {
			!0 === this.get("multipleFiles")
					&& this.fileInputField.setAttribute("multiple", "multiple")
		},
		setFileFilters : function() {
			var a = this.get("fileFilters");
			0 < a.length ? this.fileInputField.setAttribute("accept", a
							.join(",")) : this.fileInputField.setAttribute(
					"accept", "")
		},
		triggerEnabled : function() {
			var a = this.get("dragAndDropArea");
			fRemoveClass(a, 'stream-disabled');
			if (this.get("enabled") && null === this.buttonBinding)
				this.bindSelectButton(), this.bindDropArea(), fRemoveClass(a, 'stream-disabled');
			else if (!this.get("enabled") && this.buttonBinding) {
				fRemoveEventListener(this.contentBox, "click", this.buttonBinding),
				this.buttonBinding = null;
				
				null !== a && this.dropBinding != null && (fRemoveEventListener(a, "drop", this.dropBinding),
							fRemoveEventListener(a, "dragenter", this.dropBinding),
							fRemoveEventListener(a, "dragover", this.dropBinding),
							fRemoveEventListener(a, "dragleave", this.dropBinding),
							fAddClass(a, 'stream-disabled'));
			}				
		},
		updateFileList : function(a) {
			for (var a = a.target.files, b = [], c = 0; c < a.length; c++) {
				if (a[c].name == ".") continue;
				b.push(new StreamUploader(a[c]));
			}
			0 < b.length && this.fire("fileselect", {fileList : b});
			this.rebindFileField();
		},
		openFileSelectDialog : function(a) {
			this.fileInputField && this.fileInputField.click && a.target != this.fileInputField && this.fileInputField.click();
		},
		uploadEventHandler : function(a) {
			switch (a.type) {
				case "executor:uploadstart" :
					this.fire("fileuploadstart", a);
					break;
				case "executor:uploadprogress" :
					this.fire("uploadprogress", a);
					break;
				case "uploaderqueue:totaluploadprogress" :
					this.fire("totaluploadprogress", a);
					break;
				case "executor:uploadcomplete" :
					this.fire("uploadcomplete", a);
					break;
				case "uploaderqueue:alluploadscomplete" :
					this.queue = null;
					this.fire("alluploadscomplete", a);
					break;
				case "executor:uploaderror" :
				case "uploaderqueue:uploaderror" :
					this.fire("uploaderror", a);
					break;
				case "executor:uploadcancel" :
				case "uploaderqueue:uploadcancel" :
					this.fire("uploadcancel", a);
			}
		},
		upload : function(uploader, url, postVars) {
			var url = url || this.get("uploadURL"), postVars = fMergeJson(postVars, this.get("postVarsPerFile")),
				d = uploader.id, postVars = postVars.hasOwnProperty(d) ? postVars[d] : postVars;
			uploader instanceof StreamUploader
					&& (uploader.on("uploadstart", this.uploadEventHandler, this),
						uploader.on("uploadprogress", this.uploadEventHandler, this),
						uploader.on("uploadcomplete", this.uploadEventHandler, this),
						uploader.on("uploaderror", this.uploadEventHandler, this),
						uploader.on("uploadcancel", this.uploadEventHandler, this),
						uploader.startUpload(url, postVars, this.get("fileFieldName")));
		}
	};
	
	var StreamUploader = function(){
		this.remainTime = this.bytesSpeed = this.bytesStart = this.bytesPrevLoaded = 0;
		this.bytesSpeeds = [];
		this.retryTimes = this.preTime = 0;
		this.config = {
			id : "",
			name : "",
			size : "",
			type : "",
			dateCreated : "",
			dateModified : "",
			uploader : "",
			uploadURL : "",
			serverAddress : "",
			portionSize : 10485760,
			parameters : {},
			fileFieldName : "FileData",
			uploadMethod : "formUpload"
		};
		Parent.apply(this, arguments);
	};
	StreamUploader.isValidFile = function(a) {return "undefined" != typeof File && a instanceof File;};
	StreamUploader.canUpload = function() {return "undefined" != typeof FormData;};
	StreamUploader.prototype = {
		constructor : StreamUploader,
		name: "executor",
		initializer: function(file){
			this.XHR = null;
			this.retryTimes = 10;
			this.retriedTimes = 0;
			this.file = null;
			this.fileId = null;
			this.filePiece = 10485760;/** 10M. */
			this.fileSizeValue = 0;
			this.fileStartPosValue = null;
			
			this.durationTime = 2000;
			this.xhrHandler = null;
			
			var b = StreamUploader.isValidFile(file) ? file : StreamUploader.isValidFile(file.file)	? file.file	: !1;
			this.get("id") || this.set("id", fGenerateId("file"));
			if (b && StreamUploader.canUpload()) {
				if (!this.file)
					this.file = b;
				this.set("name", b.RelativePath || b.webkitRelativePath || b.name || b.fileName);
				if (this.get("size") != (b.size || b.fileSize))
					this.set("size", b.size || b.fileSize);
				this.get("type") || this.set("type", b.type);
				b.lastModifiedDate && !this.get("dateModified")	&& this.set("dateModified", b.lastModifiedDate);
			}
		},
		resetXhr: function(){
			if(this.XHR){
				try{
					this.XHR.upload.removeEventListener("progress", this.xhrHandler),
					this.XHR.upload.removeEventListener("error", this.xhrHandler),
					this.XHR.upload.removeEventListener("abort", this.xhrHandler),
					this.XHR.removeEventListener("loadend", this.xhrHandler),
					this.XHR.removeEventListener("error", this.xhrHandler),
					this.XHR.removeEventListener("abort", this.xhrHandler),
					this.XHR.removeEventListener("readystatechange", this.xhrHandler);
				}catch(e){throw e;}
				this.XHR = null;
			}
		},
		formUpload : function() {
			this.resetXhr();
			this.XHR = new XMLHttpRequest;
			this.uploadEventHandler = fExtend(this.uploadEventHandler, this);
			var fd = new FormData, fileFileName = this.get("fileFieldName"),
				url = this.get("uploadURL"), _xhr = this.XHR, _upload = _xhr.upload;
			this.set("uploadMethod", "formUpload");
			this.bytesStart = 0;
			this.preTime = (new Date).getTime();
			fd.append(fileFileName, this.file);
			_xhr.addEventListener("loadstart", this.uploadEventHandler, !1);
			_upload.addEventListener("progress", this.uploadEventHandler, !1);
			_xhr.addEventListener("load", this.uploadEventHandler, !1);
			_xhr.addEventListener("error", this.uploadEventHandler, !1);
			_upload.addEventListener("error", this.uploadEventHandler, !1);
			_upload.addEventListener("abort", this.uploadEventHandler, !1);
			_xhr.addEventListener("abort", this.uploadEventHandler, !1);
			_xhr.addEventListener("loadend", this.uploadEventHandler, !1);
			_xhr.addEventListener("readystatechange", this.uploadEventHandler, !1);
			_xhr.open("POST", url, !0);
			_xhr.send(fd);
			this.fire("uploadstart", {xhr : _xhr});
		},
		streamUpload: function(pos){
			/** whether continue uploading. */
			var _url = this.get("uploadURL");
			this.resetXhr();
			this.resume = false;
			this.bytesStart = pos;
			this.XHR = new XMLHttpRequest;
			this.xhrHandler = fExtend(this.uploadEventHandler, this);
			//register callback function
			var _xhr = this.XHR, upload = _xhr.upload;
			_xhr.addEventListener("loadstart", this.xhrHandler, !1);
			upload.addEventListener("progress", this.xhrHandler, !1);
			_xhr.addEventListener("load", this.xhrHandler, !1);
			_xhr.addEventListener("error", this.xhrHandler, !1);
			upload.addEventListener("error", this.xhrHandler, !1);
			upload.addEventListener("abort", this.xhrHandler, !1);
			_xhr.addEventListener("abort", this.xhrHandler, !1);
			_xhr.addEventListener("loadend", this.xhrHandler, !1);
			_xhr.addEventListener("readystatechange", this.xhrHandler, !1);
			var blob = this.sliceFile(this.file, pos, pos + this.filePiece);
			var range = "bytes "+ pos + "-"+ (pos + blob.size) + "/" + this.get("size");
			this.preTime = (new Date).getTime();
			_xhr.open("POST", _url, !0);
			_xhr.setRequestHeader("Content-Range", range);
			_xhr.send(blob);
			0 === pos && this.fire("uploadstart", {xhr : _xhr});
		},
		resumeUpload: function() {
			/** when Browse has `File`, but has not `File.slice` */
			if (!bFileSlice) {
				this.formUpload();
				return;
			}
			
			this.resetXhr();
			this.XHR = new XMLHttpRequest;
			this.resume = true;
			
			var _url = this.get("uploadURL") + "&" + fGetRandom();
			this.xhrHandler = fExtend(this.uploadEventHandler, this);
			this.XHR.addEventListener("loadstart", this.xhrHandler, !1);
			this.XHR.addEventListener("load", this.xhrHandler, !1);
			this.XHR.addEventListener("abort", this.xhrHandler, !1);
			this.XHR.addEventListener("error", this.xhrHandler, !1);
			this.XHR.addEventListener("loadend", this.xhrHandler, !1);
			this.XHR.addEventListener("readystatechange", this.xhrHandler, !1);
			this.preTime = (new Date).getTime();
			this.XHR.open("GET", _url, !0);
			this.XHR.send(null);
		},
		retry: function(){
            this.retriedTimes++;
            var g = this;
            2 > this.retriedTimes ? this.resumeUpload()
            					: (this.timeoutHandler && clearTimeout(this.timeoutHandler), this.timeoutHandler = setTimeout(function() {g.resumeUpload()}, 1E4));
		},
		uploadEventHandler: function(event){
			var xhr = this.XHR, method = this.get("uploadMethod");
			switch(event.type){
				case "load":
					var uploaded = 0;
					var respJson = null;
					var bError = !1;
					try {
						if (xhr.readyState == 4 && (xhr.status == 200 || xhr.status == 308)) {
							uploaded = (respJson = eval("(" + xhr.responseText + ")")) ? respJson.start : -1;
						} else if (xhr.status < 500 && xhr.status >= 400) {
							bError = !0;
						} else if (xhr.status < 200) {return;}
						/** the response can't process the request, so throws out the error. */
						bError = bError || respJson.success == false;
					} catch(e) {
						bError = "formUpload" === method || this.retriedTimes > this.retryTimes;
						if (!bError) {
							this.retry();
							return;
						}
					}
					if (bError) {
						this.fire("uploaderror", {
							originEvent : event,
							status : xhr.status,
							statusText : xhr.responseText,
							source : respJson && respJson.message
						});
						return;
					}
					//check whether upload complete yet
					if(uploaded < this.get("size") -1) {
						this.retriedTimes = 0;
						/** StreamUploader request is over and mark the date. */
						this.streamUpload(uploaded);
					} else {
						this.fire("uploadcomplete", {originEvent : event, data : event.target.responseText});
					}
					break;
				case "error":
					this.retriedTimes < this.retryTimes ? this.retry()
						: this.fire("uploaderror", {
									originEvent : event,
									status : xhr.status,
									statusText : xhr.statusText,
									source : "io"
								});
					break;
				case "abort":
					this.fire("uploadcancel", {originEvent : event});
					break;
				case "progress":
					var total = this.get("size"), loaded = this.bytesStart + event.loaded,
						now = (new Date).getTime(), cost = (now - this.preTime) / 1E3, totalSpeeds = 0;
					if (0.68 <= cost || 0 === this.bytesSpeeds.length) {
						this.bytesPrevLoaded = Math.max(this.bytesStart, this.bytesPrevLoaded);
						this.bytesSpeed = Math.round((loaded - this.bytesPrevLoaded) / cost);
						this.bytesPrevLoaded = loaded;
						this.preTime = now;
						5 < this.bytesSpeeds.length && this.bytesSpeeds.shift();
						5 > this.bytesSpeeds.length && (this.bytesSpeed = this.bytesSpeed / 2);
						this.bytesSpeeds.push(this.bytesSpeed);
						for (var i = 0; i < this.bytesSpeeds.length; i++)
							totalSpeeds += this.bytesSpeeds[i];
						this.bytesSpeed = Math.round(totalSpeeds / this.bytesSpeeds.length);
						this.remainTime = Math.ceil((total - loaded) / this.bytesSpeed);
					}
					this.fire("uploadprogress", {
								originEvent : event,
								bytesLoaded : loaded,
								bytesTotal : total,
								bytesSpeed : this.bytesSpeed,
								remainTime : this.remainTime,
								percentLoaded : Math.min(100, Math.floor(1E4 * loaded / total) / 100)
							});
					break;
				case "readystatechange":
					this.fire("readystatechange", {readyState : event.target.readyState, originEvent : event});
			}
		},
		startUpload: function(url, postVars, fileFieldName){
			this.fileStartPosValue = null;
			this.retriedTimes = 0;

			postVars.name = this.get("name");
			postVars.size = this.get("size");
			var method = this.get("uploadMethod");
			this.set("uploadURL", fAddVars(postVars, url));
			this.set("parameters", postVars);
			this.set("fileFieldName", fileFieldName);
			this.remainTime = this.bytesSpeed = this.bytesPrevLoaded = 0;
			this.bytesSpeeds = [];
			this.resetXhr();
			switch (method) {
				case "formUpload" :
					this.formUpload();
					break;
				case "streamUpload" :
					this.streamUpload();
					break;
				case "resumeUpload" :
					this.resumeUpload()
			}
		},
		sliceFile: function(f, startPos, endPos){
			startPos = startPos || 0;
			endPos = endPos || 0;
			return f.slice ? f.slice(startPos, endPos) : f.webkitSlice ? f.webkitSlice(startPos, endPos) : f.mozSlice ? f.mozSlice(startPos, endPos) : f;
		},
		cancelUpload : function() {
			this.XHR && (this.XHR.abort(), this.resetXhr());
		}
	};
	
	function Main(cfg){
		cfg = cfg || {};
		this.bStreaming = bStreaming;
		this.bDraggable = bDraggable;
		this.uploadInfo = {};
		this.config = {
			enabled : !0,
			customered : !!cfg.customered,
			multipleFiles : !!cfg.multipleFiles,
			autoRemoveCompleted : !!cfg.autoRemoveCompleted,
			autoUploading : cfg.autoUploading == null ? true : !!cfg.autoUploading,
			dragAndDropArea: cfg.dragAndDropArea,
			dragAndDropTips: cfg.dragAndDropTips || "<span>把文件(文件夹)拖拽到这里</span>",
			fileFieldName : cfg.fileFieldName || "FileData",
			browser : cfg.browser,
			browseFileId : cfg.browseFileId || "i_select_files",
			browseFileBtn : cfg.browseFileBtn || "<div>请选择文件</div>",
			filesQueueId : cfg.filesQueueId || "i_stream_files_queue",
			filesQueueHeight : cfg.filesQueueHeight || 450,
			messagerId : cfg.messagerId || "i_stream_message_container",
			onSelect : cfg.onSelect,
			onAddTask: cfg.onAddTask,
			onMaxSizeExceed : cfg.onMaxSizeExceed,
			onFileCountExceed : cfg.onFileCountExceed,
			onExtNameMismatch : cfg.onExtNameMismatch,
			onCancel : cfg.onCancel,
			onStop : cfg.onStop,
			onCancelAll : cfg.onCancelAll,
			onComplete : cfg.onComplete,
			onQueueComplete: cfg.onQueueComplete,
			onUploadProgress: cfg.onUploadProgress,
			onUploadError: cfg.onUploadError,
			onDestroy: cfg.onDestroy,
			maxSize : cfg.maxSize || 2147483648,
			simLimit : cfg.simLimit || 10000,
			fileFilters: fIsArray(cfg.extFilters) ? cfg.extFilters : [],
			retryCount : cfg.retryCount || 5,
			postVarsPerFile : cfg.postVarsPerFile || {},
			swfURL : cfg.swfURL || "/swf/FlashUploader.swf",
			tokenURL : cfg.tokenURL || "/tk",
			frmUploadURL : cfg.frmUploadURL || Browser.firefox ? "/fd;" + document.cookie : "/fd",
			uploadURL : cfg.uploadURL || "/upload"
		};
		Parent.apply(this, arguments);
	}
	Main.applyTo = function(a, b) {
		if (!a || "SWF.eventHandler" != a)
			return null;
		try {
			return SWFReference.eventHandler.apply(SWFReference, b);
		} catch (c) {
			return null;
		}
	};
	Main.prototype = {
		constructor : Main,
		name : "uploader",
		initializer : function() {
			sStreamMessagerId = this.config.messagerId;
			this.startPanel = this.config.browser || document.getElementById(this.config.browseFileId);
			/** the default UI */
			if (!this.config.customered) {
				fAddClass(this.startPanel, "stream-browse-files");
				this.startPanel.appendChild(fCreateContentEle(this.config.browseFileBtn));
				var filesQueuePanel = document.getElementById(this.config.filesQueueId);
				fAddClass(filesQueuePanel, "stream-main-upload-box");
				var filesContainerId = fGenerateId("files-container"),
				    totalContainerId = fGenerateId("total-container");
				var filesQueue = fCreateContentEle(sFilesContainer.replace("#filesContainerId#", filesContainerId).replace("#filesQueueHeight#", this.config.filesQueueHeight)),
					totalQueue = fCreateContentEle(sTotalContainer.replace("#totalContainerId#", totalContainerId));
				filesQueuePanel.appendChild(filesQueue);
				filesQueuePanel.appendChild(totalQueue);
				
				this.containerPanel = document.getElementById(filesContainerId);
				this.totalContainerPanel = document.getElementById(totalContainerId);
				this.template = sCellFileTemplate;
			}
			
			this.fileProvider = new Provider(this.config);
			this.fileProvider.render(this.startPanel);
			this.fileProvider.on("uploadprogress", this.uploadProgress, this);
			this.fileProvider.on("uploadcomplete", this.uploadComplete, this);
			this.fileProvider.on("uploaderror", this.uploadError, this);
			this.fileProvider.on("fileselect", this.fileSelect, this);
			fAddEventListener(window, "beforeunload", fExtend(this.unloadHandler, this));
			this.waiting = [];
			this.uploading = !1;
			this.totalFileSize = 0;
			this.totalUploadedSize = 0;
			this.showBrowseBlock();
		},
		addStreamTask : function(a) {
			var file_id = a.get("id"), cell_file = fCreateContentEle("<li id='" + file_id + "' class='stream-cell-file'></li>");
			cell_file.innerHTML = this.template;
			this.uploadInfo[file_id] = {
				uploadToken : "",
				uploadComplete : !1,
				file : a,
				disabled : !1,
				actived : !1,
				progressNode : this.getNode("stream-process", cell_file),
				cellInfosNode : this.getNode("stream-cell-infos", cell_file)
			};
			this.totalFileSize += this.uploadInfo[file_id].file.get("size");
			if (!this.config.customered) {
				this.getNode("stream-file-name", cell_file).getElementsByTagName("strong")[0].innerHTML = a.get("name");
				this.containerPanel.appendChild(cell_file);
				this.renderUI(file_id);
				this.bindUI(file_id);
			}
			/** do not hidden the upload button */
			/*bStreaming ? this.startPanel.style.display = "none" : (this.startPanel.style.height = "1px", this.startPanel.style.width = "1px");*/
			this.waiting.push(file_id);
			this.config.autoUploading && this.upload(file_id);
		},
		hideBrowseBlock: function() {
			this.browseFileBlockHeight = fGetHeight(this.startPanel);
			this.browseFileBlockWidth = fGetWidth(this.startPanel);
			!this.browseFileBlockDisplay && (this.browseFileBlockDisplay = this.startPanel.style.display == "" ? "block" : this.startPanel.style.display);
			bStreaming ? this.startPanel.style.display = "none" : (this.startPanel.style.height = "1px", this.startPanel.style.width = "1px");
		},
		showBrowseBlock: function() {
			!this.browseFileBlockHeight && (this.browseFileBlockHeight = fGetHeight(this.startPanel));
			!this.browseFileBlockWidth && (this.browseFileBlockWidth = fGetWidth(this.startPanel));
			!this.browseFileBlockDisplay && (this.browseFileBlockDisplay = this.startPanel.style.display == "" ? "block" : this.startPanel.style.display);
			if (this.browseFileBlockDisplay == "none") {this.browseFileBlockDisplay = "block", this.browseFileBlockWidth = null, this.browseFileBlockHeight = null; return !1;}
			bStreaming ? this.startPanel.style.display = this.browseFileBlockDisplay : (this.startPanel.style.height = this.browseFileBlockHeight, this.startPanel.style.width = this.browseFileBlockWidth);
		},
		renderUI : function(file_id) {
			var progressNode = this.uploadInfo[file_id].progressNode,
				cellInfosNode = this.uploadInfo[file_id].cellInfosNode,
				size = this.uploadInfo[file_id].file.get("size"),
				total = this.formatBytes(size);
			this.getNode("stream-process-bar", progressNode).innerHTML = "<span style='width:0%;'></span>";
			this.getNode("stream-percent", progressNode).innerHTML = "0%";
			this.getNode("stream-speed", cellInfosNode).innerHTML = "-";
			this.getNode("stream-remain-time", cellInfosNode).innerHTML = "--:--:--";
			this.getNode("stream-uploaded", cellInfosNode).innerHTML = "0/" + total;
			var _total = this.formatBytes(this.totalFileSize);
			this.getNode("_stream-total-size", this.totalContainerPanel).innerHTML = _total;
		},
		bindUI : function(file_id) {
			var b = this.uploadInfo[file_id].progressNode, cancelBtn = this.getNode("stream-cancel", b);
			this.cancelBtnHandler = fExtend(this.cancelUploadHandler, this, {type : "click",	nodeId : file_id});
			fAddEventListener(cancelBtn, "click", this.cancelBtnHandler);
		},
		completeUpload : function(info) {
			/** set the current scroll for files container */
			var count = 0, scroll = null, ratio = 1;
			for(var i in this.uploadInfo) count++;
			ratio = (count - this.waiting.length - 1) / (count <= 0 ? 1 : count);
			this.containerPanel && this.containerPanel.parentNode && (scroll = this.containerPanel.parentNode, scroll.scrollTop = scroll.scrollHeight * ratio);
			this.get("onComplete") ? this.get("onComplete")(info) : this.onComplete(info);
			this.waiting.length == 0 && (this.get("onQueueComplete") ? this.get("onQueueComplete")(info.msg) : this.onQueueComplete(info.msg));
			this.config.autoRemoveCompleted && (info = document.getElementById(info.id), info.parentNode && info.parentNode.removeChild(info));
			this.uploading = !1;
			this.upload();
		},
		onSelect : function(list) {
			fShowMessage("selected files: " + list.length);
		},
		onFileCountExceed : function(selected, limit) {
			fShowMessage("File counts:" + selected + ", but limited:" + limit, true);
		},
		onMaxSizeExceed : function(file) {
			fShowMessage("File:" + file.name + " size is:" + file.size +" Exceed limited:" + file.limitSize, true);
		},
		onExtNameMismatch: function(file) {
			fShowMessage("Allow ext name: [" + file.filters.toString() + "], not for " + file.name, true);
		},
		onAddTask: function(file) {
			fShowMessage("Add to task << name: [" + file.name);
		},
		onCancel : function(file) {
			fShowMessage("Canceled: " + file.name);
		},
		onStop : function() {
			fShowMessage("Stopped!");
		},
		onCancelAll : function(numbers) {
			fShowMessage(numbers + " files Canceled! ");
		},
		onComplete : function(file) {
			fShowMessage("File:" + file.name + ", Size:" + file.size + " onComplete	[OK]");
		},
		onQueueComplete : function(msg) {
			fShowMessage("onQueueComplete(msg: "+msg+")	---==>		[OK]");
		},
		onUploadError : function(status, msg) {
			fShowMessage("Error Occur.  Status:" + status + ", Message: " + msg, true);
		},
		disable : function() {
			this.fileProvider.set("enabled", !1), this.fileProvider.triggerEnabled(), fAddClass(this.startPanel.children[0], "stream-disable-browser"), fAddClass(this.startPanel, "disabled");
		},
		enable : function() {
			this.fileProvider.set("enabled", !0), this.fileProvider.triggerEnabled(), fRemoveClass(this.startPanel.children[0], "stream-disable-browser"), fRemoveClass(this.startPanel, "disabled");
		},
		stop : function() {
			if (!this.uploading) return false;
			this.uploading = !1;
			var files = this.uploadInfo, number = 0;
			/** cancel the unfinished uploading files */
			for(var fileId in files) {
				/** add the `file_id` to `waiting` @ index of 0 */
				if (!files[fileId].uploadComplete) {
					this.cancelOne(fileId, true) && this.uploadInfo[fileId] && this.waiting.unshift(fileId);
					break;	
				}
			}
			this.get("onStop") ? this.get("onStop")() : this.onStop();
		},
		destroy : function() {
			this.stop();
			this.fileProvider.destroy();
			this.waiting = [];
			/** the default UI */
			if (!this.config.customered) {
				fRemoveClass(this.startPanel, "stream-browse-files");
				fRemoveClass(this.startPanel, "stream-browse-drag-files-area");
				var filesQueuePanel = document.getElementById(this.config.filesQueueId);
				fRemoveClass(filesQueuePanel, "stream-main-upload-box");
				while (this.startPanel.firstChild) {
					var oldNode = this.startPanel.removeChild(this.startPanel.firstChild);
					oldNode = null;
				}
				while (filesQueuePanel.firstChild) {
					var oldNode = filesQueuePanel.removeChild(filesQueuePanel.firstChild);
					oldNode = null;
				}
			}
			this.get("onDestroy") && this.get("onDestroy")(); 
			var selfthis = this, selfthis = null;
		},
		cancel : function() {
			this.uploading = !1;
			var files = this.uploadInfo, number = 0;
			/** cancel the unfinished uploading files */
			for(var fileId in files)
				!files[fileId].uploadComplete && (++number) && this.cancelOne(fileId);
			this.get("onCancelAll") ? this.get("onCancelAll")(number) : this.onCancelAll(number);
		},
		cancelOne : function(file_id, stopping) {
			var provider = this.uploadInfo[file_id].file, actived = this.uploadInfo[file_id].actived;
			provider && provider.cancelUpload && provider.cancelUpload();
			if (!!stopping) return true;
			
			var totalSize = this.totalFileSize - this.uploadInfo[file_id].file.config.size, info = {
				id:   file_id,
				name: this.uploadInfo[file_id].file.config.name,
				size: this.uploadInfo[file_id].file.config.size,
				totalSize: totalSize,
				formatTotalSize: this.formatBytes(totalSize),
				totalLoaded: this.totalUploadedSize,
				formatTotalLoaded: this.formatBytes(this.totalUploadedSize),
				totalPercent: totalSize == 0 ? 0 : this.totalUploadedSize * 10000 / totalSize / 100
			};
			100 > info.totalPercent && (info.totalPercent = parseFloat(info.totalPercent).toFixed(2));
			
			this.get("onCancel") ? this.get("onCancel")(info) : this.onCancel(info);
			this.uploadInfo[file_id] && delete this.uploadInfo[file_id];
			fRemoveEventListener(document, "click", this.cancelBtnHandler);
			!this.config.customered && this.containerPanel.removeChild(document.getElementById(file_id));
			if (actived) {
				this.uploading = !1;
				this.upload();
			} else {
				for(var i in this.waiting)
					if (this.waiting[i] === file_id)
						this.waiting.splice(i, 1);
			}
			var size = provider.config.size;
			this.totalFileSize -= size;
			var _loaded = this.formatBytes(this.totalUploadedSize);
			var percent = this.totalUploadedSize * 10000 / this.totalFileSize / 100;
			100 > percent && (percent = parseFloat(percent).toFixed(2));
			if (this.totalFileSize === 0)
				percent = 100;
				
			if (!this.config.customered) {
				var _total = this.formatBytes(this.totalFileSize);
				this.getNode("_stream-total-size", this.totalContainerPanel).innerHTML = _total;
				this.getNode("_stream-total-uploaded", this.totalContainerPanel).innerHTML = _loaded;
				this.getNode("stream-percent", this.totalContainerPanel).innerHTML = percent + "%";
				this.getNode("stream-process-bar", this.totalContainerPanel).innerHTML = '<span style="width: '+percent+'%;"></span>';
				
				/*** TODO: this code will be removed in the future.
				bStreaming ? this.startPanel.style.display = "block"
					: (this.startPanel.style.height = "auto", this.startPanel.style.width = "970px");*/
			}
		},
		cancelUploadHandler: function (event, b) {
		    //alert(JSON.stringify(b));
		    delArrayPathById(b.nodeId);//移除数组
			var c = event || window.event, id = b.nodeId, self = this;
			this.preventDefault(c);
			this.stopPropagation(c);
			if (this.uploadInfo[id].disabled)
				return !1;
			this.uploadInfo[id] && !this.uploadInfo[id].uploadComplete;
			this.cancelOne(id);
		},
		unloadHandler : function(evt) {
			var evt = evt || window.event;
			if (this.waiting.length > 0)
				return evt.returnValue = "\u60A8\u6B63\u5728\u4E0A\u4F20\u6587\u4EF6\uFF0C\u5173\u95ED\u6B64\u9875\u9762\u5C06\u4F1A\u4E2D\u65AD\u4E0A\u4F20\uFF0C\u5EFA\u8BAE\u60A8\u7B49\u5F85\u4E0A\u4F20\u5B8C\u6210\u540E\u518D\u5173\u95ED\u6B64\u9875\u9762";
		},
		upload : function(index) {
			if(this.uploading) return;
			index = this.waiting.shift();
			if(index == null) return;
			this.uploading = !0;
			
			this.uploadInfo[index].actived = !0;
			var file = this.uploadInfo[index].file, self = this;
			var frmUploadURL = this.get("frmUploadURL");
			var uploadURL = this.get("uploadURL");
			/** request the server to figure out what's the token for the file: */
			var xhr = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject("Microsoft.XMLHTTP");
			
			var vars = {
				name:	 file.get('name'),
				type: file.get('type'),
				size: file.get('size'),
				modified: file.get("dateModified") + ""
			};
			vars = fMergeJson(vars, this.get("postVarsPerFile"));
			var tokenUrl = fAddVars(vars, this.get("tokenURL")) + "&" + fGetRandom();
			xhr.open("GET", tokenUrl, !0);
			/** IE7,8 兼容*/
			xhr.onreadystatechange = function() {
			    if (xhr.readyState != 4 || xhr.status < 200)
			        return false;
			    
			    var token, server;
				try {
					try {
						token = eval("(" + xhr.responseText + ")").token;
						server = eval("(" + xhr.responseText + ")").server;
					} catch(e) {}
					if (token) {
						if(server != null && server != "") {
							frmUploadURL = server + frmUploadURL;
							uploadURL = server + uploadURL;
						}
						bStreaming && bFileSlice ? (self.uploadInfo[index].serverAddress = server,
										self.uploadFile(file, uploadURL, token, "resumeUpload"))
								: self.uploadFile(file, frmUploadURL, token, "formUpload");
					} else {
						/** not found any token */
						self.cancelOne(index);
						var msg = "\u521B\u5EFA\u4E0A\u4F20\u4EFB\u52A1\u5931\u8D25[tokenURL=" + self.get("tokenURL") + "],\u72B6\u6001\u7801:" + xhr.status;
						fShowMessage(msg, true);
					}
				} catch(e) {
					/** streaming, swf, resume methods all failed, no more try  */
				}
			}
			window.XMLHttpRequest && (xhr.onerror = function() {
				self.cancelOne(index);
				var msg = "\u521B\u5EFA\u4E0A\u4F20\u4EFB\u52A1\u5931\u8D25,\u72B6\u6001\u7801:" + xhr.status + ",\u8BF7\u68C0\u6D4B\u7F51\u7EDC...";
				fShowMessage(msg, true);
			});
			xhr.send();
		},
		uploadFile : function(file, url, token, method) {
			var token = {
				token : token,
				client : method == "formUpload" ? "form" : "html5"
			};
			url = url || "";
			method && file instanceof StreamUploader && file.set("uploadMethod", method);
			this.fileProvider.upload(file, url, token);
		},
		uploadProgress : function(a) {
			var id = a.target.get("id"), percent = Math.min(99.99, a.percentLoaded),
				totalPercent = (this.totalUploadedSize + a.bytesLoaded) * 10000 / this.totalFileSize / 100, totalPercent = Math.min(99.99, totalPercent);
			100 > totalPercent && (totalPercent = parseFloat(totalPercent).toFixed(2));	
			
			if (!this.uploadInfo[id]) return false;
			if (this.config.customered) {
				var info = {
					id:                 id,
					loaded:             a.bytesLoaded,
					formatLoaded:       this.formatBytes(a.bytesLoaded),
					speed:              a.bytesSpeed,
					formatSpeed:        this.formatSpeed(a.bytesSpeed),
					size:               a.bytesTotal,
					formatSize:         this.formatBytes(a.bytesTotal),
					percent:            percent,
					timeLeft:           a.remainTime,
					formatTimeLeft:     this.formatTime(a.remainTime),
					totalSize:          this.totalFileSize,
					formatTotalSize:    this.formatBytes(this.totalFileSize),
					totalLoaded:        this.totalUploadedSize + a.bytesLoaded,
					formatTotalLoaded:  this.formatBytes(this.totalUploadedSize + a.bytesLoaded),
					totalPercent:       totalPercent
				};
				this.get("onUploadProgress") && this.get("onUploadProgress")(info);
				return false;
			}
			
			var progressNode = this.uploadInfo[id].progressNode,
				cellInfosNode = this.uploadInfo[id].cellInfosNode, bytesLoaded = a.bytesLoaded,
				c = this.formatSpeed(a.bytesSpeed), loaded = this.formatBytes(bytesLoaded),
				total = this.formatBytes(a.bytesTotal), _remainTime = this.formatTime(a.remainTime),
				a = Math.min(99.99, a.percentLoaded);
			100 > a && (a = parseFloat(a).toFixed(2));
			this.getNode("stream-process-bar", progressNode).innerHTML = "<span style='width:"+a+"%;'></span>";
			this.getNode("stream-percent", progressNode).innerHTML = a + "%";
			this.getNode("stream-speed", cellInfosNode).innerHTML = c;
			if (_remainTime)
				this.getNode("stream-remain-time", cellInfosNode).innerHTML = _remainTime;
			this.getNode("stream-uploaded", cellInfosNode).innerHTML = loaded + "/" + total;
			
			var _loaded = this.formatBytes(this.totalUploadedSize + bytesLoaded);
			var percent = (this.totalUploadedSize + bytesLoaded) * 10000 / this.totalFileSize / 100, percent = Math.min(99.99, percent);
			100 > percent && (percent = parseFloat(percent).toFixed(2));
			this.getNode("_stream-total-uploaded", this.totalContainerPanel).innerHTML = _loaded;
			this.getNode("stream-percent", this.totalContainerPanel).innerHTML = percent + "%";
			this.getNode("stream-process-bar", this.totalContainerPanel).innerHTML = '<span style="width: '+percent+'%;"></span>';
		},
		uploadComplete : function(a) {
			this.totalUploadedSize += a.target.get("size");
			var id = a.target.get("id"), percent = Math.min(100, a.percentLoaded),
				totalPercent = this.totalUploadedSize * 10000 / this.totalFileSize / 100;
			100 > totalPercent && (totalPercent = parseFloat(totalPercent).toFixed(2));
			if (this.totalFileSize === 0)
				percent = 100;

			if (!this.uploadInfo[id]) return false;
			
			var info = {
				id:                 id,
				name:               a.target.get("name"),
				loaded:             a.target.get("size"),
				formatLoaded:       this.formatBytes(a.target.get("size")),
				size:               a.target.get("size"),
				formatSize:         this.formatBytes(a.target.get("size")),
				percent:            100,
				totalSize:          this.totalFileSize,
				formatTotalSize:    this.formatBytes(this.totalFileSize),
				totalLoaded:        this.totalUploadedSize,
				formatTotalLoaded:  this.formatBytes(this.totalUploadedSize),
				totalPercent:       totalPercent,
				msg:                a.data
			};
			/** uploaded flag and its callback function. */
			this.uploadInfo[id].uploadComplete = !0;
			
			if (!this.config.customered) {
				var progressNode = this.uploadInfo[id].progressNode,
					cellInfosNode = this.uploadInfo[id].cellInfosNode,
					size = a.target.get("size"), a = eval("(" + a.data + ")"), fmtSize = this.formatBytes(size);
				this.getNode("stream-process-bar", progressNode).innerHTML = "<span style='width:100%;'></span>";
				this.getNode("stream-percent", progressNode).innerHTML = "100%";
				this.getNode("stream-uploaded", cellInfosNode).innerHTML = fmtSize + "/" + fmtSize;
				this.getNode("stream-remain-time", cellInfosNode).innerHTML = "00:00:00";
				//this.getNode("stream-cancel", progressNode).innerHTML = "";
				
				var _loaded = this.formatBytes(this.totalUploadedSize);
				var percent = this.totalUploadedSize * 10000 / this.totalFileSize / 100;
				100 > percent && (percent = parseFloat(percent).toFixed(2));
				if (this.totalFileSize === 0)
					percent = 100;
				this.getNode("_stream-total-uploaded", this.totalContainerPanel).innerHTML = _loaded;
				this.getNode("stream-percent", this.totalContainerPanel).innerHTML = percent + "%";
				this.getNode("stream-process-bar", this.totalContainerPanel).innerHTML = '<span style="width: '+percent+'%;"></span>';
			}
			
			this.completeUpload(info);
		},
		getNode : function(a, b) {
			return fContains(b || this.containerPanel, a)[0] || null;
		},
		uploadError : function(evt) {
			this.get("onUploadError") ? this.get("onUploadError")(evt.status, evt.statusText) : this.onUploadError(evt.status, evt.statusText);
		},
		fileSelect : function(a) {
			var a = a.fileList, b = 0, c, files = [];
			for (c = 0; c < a.length; c++)
				files.push(a[c].config);
			this.get("onSelect") ? this.get("onSelect")(files) : this.onSelect(files);
			for (c in this.uploadInfo)
				b++;
			if (b == this.get("simLimit") || a.length > this.get("simLimit")) {
				this.get("onFileCountExceed") ? this.get("onFileCountExceed")(Math.max(a.length, b), this.get("simLimit"))
						: this.onFileCountExceed(Math.max(a.length, b), this.get("simLimit"));
				return !1;
			}
			for (c = 0; c < a.length; c++)
				this.validateFile(a[c]) && this.addStreamTask(a[c]);
		},
		validateFile : function(uploader) {
			var name = uploader.get("name"), size = uploader.get("size"),
				ext = -1 !== name.indexOf(".") ? name.replace(/.*[.]/, "").toLowerCase() : "",
				filters = this.get("fileFilters"), valid = !1, msg = "",
				info = {
					id:               uploader.get("id"),
					name:             uploader.get("name"),
					size:             uploader.get("size"),
					formatSize:       this.formatBytes(uploader.get("size")),
					lastModifiedDate: uploader.get("lastModifiedDate"),
					limitSize:        this.get("maxSize"),
					formatLimitSize:  this.formatBytes(this.get("maxSize")),
					filters:          filters
				};
			if(!bStreaming && size > 2147483648){this.uploadError({status:100, statusText:"Flash最大只能上传2G的文件!"});return !1;}
			if (this.get("maxSize") < size)
				this.get("onMaxSizeExceed") ? this.get("onMaxSizeExceed")(info) : this.onMaxSizeExceed(info);
			else {
				filters.length || (valid = !0);
				for (var i = 0; i < filters.length; i++)
					filters[i].toLowerCase() == "." + ext && (valid = !0);
				if (!valid)
					this.get("onExtNameMismatch") ? this.get("onExtNameMismatch")(info) : this.onExtNameMismatch(info);
			}
			valid && this.config.customered && this.get("onAddTask") && this.get("onAddTask")(info, uploader);
			return valid;
		},
		formatSpeed : function(a) {
			var b = 0;
			1024 <= Math.round(a / 1024) 
				? (b = Math.round(100 * (a / 1048576)) / 100, b = Math.max(0, b), b = isNaN(b) ? 0 : parseFloat(b).toFixed(2), a = b + "MB/s")
				: (b = Math.round(100 * (a / 1024))	/ 100, b = Math.max(0, b), b = isNaN(b) ? 0 : parseFloat(b).toFixed(2), a = b + "KB/s");
			return a;
		},
		formatBytes : function(size) {
			if (size < 100) {
				return (size + 'B');
			} else if (size < 102400) {
				size = Math.round(100 * (size / 1024)) / 100;
				size = isNaN(size) ? 0 : parseFloat(size).toFixed(2);
				return (size + 'K');
			} else if (size < 1047527424) {
				size = Math.round(100 * (size / 1048576)) / 100;
				size = isNaN(size) ? 0 : parseFloat(size).toFixed(2);
				return (size + 'M');
			}
			
			size = Math.round(100 * (size / 1073741824)) / 100;
			size = isNaN(size) ? 0 : parseFloat(size).toFixed(2);
			return (size + 'G');
		},
		formatTime : function(time) {
			var total = time || 0, hour = Math.floor(total / 3600), minute = Math.floor((total - 3600 * hour) / 60),
				second = Math.floor(total - 3600 * hour - 60 * minute), hour = "" + (!isNaN(hour) && 0 < hour ? (hour < 10 ? ("0" + hour + ":") : (hour + ":")): "00:"),
				hour = hour + (!isNaN(minute) && 0 < minute ? (minute < 10 ? ("0" + minute + ":") : minute + ":") : "00:");
			return hour += !isNaN(second) && 0 < second ? (second < 10 ? ("0" + second + "") : second): "00";
		},
		preventDefault : function(a) {
			a.preventDefault ? a.preventDefault() : a.returnValue = !1
		},
		stopPropagation : function(a) {
			a.stopPropagation ? a.stopPropagation() : a.cancelBubble = !0
		}
	};
	
	var sIEFlashClassId = "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000",
		sShockwaveFlash = "application/x-shockwave-flash", sFlashVersion = "10.0.22",
		sFlashDownload = "http://fpdownload.macromedia.com/pub/flashplayer/update/current/swf/autoUpdater.swf?"	+ Math.random(),
		sFlashEventHandler = "SWF.eventHandler",
		oa = {
			align : "",
			allowFullScreen : "",
			allowNetworking : "",
			allowScriptAccess : "",
			base : "",
			bgcolor : "",
			loop : "",
			menu : "",
			name : "",
			play : "",
			quality : "",
			salign : "",
			scale : "",
			tabindex : "",
			wmode : ""
		};
	var Browser = function(a) {
		var b = function(a) {
			var b = 0;
			return parseFloat(a.replace(/\./g, function() {
						return 1 == b++ ? "" : ".";
					}))
		}, c = window, d = c && c.navigator, e = {
			ie : 0,
			opera : 0,
			gecko : 0,
			webkit : 0,
			safari : 0,
			chrome : 0,
			firefox : 0,
			mobile : null,
			air : 0,
			phantomjs : 0,
			air : 0,
			ipad : 0,
			iphone : 0,
			ipod : 0,
			ios : null,
			android : 0,
			silk : 0,
			accel : !1,
			webos : 0,
			caja : d && d.cajaVersion,
			secure : !1,
			os : null,
			nodejs : 0
		}, a = a || d && d.userAgent, d = (c = c && c.location) && c.href, c = 0, f, g, h;
		e.userAgent = a;
		e.secure = d && 0 === d.toLowerCase().indexOf("https");
		if (a) {
			if (/windows|win32/i.test(a))
				e.os = "windows";
			else if (/macintosh|mac_powerpc/i.test(a))
				e.os = "macintosh";
			else if (/android/i.test(a))
				e.os = "android";
			else if (/symbos/i.test(a))
				e.os = "symbos";
			else if (/linux/i.test(a))
				e.os = "linux";
			else if (/rhino/i.test(a))
				e.os = "rhino";
			if (/KHTML/.test(a))
				e.webkit = 1;
			if (/IEMobile|XBLWP7/.test(a))
				e.mobile = "windows";
			if (/Fennec/.test(a))
				e.mobile = "gecko";
			if ((d = a.match(/AppleWebKit\/([^\s]*)/)) && d[1]) {
				e.webkit = b(d[1]);
				if ((d = a.match(/Version\/([^\s]*)/)) && d[1])
					e.safari = d[1];
				if (/PhantomJS/.test(a) && (d = a.match(/PhantomJS\/([^\s]*)/))
						&& d[1])
					e.phantomjs = b(d[1]);
				if (/Mobile\//.test(a) || /iPad|iPod|iPhone/.test(a)) {
					if (e.mobile = "Apple", (d = a.match(/OS ([^\s]*)/))
							&& d[1] && (d = b(d[1].replace("_", "."))), e.ios = d, e.os = "ios", e.ipad = e.ipod = e.iphone = 0, (d = a
							.match(/iPad|iPod|iPhone/))
							&& d[0])
						e[d[0].toLowerCase()] = e.ios;
				} else {
					if (d = a.match(/NokiaN[^\/]*|webOS\/\d\.\d/))
						e.mobile = d[0];
					if (/webOS/.test(a)
							&& (e.mobile = "WebOS", (d = a
									.match(/webOS\/([^\s]*);/))
									&& d[1]))
						e.webos = b(d[1]);
					if (/ Android/.test(a)) {
						if (/Mobile/.test(a))
							e.mobile = "Android";
						if ((d = a.match(/Android ([^\s]*);/)) && d[1])
							e.android = b(d[1]);
					}
					if (/Silk/.test(a)) {
						if ((d = a.match(/Silk\/([^\s]*)\)/)) && d[1])
							e.silk = b(d[1]);
						if (!e.android)
							e.android = 2.34, e.os = "Android";
						if (/Accelerated=true/.test(a))
							e.accel = !0;
					}
				}
				if ((d = a.match(/(Chrome|CrMo|CriOS)\/([^\s]*)/)) && d[1]
						&& d[2]) {
					if (e.chrome = b(d[2]), e.safari = 0, "CrMo" === d[1])
						e.mobile = "chrome";
				} else if (d = a.match(/AdobeAIR\/([^\s]*)/))
					e.air = d[0];
			}
			if (!e.webkit)
				if (/Opera/.test(a)) {
					if ((d = a.match(/Opera[\s\/]([^\s]*)/)) && d[1])
						e.opera = b(d[1]);
					if ((d = a.match(/Version\/([^\s]*)/)) && d[1])
						e.opera = b(d[1]);
					if (/Opera Mobi/.test(a) && (e.mobile = "opera", (d = a.replace("Opera Mobi", "").match(/Opera ([^\s]*)/)) && d[1]))
						e.opera = b(d[1]);
					if (d = a.match(/Opera Mini[^;]*/))
						e.mobile = d[0];
				} else if ((d = a.match(/MSIE\s([^;]*)/)) && d[1])
					e.ie = b(d[1]);
				else if (d = a.match(/Gecko\/([^\s]*)/)) {
					if (e.gecko = 1, (d = a.match(/rv:([^\s\)]*)/)) && d[1])
						e.gecko = b(d[1]);
					if ((d = a.match(/(Firefox)\/([^\s]*)/)) && d[1] && d[2])
						e.firefox = d[2];
				}
		}
		if (e.gecko || e.webkit || e.opera) {
			if (b = navigator.mimeTypes["application/x-shockwave-flash"])
				if (b = b.enabledPlugin)
					f = b.description.replace(/\s[rd]/g, ".").replace(
							/[A-Za-z\s]+/g, "").split(".");
		} else if (e.ie) {
			try {
				g = new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6"), g.AllowScriptAccess = "always";
			} catch (j) {null !== g && (c = 6);}
			if (0 === c)
				try {
					h = new ActiveXObject("ShockwaveFlash.ShockwaveFlash"),
					f = h.GetVariable("$version").replace(/[A-Za-z\s]+/g, "").split(",");
				} catch (s) {}
		}
		if (fIsArray(f)) {
			if (fIsNumber(parseInt(f[0], 10)))
				e.flashMajor = f[0];
			if (fIsNumber(parseInt(f[1], 10)))
				e.flashMinor = f[1];
			if (fIsNumber(parseInt(f[2], 10)))
				e.flashRev = f[2];
		}
		return e;
	}();
	var bFileSlice = !1;
	var bStreaming = function() {
		var bFile = !1, bHtml5 = !1, bFormData = window.FormData ? !0 : !1, bStreaming = !1;
		"undefined" != typeof File && "undefined" != typeof (new XMLHttpRequest).upload && (bFile = !0);
		if (bFile && (bFileSlice = "slice" in File.prototype || "mozSlice" in File.prototype || "webkitSlice" in File.prototype))
			bHtml5 = !0;
		(function() {
			for (var a = 0; a < aOtherBrowsers.length; a++)
				-1 !== navigator.userAgent.indexOf(aOtherBrowsers[a]) && (bHtml5 = !1);
		})();
		/** some browsers has problems. */
		(bFormData && Browser.os === "windows" && Browser.safari === "5.1.7") && (bFormData = !1);
		return bFile && (bFormData || bHtml5);
	}(), bDraggable = bStreaming && ('draggable' in document.createElement('span')), bFolder = bDraggable && (window.webkitRequestFileSystem || window.requestFileSystem);
	Provider = bStreaming ? StreamProvider : SWFProvider;
	window.Stream = window.Uploader = Main; /** window.Uploader是SWF组件的关键字(保留) */
})();
