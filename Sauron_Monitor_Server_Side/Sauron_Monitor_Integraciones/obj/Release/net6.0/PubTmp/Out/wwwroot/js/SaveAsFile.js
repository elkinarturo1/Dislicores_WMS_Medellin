function guardarArchivo(fileName, byteBase64) {
    var link = document.createElement("a");
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function guardarArchivoBase64(fileName, byteBase64) {
    var link = document.createElement("a");
    link.download = fileName;
    link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function alerta() {
    alert("Hello! I am an alert box!");
}