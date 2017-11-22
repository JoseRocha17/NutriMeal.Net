
function calculateAge(yearOfBirth) {
    //debugger;
    var age = 2016 - yearOfBirth;
    return age;
    //window.alert(age);
}

function yearsUntilRetirement(name, year) {
    //debugger;
    var retirementString="";
    var age = calculateAge(year);
    var retirement = 65 - age;
    if (retirement >= 0) {
        window.alert(name + " retires in " + retirement + " years!");
        //document.getElementById('idadeUserText').innerHTML = age;
        //retirementString = "Ainda faltam " + retirement + " anos!";
        //document.getElementById('reformaEstadoUserText').innerHTML = retirementString;
    } else {
        //retirementString = "Já Reformado!";
        //document.getElementById('reformaEstadoUserText').innerHTML = retirementString;
        //window.alert(name + " already retired!");
    }

}