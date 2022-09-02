/* ***** CARGAR GLOBALIZACIÓN ********************************************************************/
Globalize.locale(appData.currentCulture);
/******************************************************************************/

loadAdaptConfig(appData.resourcesUrl + 'Content/utils/adapt/');
/******************************************************************************/
$(document).ready(function () {
    appData.unirCommonsApiVersion = "api/v1/";
    appData.unirCommonsCountries = "countries/";
    appData.unirCommonsDivisions = "divisions/";
    appData.unirCommonsEntities = "entities/";
    appData.unirCommonsFilterPrefix = "filterPrefix";
    appData.unirCommonsPersonalIdentityTypes = "personal-identity-types/";
    appData.unirCommonsCountryPersonalIdentityTypes = "country-personal-identity-types/";
    appData.cbxDivisions = [];
    $.tableSetup({
        bJQueryUI: true,
        aLengthMenu: [
            $.map(appData.itemsPerPage.split('|'), function (item) {
                return parseInt(item);
            }),
            $.map(appData.itemsPerPage.split('|'), function (item) {
                return parseInt(item);
            })],
        iDisplayLength: parseInt(appData.itemsPerPage.split('|')[0])
        //bLengthChange  : false
    });
    /**************************************************************************/
    $.comboboxSetup({
        delay: 900,
        textOverlabel: Globalize.formatMessage('TextSimpleSearch'),
        messageLoading: $('<img />').addClass('ui-box-message-loading')
                .attr('title', Globalize.formatMessage('TextLoading'))
                .attr('alt', Globalize.formatMessage('TextLoading'))
                .attr('src', appData.resourcesUrl + 'images/loading-control.gif'),
        pageable: true,
        configButtonPrev: {
            label: 'Anterior',
            text: true,
            icons: {}
        },
        configButtonNext: {
            label: 'Siguiente',
            text: true,
            icons: {}
        }
    });
    /**************************************************************************/
    $('.box-fieldset .field-title').collapsibleContainer();
    /**************************************************************************/
    $.showPopupPageSetup({
        title: 'Gestión de Prácticas'
    });
    /**************************************************************************/
    $.showCustomMessageSetup({
        title: 'Gestión de Prácticas'
    });
    /**************************************************************************/
    $.showMessageSetup({
        title: 'Gestión de Prácticas',
        minHeight: 80,
        timeOut: 1000
    });
    /**************************************************************************/
    //$.blockUI.defaults.message = 'Cargando...';
    $.blockUI.defaults.message = '<img src="' + appData.resourcesUrl + 'images/loading.gif' + '" />';
    $.blockUI.defaults.css.border = '0px';
    $.blockUI.defaults.css.backgroundColor = 'transparent';
    $.blockUI.defaults.overlayCSS.backgroundColor = '#000000';
    $.blockUI.defaults.overlayCSS.opacity = 0.5;
    $.blockUI.defaults.filter = 'Alpha(Opacity=50)';

    $.datepickerSetup({
        buttonImage: appData.resourcesUrl + "images/calendar.gif"
    });
    /**************************************************************************/
    $('.accordion').accordion();
    /**************************************************************************/
    $.ajaxSetup({
        cache: false,
        type: "POST",
        contentType: "application/json",
        complete: function (xhr) {
            if (xhr.status == 401) {
                showErrors(["Su sesión de usuario ha expirado. Por favor, acceda de nuevo a la aplicación"])
                window.location.href = appData.erpAcademicoHostHome;
            }
        }
    });
    /**************************************************************************/
    $('.tabs').tabs();
    /**************************************************************************/
    $('.button').button();
    /**************************************************************************/
    $('input.datepicker').compDatepicker();
    /**************************************************************************/
    $('.box-current-user .btn-opciones').click(function () {
        $('.box-current-user .list-opciones').toggle('fade');
    });
});
/*************************************************************************************************/
/*AUTONUMERIC*/
var decimalSeparator = Globalize.numberFormatter()(1.1).substring(1, 2);
var thousandsSeparator = Globalize.numberFormatter()(10000).substring(2, 3);
if (thousandsSeparator === "0")
    thousandsSeparator = "";

appData.autoNumeric = {
    integerFormat: {
        mDec: 0,
        aSep: thousandsSeparator,
        aDec: decimalSeparator
    },
    decimalFormat: {
        mDec: 2,
        aSep: thousandsSeparator,
        aDec: decimalSeparator
    },
    numberNoFormat: {
        mDec: 0,
        aSep: '',
        aDec: '.'
    },
};



/*********************************************************************************************/
appData.redirectTo = function (route) {
    if ($.isPlainObject(route)) {
        $.ajax({
            url: appData.siteUrl + route.saveRoute,
            data: $.toJSON(route.saveParams),
            success: function () {
                appData.redirectTo(route.route);
            }
        });
    } else {
        if (route) {
            if (appData.currentNavigationNodeKey) {
                window.location.href = appData.siteUrl + route;
            } else {
                window.location.href = appData.siteUrl + route;
            }
        } else {
            if (appData.currentNavigationNodeKey) {
                window.location.href = appData.siteUrl + "?navKey=" + appData.currentNavigationNodeKey;
            } else {
                window.location.href = appData.siteUrl;
            }
        }
    }
};
/******************************************************************************/
appData.goBack = function () {
    appData.redirectTo("GoBack");
};
/******************************************************************************/
/**
 * Muestra dialog o popup para un mensaje de success con warning
 */
function showMessageWithWarnings(title, message, warnings) {
    var dialog = $('<div />')
    $('<p />').text(message).appendTo(dialog);
    if ($.isArray(warnings) && warnings.length > 0) {
        var list = $('<ul class="list-errors" />');
        $.each(warnings, function (item, value) {
            $('<li class="item-warning" />').text(value).appendTo(list);
        });
        dialog.append(list);
    }
    dialog.dialog({
        title: title,
        modal: true,
        close: function (event, ui) {
            $('.list-errors', this).empty();
        }
    });
}

/**
 * generar html para parrafo resumido
 */
function summaryHtml(text, length, end) {

    return '<span title="' + text + '">'
        + trim(text.substr(0, length) + ((text.length > length) ? (isNull(end) ? '' : '...') : ''))
        + '</span>';
}

/*Configuracion toolbar combo por privilegios*/
function setPersistenceStatus(selectRef, moduleKeyName) {
    if (!pageModulePrivileges[moduleKeyName].canCreate)
        selectRef.combobox('removeToolAdd');
    if (!pageModulePrivileges[moduleKeyName].canUpdate)
        selectRef.combobox('removeToolEdit');
}

// Prototipando Globalize para acatar la recomendación de no extener tipos integrados
Globalize.formatDateToISOString = function (date) {
    var datetimeMoment = moment(date);
    var dateMoment = moment.utc({
        year: datetimeMoment.year(),
        month: datetimeMoment.month(),
        day: datetimeMoment.date()
    });
    return dateMoment.toISOString();
};
Globalize.formatDateToUTCISOString = function (date) {
    var dateUtc = new Date(
        date.getUTCFullYear(),
        date.getUTCMonth(),
        date.getUTCDate(),
        date.getUTCHours(),
        date.getUTCMinutes(),
        date.getUTCSeconds());
    return Globalize.formatDateToISOString(dateUtc);
};
Globalize.parseDateISOString = function (isoString) {
    var dateMoment = moment(isoString, "YYYY-MM-DDTHH:mm:ss");
    return dateMoment.toDate();
};
Globalize.formatDateUsingMask = function (date, mask) {
    var dateMoment = moment(date);
    if (mask) {
        return dateMoment.format(mask);
    }
    return dateMoment.format('DD/MM/YYYY');
};
// ----

// ----- Protección contra XSS para JQuery Datatables
function escapeHtmlCellRender(data) { return $('<div/>').text(data).html(); }
// -----


function CustomDefaultCombobox(conf) {
    if (isNull(conf)) {
        return {};
    }

    if (!$.isFunction(conf.fnParams)) {
        conf.fnParams = function () {
            return {};
        };
    } else {
        if (!$.isPlainObject(conf.fnParams())) {
            conf.fnParams = function () {
                return {};
            };
        }
    }

    if (!$.isFunction(conf.fnPrecondition)) {
        conf.fnPrecondition = function () {
            return true;
        };
    }

    conf.changeParams = isNull(conf.changeParams) ? {} : conf.changeParams;
    conf.changeParams.SearchText = isNullOrEmpty(conf.changeParams.SearchText) ? 'Descripcion,Description' : conf.changeParams.SearchText;
    conf.changeParams.PageIndex = isNullOrEmpty(conf.changeParams.PageIndex) ? 'PageIndex,Pagina' : conf.changeParams.PageIndex;
    conf.successData = isNull(conf.successData) ? {} : conf.successData;
    conf.successData.Id = isNullOrEmpty(conf.successData.Id) ? 'Id' : conf.successData.Id;
    conf.successData.Description = isNullOrEmpty(conf.successData.Description) ? 'Description,Descripcion' : conf.successData.Description;

    var extraConfig = {
        fnLoadServerData: function (elem, request, response) {
            if (conf.fnPrecondition()) {
                if (elem.options.messageLoading) {
                    elem.box.append(elem.options.messageLoading);
                }

                var dataParams = conf.fnParams();
                $.each(conf.changeParams.SearchText.split(','), function (i, v) {
                    dataParams[v] = request.term;
                });
                $.each(conf.changeParams.PageIndex.split(','), function (i, v) {
                    dataParams[v] = elem.getCurrentPage();
                });

                $.ajax({
                    url: $.isFunction(conf.url) ? conf.url() : conf.url,
                    data: $.toJSON(dataParams),
                    type: 'POST',
                    success: function (data, status, xhr) {
                        if (elem.options.messageLoading) {
                            elem.options.messageLoading.remove();
                        }

                        elem.loadPagination({
                            totalPages: xhr.getResponseHeader("X-TotalPages")
                        });

                        var fnValueProperty = function (obj, propertyes, index) {
                            if (index > propertyes.length) return '';
                            if (!isNull(obj[propertyes[index]]) && obj[propertyes[index]].toString() != ''
                            ) return obj[propertyes[index]];
                            return fnValueProperty(obj, propertyes, index + 1);
                        };

                        var textMappings = conf.successData.Description.split(',');
                        var idMappings = conf.successData.Id.split(',');

                        response($.map(data, function (item) {
                            var text = fnValueProperty(item, textMappings, 0);
                            var id = fnValueProperty(item, idMappings, 0);
                            item.Description = text;

                            var itemLabel = highlightText(isNull(item.Descripcion)
                                    ? (!isNull(conf.itemLength)
                                        ? summary(item.Description, conf.itemLength, '...')
                                        : item.Description)
                                    : (!isNull(conf.itemLength)
                                        ? summary(item.Descripcion, conf.itemLength, '...')
                                        : item.Descripcion),
                                    request.term);
                            var itemValue = isNull(item.Descripcion) ? item.Description : item.Descripcion;

                            if (!isNull(conf.fnPreloadLabel)) {
                                itemLabel = conf.fnPreloadLabel(item);
                            }
                            if (!isNull(conf.fnPreloadValue)) {
                                itemValue = conf.fnPreloadValue(item);
                            }
                            return {
                                label: itemLabel,
                                value: itemValue,
                                id: id,
                                option: this,
                                data: item
                            };
                        }));
                    }
                });
            }
        }
    };
    conf = $.extend({}, extraConfig, conf);
    return conf;
}

function clearTable(table) {
    var rows = table.table('getRows');
    if (rows.length) {
        $(rows).remove();
        $.each(rows,
            function (index, value) {
                table.dataTable().fnDeleteRow(value);
            });
    }
}
