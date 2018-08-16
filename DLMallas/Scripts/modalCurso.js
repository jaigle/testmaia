var cursoModal = function () {
    $(".cursoModal").append('<div class="modal fade"  id="modalCursoPlayer" style="overflow-y:hidden"  tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true"><div class="modal-dialog-expanded" ><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal">X</button><h4 class="modal-title">&nbsp;</h4> </div><div class="modal-body-extended"><iframe id="frameCurso"  width="100%" height="100%" frameborder="0" allowtransparency="true"></iframe></div></div></div></div>');
}

cursoModal.prototype.show = function (URL) {
    $(".modal-header").hide()
    $("#frameCurso").attr("src", URL)
    $("#modalCursoPlayer").modal({ backdrop: 'static' })
    $("#modalCursoPlayer").modal("show");
};

cursoModal.prototype.showUrl = function (URL) {
    $(".modal-header").show()
    $("#frameCurso").attr("src", URL)
    $("#modalCursoPlayer").modal({ backdrop: 'static' })
    $("#modalCursoPlayer").modal("show");
};


cursoModal.prototype.hide = function () {


    $("#modalCursoPlayer").modal("hide");
    $("#frameCurso").attr("src", "about:blank");

}
