(function ($) {
    "use strict";

    var Itinerario = function () {
        // Create reference to this instance
        var self = this;
        // Initialize app when document is ready
        $(document).ready(function () {
            self.initialize(self);
        });
    };

    var p = Itinerario.prototype;

    // =========================================================================
    // INIT
    // =========================================================================

    p.initialize = function (self) {

        $('#tblListadoItinerarios').dataTable({
            responsive: true,
            "language": {
                "url": "/Content/DataTables/plugins/spanish.js"
            },
            dom: 'Bfrtip',
            buttons: [
                'excelHtml5'
            ]
        });

        var interval = setInterval(function() {
             var button = $(".dt-button, .buttons-excel, .buttons-html5").addClass("btn btn-sm pull-left").html("<span>Exportar a Excel</span>");
             window.clearInterval(interval);
        }, 100);
        
    };

    // Funciones privadas  ======================================================
 

    // Eventos =================================================================


    // =========================================================================
    window.itinerario = new Itinerario();
}(jQuery));
