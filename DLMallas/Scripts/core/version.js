(function ($) {
    "use strict";

    var Version = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });
    };

    var p = Version.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {
        /* diseño tabla */
        $('#tblListado').dataTable({
            responsive: true,
            "language": {
                "url": "/Content/DataTables/plugins/spanish.js"
            }
        });

        /* datepicker version */
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            weekStart: 1,
            //startDate: "now",
            language: "es",
            autoclose: true
        });

        /* popup crea version */
        $("#btnCrearVersion").click(self.crear_version_click);
        /* guarda ajax formulario*/
        $("#btnGuardarNuevaVersion").click(self.guardar_version_click);

        /* actualiza ajax formulario */
        $("#btnActualizarVersion").click(self.actualizar_version_click);
    };

    // Funciones privadas  ======================================================

    p.crear_version_click = function () {
        $("#div_nombre_malla").html($("#malla_hidden").val());
        $("#modCrearVersion").modal('show');
    }

    p.guardar_version_click = function () {
        var fecha = $('#txtFechainicio').val();
        var actionData = { fechainicio: fecha, idmalla: $("#id_malla_hidden").val() };

        if (fecha === "") {
            alert("Debe Ingresar una Fecha");
        } else {
            $.ajax({
                type: "POST",
                url: "/Version/GuardarVersion",
                data: actionData,
                traditional: true,
                success: function(result) {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "/Version/Index/" + $("#id_malla_hidden").val();
                },
                error: function(xhr, status, error) {
                    alert("Ha ocurrido un error al intentar guardar el registro. Error:"+error);
                }
            });
        }
    }

    p.actualizar_version_click = function () {
        var id = $('#txtIdVersion').val();
        var fecha = $('#txtFechainicioActualiza').val();
        var actionData = "{'id':'" + id + "' ,'fechainicio': '" + fecha + "'}";

        if (fecha === "") {
            alert("Debe Ingresar una Fecha");
        } else {
            $.ajax({
                type: "POST",
                url: "/Version/ActualizarVersion",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                dataType: "json",
                success: function () {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "/Version/Index/" + $("#id_malla_hidden").val();
                }
            });
        }
    }

    // Eventos =================================================================

    p.editarVersion = function (id, fechainicio) {
        $("#modEditarVersion").modal('show');
        $('#txtFechainicioActualiza').val(fechainicio);
        $('#txtIdVersion').val(id);
    }

    p.eliminarVersion = function (id) {
        if (confirm("Está Seguro de Eliminar el registro")) {
            $.ajax({
                type: "POST",
                url: "/Version/EliminarVersion",
                contentType: "application/json; charset=utf-8",
                data: "{'id': '" + id + "'}",
                dataType: "json",
                success: function () {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "/Version/Index/" + $("#id_malla_hidden").val();
                }
            });
        }
    }

    p.detalleVersion = function (id, idMalla) {
        //alert(id);;
        //DetalleVersion
        window.location.href = "/Version/DetalleVersion/?IdVersion=" + id + "&idMalla=" + idMalla;
    }


    // =========================================================================
    window.version = new Version();
}(jQuery));
