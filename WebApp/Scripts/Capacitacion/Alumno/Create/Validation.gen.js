//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function validateAlumno(params, errors) {
    if (params.Nombres.isEmpty()) {
        errors.push(Globalize.formatMessage("ErrorNoNombres"));
    }
    if (params.Apellidos.isEmpty()) {
        errors.push(Globalize.formatMessage("ErrorNoApellidos"));
    }
}
