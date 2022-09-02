//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
var pageData = {
    idAlumno: 0,
    displayNameAlumno: '',
};
$(document).ready(function () {
    pageData.idAlumno = parseInt($('#hd-id-alumno').val());
	
    loadAlumnoEditComponents();
    loadAlumnoData();
    
    $('#btn-save').click(function() {
        var errors = new Array();

        var params = getAlumnoEditParameters();
        validateAlumno(params, errors);

        if (errors.length === 0) {
            $.blockUI();
            $.ajax({
                url: appData.siteUrl + 'api/v1/alumnos/' + pageData.idAlumno,
                data: $.toJSON(params),
				type: 'PUT',
                success: function (data, status, xhr) {
                    $.unblockUI();
                    showMessage(Globalize.formatMessage("MessageSavedOK"), true);
                    appData.goBack();
                },
				error: function(xhr) {
				    $.unblockUI();
				    if (xhr.status !== 500) {
				        var result = $.parseJSON(xhr.responseText);
				        showErrors(result.Errors, result.Warnings,
								   function() { appData.goBack(); });
				    } else {
				        showApplicationFatalErrorMessage();
				    }			
				}
            });
		} else {
			showErrors(errors);
		}
    });
});
