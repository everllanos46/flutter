
var Personas = [];
function CalcularPulsacion(){
    let pulsacion=0;
    let edad=document.getElementById("edad").value;
    let sexo=document.getElementById("cmbSexo").value;
    if(sexo=="m"){
        pulsacion=(220-edad)/10;
    } else{
        pulsacion=(210-edad)/10;
    }
    alert('Su pulsación es de ' + pulsacion);
    
    Guardar(pulsacion);
}

function Guardar( pulsacion){
    let persona={
        idP:document.getElementById("idPersona").value,
        nombre:document.getElementById("nombre").value,
        edad:document.getElementById("edad").value,
        sexo:document.getElementById("cmbSexo").value,
        ppulsacion:pulsacion
    }
    var listaPersonas=localStorage.getItem("personas");
    if(listaPersonas==null){
        Personas=[];
        Personas.push(persona);
    } else{
        Personas = JSON.parse(listaPersonas);
        Personas.push(persona);
    }
    localStorage.setItem("personas", JSON.stringify(Personas));
}

function limpiarTabla(){
    var myTable = document.getElementById("mytable");
var rowCount = myTable.rows.length;
for (var x=rowCount-1; x>0; x--) {
      myTable.deleteRow(x);
}
}

function consultarDatos() {
    limpiarTabla();
    var personas = []; /* Array para sacar los datos a Consultar*/
     
    if (localStorage.getItem('personas') != null) {

        personas = JSON.parse(localStorage.getItem('personas'));
    }
    personas.forEach(item => {
        
        document.getElementById("tbodypulsacion").innerHTML  +=
        '<tr>' +
            '<td align="center" style="dislay: none;">' + item.idP + '</td>' +
            '<td align="center" style="dislay: none;">' + item.nombre+ '</td>' +
            '<td align="center" style="dislay: none;">' + item.edad+ '</td>' +
            '<td align="center" style="dislay: none;">' + item.sexo+ '</td>' + 
            '<td align="center" style="dislay: none;">' + item.ppulsacion+ '</td>' + '</tr>';
    });
   }

