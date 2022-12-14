//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function btnDeleteAlumnosClick() {
    var ids = new Array();
    $.each(pageData.tbAlumnos.table("getRows"), function (item, value) {
        if ($(':checkbox', value).is(":checked")) {
            ids.push($(value).data('data').Id);
        }
    });

    if (ids.length === 0) {
        showMessage(Globalize.formatMessage('MessageAtLeastOneEntry'));
    } else {
        var buttons = new Object();
        buttons[Globalize.formatMessage('TextYes')] = function () {
            var popup = $(this);
            popup.block();
            $.ajax({
                url: appData.siteUrl + 'api/v1/alumnos/delete',
				type: 'POST',
                data: $.toJSON({
                    Ids: ids
                }),
                success: function () {
                    popup.unblock();
					popup.dialog('close');
					showMessage(Globalize.formatMessage("MessageRemovedOK"), true);
					pageData.tbAlumnos.table('update');
                },
				error: function(xhr) {
				    popup.unblock();
				    if (xhr.status !== 500) {
				        var result = $.parseJSON(xhr.responseText);
				        showErrors(result.Errors);
				    } else {
				        showApplicationFatalErrorMessage();
				    }					
					pageData.tbAlumnos.table('update');
					popup.dialog('close');
				}
            });
        };
        buttons[Globalize.formatMessage('TextNo')] = function () {
            $(this).dialog('close');
        };
        showCustomMessage({
            message: Globalize.formatMessage('MessageConfirmRemoveEntries'),
            buttons: buttons
        });
    }
}

function popupDeleteAlumnos(id) {
    var buttons = new Object();
    var popup = null;

    buttons[Globalize.formatMessage('TextYes')] = function () {
        var popup = $(this);
        popup.block();
        $.ajax({
			url: appData.siteUrl + 'api/v1/alumnos/delete',
			type: 'POST',
            data: $.toJSON({
                Ids: [ id ]
            }),
            success: function () {
                popup.unblock();
				popup.dialog('close');
				showMessage(Globalize.formatMessage("MessageRemovedOK"), true);
				pageData.tbAlumnos.table('update');
            },
			error: function(xhr){
                popup.unblock();
				popup.dialog('close');
				if (xhr.status !== 500) {
					var result = $.parseJSON(xhr.responseText);
					showErrors(result.Errors);
				} else {
					showApplicationFatalErrorMessage();
				}			
				pageData.tbAlumnos.table('update');
			}
        });
    };
    buttons[Globalize.formatMessage('TextNo')] = function () {
        $(this).dialog('close');
    };
    showCustomMessage({
        message: Globalize.formatMessage('MessageConfirmRemoveEntry'),
        buttons: buttons,
        open: function () {
            popup = $(this);
        }
    });
}
