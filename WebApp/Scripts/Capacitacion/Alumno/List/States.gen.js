//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function loadAlumnosFilterState() {
    var data = pageData.AlumnosMainListParams;
    if (!isNull(data)) {
        if (!isNull(data.FilterNombres)) {
            $("#txt-nombres").val(data.FilterNombres);
        }
        if (!isNull(data.FilterApellidos)) {
            $("#txt-apellidos").val(data.FilterApellidos);
        }
        if (!isNull(data.FilterFechaNacimientoFrom)) {
            $('#txt-fecha-nacimiento-from').datepicker('setDate', Globalize.parseDateISOString(data.FilterFechaNacimientoFrom));
        }
        if (!isNull(data.FilterFechaNacimientoTo)) {
            $('#txt-fecha-nacimiento-to').datepicker('setDate', Globalize.parseDateISOString(data.FilterFechaNacimientoTo));
        }
    }

}
