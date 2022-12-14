//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function loadAlumnosDataSetOptions() {
    $('#btn-select-alumnos').hide();
    $('#btn-go-back').hide();
    $('#btn-new-alumno').click(function () {
        appData.redirectTo('Alumno/Create');
    });
    $('#btn-clone-alumnos').click(btnCloneAlumnosClick);
    $('#btn-delete-alumnos').click(btnDeleteAlumnosClick);
    $("#btn-export-alumnos").click(btnExportAlumnosClick);
    $("#btn-print-alumnos").click(btnPrintAlumnosClick);
}

function loadAlumnosSelectionButtons() {
    $('#btn-new-alumno').click(function () {
        appData.redirectTo('Alumno/Create');
    });
	
    $('#btn-clone-alumnos').hide();
	
    $('#btn-delete-alumnos').hide();
	
    $("#btn-export-alumnos").hide();
	
    $("#btn-print-alumnos").hide();
	
    $('#btn-select-alumnos').click(function () {
        var items = new Array();
        $.each(pageData.tbAlumnos.table("getRows"), function (item, value) {
            if ($(':checkbox', value).is(":checked")) {
                items.push({
                    Id: $(value).data('data').Id,
                    Value: $(value).data('data').DisplayName
                });
            }
        });

        if (items.length === 0) {
            showMessage(Globalize.formatMessage('MessageAtLeastOneEntry'));
        } else {
            $.ajax({
                url: appData.siteUrl + 'SelectItems',
				type: 'POST',
                data: $.toJSON({ SimpleItems: items }),
                success: function () {
                    appData.goBack();					
                }
            });
        }
    });
    $('#btn-go-back').click(function() {
        appData.goBack();		
    });
}
