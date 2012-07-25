<?php
$color       = isset($_GET[ 'theme' ]) ? $_GET[ 'theme' ] : 'stylish-yellow';
$themeroller = isset($_GET[ 'themeroller' ]);

function css($link)
{
	return '<link href="' . $link . '" rel="stylesheet" type="text/css"/>';
}

function js($link)
{
	return '<script src="' . $link . '"></script>';
}

function getTags($id)
{
	return '$("#demo' . $id . 'GetTags").click(function () { showTags($("#demo' . $id . '").tagit("tags")) });';
}

?>

<!doctype html>
<html>
<head>
<title>jQuery Tagit Demo Page (PHP<?php echo isset($themeroller) ? '/ThemeRoller' : ''; ?>)</title>
<?php
echo js('demo/js/jquery.1.7.2.min.js');
echo js('demo/js/jquery-ui.1.8.20.min.js');
echo css('demo/css/demo.css');

if(!$themeroller)
{
	echo js('js/tagit.js');
	echo css('demo/css/jquery-ui-base-1.8.20.css');
	echo css('css/tagit-' . $color . '.css');
}
else
{
	echo js('js/tagit-themeroller.js');
	echo js('demo/themeswitcher/jquery.themeswitcher.js');
	echo css('css/themeroller/tagit.css');
	echo css('css/themeroller/bootstrap/Bootstrap.css');
} ?>
<script>
$(function () {

<?php if($themeroller)
{
	?>
	$('#switcher').themeswitcher({
		imgpath:'demo/themeswitcher/images/',
		additionalThemes:[
			{
				title:'Aristo',
				name:'aristo',
				icon:'theme_90_aristo.png',
				url:'css/themeroller/aristo/Aristo.css'
			},
			{
				title:'Twitter Bootstrap',
				name:'bootstrap',
				icon:'theme_90_aristo.png',
				url:'css/themeroller/bootstrap/Bootstrap.css'
			}
		],
		loadTheme:'Bootstrap'
	});
	<?php } ?>

	var availableTags = [
		"ActionScript",
		"AppleScript",
		"Asp",
		"BASIC",
		"C",
		"C++",
		"Clojure",
		"COBOL",
		"ColdFusion",
		"Erlang",
		"Fortran",
		"Groovy",
		"Haskell",
		"Java",
		"JavaScript",
		"Lisp",
		"Perl",
		"PHP",
		"Python",
		"Ruby",
		"Scala",
		"Scheme"
	];
<?php if($themeroller)
{
	?>
	var availableTagsCustom = [
		{
			label:'ActionScript',
			value:'actionscript',
			desc:'ActionScript is a scripting language used for RIAs, mobiles applications, web applications, etc.',
			count:5496
		},
		{
			label:'AppleScript',
			value:'applescript',
			desc:'AppleScript is the Mac OS scripting language.',
			count:1502
		},
		{
			label:'Asp',
			value:'asp',
			desc:'Active Server Pages (ASP), also known as Classic ASP or ASP Classic, was Microsoft&#39;s first server-side script-engine for dynamically-generated web pages. The introduction of ASP.NET led to use of the term Classic ASP for the original technology.',
			count:4359
		},
		{
			label:'BASIC',
			value:'basic',
			desc:'BASIC (Beginner’s All-purpose Symbolic Instruction Code) is a family of high-level programming languages designed to be easy to use.',
			count:73
		},
		{
			label:'C',
			value:'c',
			desc:'C is a general-purpose computer programming language used for operating systems, games and other high performance work and is clearly distinct from C++. It was developed in 1972 by Dennis Ritchie for use with the Unix operating system.',
			count:61619
		},
		{
			label:'C++',
			value:'c++',
			desc:'A statically typed, free-form, compiled, multi-paradigm, general-purpose programming language widely used by enthusiasts and professionals.',
			count:130385
		},
		{
			label:'Clojure',
			value:'clojure',
			desc:'Clojure is a modern Lisp dialect. Features include: an emphasis on functional programming (lazy/impure), running on the JVM with transparent access to all Java libraries, an interactive REPL development environment, dynamic runtime polymorphism, Lisp-style macro meta-programming and concurrent programming capabilities supported by software transactional memory. Versions of Clojure are also available for the CLR and Javascript.',
			count:3256
		},
		{
			label:'COBOL',
			value:'cobol',
			desc:'COBOL (COmmon Business Oriented Language) was the product of a US Department of Defense initiative to develop a standard and portable programming language for business applications. COBOL celebrated its 50th birthday in 2009. It is generally believed that new COBOL development is in decline but a commercial commitment remains to keep the language relevant in today’s computing landscape.',
			count:316
		},
		{
			label:'ColdFusion',
			value:'coldfusion',
			desc:'ColdFusion is a server-side rapid application development platform, from Adobe. ColdFusion can also refer to CFML, the dynamic programming language which Adobe ColdFusion ("CF") implements, also used by a number of alternative CFML engines - notably Open BlueDragon and Railo.',
			count:3986
		},
		{
			label:'Erlang',
			value:'erlang',
			desc:'Erlang is a general-purpose programming language and runtime environment, with built-in support for concurrency, distribution and fault tolerance. Erlang is used in several large telecommunication systems from Ericsson. Erlang is open source and available for download on GitHub.',
			count:2419
		},
		{
			label:'Fortran',
			value:'fortran',
			desc:'Fortran is a general-purpose, procedural, imperative programming language that is especially suited for numeric computation and scientific computing.',
			count:1174
		},
		{
			label:'Groovy',
			value:'groovy',
			desc:'Groovy is an object-oriented programming language for the Java platform. It is a dynamic language with features similar to those of Python, Ruby, Perl, and Smalltalk. It can be used as a scripting language for the Java Platform.',
			count:4237
		},
		{
			label:'Haskell',
			value:'haskell',
			desc:'Haskell is an advanced functional programming language, featuring strong static typing, lazy evaluation, and monadic effects.',
			count:7096
		},
		{
			label:'Java',
			value:'java',
			desc:'Java is an object-oriented language and runtime environment. Java programs can run unchanged on most platforms in a Virtual Machine called the JVM.',
			count:256007
		},
		{
			label:'JavaScript',
			value:'javascript',
			desc:'JavaScript is a dynamic language commonly used for scripting in web browsers. It is NOT the same as Java. Use this tag for questions regarding ECMAScript and its dialects/implementations (excluding ActionScript and JScript). If a framework or library, such as jQuery, is used, include that tag as well. Questions that don&#39;t include a framework/library tag, such as jQuery, implies that the question requires a pure JavaScript answer.',
			count:220246
		},
		{
			label:'Lisp',
			value:'lisp',
			desc:'Lisp is a family of programmable programming languages.',
			count:1937
		},
		{
			label:'Perl',
			value:'perl',
			desc:'Perl is a high-level, general-purpose, interpreted, dynamic programming language.',
			count:18684
		},
		{
			label:'PHP',
			value:'php',
			desc:'PHP is a widely-used, general-purpose server side scripting language that is especially suited for web development.',
			count:235270
		},
		{
			label:'Python',
			value:'python',
			desc:'Python is an interpreted, general-purpose high-level programming language whose design philosophy emphasizes code readability.',
			count:112811
		},
		{
			label:'Ruby',
			value:'ruby',
			desc:'Ruby is an open-source dynamic object-oriented interpreted language created by Yukihiro Matsumoto (Matz) in 1993.',
			count:47581
		},
		{
			label:'Scala',
			value:'scala',
			desc:'Scala is a general purpose programming language principally targeting the Java Virtual Machine. Designed to express common programming patterns in a concise, elegant, and type-safe way, it fuses both imperative and functional programming styles. Its key features are: statically typed; advanced type-system with type inference; function types; pattern-matching; implicit parameters and conversions; operator overloading; full interoperability with Java.',
			count:9380
		},
		{
			label:'Scheme',
			value:'scheme',
			desc:'Scheme is a functional programming language in the Lisp family, closely modelled on lambda calculus with eager (applicative-order) evaluation.',
			count:1667
		}
	];
	<?php } ?>

	$('#demo1').tagit({tagSource:availableTags, select:true, sortable:true});
	$('#demo2').tagit({tagSource:availableTags});
	$('#demo3').tagit({tagSource:availableTags, triggerKeys:['enter', 'comma', 'tab']});
	$('#demo4').tagit({tagSource:availableTags, sortable:true, tagsChanged:function (a, b) {
		$('#demo4Out').html(a + ' was ' + b);
	} });
	$('#demo5').tagit({maxLength:5, maxTags:5 });
	$('#demo6').tagit({tagSource:availableTags, sortable:true});
	$('#demo7').tagit({tagSource:availableTags, sortable:'handle'});

<?php if($themeroller)
{
	?>
	$('#demo8').tagit({tagSource:function (request, response) {
		//setup the search to search the label and the description
		var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
		response($.grep(availableTagsCustom, function (value) {
			return matcher.test(value.label) || matcher.test(value.desc);
		}));
	}});

	//get a reference to the autocomplete object
	var ac = $('#demo8').tagit('autocomplete');

	//add a custom class for themeing
	ac.menu.element.addClass('custom-ac');

	//attach the autocomplete to the bottom left of the tag list
	ac.options.position = {    my:"left top", at:"left bottom", collision:"none", of:$('#demo8').data('tagit').element };

	//overwrite the autocomplete _renderItem function!
	ac._renderItem = function (ul, item) {

		//highlight the matching terms
		var re = new RegExp(this.term, "gi");
		var label = item.label.replace(re, '<span class="blue">' + "$&" + "</span>");
		var desc = item.desc.replace(re, '<span class="blue">' + "$&" + "</span>");

		//render the entry
		var rendered = '<a><div class="ui-widget-header">' + label + ' <span style="font-weight:normal">(used ' + item.count + " times)</span></div>" +
			'<div class="ui-widget-content">' + desc + "</div></a>";

		return $('<li class="ac-item ui-corner-all"></li>')
			.data("item.autocomplete", item)
			.append(rendered)
			.appendTo(ul);
	};

	<?php
}

for($i = 1; $i <= 7; $i++)
	echo getTags($i);

if($themeroller)
{
	echo getTags(8);
}
?>

	$('#demo2ResetTags').click(function () {
		$('#demo2').tagit('reset')
	});

	function showTags(tags) {
		console.log(tags);
		var string = "Tags (label : value)\r\n";
		string += "--------\r\n";
		for (var i in tags)
			string += tags[i].label + " : " + tags[i].value + "\r\n";
		alert(string);
	}

	$('.browser').hover(
		function () {
			$(this).children('a').children('div').show('fast');
		},
		function () {
			$(this).children('a').children('div').hide('fast');
		});

	setInterval("$('#fork').effect('pulsate', { times:1 }, 500);", 5000);
});
</script>
</head>
<body>
<a id="fork" href="https://github.com/hailwood/jQuery-Tagit">
	<img style="position: fixed; top: 0; left: 0; border: 0;"
	     src="https://s3.amazonaws.com/github/ribbons/forkme_left_red_aa0000.png" alt="Fork me on GitHub">
</a>

<div id="wrap">
<div id="switcher_parent">
	<?php if(!$themeroller)
{
	?>
	<div id="switcher" class="notr">
		<a href="?themeroller=true">
			Tried Tagit with ThemeRoller?<br/>
			<img class="tr"
			     src="http://www.filamentgroup.com/examples/RollAUI/images/themeroller_ready_white_400px.gif"/>
		</a>
	</div>
	<?php
}
else
{
	?>
	<div id="switcher"></div>
	<?php } ?>
</div>
<h1>jQuery Tagit Demo Page</h1>

<div id="description" class="box"><a name="description"></a>
	The jQuery Tagit plugin transforms an html unordered list into a unique tagging plugin.<br/>
	Why unique? Because jQuery Tagit uses jQuery Ui's auto-complete plugin to supply suggestions to users
	as they type.
</div>

<div class="box"><a href="#demos">Jump straight to the demos!</a></div>

<h2><a name="browsers">Browser Support</a></h2>

<div class="box">
	<div class="browser">
		<a id="chrome" href="http://www.google.com/chrome">
			<div>Works in Google Chrome!</div>
		</a>
	</div>
	<div class="browser">
		<a id="firefox" href="http://www.mozilla.com">
			<div>Works in Firefox!</div>
		</a>
	</div>
	<div class="browser">
		<a id="ie" href="http://www.microsoft.com/windows/internet-explorer">
			<div>Works in IE7+!</div>
		</a>
	</div>
	<div class="browser">
		<a id="opera" href="http://www.opera.com">
			<div>Works in Opera!</div>
		</a>
	</div>
	<div class="browser" style="margin-right: 0">
		<a id="safari" href="http://www.apple.com/safari">
			<div>Works in Safari!</div>
		</a>
	</div>
	<div style="clear: both;"></div>
</div>

<h2><a name="features">Features</a></h2>

<div class="box features">
	<ul>
		<li>Convenient way for users to enter a list of items</li>
		<li>Fully integrated with jQuery ui auto complete</li>
		<li>Automatically adds current input as tag if input loses focus</li>
		<li>Easy to use public methods</li>
		<li>Easy to theme e.g.(<a href="?theme=simple-green#demos">Simple Green</a> <a href="?theme=simple-blue#demos">Simple
			Blue</a> <a href="?theme=simple-grey#demos">Simple Grey</a>)
		</li>
		<li>Customizable <em>accept</em> keys</li>
		<li>Backspace on empty input deletes previous tag</li>
		<li>Ability to provide <em>initial tags</em> on creation through options</li>
		<li>Ability to provide <em>initial tags</em> on creation via list items</li>
		<li>Option to toggle usage of a hidden select so the tags can be sent using a normal form!</li>
		<li>Ability to re-arrange tags by drag and drop!</li>
		<li><a href="?themeroller=true">Optional ThemeRoller compatibility!</a></li>
	</ul>
</div>

<h2><a name="code">The Minimum Code Required</a></h2>

<div class="code box">
	$(<span class="green">'#tags'</span>).tagit();
</div>

<h2><a name="options">Options</a></h2>

<table class="options">
	<thead>
	<tr>
		<th>Name</th>
		<th>Type</th>
		<th>Default</th>
		<th>Note</th>
	</tr>
	</thead>
	<tbody>
	<tr class="odd">
		<td>tagSource</td>
		<td>String, Array, Callback</td>
		<td>[]</td>
		<td class="left">This option maps directly to the <a href="http://jqueryui.com/demos/autocomplete/">jQuery
			UI Autocomplete source option</a></td>
	</tr>

	<tr class="even">
		<td>triggerKeys</td>
		<td>Array</td>
		<td>['enter', 'space', 'comma', 'tab']</td>
		<td class="left">An array containing all or any of the default options.<br/>
			These are the keys that will trigger a tag completion
		</td>
	</tr>

	<tr class="odd">
		<td>allowNewTags</td>
		<td>Bool</td>
		<td>true</td>
		<td class="left">Allow tags that do not exist in tagSource to be entered?</td>
	</tr>

	<tr class="even">
		<td>initialTags</td>
		<td>Array</td>
		<td>[]</td>
		<td class="left">An array containing tags to pre-populate the field with</td>
	</tr>

	<tr class="odd">
		<td>minLength</td>
		<td>Int</td>
		<td>1</td>
		<td class="left">The minimum length before a triggerKey will create a tag</td>
	</tr>

	<tr class="even">
		<td>select</td>
		<td>Bool</td>
		<td>false</td>
		<td class="left">Maintain a hidden select in place for form submissions<br/>
			To name the select simply give your UL a name attribute!
			<hr/>
			Don't forget
			to include &#91; and &#93; if your language (e.g. PHP) requires them!
		</td>
	</tr>

	<tr class="odd">
		<td>tagsChanged</td>
		<td>Callback</td>
		<td>function(tagValue, action, element)</td>
		<td class="left">Callback on changed tags:<br>
			<b>tagValue:</b> string<br>
			<b>action:</b> string - either 'added', 'popped', 'moved' or 'reset'<br>
			<b>element:</b> object - reference to the added LI element
		</td>
	</tr>

	<tr class="even">
		<td>caseSensitive</td>
		<td>Bool</td>
		<td>false</td>
		<td class="left">
			The check for existing tags is case sensitive. If false the words "Foo" and "foo" considered the same
		</td>
	</tr>

	<tr class="odd">
		<td>highlightOnExistColor</td>
		<td>String</td>
		<td>#0F0</td>
		<td class="left">
			If the user tries to add a tag, that already exists, the existing tag will run a highlight effect using
			the defined background color.
			If null, the highlight effect is turned off.
		</td>
	</tr>

	<tr class="even">
		<td>maxLength</td>
		<td>Int</td>
		<td><em>unlimited</em></td>
		<td class="left">
			The maximum allowable length of a tag.<br/>
			If omitted, tags of unlimited length are allowed.
		</td>
	</tr>

	<tr class="odd">
		<td>maxTags</td>
		<td>Int</td>
		<td><em>unlimited</em></td>
		<td class="left">
			The maximum number of tags that the user can enter.<br/>
			If omitted, an unlimited number of tags are allowed.
		</td>
	</tr>

	<tr class="even">
		<td>sortable</td>
		<td>Bool, String</td>
		<td><em>false</em></td>
		<td class="left">
			Allows the user to re-order the tags using drag and drop.<br/>
			If true the whole tag is draggable, if 'handle' a handle is <br/>
			rendered and the tag is only draggable using the handle.
		</td>
	</tr>
	</tbody>
</table>

<h2><a name="methods">Methods</a></h2>

<table class="methods">
	<thead>
	<tr>
		<th>Name</th>
		<th>Return</th>
		<th>Note</th>
	</tr>
	</thead>
	<tbody>
	<tr class="odd">
		<td>.tagit("destroy")</td>
		<td>null</td>
		<td class="left">Returns the ul to its original state</td>
	</tr>

	<tr class="even">
		<td>.tagit("tags")</td>
		<td>Array</td>
		<td class="left">Returns an array of objects about all the tags.</td>
	</tr>

	<tr class="odd">
		<td>.tagit("reset")</td>
		<td>null</td>
		<td class="left">Resets the tags list to the initial value</td>
	</tr>

	<tr class="even">
		<td>.tagit("fill", [{label: 'tag', value: 12}, {label: 'stuff', value: 13}])</td>
		<td>null</td>
		<td class="left">Empties the tags and fills the plugin with the provided tags.</td>
	</tr>

	<tr class="odd">
		<td>.tagit("add", {label: 'tag', value: 12})</td>
		<td>Bool</td>
		<td class="left">Adds a tag to the plugin.</td>
	</tr>

	</tbody>
</table>

<h2><a name="demos">Demos</a></h2>
<?php if(!$themeroller)
{
	?>
<div class="box"><strong>Theme: </strong>
	<a href="?theme=simple-green#demos">Simple Green</a> |
	<a href="?theme=simple-blue#demos">Simple Blue</a> |
	<a href="?theme=simple-grey#demos">Simple Grey</a> |
	<a href="?theme=stylish-yellow#demos">Stylish Yellow</a> |
	<a href="?theme=dark-grey#demos">Dark Grey</a> |
	<a href="?theme=awesome-orange#demos">Awesome Orange</a> |
	<a href="?theme=awesome-blue#demos">Awesome Blue</a> |
</div>
	<?php } ?>

<h3>Hidden Select</h3>

<div class="box">
	<div class="note">
		Normally the select is hidden, however we have shown it for this demo so you can see
		how it operates!
	</div>
	<ul id="demo1" name="nameOfSelect"></ul>
	<div class="buttons">
		<button id="demo1GetTags" value="Get Tags">Get Tags</button>
	</div>
</div>

<h3>Initial Tags</h3>

<div class="box">
	<div class="note">
		You can manually specify tags in your markup by adding <em>list items</em> to the unordered list!
	</div>

	<ul id="demo2" name="demo2">
		<li>here</li>
		<li>are</li>
		<li>some</li>
		<li>initial</li>
		<li>tags</li>
	</ul>
	<div class="buttons">
		<button id="demo2GetTags" value="Get Tags">Get Tags</button>
		<button id="demo2ResetTags" value="Reset Tags">Reset Tags</button>
	</div>
</div>

<h3>Allowing Spaces</h3>

<div class="box">
	<div class="note">
		By overriding the <em>trigger keys</em> you can have spaces, comma's and any other character in your tags!
	</div>

	<ul id="demo3"></ul>
	<div class="buttons">
		<button id="demo3GetTags" value="Get Tags">Get Tags</button>
	</div>
</div>

<h3>Callback</h3>

<div class="box">
	<div class="note">
		By passing a function in for <em>tagsChanged</em> you can preform your own events too!
	</div>

	<ul id="demo4"></ul>
	<div class="buttons">
		<button id="demo4GetTags" value="Get Tags">Get Tags</button>
	</div>
	<p>Action:

	<div id="demo4Out">none</div>
	<p>
</div>

<h3>Limits</h3>

<div class="box">
	<div class="note">
		You can limit both the maximum and minimum amount of, and characters per tag!
	</div>

	<ul id="demo5"></ul>
	<div class="buttons">
		<button id="demo5GetTags" value="Get Tags">Get Tags</button>
	</div>
	<p>Maximum of 5 tags and 5 characters per tag.</p>
</div>

<h3>Sortable : true</h3>

<div class="box">
	<div class="note">
		You can allow the tags to be sortable by dragging the entire tag!
	</div>

	<ul id="demo6" name="demo6">
		<li>here</li>
		<li>are</li>
		<li>some</li>
		<li>initial</li>
		<li>tags</li>
	</ul>
	<div class="buttons">
		<button id="demo6GetTags" value="Get Tags">Get Tags</button>
	</div>
</div>

<h3>Sortable : handle</h3>

<div class="box">
	<div class="note">
		Or only draggable by a handle!
	</div>

	<ul id="demo7" name="demo7">
		<li>here</li>
		<li>are</li>
		<li>some</li>
		<li>initial</li>
		<li>tags</li>
	</ul>
	<div class="buttons">
		<button id="demo7GetTags" value="Get Tags">Get Tags</button>
	</div>
</div>

<h3>Custom Autocomplete</h3>

<div class="box">
	<div class="note">
		You can hack into the autocomplete dropdown to display custom data!
	</div>
	<?php if($themeroller)
{
	?>
	<ul id="demo8" name="demo8"></ul>
	<div class="buttons">
		<button id="demo8GetTags" value="Get Tags">Get Tags</button>
	</div>
	<?php
}
else
{
	?>
	<div class="note">
		While this demo could be done using either the <a href="?themeroller=true">themeroller</a> or normal version
		for simplicities sake we have only created this particular demo using <a
		href="?themeroller=true">themeroller</a>.
		<hr/>
		Please <a href="?themeroller=true#demo8">Click here to view this demo</a>!
	</div>
	<?php } ?>
</div>


<h2></h2>

<div class="box">
	&copy; Content and Design Matthew Hailwood <?php date_default_timezone_set('UTC'); echo Date('Y'); ?><br/>
</div>

</div>
</body>
</html>
