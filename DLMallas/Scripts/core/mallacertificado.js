(function ($) {
    "use strict";

    var Certificado = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });
    };

    var p = Certificado.prototype;

    // =========================================================================
    // INIT
    // =========================================================================


    p.initialize = function (self) {

        $("#ajaxUploadLogo").change(function (event) {
            $("#ajaxUploadButtonLogo").prop("disabled", false);
        });

        $("#ajaxUploadImg").change(function (event) {
            $("#ajaxUploadButtonImg").prop("disabled", false);
        });

        $("#ajaxUploadFirma").change(function (event) {
            $("#ajaxUploadButtonFirma").prop("disabled", false);
        });

        $("#ajaxUploadLogo").ajaxForm({
            iframe: true,
            type: "json",
            cache: false,
            data: $(this).serialize(),
            beforeSubmit: function () {
                //waitingDialog.show("Procesando...", { dialogSize: "sm" });
            },
            success: function (resultado) {
                //waitingDialog.hide();
                $("#ajaxUploadLogo").resetForm();
                var data = JSON.parse(resultado);
                alert(data);
                if (data.exito) {
                    $("#bodyAlert").html("Imagen actualizada satisfactoriamente");
                    $("#alertModal").modal("show");
                }
                else {
                    $("#bodyAlert").html("Error al subir archivo: " + data.mensaje);
                    $("#alertModal").modal("show");

                }
            },
            error: function (resultado) {
                //waitingDialog.hide();
                var data = JSON.parse(resultado);
                $("#ajaxUploadLogo").resetForm();
                alert("Error al subir archivo: " + data.mensaje);
            }
        });

        $("#ajaxUploadImg").ajaxForm({
            iframe: true,
            type: "json",
            cache: false,
            data: $(this).serialize(),
            beforeSubmit: function () {
                //waitingDialog.show("Procesando...", { dialogSize: "sm" });
            },
            success: function (resultado) {
                //waitingDialog.hide();
                $("#ajaxUploadImg").resetForm();
                var data = JSON.parse(resultado);
                if (data.exito == "1") {
                    $("#bodyAlert").html("Imagen actualizada satisfactoriamente");
                    $("#alertModal").modal("show");
                }
                else {
                    $("#bodyAlert").html("Error al subir archivo: " + data.mensaje);
                    $("#alertModal").modal("show");

                }
            },
            error: function (resultado) {
                //waitingDialog.hide();
                var data = JSON.parse(resultado);
                $("#ajaxUploadImg").resetForm();
                alert("Error al subir archivo: " + data.mensaje);
            }
        });

        $("#ajaxUploadFirma").ajaxForm({
            iframe: true,
            type: "json",
            cache: false,
            data: $(this).serialize(),
            beforeSubmit: function () {
                //waitingDialog.show("Procesando...", { dialogSize: "sm" });
            },
            success: function (resultado) {
                //waitingDialog.hide();
                $("#ajaxUploadFirma").resetForm();
                var data = JSON.parse(resultado);
                alert(data);
                if (data.exito) {
                    $("#bodyAlert").html("Imagen actualizada satisfactoriamente");
                    $("#alertModal").modal("show");
                }
                else {
                    $("#bodyAlert").html("Error al subir archivo: " + data.mensaje);
                    $("#alertModal").modal("show");

                }
            },
            error: function (resultado) {
                //waitingDialog.hide();
                var data = JSON.parse(resultado);
                $("#ajaxUploadFirma").resetForm();
                alert("Error al subir archivo: " + data.mensaje);
            }
        });

        $("#btnVistaPrevia").click(self.vistaprevia_certificado_click);
    };

    // Funciones privadas  ======================================================
    p.vistaprevia_certificado_click = function () {
        $('#myModal44').modal('show');
    }

    // Eventos =================================================================
   

    // =========================================================================
    window.Certificado = new Certificado();
}(jQuery));


