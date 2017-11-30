


function calcularCaloraisRefeicao(elem) {
    debugger;
    //var id = elem.getAttribute('id');
    var objTR = elem.getElementsByTagName('tr');

    var objTD = elem.getElementsByTagName('td');

    var totalCalorias = 0;

    var numberPattern = /\d+/g;

    //return obj;
    for (i = 0; i < objTR.length-1; i++) {
        var text = objTR[i+1].children[1].innerHTML;

        var caloriaTD = text.match(numberPattern);

        var caloriaToInt = parseInt(caloriaTD);

        totalCalorias = totalCalorias + caloriaToInt; 
    }

    alert(totalCalorias);


}