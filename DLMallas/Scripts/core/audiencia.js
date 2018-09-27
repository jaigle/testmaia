(function ($) {
    "use strict";

    var Audiencia = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });

    };

    var p = Audiencia.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {
        $("#tblListadoNomina").dataTable({
            responsive: true,
            orderCellsTop: true,
            fixedHeader: true,
            autoFill: true,
            "language": {
                "url": "/Content/DataTables/plugins/spanish.js"
            }
        });

        $("#btnNominaEliminarTodo").click(self.eliminar_todo_click);
        $("#btnNominaEliminarSelecionados").click(self.eliminar_selecionados_click);
    };

    // Funciones privadas  ======================================================

    p.eliminar_todo_click = function () {

        if (confirm("Está seguro de elimina el registro?")) {
            var id = $("#id_itinerario_hidden").val();
            var actionData = { idItinerario: id };

            $.ajax({
                type: "POST",
                url: "/AdministracionItinerario/EliminarNominaTodos",
                traditional: true,
                data: actionData,
                complete: function (result) {
                    alert("Registros eliminados");
                    window.location.href = "/AdministracionItinerario/Audiencia/" + id;
                },
                error: function (xhr, status, error) {
                    alert("Ha ocurrido un error al intentar eliminar los registros.");
                }
            });
        }
    }

    p.eliminar_selecionados_click = function () {

        if (confirm("Está seguro de elimina el registro?")) {
            var id = $("#id_itinerario_hidden").val();
            var ids = [];

            $("input.chkNomina:checked").each(function () {
                ids.push(this.value);
            });

            var actionData = { idItinerario: id, Idslist: ids.toString() };

            $.ajax({
                type: "POST",
                url: "/AdministracionItinerario/EliminarNominaSelecionados",
                traditional: true,
                data: actionData,
                complete: function (result) {
                    alert("Registros eliminados");
                    window.location.href = "/AdministracionItinerario/Audiencia/" + id;
                },
                error: function (xhr, status, error) {
                    alert("Ha ocurrido un error al intentar eliminar los registros.");
                }
            });
        }
    }

    // Eventos =================================================================


    // =========================================================================
    window.audiencia = new Audiencia();
}(jQuery));
