(function ($) {
    "use strict";

    var DetalleVersion = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });
    };

    var p = DetalleVersion.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {
        $('#seccion-color-picker').colorpicker();


        $("#btnCrearSeccion").click(self.crear_seccion_click);
        $('#favcolor').change(self.favcolor_change);
        $("#btnGuardarNuevaSeccion").click(self.guardar_seccion_click);
        $("#btnActualizarSeccion").click(self.actualizar_seccion_click);
        /*acciones de componente/uc*/
        $("#btnGuardarNuevoComponente").click(self.guardar_nuevo_componente_click);
        $("#btnActualizarComponente").click(self.actualizar_componente_click);
        $("#btnGuardarPrerrequisito").click(self.guardar_prerrequisito_click);
    };

    // Funciones privadas  ======================================================

    p.crear_seccion_click = function() {
        $('#txtNombreSeccion').val('')
        $('#favcolor').val('')
        $('#txtColorSeccion').val('');
        $("#modCrearSeccion").modal('show');

    };

    p.favcolor_change = function() {
        $('#txtColorSeccion').val($('#favcolor').val());
    };

    p.guardar_seccion_click = function() {
        var nombre = $('#txtNombreSeccion').val();
        var color = $('#txtColorSeccion').val();
        var idVersion = $('#txtIdVersion').val();
        var idMalla = $('#txtIdMalla').val();
        var actionData = "{'idversion': '" + idVersion + "','nombre': '" + nombre + "','color': '" + color + "'}";

        $.ajax({
            type: "POST",
            url: "/Seccion/GuardarSeccion",
            contentType: "application/json; charset=utf-8",
            data: actionData,
            dataType: "json",
            complete: function(result) {
                alert("Registro Guardado Correctamente");
                window.location.href = "/Version/DetalleVersion/?IdVersion=" + idVersion + "&idMalla=" + idMalla;
                //window.location.href = "@Url.Action("DetalleVersion", "Version", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
            }
        });

    };

    p.actualizar_seccion_click = function() {
        var id = $('#txtIdSeccionEdit').val();
        var nombre = $('#txtNombreSeccionEdit').val();
        var color = $('#txtColorSeccionEdit').val();
        var actionData = "{'id':'" + id + "','nombre': '" + nombre + "','color': '" + color + "'}";

        //if (nombre == "" || color == "") {
        //    alert("Debe Ingresar Nombre y Color");
        // } else {
        $.ajax({
            type: "POST",
            url: "/Seccion/ActualizarSeccion",
            contentType: "application/json; charset=utf-8",
            data: actionData,
            dataType: "json",
            complete: function(result) {
                alert("Registro Actualizado Correctamente");
                window.location.href = "@Url.Action("
                DetalleVersion
                ", "
                Version
                ", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
            }
        });
        //}
    };

    p.guardar_nuevo_componente_click = function() {
        var idseccion = $('#comboSeccion').val();
        var idmodalidad = $('#comboModalidad').val();
        var iduc;

        $('#comboUC option').each(function() {
            iduc = this.value;
            var actionData = "{'idseccion': '" +
                idseccion +
                "', 'idmodalidad': '" +
                idmodalidad +
                "', 'iduc': '" +
                iduc +
                "'}";

            $.ajax({
                type: "POST",
                url: "/Componente/GuardarComponente",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                dataType: "json",
                complete: function(result) {
                    alert("Registro Guardado Correctamente");
                    window.location.href = "@Url.Action("
                    DetalleVersion
                    ", "
                    Version
                    ", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
                }
            });
        });
    };

    p.actualizar_componente_click = function() {
        var id = $('#txtIdComponente').val();
        var idseccion = $('#comboSeccion').val();
        var idmodalidad = $('#comboModalidad').val();
        var actionData = "{'id': '" + id + "','idseccion': '" + idseccion + "','idmodalidad': '" + idmodalidad + "'}";

        $.ajax({
            type: "POST",
            url: "/Componente/ActualizarComponente",
            contentType: "application/json; charset=utf-8",
            data: actionData,
            dataType: "json",
            complete: function(result) {
                alert("Registro Actualizado Correctamente");
                window.location.href = "@Url.Action("
                DetalleVersion
                ", "
                Version
                ", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
            }
        });

    };

    p.guardar_prerrequisito_click = function() {
        var idcomponente = $('#idcomponente').val();
        $("input[name='idUnidadesChx[]']:checked").each(function() {

            var actionData = "{'idcomponente': '" +
                idcomponente +
                "','idcomponenteprerrequisito': '" +
                this.value +
                "'}";
            $.ajax({
                type: "POST",
                url: "/Componente/GuardarPrerrequisito",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                dataType: "json",
                complete: function(result) {
                    alert("Prerrequisito Guardado Correctamente");
                    window.location.href = "@Url.Action("
                    DetalleVersion
                    ", "
                    Version
                    ", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
                }
            });

        });
    };
    // =========================================================================

    /*acciones de componente/uc*/
    p.agregarComponente =  function (idversion) {
        $("#modCrearComponente").modal('show');
        cargaComboSeccion(idversion);
        cargaComboUC();
        cargaComboModalidad();
    }

    p.editarComponente =  function (id, idversion) {
        var idseccion;
        var idmodalidadcomponente;
        var idunidadcurricular;

        $.ajax({
            type: "POST",
            url: "/Componente/ObtenerComponente",
            contentType: "application/json; charset=utf-8",
            data: "{'id': '" + id + "'}",
            dataType: "json",
            complete: function (data) {
                for (var i = 0; i < data.length; i++) {
                    idseccion = data[i].IdSeccion;
                    idmodalidadcomponente = data[i].IdModalidadComponente;
                    idunidadcurricular = data[i].IdUnidadCurricular;

                    $("#txtIdComponente").val(id);
                    cargaComboSeccion(idversion);
                    cargaComboUC();
                    cargaComboModalidad();
                }
            },
            done: function () {
                $("#comboSeccion").val(idseccion);
                $("#comboUC").val(idunidadcurricular);
                $("#comboUC").attr("disabled", true);
                $("#comboModalidad").val(idmodalidadcomponente);
            }
        });
    }

    p.eliminarComponente = function (id) {
        if (confirm("Está Seguro de Eliminar el Registro")) {
            $.ajax({
                type: "POST",
                url: "/Componente/EliminarComponente",
                contentType: "application/json; charset=utf-8",
                data: "{'id': '" + id + "'}",
                dataType: "json",
                complete: function (result) {
                    alert("Registro Eliminado Correctamente");
                    window.location.href = "@Url.Action("DetalleVersion", "Version", new { IdVersion = @Model.ObtenerVersion[0].Id, IdMalla = @Model.ObtenerVersion[0].IdMalla })";
                }
            });
        }
    }

    p.cargaComboSeccion =  function (idversion) {
        $.ajax({
            type: "POST",
            url: "/Componente/ObtenerListadoSeccion",
            contentType: "application/json; charset=utf-8",
            data: "{'idversion': '" + idversion + "'}",
            dataType: "json",
            complete: function (data) {
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].Nombre, data[i].Id);
                    $('#comboSeccion').append(opt);
                }
            }
        });
    }

    p.cargaComboUC =  function () {
        $.ajax({
            type: "POST",
            url: "/Componente/OtenerListadoCatalogoCurso",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            complete: function (data) {
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].Nombre, data[i].Id);
                    $('#comboUC').append(opt);

                }
            },
            done: function () {
                $('#comboUC').multiselect();
                $("#comboUC").multiselect().multiselectfilter({
                    label: "",
                    placeholder: "Buscar"
                });
            }
        });
    }

    p.cargaComboModalidad =  function () {
        $.ajax({
            type: "POST",
            url: "/Componente/ObtenerListadoModalidadComponente",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            complete: function (data) {
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].Nombre, data[i].Id);
                    $('#comboModalidad').append(opt);
                }
            }
        });
    }

    p.seleccionarPrerrequisito =  function (id) {
        $("#modCrearComponente").modal('show');
        $("#idcomponente").val(id);

        $.ajax({
            type: "POST",
            url: "/Componente/ObtenerComponentePrerrequisito",
            contentType: "application/json; charset=utf-8",
            data: "{'id': '" + id + "'}",
            dataType: "json",
            complete: function (data) {
                for (var i = 0; i < data.length; i++) {
                    $('#checkboxes').append('<input type="checkbox" name="idUnidadesChx[]" value="' + data[i].Id + '" />');
                    $('#nombreUnidades').append('<label>' + data[i].UnidadCurricular + '</label>');
                }
            }
        });
    }

    window.detalle_version = new DetalleVersion();
}(jQuery));
