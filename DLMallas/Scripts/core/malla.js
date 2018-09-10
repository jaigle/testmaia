(function ($) {
    "use strict";

    var Malla = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });
    };

    var p = Malla.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {

        $('#tblListado').dataTable({
            responsive: true,
            "language": {
                "url": "/Content/DataTables/plugins/spanish.js"
            }
        });

        $("#btnCrearMalla").click(self.crear_malla_click);
        $("#btnGuardarNuevaMalla").click(self.guardar_malla_click);
        $("#btnActualizaMalla").click(self.actualizar_malla_click);
    };

    // Funciones privadas  ======================================================
    p.crear_malla_click = function () {
        $.ajax({
            type: "POST",
            url: "/Malla/CargarEscuelas",
            contentType: "text/html; charset=utf-8",
            dataType: "html",
            complete: function (result) {
                $('#slEscuela').html(result.responseText);
                $('#modCrearMalla').modal('show');
            }
        });
    }

    p.actualizar_malla_click = function () {
        var id = $('#txtId').val();
        var nombre = $('#txtNombre').val();
        var escuela = $('#slEscuela').val();
        var desc = $('#txtDescripcion').val();
        var activo = ($('#chkActiva').is(":checked")) ? "1" : "0";

        if (nombre === "" || desc === "") {
            alert("Ingrese todos los campos!");
        } else {
            var actionData = {nombre: nombre, escuela: escuela, desc: desc, activo: activo};

            $.ajax({
                type: "POST",
                url: "/Malla/ActualizarMalla",
                traditional: true,
                data: actionData,
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "/Malla";
                },
                error: function(xhr, status, error) {
                    alert("Ha ocurrido un error al intentar guardar el registro.");
                }
            });
        }
    }

    p.guardar_malla_click = function () {
        var nombre = $('#txtNombre').val();
        var escuela = $('#slEscuela').val();
        var desc = $('#txtDescripcion').val();
        var activo = ($('#chkActiva').is(":checked")) ? "1" : "0";

        if (nombre == "" || desc == "" || escuela == "0") {
            alert("Debe Ingresar un Nombre, Descripción y Escuela");
        }
        else {
            var actionData = {nombre: nombre, escuela: escuela, desc: desc, activo: activo};

            $.ajax({
                type: "POST",
                url: "/Malla/GuardarMalla",
                traditional: true,
                data: actionData,
            }).done(function () {
                alert("Registro Guardado Correctamente");
                window.location.href = "/Malla";
            }).fail(function() {
                alert("Ha ocurrido un error al intentar guardar el registro.");
            });
        }
    }

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
