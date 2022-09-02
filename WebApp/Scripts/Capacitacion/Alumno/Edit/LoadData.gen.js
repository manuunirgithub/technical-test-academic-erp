//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function loadAlumnoData() {
    $.blockUI();
    $.ajax({
        url: appData.siteUrl + 'api/v1/alumnos/' + pageData.idAlumno,
		type: 'GET',
        success: function (data, status, xhr) {
            $.unblockUI();			
			pageData.displayNameAlumno = data.DisplayName;			
			
			// Propiedades Escalares
			$('#txt-nombres').val(data.Nombres);
			$('#txt-apellidos').val(data.Apellidos);
			$('#txt-fecha-nacimiento').datepicker('setDate',
				data.FechaNacimiento ? Globalize.parseDateISOString(data.FechaNacimiento) : null);
			loadAlumnoState();
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
}