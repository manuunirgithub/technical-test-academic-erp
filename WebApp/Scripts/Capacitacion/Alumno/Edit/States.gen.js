//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function loadAlumnoState() {
	loadAlumnoStateData(pageData.AlumnoInstanceParams);
}

function loadAlumnoStateData(data) {
    // Escalares
    if (!isNull(data) && !isNull(data.Nombres)) {
        $("#txt-nombres").val(data.Nombres);
    }
    if (!isNull(data) && !isNull(data.Apellidos)) {
        $("#txt-apellidos").val(data.Apellidos);
    }
    if (!isNull(data) && !isNull(data.FechaNacimiento)) {
        $('#txt-fecha-nacimiento').datepicker('setDate', Globalize.parseDateISOString(data.FechaNacimiento));
    }
}
