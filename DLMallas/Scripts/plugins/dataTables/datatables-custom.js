// Custom Datatables

$(document).ready(function() {
	$('#tblResultados,#tblResultados-asignaciones,#tblResultados-asignacionmasiva').DataTable(
	{
		"language": {
			"url": "DataTables-1.10.5/media/js/dataTables.spanish.js"
		},
		responsive:true, //tabla responsiva
       // "scrollX": true, //scroll horizontal no usar en tablas de modal
		
		// Disable sorting on the no-sort class
"aoColumnDefs" : [ {
    "bSortable" : false,
    "aTargets" : [ "no-sort" ]
} ],

//Disable automatic sorting on the first column
"aaSorting": []
	});


	
	$('table.display').DataTable();/*multiples tablas en la misma página*/

} )

A.DataTable();
