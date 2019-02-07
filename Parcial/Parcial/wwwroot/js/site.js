// Write your JavaScript code.
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').focus()
})

var items;




function getDataAjax(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
              //console.log(response);
               OnSuccess(response);
        }

    });
}

function OnSuccess(response) {
    items = response;
    $.each(items, function (index, val) {

        $('input[name=IdProvedor]').val(val.idProvedor);
        $('input[name=Ruc]').val(val.ruc);
        $('input[name=Nombre]').val(val.nombre);
        $('input[name=Direccion]').val(val.direccion);
        $('input[name=Telefono]').val(val.telefono);
        $('input[name=Extencion]').val(val.extencion);
        $('input[name=CelularContacto]').val(val.celularContacto);
        $('input[name=NombreContacto]').val(val.nombreContacto);
    });
}

