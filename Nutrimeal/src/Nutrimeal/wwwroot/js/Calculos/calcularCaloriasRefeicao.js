function calcularCaloraisRefeicao(elem) {
    debugger;
    //var id = elem.getAttribute('id');
    var objTR = elem.getElementsByTagName('tr');

    var objTD = elem.getElementsByTagName('td');

    var totalCalorias = 0;

    var medidaControlo = "";

    var numberPattern = /\d+/g;
    
    var wordPattern = /[A-Za-z]+/;

    //return obj;
    for (i = 0; i < objTR.length - 1; i++) {
        var caloriaAlimento = objTR[i + 1].children[1].innerHTML;

        var valorConsumirTD = objTR[i + 1].children[2].innerHTML;

        var caloriaTD = caloriaAlimento.match(numberPattern);

        var caloriaToInt = parseInt(caloriaTD);

        var valorConsumir = valorConsumirTD.match(numberPattern);

        var valorConsumirToInt = parseInt(valorConsumir);

        medidaControlo = valorConsumirTD.match(wordPattern);

        if (medidaControlo == "Gramas") {
            if (valorConsumirToInt <= 100) {
                caloriaToInt = caloriaToInt;
            } else {
                valor = valorConsumirToInt - 100;
                caloriaToInt = caloriaToInt * valor;
            }
            
        } else if (medidaControlo == "Unidades") {
            caloriaToInt = caloriaToInt * valorConsumirToInt;
        } else if (medidaControlo == "Cl") {
            if (valorConsumirToInt <= 100) {
                caloriaToInt = caloriaToInt;
            } else {
                valor = valorConsumirToInt - 100;
                caloriaToInt = caloriaToInt * valor;
            }
        }

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



    //return totalCalorias;
    //alert(medidaControlo);


}


