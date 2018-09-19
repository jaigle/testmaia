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


