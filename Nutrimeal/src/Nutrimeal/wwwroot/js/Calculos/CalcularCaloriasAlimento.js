function calcularCaloriasAlimento(elem) {
    debugger;
    //var id = elem.getAttribute('id');
    var objTR = elem.getElementsByTagName('tr');

    var objTD = elem.getElementsByTagName('td');

    var totalCalorias = 0;

    var gorduraAlimento = 0;
    var carboidratosAlimento = 0;
    var proteinasAlimento = 0;

    var medidaControlo = "";

    var numberPattern = /\d+/g;

    //var wordPattern = /[A-Za-z]+/;

    //return obj;
    for (i = 0; i < objTR.length - 1; i++) {
        var text = objTR[i + 1].children[0].innerHTML;
        var value = objTR[i + 1].children[1].innerHTML;

        var caloriaTD = value.match(numberPattern);

        var caloriaToInt = parseInt(caloriaTD);

        if (text == "Gordura") {
            gorduraAlimento = caloriaToInt * 9;
        } else if (text == "Carboidratos") {
            carboidratosAlimento = caloriaToInt * 4;
        } else if (text == "Proteina") {
            proteinasAlimento = caloriaToInt * 4;
        }

        //medidaControlo = text.match(wordPattern);

        //if (medidaControlo == "Gramas") {
        //    caloriaToInt = caloriaToInt;
        //} else if (medidaControlo == "Unidades") {
        //    caloriaToInt = caloriaToInt * 3;
        //} else if (medidaControlo == "Cl") {
        //    caloriaToInt = 3;
        //}

       



    }
    totalCalorias = gorduraAlimento +  carboidratosAlimento + proteinasAlimento;

    //var divResultado = document.getElementById('divTotalCalorias');
    //var spanResultado = document.getElementById('spanResultadoTotalCalorias');

    //if (totalCalorias > 0) {

    //    divResultado.style.display = "block";
    //    if (spanResultado.className == "noResult") {
    //        spanResultado.appendChild(document.createTextNode(totalCalorias));
    //        spanResultado.className = "hasValue";
    //    } else {
    //        spanResultado.textContent = totalCalorias;
    //    }
    //} else {
    //    if (spanResultado.className == "noResult") {
    //        spanResultado.appendChild(document.createTextNode("Sem alimentos na refeição!"));
    //        spanResultado.className = "hasValue";
    //    } else {
    //        spanResultado.textContent = "Sem alimentos na Refeição";
    //    }

    //}

    var inputCalorias = document.getElementById('totalCaloriasAlimento');
    var divEditarCalorias = document.getElementById('adicionarCaloriasAlimento');

    divEditarCalorias.style.display = "block";
    inputCalorias.value = totalCalorias;



    //return totalCalorias;
    //alert(totalCalorias);


}