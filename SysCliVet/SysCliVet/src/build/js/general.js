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

function FN_Mensaje(tipo, mensaje, id) {
    var result = '';
    switch (tipo) {
        case "s":
            result = '<div class="myForm1_alert"><span class=""></span><p class="alert alert-success">' + ((mensaje == undefined) ? "Guardado Correctamente!" : mensaje) + '</p></div>'
            break;
        case "e":
            result = '<div class="myForm1_alert"><span class=""></span><p class="alert alert-danger">' + ((mensaje == undefined) ? "Ha ocurrido un error guardando" : mensaje) + '</p></div>';
            break;
        case "i":
            result = '<p class="alert alert-warning">' + ((mensaje == undefined) ? "Advertencia!" : mensaje) + '</p>';
            break;
    }

    if (id == '' || id == undefined) {
        $('div[id$=idMensaje]').empty().fadeIn().append(result);
        $('div[id$=idMensaje]').delay("6000").fadeOut();
    } else {
        $('div[id$=' + id + ']').empty().fadeIn().append(result);
        $('div[id$=' + id + ']').delay("6000").fadeOut();
    }
    $('html, body').animate({ scrollTop: 1 }, 'slow');
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