(function ($) {
    "use strict";

    var AdminItinerario = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });

    };

    var p = AdminItinerario.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {
        $("#tblItinerarios").dataTable({
            responsive: true,
            orderCellsTop: true,
            fixedHeader: true,
            autoFill: true,
            "language": {
                "url": "/Content/DataTables/plugins/spanish.js"
            }
        });

        $('.date').datepicker({
            format: "dd/mm/yyyy",
            weekStart: 1,
            //startDate: "now",
            language: "es",
            autoclose: true
        });

        window.interval = setInterval(self.configuracion_vista, 50);
        $.fn.dataTable.ext.search.push(self.dataTable_ext_search);
        $("#btnCrearItinerario").click(self.crear_itinerario_click);
        $("#btnSelectMalla").click(self.selecionar_malla_click);
        $("#btnAceptarSelecionMalla").click(self.aceptar_malla_selecionada);
        $("#btnGuardarNuevoItinerario").click(self.aceptar_guardar_itinerario);
        $("#btnSelectMallaEditar").click(self.selecionar_malla_editar_click);
        $("#btnActualizaItinerario").click(self.aceptar_actualizar_itinerario);
    };

    // Funciones privadas  ======================================================

    p.configuracion_vista = function () {
        var html = '<div class="pull-right col-lg-12 col-md-12 col-sm-12">' +
            '<label class="pull-left col-lg-6 col-md-6 col-sm-6"><input type="text" placeholder="Buscar Itinerario" class="form-control input-sm" id="bItinerario"></label>' +
            '<label class="pull-right col-lg-6 col-md-6 col-sm-6"><input type="text" placeholder="Buscar Malla" class="form-control input-sm" id="bMalla"></label></div>';

        $("#tblItinerarios_filter").html(html);
        $("#tblItinerarios_length").addClass("col-lg-4 col-md-4 col-sm-4");

        $('#bItinerario, #bMalla').keyup(function () {
            var table = $('#tblItinerarios').DataTable();
            table.draw();
        });

        window.clearInterval(window.interval);
    };

    p.dataTable_ext_search = function (settings, data, dataIndex) {
        var itinerario = $('#bItinerario').val();
        var malla = $('#bMalla').val();

        var col1 = data[1];
        var col2 = data[2];
        if ((itinerario === undefined && malla === undefined) ||
            (itinerario.length === 0 && malla.length === 0) ||
            (itinerario !== undefined && itinerario.length > 0 && col1.includes(itinerario)) ||
            (malla !== undefined && malla.length > 0 && col2.includes(malla))) {
            return true;
        }
        return false;
    }

    p.crear_itinerario_click = function () {
        $.ajax({
            type: "POST",
            url: "/AdministracionItinerario/TablaSelecionarMalla",
            dataType: "html",
            traditional: true,
            complete: function (req) {
                $("#contenidoSelecionarMallas").html(req.responseText);
                $("#tablaSelecionarMalla").dataTable({
                    responsive: true,
                    "language": {
                        "url": "/Content/DataTables/plugins/spanish.js"
                    }
                });
                $('#modCrearItinerario').modal('show');
            },
            error: function (xhr, status, error) {
                alert("Ha ocurrido un error al intentar devolver los registros.");
            }
        });
    }

    p.selecionar_malla_click = function () {
        $("#tablaSelecionarMalla_info").parent().removeClass("col-sm-5");
        $("#tablaSelecionarMalla_paginate").parent().removeClass("col-sm-7").addClass("col-sm-12");
        $("#tablaSelecionarMalla_info").html("");
        $('#modSelecionarMalla').modal('show');
    }

    p.selecionar_malla_editar_click = function () {
        $.ajax({
            type: "POST",
            url: "/AdministracionItinerario/TablaSelecionarMalla?idMalla=" + $("#itinerarioMallaIdEditar").val(),
            dataType: "html",
            traditional: true,
            complete: function (req) {
                $("#contenidoSelecionarMallas").html(req.responseText);
                $("#tablaSelecionarMalla").dataTable({
                    responsive: true,
                    "language": {
                        "url": "/Content/DataTables/plugins/spanish.js"
                    }
                });
                $('#modSelecionarMalla').modal('show');
                window.intervalSelect = setInterval(self.configuracion_vista, 50);

            },
            error: function (xhr, status, error) {
                alert("Ha ocurrido un error al intentar devolver los registros.");
            }
        });
    }

    p.configuracion_vista = function () {
        $("#tablaSelecionarMalla_info").parent().removeClass("col-sm-5");
        $("#tablaSelecionarMalla_paginate").parent().removeClass("col-sm-7").addClass("col-sm-12");
        $("#tablaSelecionarMalla_info").html("");
        window.clearInterval(window.intervalSelect);
    };

    p.selecionar_malla_click = function () {
        $("#tablaSelecionarMalla_info").parent().removeClass("col-sm-5");
        $("#tablaSelecionarMalla_paginate").parent().removeClass("col-sm-7").addClass("col-sm-12");
        $("#tablaSelecionarMalla_info").html("");
        $('#modSelecionarMalla').modal('show');
    }

    p.aceptar_malla_selecionada = function () {
        var itinerarioId = $("#itinerarioIdEditar").val();
        var id = $('input[name=mallaRadioBtn]:checked').val();
        if (itinerarioId === undefined) {
            $("#itinerarioMallaId").val(id);
            $("#txtItinerarioMalla").val($("#nombreMalla-" + id).val());
        } else {
            $("#itinerarioMallaIdEditar").val(id);
            $("#txtItinerarioMallaEditar").val($("#nombreMalla-" + id).val());
        }

        $('#modSelecionarMalla').modal('hide');
    }

    p.aceptar_guardar_itinerario = function () {
        var idMalla = $("#itinerarioMallaId").val();
        var nombre = $("#txtItinerarioNombre").val();
        var fechaInic = $("#txtItinerarioFechainicio").val();
        var fechaFin = $("#txtItinerarioFechaFin").val();

        if (idMalla === "" || nombre === "" || fechaInic === "" || fechaFin === "") {
            alert("Ingrese todos los campos!");
        } else {

            var actionData = { mallaId: idMalla, nombre: nombre, fechaInic: fechaInic, fechaFin: fechaFin };
            var url = "/AdministracionItinerario/GuardarItinerario";


            $.ajax({
                type: "POST",
                url: url,
                traditional: true,
                data: actionData,
                complete: function (result) {
                    window.location.href = "/AdministracionItinerario";
                    alert("Registro Guardado Correctamente");
                },
                error: function (xhr, status, error) {
                    alert("Ha ocurrido un error al intentar guardar el registro.");
                }
            });

        }
    }

    p.aceptar_actualizar_itinerario = function () {
        var idMalla = $("#itinerarioMallaIdEditar").val();
        var nombre = $("#txtItinerarioNombreEditar").val();
        var fechaInic = $("#txtItinerarioFechainicioEditar").val();
        var fechaFin = $("#txtItinerarioFechaFinEditar").val();

        if (idMalla === "" || nombre === "" || fechaInic === "" || fechaFin === "") {
            alert("Ingrese todos los campos!");
        } else {

            var id = $("#itinerarioIdEditar").val();
            var url = "/AdministracionItinerario/ActualizarItinerario";
            var actionData = { id: id, mallaId: idMalla, nombre: nombre, fechaInic: fechaInic, fechaFin: fechaFin };

            $.ajax({
                type: "POST",
                url: url,
                traditional: true,
                data: actionData,
                complete: function (result) {
                    alert("Registro Guardado Correctamente");
                },
                error: function (xhr, status, error) {
                    alert("Ha ocurrido un error al intentar guardar el registro.");
                }
            });
        }
    }

   

    // Eventos =================================================================


    // =========================================================================
    window.admin_itinerario = new AdminItinerario();
}(jQuery));
