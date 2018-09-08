(function ($) {
	"use strict";

	var Malla = function () {
		// Create reference to this instance
		var self = this;
		// Initialize app when document is ready
		$(document).ready(function () {
		    self.initialize();
		});
	};

	var p = Malla.prototype;

	// =========================================================================
	// INIT
	// =========================================================================

	p.initialize = function () {

	    $('#tblListado').dataTable({
	        responsive: true,
	        "language": {
	            "url": "/Content/DataTables/plugins/spanish.js"
	        }
	    });

	    $("#btnCrearMalla").click(function () {
	        $("#modCrearMalla").modal('show');
	    });

	    $("#btnGuardarNuevaMalla").click(function () {

	        var nombre = $('#txtNombre').val();
	        var desc = $('#txtDescripcion').val();
	        var activo = ($('#chkActiva').is(":checked")) ? "1" : "0";

	        if (nombre == "" || desc == "") {
	            alert("Debe Ingresar un Nombre y Descripción");
	        }
	        else {
	            var actionData = "{'nombre': '" + nombre + "','desc': '" + desc + "', 'activo': '" + activo + "'}";

	            $.ajax({
	                type: "POST",
	                url: "/Malla/GuardarMalla",
	                contentType: "application/json; charset=utf-8",
	                data: actionData,
	                dataType: "json",
	                complete: function (result) {
	                    alert("Registro Guardado Correctamente");
	                    window.location.href = "/Malla";
	                }
	            });
	        }
	    });
	};

    
    // Eventos =================================================================

    p.eliminaMalla = function (id) {
        if (confirm("Está seguro de elimina el registro?")) {
            $.ajax({
                type: "POST",
                url: "/Malla/EliminarMalla",
                contentType: "application/json; charset=utf-8",
                data: "{'id':'" + id + "'}",
                dataType: "json",
                complete: function (result) {
                    alert("Registro Eliminado Correctamente");
                    window.location.href = "/Malla";
                }
            });
        }
    }

	// =========================================================================
	window.Malla = new Malla();
}(jQuery)); 
