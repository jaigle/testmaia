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
        $("#btnAgregarParticipante").click(self.agregar_participante_click);
        $("#btnBuscarParticipante").click(self.buscar_participante_click);
        $("#btnGuardarParticipante").click(self.guardar_participante_click);
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

    p.agregar_participante_click = function () {
        $("#modAgregarParticipante").modal("show");
    }

    p.buscar_participante_click = function () {
        var txtCedulaIdent = $("#txtCedulaIdent").val();
        var txtSociedadCont = $("#txtSociedadCont").val();
        var txtApellidoPat = $("#txtApellidoPat").val();
        var txtApellidoMat = $("txtApellidoMat").val();
        var txtCargo = $("txtCargo").val();
        var txtUnidadOrg = $("txtUnidadOrg").val();
        var txtFranquicia = $("txtFranquicia").val();
        var txtUnidadNeg = $("txtUnidadNeg").val();

        if (txtCedulaIdent !== "" || txtSociedadCont !== "" ||
            txtApellidoPat !== "" || txtApellidoMat !== "" ||
            txtCargo !== "" || txtUnidadOrg !== "" ||
            txtFranquicia !== "" || txtUnidadNeg !== "") {

            var actionData = {
                cedulaIdent: txtCedulaIdent, 
                apellidoPat:  txtApellidoPat, 
                apellidoMat: txtApellidoMat,
                cargo: txtCargo,
                sociedadCont: txtSociedadCont,
                unidadOrg: txtUnidadOrg,
                franquicia: txtFranquicia,
                unidadNeg: txtUnidadNeg
            }

            $.ajax({
                type: "POST",
                url: "/AdministracionItinerario/BuscarParticipante",
                contentType: "text/html; charset=utf-8",
                data: actionData,
                dataType: "html",
                complete: function (result) {
                    $('#contenidoListadoParticipantes').html(result.responseText);
                    $("#tblListadoParticipantes").dataTable({
                        responsive: true,
                        "language": {
                            "url": "/Content/DataTables/plugins/spanish.js"
                        }
                    });
                }
            });
        }
    }

    p.guardar_participante_click = function() {
        var ids = [];

        $("input.chkNominaParticipante:checked").each(function () {
            ids.push(this.value);
        });

        var itinerario = $("#id_itinerario_hidden").val();

        if (ids.length === 0 || itinerario === "") {
            alert("Selecione al menos un participante!");
        } else {
            var actionData = { idItinerario: itinerario, participantes: ids.toString() };
            
            $.ajax({
                type: "POST",
                url:  "/AdministracionItinerario/GuardarParticipantes",
                traditional: true,
                data: actionData,
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "/AdministracionItinerario/Audiencia/" + itinerario;
                },
                error: function (xhr, status, error) {
                    alert("Ha ocurrido un error al intentar guardar el registro.");
                }
            });

        }
    }

    // Eventos =================================================================


    // =========================================================================
    window.audiencia = new Audiencia();
}(jQuery));
