// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$("#FrequenciaExecucaoId").change(function () {
    var frequencia = $("#FrequenciaExecucaoId option:selected").text();
    if (frequencia == "DIÁRIO") {
        EsconderTodasFrequencias();
        $("#divHorario")[0].style.display = 'block';
    }
    else if (frequencia == "SEMANAL") {
        EsconderTodasFrequencias();
        $("#divDiaDaSemana")[0].style.display = 'block';
        $("#divHorario")[0].style.display = 'block';
    }
    else if (frequencia == "QUINZENAL") {
        EsconderTodasFrequencias();
        $("#divDia1")[0].style.display = 'block';
        $("#divDia2")[0].style.display = 'block';
        $("#divHorario")[0].style.display = 'block';
    }
    else if (frequencia == "MENSAL") {
        EsconderTodasFrequencias();
        $("#divDia1")[0].style.display = 'block';        
        $("#divHorario")[0].style.display = 'block';
    }

});
function EsconderTodasFrequencias() {
    $("#divDiaDaSemana")[0].style.display = 'none';
    $("#divDia1")[0].style.display = 'none';
    $("#divDia2")[0].style.display = 'none';
    $("#divHorario")[0].style.display = 'none';
}

$("#btnAdd").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Arquivos/AddCampo',
        success: function (partialView) {
            console.log("partialView: " + partialView);
            $('#camposContainer').html(partialView);
        }
    });
});