function SolicitarPeticion()
{
  var request = new Request('https://localhost:44337/api/Values', {
        method: 'Get',
       
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        console.log('data = ', data);
    })
    .catch(function(err) {
        console.error(err);
    });

}

function IniciarSesion(){
    var ced = document.getElementById("ced").value;
    var clave = document.getElementById("clave").value;

    var request = new Request('https://localhost:44395/api/Usuario/'+ced+"/"+clave, {
        method: 'Get',
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        console.log('data = ', data);
        if (data =="1"){
            localStorage.setItem("ced",ced);
            alert("Ir a pagina de Autor");
            window.open("autor.html");
        }else if(data =="2"){
            localStorage.setItem("ced",ced);
            alert("Ir a pagina de Editor");
            window.open("editor.html");
        }
    })
    .catch(function(err) {
        console.error(err);
    });
}

function IngresarArticulo() {
    var request = new Request('https://localhost:44395/api/Articulo', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            ced: localStorage.getItem("ced"),
            titulo: document.getElementById("title").value,
            descripcion : document.getElementById("desc").value,
            contenido: document.getElementById("cont").value,
            fecha: new Date().getFullYear()+"-"+parseInt( new Date().getMonth()+1)+"-"+new Date().getDate(),
        })
    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {

            alert(data);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function EliminarArticulo(){
    ced =localStorage.getItem("ced");
    titulo= document.getElementById("title").value;
    var request = new Request('https://localhost:44395/api/Articulo/'+ced+"/"+titulo+"/", {
        method: 'Delete',
        
    });

    fetch(request)
        .then(function (response) {
            return response.text();
        })
        .then(function (data) {

            alert(data);
        })
        .catch(function (err) {
            console.error(err);
        });
}

function IngresarUsuario(){
    
    var request = new Request('https://localhost:44395/api/Usuario', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          ced: document.getElementById("ced").value,
          nom1: document.getElementById("nom1").value,
          nom2: document.getElementById("nom2").value,
          apell1: document.getElementById("apell1").value,
          apell2: document.getElementById("apell2").value,
          email: document.getElementById("correo").value,
          clave: document.getElementById("clave").value,
          tipo: parseInt(document.getElementById("tipo").value),
        })
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        console.log('data = ', data);
        alert(data);
    })
    .catch(function(err) {
        console.error(err);
    });

}


function EliminarUsuario(){
    var request = new Request('https://localhost:44395/api/Usuario', {
        method: 'Delete',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          ced: document.getElementById("ced").value,
        })
    });

    fetch(request)
    .then(function(response) {
        return response.text();
    })
    .then(function(data) {
        console.log('data = ', data);
        alert(data);
    })
    .catch(function(err) {
        console.error(err);
    });

}

function IrAtras(){
    window.history.back();
}