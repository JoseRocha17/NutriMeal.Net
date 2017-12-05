﻿


function calcularCaloraisRefeicao(elem) {
    debugger;
    //var id = elem.getAttribute('id');
    var objTR = elem.getElementsByTagName('tr');

    var objTD = elem.getElementsByTagName('td');

    var totalCalorias = 0;

    var numberPattern = /\d+/g;

    //return obj;
    for (i = 0; i < objTR.length - 1; i++) {
        var text = objTR[i + 1].children[1].innerHTML;

        var caloriaTD = text.match(numberPattern);

        var caloriaToInt = parseInt(caloriaTD);

        totalCalorias = totalCalorias + caloriaToInt;
    }

    var divResultado = document.getElementById('divTotalCalorias');
    var spanResultado = document.getElementById('spanResultadoTotalCalorias');

    if (totalCalorias > 0) {

        divResultado.style.display = "block";
        if (spanResultado.className == "noResult") {
            spanResultado.appendChild(document.createTextNode(totalCalorias));
            spanResultado.className = "hasValue";
        } else {
            spanResultado.textContent = totalCalorias;
        }
    } else {
        if (spanResultado.className == "noResult") {
            spanResultado.appendChild(document.createTextNode("Sem alimentos na refeição!"));
            spanResultado.className = "hasValue";
        } else {
            spanResultado.textContent = "Sem alimentos na Refeição";
        }

    }

    var inputCalorias = document.getElementById('totalCaloriasRefeicao');
    var divEditarCalorias = document.getElementById('adicionarCaloriasRefeicoes');

    divEditarCalorias.style.display = "block";
    inputCalorias.value = totalCalorias;



    return totalCalorias;
    //alert(totalCalorias);


}

function calcularCaloriasPerfilAlimentar(elem) {

    var objTR = elem.getElementsByTagName('tr');

    var objTD = elem.getElementsByTagName('td');

    var totalCalorias = 0;

    for (i = 0; i < objTR.length - 1; i++) {
        var text = objTR[i + 1].children[1].innerHTML;

        var caloriaToInt = parseInt(text);

        totalCalorias = totalCalorias + caloriaToInt;
    }

    var spanResultado = document.getElementById('spanTotalCaloriasPerfil');

    if (totalCalorias > 0) {

        //divResultado.style.display = "block";
        if (spanResultado.className == "noResult") {
            spanResultado.appendChild(document.createTextNode(totalCalorias));
            spanResultado.className = "hasValue";
        } else {
            spanResultado.textContent = totalCalorias;
        }
    } else {
        if (spanResultado.className == "noResult") {
            spanResultado.appendChild(document.createTextNode("Sem alimentos na refeição!"));
            spanResultado.className = "hasValue";
        } else {
            spanResultado.textContent = "Sem alimentos na Refeição";
        }

    }

    var inputCalorias = document.getElementById('totalCaloriasPerfilAlimentar');
    var divEditarCalorias = document.getElementById('adicionarCaloriasPerfilAlimentar');

    divEditarCalorias.style.display = "block";
    inputCalorias.value = totalCalorias;
}

