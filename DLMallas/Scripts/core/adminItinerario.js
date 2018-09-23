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
            format: "yyyy/mm/dd",
            weekStart: 1,
            //startDate: "now",
            language: "es",
            autoclose: true
        });

        window.interval = setInterval(self.configuracion_vista, 50);
        $.fn.dataTable.ext.search.push(self.dataTable_ext_search);
        $("#btnCrearItinerario").click(self.crear_itinerario_click);
    };

    // Funciones privadas  ======================================================

    p.configuracion_vista = function() {
        var html = '<div class="pull-right col-lg-12 col-md-12 col-sm-12">' +
            '<label class="pull-left col-lg-6 col-md-6 col-sm-6"><input type="text" placeholder="Buscar Itinerario" class="form-control input-sm" id="bItinerario"></label>' +
            '<label class="pull-right col-lg-6 col-md-6 col-sm-6"><input type="text" placeholder="Buscar Malla" class="form-control input-sm" id="bMalla"></label></div>';

        $("#tblItinerarios_filter").html(html);
        $("#tblItinerarios_length").addClass("col-lg-4 col-md-4 col-sm-4");

        $('#bItinerario, #bMalla').keyup(function() {
            var table = $('#tblItinerarios').DataTable();
            table.draw();
        });

        window.clearInterval(window.interval);
    };

    p.dataTable_ext_search = function (settings, data, dataIndex) {
        var itinerario = $('#bItinerario').val();
        var malla = $('#bMalla').val();

        var col1 =  data[1];
        var col2 = data[2];
        if ((itinerario === undefined && malla === undefined) || 
            (itinerario.length === 0 && malla.length === 0) ||
            (itinerario !== undefined && itinerario.length > 0 && col1.includes(itinerario)) || 
            (malla !== undefined && malla.length > 0 && col2.includes(malla)) ) {
            return true;
        }
        return false;
    }

    p.crear_itinerario_click = function() {
        $('#modCrearItinerario').modal('show');
    }

    // Eventos =================================================================


    // =========================================================================
    window.admin_itinerario = new AdminItinerario();
}(jQuery));
