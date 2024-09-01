(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [];


(lib.AnMovieClip = function(){
	this.actionFrames = [];
	this.ignorePause = false;
	this.currentSoundStreamInMovieclip;
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		var pos = this.timeline.resolve(positionOrLabel);
		if (pos != null) { this.startStreamSoundsForTargetedFrame(pos); }
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		this.soundStreamDuration.forEach(function(value,key){
			key.instance.stop();
		});
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var _this = this;
			this.soundStreamDuration.forEach(function(value,key,arr){
				if((value.end) == currentFrame){
					key.instance.stop();
					if(_this.currentSoundStreamInMovieclip == key) { _this.currentSoundStreamInMovieclip = undefined; }
					arr.delete(key);
				}
			});
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			var _this = this;
			if(this.soundStreamDuration.size > 0){
				var maxDuration = 0;
				this.soundStreamDuration.forEach(function(value,key){
					if(value.end > maxDuration){
						maxDuration = value.end;
						_this.currentSoundStreamInMovieclip = key;
					}
				});
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if((deltaFrame >= 0) && this.ignorePause){
					cjs.MovieClip.prototype.play.call(this);
					this.ignorePause = false;
				}
				else if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
				else if(deltaFrame <= -2){
					cjs.MovieClip.prototype.stop.call(this);
					this.ignorePause = true;
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:
// helper functions:

function mc_symbol_clone() {
	var clone = this._cloneProps(new this.constructor(this.mode, this.startPosition, this.loop, this.reversed));
	clone.gotoAndStop(this.currentFrame);
	clone.paused = this.paused;
	clone.framerate = this.framerate;
	return clone;
}

function getMCSymbolPrototype(symbol, nominalBounds, frameBounds) {
	var prototype = cjs.extend(symbol, cjs.MovieClip);
	prototype.clone = mc_symbol_clone;
	prototype.nominalBounds = nominalBounds;
	prototype.frameBounds = frameBounds;
	return prototype;
	}


(lib.теложука = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(1,1,1).p("ABfh8QANANAMARQAwBFACBfAhZiAQAEgEAFgEQAkgdAsAAQAiAAAdARQARAJAPAPABIkEQAgAtgJBbABIkEIAyg7AipBOQAAAAAAgBQAAhkAyhHQAOgUAQgOQgIhhArgtQAPgRAWgJQADgBACgBQAGgCAGgCQAvAIAZAiAhqk5IA0ArAipBOQAkgqAqgoQAqgqAvAAQADAAAEAAQArADAqAkQAtAmAjAnQAAADAAAEQAABlgyBGQgwBFhDACQgCAAgDAAQhFAAgyhHQgxhGgBhkgAAFguIAAFt");
	this.shape.setTransform(16.95,31.95);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#663300").s().p("AAFC3gAAAC3QhFAAgyhHQgxhGgBhjQAkgqAqgpQAqgqAvAAIAHAAQArADAqAkQAtAnAjAnIAAAHQAABjgzBHQgvBFhDACIAAltIAAFtIgFAAg");
	this.shape_1.setTransform(16.95,45.575);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#424221").s().p("AA8BAQgdgQghAAQgtAAgkAdIgJAIQgHhhAqgsQAPgRAXgKIAFgBIALgEQAvAIAZAiQAgAtgJBaQgPgPgRgKg");
	this.shape_2.setTransform(17.217,10.6);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#666633").s().p("AipB5QAAhlAyhGQAOgUAQgOIAJgIQAkgdAsAAQAiAAAdAQQARAKAOAPQANANAMARQAxBEACBgQgjgngtgnQgqgkgrgCIgHAAQgvgBgqApQgqAqgkAqIAAgBg");
	this.shape_3.setTransform(16.95,27.6);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_3},{t:this.shape_2},{t:this.shape_1},{t:this.shape}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-1,-1,35.9,65.9);


(lib.Button_start = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#5245D7").ss(1,1,1).p("AGuAAQAACHh+BfQh+BfiyAAQixAAh+hfQh+hfAAiHQAAiFB+hgQB+hfCxAAQCyAAB+BfQB+BgAACFg");
	this.shape.setTransform(-209.95,19.55);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#D600A6").s().p("AkvDlQh+hfAAiGQAAiGB+hfQB+hfCxAAQCyAAB+BfQB+BfAACGQAACGh+BfQh+BgiyAAQixAAh+hgg");
	this.shape_1.setTransform(-209.95,19.55);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).to({state:[{t:this.shape_1},{t:this.shape}]},2).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-253.9,-13.9,88,67);


(lib.Button_again = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#5245D7").ss(1,1,1).p("AI6AAQAAC9inCFQinCFjsAAQjrAAiniFQiniFAAi9QAAi7CniGQCniFDrAAQDsAACnCFQCnCGAAC7g");
	this.shape.setTransform(-130.95,68.55);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#D600A6").s().p("AmSFCQiniFAAi9QAAi7CniGQCniFDrAAQDsAACnCFQCnCGAAC7QAAC9inCFQinCFjsAAQjrAAiniFg");
	this.shape_1.setTransform(-130.95,68.55);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).to({state:[{t:this.shape_1},{t:this.shape}]},2).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-188.9,22.1,116,93);


(lib.Burron_stop = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#5245D7").ss(1,1,1).p("AKoAAQAACgjIBwQjHBxkZAAQkZAAjHhxQjHhwAAigQAAieDHhxQDHhxEZAAQEZAADHBxQDIBxAACeg");
	this.shape.setTransform(-131.95,21.55);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#D600A6").s().p("AngEQQjHhxAAifQAAieDHhxQDHhxEZAAQEaAADHBxQDHBxAACeQAACfjHBxQjHBxkaAAQkZAAjHhxg");
	this.shape_1.setTransform(-131.95,21.55);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).to({state:[{t:this.shape_1},{t:this.shape}]},2).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-200.9,-17.9,138,79);


(lib.Символ1 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(1,1,1).p("AD5h0IA7AAIhJA0AE0h0IBDAAIAWAAAEtifIBKArAC8h0IhFAzAAeiWIBYAiAAyh0IBEAAIBGAAIA9AAACtikIBMAwAhuguIAvgjIAugjIBDAAAhYh9IBHAJAiogDIA6grAiogDIgXBIAg/hRIgdBfAj2A2IAkgbIAqgeAkmAsIBUgRAmMClIBnhMIAvgjIgaBCAlqBuIBFgVAjVgwIBnACAgEhJIA2gr");
	this.shape.setTransform(39.675,16.475);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f().s("#000000").ss(1,1,1).p("AC8h0IhFAzAC8h0IA9AAIA7AAIBDAAIAWAAAAeiWIBYAiIBGAAAEtifIBKArAE0h0IhJA0ACtikIBMAwAklBZIAvgjIAkgbIAqgeIA6grIAvgjIgdBfAkmAsIBUgRAiogDIgXBIAjVgwIBnACAhYh9IBHAJAg/hRIAugjAgEhJIA2grIhDAAAAyh0IBEAAAj2A2IgaBCAmMClIBnhMAlqBuIBFgV");
	this.shape_1.setTransform(30.975,39.125);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape}]}).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-9.7,-1,90.10000000000001,57.6);


(lib.Лапки = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.instance = new lib.Символ1();
	this.instance.setTransform(-98.35,-184.4,1,1,0,0,0,78.4,5);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({rotation:-14.9983,x:-98.3},4).to({rotation:-2.3},5).to({scaleX:0.9999,scaleY:0.9999,rotation:-14.7818},5).to({regX:78.3,regY:4.9,rotation:-12.6923,x:-98.45,y:-184.5},1).to({_off:true},1).wait(3).to({_off:false,regY:5,scaleX:1,scaleY:1,rotation:-4.3319,x:-98.4,y:-184.4},0).to({_off:true},1).wait(40));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-177.4,-190.1,87.9,53.599999999999994);


(lib.Жук_1 = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.instance = new lib.теложука("synched",0);
	this.instance.setTransform(8,5,1,1,0,0,0,16.9,31.9);

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-9.9,-27.9,35.9,65.9);


(lib.Полныйжукслапками = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.instance = new lib.Лапки("synched",19);
	this.instance.setTransform(65.15,58.1,0.5261,0.5249,0,56.0439,-123.9583,-97.7,-184.1);

	this.instance_1 = new lib.Лапки("synched",9);
	this.instance_1.setTransform(69.1,43.6,0.5261,0.525,0,37.7985,-142.2008,-97.7,-184.5);

	this.instance_2 = new lib.Лапки("synched",9);
	this.instance_2.setTransform(67.15,31.05,0.378,0.3778,134.9215,0,0,-96.9,-184.4);

	this.instance_3 = new lib.Лапки("synched",9);
	this.instance_3.setTransform(36.3,32.25,0.378,0.5875,0,-145.0055,34.9935,-97.1,-184.4);

	this.instance_4 = new lib.Лапки("synched",15);
	this.instance_4.setTransform(34.75,45.35,0.5261,0.525,-38.0299,0,0,-97.2,-184.2);

	this.instance_5 = new lib.Лапки("synched",12);
	this.instance_5.setTransform(37.5,55.7,0.5644,0.5644,-53.2107,0,0,-97.7,-184.3);

	this.instance_6 = new lib.Жук_1("synched",0);
	this.instance_6.setTransform(52,34.8,1,1,0,0,0,8.1,5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = getMCSymbolPrototype(lib.Полныйжукслапками, new cjs.Rectangle(15.9,-0.7,77,104.2), null);


(lib.полныйжук = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	// Слой_1
	this.instance = new lib.Лапки("synched",7);
	this.instance.setTransform(-16.2,85.8,0.5261,0.5249,0,56.0439,-123.9583,-97.7,-184.1);

	this.instance_1 = new lib.Лапки("synched",4);
	this.instance_1.setTransform(-12.25,71.3,0.5261,0.525,0,37.7985,-142.2008,-97.7,-184.5);

	this.instance_2 = new lib.Лапки("synched",1);
	this.instance_2.setTransform(-14.2,58.75,0.378,0.3778,134.9215,0,0,-96.9,-184.4);

	this.instance_3 = new lib.Лапки("synched",0);
	this.instance_3.setTransform(-45.05,59.95,0.378,0.5875,0,-145.0055,34.9935,-97.1,-184.4);

	this.instance_4 = new lib.Лапки("synched",3);
	this.instance_4.setTransform(-46.6,73.05,0.5261,0.525,-38.0299,0,0,-97.2,-184.2);

	this.instance_5 = new lib.Лапки("synched",6);
	this.instance_5.setTransform(-43.85,83.4,0.5644,0.5644,-53.2107,0,0,-97.7,-184.3);

	this.instance_6 = new lib.Жук_1("synched",0);
	this.instance_6.setTransform(-29.35,62.5,1,1,0,0,0,8.1,5);

	this.instance_7 = new lib.Полныйжукслапками();
	this.instance_7.setTransform(-29.35,80.3,1,1,0,0,0,52,52.6);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).to({state:[{t:this.instance_7}]},9).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-75.6,21.1,97.19999999999999,110.5);


// stage content:
(lib.lab2жук_полный_HTML5Canvas = function(mode,startPosition,loop,reversed) {
if (loop == null) { loop = true; }
if (reversed == null) { reversed = false; }
	var props = new Object();
	props.mode = mode;
	props.startPosition = startPosition;
	props.labels = {};
	props.loop = loop;
	props.reversed = reversed;
	cjs.MovieClip.apply(this,[props]);

	this.actionFrames = [0];
	this.streamSoundSymbolsList[0] = [{id:"Жук",startFrame:0,endFrame:60,loop:1,offset:0},{id:"Жуквзрослый",startFrame:0,endFrame:59,loop:1,offset:0}];
	// timeline functions:
	this.frame_0 = function() {
		this.clearAllSoundStreams();
		 
		var soundInstance = playSound("Жуквзрослый",0);
		this.InsertIntoSoundStreamData(soundInstance,0,59,1);
		var soundInstance = playSound("Жук",0);
		this.InsertIntoSoundStreamData(soundInstance,0,60,1);
		//остановка воспроизведения в начальном кадре 
		this.stop(); 
		
		//запуск воспроизведения анимации щелчком мыши по кнопке but1
		this.startbutton.addEventListener("click",f1.bind(this));
		function f1(args){this.play();} 
		
		//остановка воспроизведения щелчком мыши по кнопке but2
		this.stopbutton.addEventListener("click",f2.bind(this));
		function f2(args){this.stop();}
		
		//переход во второй кадр анимации щелчком мыши по кнопке but3
		this.againbutton.addEventListener("click",f3.bind(this));
		function f3(args){this.gotoAndStop(1);}
		/* 
		
		  stop(); 
		//запуск воспроизведения анимации щелчком мыши по кнопке but1
		  startbutton.addEventListener(MouseEvent.CLICK, f1); 
		  function f1(event:MouseEvent):void 
		  {play(); } 
		//остановка воспроизведения щелчком мыши по кнопке but2
		  stopbutton.addEventListener(MouseEvent.CLICK, f2); 
		  function f2(event:MouseEvent):void 
		  {stop(); } 
		//переход в начало анимации щелчком мыши по кнопке but3
		  againbutton.addEventListener(MouseEvent.CLICK, f3); 
		  function f3(event:MouseEvent):void 
		  {gotoAndStop(0); } 
		*/
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(60));

	// Кнопки
	this.startbutton = new lib.Button_start();
	this.startbutton.name = "startbutton";
	this.startbutton.setTransform(322.5,29.35);
	new cjs.ButtonHelper(this.startbutton, 0, 1, 2);

	this.againbutton = new lib.Button_again();
	this.againbutton.name = "againbutton";
	this.againbutton.setTransform(541.1,-8);
	new cjs.ButtonHelper(this.againbutton, 0, 1, 2);

	this.stopbutton = new lib.Burron_stop();
	this.stopbutton.name = "stopbutton";
	this.stopbutton.setTransform(391.25,21.35);
	new cjs.ButtonHelper(this.stopbutton, 0, 1, 2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.stopbutton},{t:this.againbutton},{t:this.startbutton}]}).wait(60));

	// Жук_правый
	this.instance = new lib.полныйжук();
	this.instance.setTransform(1215.6,88.6,1,1,-44.9994,0,0,-29.7,80.9);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({scaleX:0.9999,scaleY:0.9999,rotation:-97.4846,guide:{path:[1215.6,88.6,1208.5,73.6,1201.4,58.6,1190.8,54.9,1179.8,50.9,1157.9,43.1,1155.8,42.1,1105.1,42.1,1054.3,42.1,1042.6,62,1030.8,82.3,1007.2,122.9,1007,125,1009,127.6,1022.7,156.6,1047.2,189,1071.7,221.3,1101,257.7,1130.2,294,1131.1,296,1129.9,314.1,1128.7,332.3,1126.3,353.3,1120.1,408.9,1114.4,411,1089.1,417.3,1063.8,423.6,963.4,432.9,862.9,442.1], orient:'fixed'}},34).to({regX:-29.8,regY:80.8,scaleX:1,scaleY:1,rotation:-104.9985,guide:{path:[862.9,442.2,860.6,442.4,858.4,442.6,835.8,448.1,813.3,453.7], orient:'fixed'}},1).to({regX:-29.7,regY:80.9,scaleX:0.9999,scaleY:0.9999,rotation:36.2241,x:813.35,y:342.3},4).wait(1).to({regY:80.8,rotation:94.4355,x:823.2,y:451.25},0).to({regX:-29.8,regY:80.9,scaleX:0.9998,scaleY:0.9998,rotation:213.4342,x:701.7,y:410.4},5).wait(1).to({regX:-29.9,regY:80.8,scaleX:0.9999,scaleY:0.9999,rotation:255.2334,x:669.4,y:480.6},0).to({regX:-29.8,rotation:210.2338,guide:{path:[669.5,480.6,620.1,488.5,570.7,496.3,517.7,501.9,464.8,507.4,450.5,507.4,436.3,507.4,415,514.5,393.7,521.6,376.3,530.3,358.9,539,355.3,539.7,345.3,546.2,340.2,549.4,335.1,552.9,332.6,558.9,321.1,588,302.2,613.2,283.3,638.3]}},13).wait(1));

	// Жук_левый___копия
	this.instance_1 = new lib.Полныйжукслапками();
	this.instance_1.setTransform(72.05,618.9,2.7765,2.7762,4.5484,0,0,52.5,29.8);

	this.timeline.addTween(cjs.Tween.get(this.instance_1).to({regX:52.9,regY:34.8,scaleX:2.0966,scaleY:2.0963,rotation:54.2792,guide:{path:[72,618.9,72.4,614,72.7,609,78.8,527.8,96.2,448.1,97.4,442.2,98.7,436.4,116,403.9,138.3,364.5,183,285.9,200.4,252.2,217.7,218.5,277.6,193,337.5,167.5,386,167.8,434.5,168.1,452,161,462.4,159.4,487.3,184.4,508.6,205.7,537.9,243.6,563.2,276.3,587.3,311.9,609.7,345,618.8,362.3,624.7,373.3,680.7,421.3,736.6,469.4,757.5,492.6,778.3,515.8,888.9,629.2,999.3,742.4,1174.4,600.6], orient:'fixed'}},59).wait(1));

	// Жук_левый
	this.instance_2 = new lib.Полныйжукслапками();
	this.instance_2.setTransform(138.15,623.25,2.7765,2.7762,4.5484,0,0,52.5,29.8);

	this.timeline.addTween(cjs.Tween.get(this.instance_2).to({scaleX:2.0967,scaleY:2.0964,rotation:47.247,guide:{path:[138,623.2,143.6,535.5,162.4,449.6,163.6,443.7,164.9,437.9,182.2,405.4,204.5,366,249.2,287.3,274.6,253.4,304.1,214,339,179.3,361.1,171.2,383.1,163.1,450.7,162.8,518.2,162.5,554.6,176.5,591,190.5,599,205.9,606.9,221.3,622.1,248.8,637.2,276.2,670.6,336.5,685,363.8,710.5,411.7,731,462.1,738.6,470,746.2,477.8,762.9,495.2,769.9,503.3,794.9,532.4,825.6,555.3,837,563.8,848.6,571.3,862.6,578.3,876.6,585.3,992.9,597.9,1109.1,610.5,1138.5,604.9,1167.9,599.3,1181.9,588.1,1195.9,576.9,1198.7,568.5,1201.5,560.1,1201.5,410.4,1201.5,260.6,1206.6,251.9,1211.7,243.1,1222.4,224.5,1224.6,218.8,1227.2,211.9,1231.2,205.8,1237.2,196.3,1246.6,190.1,1254.7,184.7,1264.3,183,1266.1,182.6,1267.9,182.3], orient:'fixed'}},59).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(572.4,361.5,778.1,465.29999999999995);
// library properties:
lib.properties = {
	id: 'D6C2E2A612E85A4E8025814294E51F88',
	width: 1280,
	height: 720,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"sounds/Жуквзрослый_.mp3?1709560759146", id:"Жуквзрослый"},
		{src:"sounds/Жук_.mp3?1709560759146", id:"Жук"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['D6C2E2A612E85A4E8025814294E51F88'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused || stageChild.ignorePause){
			stageChild.syncStreamSounds();
		}
	}
}
an.handleFilterCache = function(event) {
	if(!event.paused){
		var target = event.target;
		if(target){
			if(target.filterCacheList){
				for(var index = 0; index < target.filterCacheList.length ; index++){
					var cacheInst = target.filterCacheList[index];
					if((cacheInst.startFrame <= target.currentFrame) && (target.currentFrame <= cacheInst.endFrame)){
						cacheInst.instance.cache(cacheInst.x, cacheInst.y, cacheInst.w, cacheInst.h);
					}
				}
			}
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;