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
            format: "yyyy/mm/dd",
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
        $("#modCrearVersion").modal('show');
    }

    p.guardar_version_click = function () {

        var fecha = $('#txtFechainicio').val();
        //var actionData = "{'fechainicio': '" + fecha + "','idmalla': '" + @Model.ObtenerMalla[0].Id + "'}";

        if (fecha == "") {
            alert("Debe Ingresar una Fecha");
        } else {
            $.ajax({
                type: "POST",
                url: "/Version/GuardarVersion",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                dataType: "json",
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                    //window.location.href = "@Url.Action("Index", "Version", new { id = @Model.ObtenerMalla[0].Id })";
                }
            });
        }
    }

    p.actualizar_version_click = function () {
        var id = $('#txtIdVersion').val();
        var fecha = $('#txtFechainicioActualiza').val();
        var actionData = "{'id':'" + id + "' ,'fechainicio': '" + fecha + "'}";

        if (fecha == "") {
            alert("Debe Ingresar una Fecha");
        } else {
            $.ajax({
                type: "POST",
                url: "/Version/ActualizarVersion",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                dataType: "json",
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                    //window.location.href = "@Url.Action("Index", "Version", new { id = @Model.ObtenerMalla[0].Id })";
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

    p.eliminarVersion =  function(id) {
        if (confirm("Está Seguro de Eliminar el registro")) {
            $.ajax({
                type: "POST",
                url: "/Version/EliminarVersion",
                contentType: "application/json; charset=utf-8",
                data: "{'id': '" + id + "'}",
                dataType: "json",
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                    //window.location.href = "@Url.Action("Index", "Version", new { id = @Model.ObtenerMalla[0].Id })";
                }
            });
        }
    }

    p.detalleVersion = function(id, idMalla)
    {
        //alert(id);;
        //DetalleVersion
        window.location.href = "/Version/DetalleVersion/?IdVersion=" + id + "&idMalla=" + idMalla;
    }


    // =========================================================================
    window.version = new Version();
}(jQuery));
