
function showDivImc() {
    var div = document.getElementById('divIMC');
    var buttonShowDivCalcIMC = document.getElementById('buttonShowDivCalcIMC');
    div.style.display = 'block';
    buttonShowDivCalcIMC.style.display = "none";
}

function calcularIMC(peso, altura) {
    //debugger;
    var flagResultado;
    var alturaFinal = altura * altura;
    var IMCResultado = peso / alturaFinal;
    var IMC = IMCResultado.toFixed(2);

    //var labelResultadoIMC = document.createElement("label");
    //var spanResultadoIMC = document.createElement("span");
    

    var br = document.createElement("br");


    //labelResultadoIMC.appendChild(document.createTextNode("Resultado: "));
    //labelResultadoIMC.style.fontWeight = "bold";

    var labelResultadoIMC = document.getElementById('labelResultadoIMC');
    var spanResultadoIMC = document.getElementById('spanResultadoIMC');
    var divResultado = document.getElementById('divResultado');

    var divIMC = document.getElementById('divIMC');
    if (IMC > 0) {

        if(spanResultadoIMC.className=="noResult"){
            divIMC.appendChild(br);
            divResultado.style.display = "block";
            labelResultadoIMC.style.display = "block";
            spanResultadoIMC.appendChild(document.createTextNode(IMC));
            spanResultadoIMC.className = "hasValue";
        } else {
            spanResultadoIMC.textContent = IMC;
        }
    


        var divTabelaResultados = document.getElementById('divTabelaResultadosIMC');
        var tabelaResultados = document.getElementById('tabelaResultadosIMC');

        divTabelaResultados.style.display = "block";

      
        //var abaixo17 = document.getElementById('abaixo17');


        for (var r = 0, n = tabelaResultados.rows.length; r < n; r++) {
            for (var c = 0, m = tabelaResultados.rows[r].cells.length; c < m; c++) {
                if (IMC < 17) {
                    tabelaResultados.rows[1].className = "selected";
                    tabelaResultados.rows[1].style.backgroundColor = "#FF0000";
                    tabelaResultados.rows[1].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC >= 17 && IMC <= 18.49) {
                    tabelaResultados.rows[2].className = "selected";
                    tabelaResultados.rows[2].style.backgroundColor = "#FFCC00";
                    tabelaResultados.rows[2].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC >= 18.5 && IMC <= 24.99) {
                    tabelaResultados.rows[3].className = "selected";
                    tabelaResultados.rows[3].style.backgroundColor = "#33CC33";
                    tabelaResultados.rows[3].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC >= 25 && IMC <= 29.99) {
                    tabelaResultados.rows[4].className = "selected";
                    tabelaResultados.rows[4].style.backgroundColor = "#FFC200";
                    tabelaResultados.rows[4].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC >= 30 && IMC <= 34.99) {
                    tabelaResultados.rows[5].className = "selected";
                    tabelaResultados.rows[5].style.backgroundColor = "#FF8300";
                    tabelaResultados.rows[5].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC >= 35 && IMC <= 39.99) {
                    tabelaResultados.rows[6].className = "selected";
                    tabelaResultados.rows[6].style.backgroundColor = "#CF0A00";
                    tabelaResultados.rows[6].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }

                if (IMC > 40) {
                    tabelaResultados.rows[7].className = "selected";
                    tabelaResultados.rows[7].style.backgroundColor = "#FF0000";
                    tabelaResultados.rows[7].style.color = "white";
                } else {
                    tabelaResultados.rows[r].className = "noSelected";
                    tabelaResultados.rows[0].className = "titleTable";
                }
            }
        }

    }
    //document.body.appendChild(spanResultadoIMC);

    return IMC;

    //gerar span


}

