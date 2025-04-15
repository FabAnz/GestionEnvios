document.querySelector("#slcEnvioTipo").addEventListener("change", CambiarFormularioEnvio);

FormularioEnvio();

function FormularioEnvio() {
    document.querySelector("#camposComunes").style.display = "block";
    document.querySelector("#camposUrgentes").style.display = "none";
}

function CambiarFormularioEnvio() {
    const tipoEnvio = document.querySelector("#slcEnvioTipo").value;

    document.querySelector("#camposComunes").style.display = "none";
    document.querySelector("#camposUrgentes").style.display = "none";

    if (tipoEnvio == "comun") {
        document.querySelector("#camposComunes").style.display = "block";
    } else {
        document.querySelector("#camposUrgentes").style.display = "block";
    }
}