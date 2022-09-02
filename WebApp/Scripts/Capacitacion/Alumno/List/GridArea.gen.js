//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function loadAlumnosDataGrid() {
    pageData.tbAlumnos = $('#tb-alumnos');
    // **********************************************************
    $('#btn-search').click(function() {
        pageData.tbAlumnos.table('update');
    });
    // **********************************************************
    loadAlumnosFilterState();
    pageData.tbAlumnos.table($.extend({}, {
        oColVis: {
            buttonText: Globalize.formatMessage('TextColumnVisualization'),
            aiExclude: [0]
        },
        sDom: '<"H"flC>t<"H"ip>',
        bInfo: true,
        aoColumns: getAlumnoGridColumns(),
        bServerSide: true,
        fnRowCallback: alumnoGridRowCallback,
        sAjaxSource: appData.siteUrl + 'api/v1/alumnos/advanced-search',
        fnServerData: function(sSource, aoData, fnCallback) {
            var paramsTabla = new Object();
            $.each(aoData, function(index, value) {
                paramsTabla[value.name] = value.value;
            });

            var params = getAlumnosTableParameters(paramsTabla);

            $('#chk-alumnos-all').prop('checked', false);
            pageData.tbAlumnos.table('block');
			
            $.ajax({
                url: sSource,
                data: $.toJSON(params),
				type: 'POST',
                success: function(data, status, xhr) {
					var rows = [];
					pageData.tbAlumnos.table('unblock');
					
					$.each(data, function(index, value) {
						rows.push(createAlumnoGridRow(value));
					});
					fnCallback({
						sEcho: paramsTabla.sEcho,
						aaData: rows,
						iTotalRecords: data.length,
						iTotalDisplayRecords: xhr.getResponseHeader("X-TotalElements")
					});

					pageData.tbAlumnos.table('setData', data);
                },
                error: function (xhr) {
                    pageData.tbAlumnos.table('unblock');
					if (xhr.status !== 500) {
						var result = $.parseJSON(xhr.responseText);
						showErrors(result.Errors);
					} else {
						showApplicationFatalErrorMessage();
					}
                }				
            });
        }
    },{
        iDisplayLength: !isNull(pageData.AlumnosMainListParams.ItemsPerPage) 
                            ? pageData.AlumnosMainListParams.ItemsPerPage
                            : parseInt(appData.itemsPerPage.split('|')[0]),
        aaSorting: [[
            !isNull(pageData.AlumnosMainListParams.OrderColumnPosition) ? pageData.AlumnosMainListParams.OrderColumnPosition : 1,
            !isNull(pageData.AlumnosMainListParams.OrderDirection) ? pageData.AlumnosMainListParams.OrderDirection : 'asc']],
        iDisplayStart: (!isNull(pageData.AlumnosMainListParams.ItemsPerPage) && !isNull(pageData.AlumnosMainListParams.PageIndex))
					? ((pageData.AlumnosMainListParams.PageIndex - 1) * pageData.AlumnosMainListParams.ItemsPerPage)
					: 0
    }));

    $('#chk-alumnos-all').click(function() {
        if (this.checked) {
            $(':checkbox', pageData.tbAlumnos.table('getRows')).prop('checked', true);
        } else {
            $(':checkbox', pageData.tbAlumnos.table('getRows')).prop('checked', false);
        }
    });
}