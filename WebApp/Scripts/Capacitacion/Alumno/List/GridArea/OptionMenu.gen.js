//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Radarc (http://radarc.net) - Radarc version: 4.9.1.22813 Formula: UNIR.1.1 version: 1.1
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
//     If you want to extend or modify the code use the designated extension points / user escapes as described in the product documentation.
// </auto-generated>
//------------------------------------------------------------------------------
function alumnoGridOptionMenu(btnRef, rowValues) {
    btnRef.contextMenu({
        fnLoadServerData: function(callbackRender) {
            var menu = new Array();
            if (pageModulePrivileges.canRead) {
				menu.push({
					value: Globalize.formatMessage('TextShow'),
					url: appData.siteUrl + 'Alumno/Show/' + $(rowValues).data('data').Id
						 + "?navKey=" + appData.currentNavigationNodeKey
				});
			}
            if (pageModulePrivileges.canUpdate) {
				menu.push({
					value: Globalize.formatMessage('TextEdit'),
					url: appData.siteUrl + 'Alumno/Edit/' + $(rowValues).data('data').Id
						 + "?navKey=" + appData.currentNavigationNodeKey
				});
			}
            if (pageModulePrivileges.canClone) {
				menu.push({
					value: Globalize.formatMessage('TextClone'),
					fnClick: function() {
						popupCloneAlumnos($(rowValues).data('data').Id);
						return false;
					}
				});
			}
            if (pageModulePrivileges.canDelete) {
				menu.push({
					value: Globalize.formatMessage('TextDelete'),
					fnClick: function() {
						popupDeleteAlumnos($(rowValues).data('data').Id);
						return false;
					}
				});
			}
            menu.push({ separator: true });
            menu.push({
                value: Globalize.formatMessage('TextShowAudit'),
                fnClick: function() {
                    showPopupPage({
                        url: appData.siteUrl + "Auditing/PopupIndex/" + $(rowValues).data('data').Id
						 + "?navKey=" + appData.currentNavigationNodeKey,
                        width: 800
                    });
                    return false;
                }
            });
            menu.push({
                value: Globalize.formatMessage('TextNotes'),
                fnClick: function() {
                    showPopupPage({
                        url: appData.siteUrl + "Notes/PopupIndex/" + $(rowValues).data('data').Id
						 + "?navKey=" + appData.currentNavigationNodeKey,
                        width: 800
                    });
                    return false;
                }
            });
            callbackRender(menu);
        }
    });
}
