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
    };

    // Funciones privadas  ======================================================

   
    // Eventos =================================================================


    // =========================================================================
    window.audiencia = new Audiencia();
}(jQuery));
