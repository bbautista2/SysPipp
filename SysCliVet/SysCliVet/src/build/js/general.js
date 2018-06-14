/*--------  Handlebars   -------*/
function fn_CargarPlantilla(plantillaID, objetoJson) {
	Handlebars.registerHelper('ifCond', function (v1, v2, options) {
		if (v1 > v2) {
			return options.fn(this);
		}
		return options.inverse(this);
	});

	Handlebars.registerHelper('showDollar', function (v1, options) {
		if (v == "1") {
			return options.fn(this);
		}
		return options.inverse(this);
	});

	Handlebars.registerHelper('escape', function (text) {
		return Handlebars.escapeExpression(fn_strEscapeSingleQuotes($('<div />').html(text).text()));
	});
	
	var stemplate = $("#" + plantillaID).html();
	var tmpl = Handlebars.compile(stemplate);
	var html = tmpl(objetoJson);
	return html;
}

function fn_AbrirLink(val) {
	window.open(val, '_blank');
}

function Fn_Mensaje(title, text, type) {
	new PNotify({
		title: title,
		text: text,
		type: type,
		styling: 'bootstrap3'
	});
}

function FN_LlamarMetodo(url, data, success, error) {
	$.ajax({
		type: "POST",
		url: url,
		data: data,
		headers: { 'XSS-Custom-Header': 'Async' },
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: success,
		error: error
	});
}