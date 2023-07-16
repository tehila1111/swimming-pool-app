
function checkAndFilter()
{
    var login = JSON.parse( sessionStorage.login);
    if (login.position == 'מנהל') {

        var wel = "הי " + " " + login.userName + " , " + "אפשר להתחיל?";
        var hey = document.getElementById("welcome");
        hey.innerHTML = wel;
        var user = document.getElementById("user");
        user.innerHTML += 'מנהל' + " - " + " " + login.userName;
    }
    else
    {
        var wel = "הי " + " " + login.userName + " , " + "אפשר להתחיל?";
        var hey = document.getElementById("welcome");
        hey.innerHTML = wel;
        var user = document.getElementById("user");
        user.innerHTML += 'מזכיר' + " - " + " " + login.userName;

      
    }


}


function position()
{
    var login = JSON.parse(sessionStorage.login);
    var user = document.getElementById("user");
    user.innerHTML += login.position + " - " + " " + login.userName;

}


function filter() {
    var login = JSON.parse(sessionStorage.login);
    if (login.position == "מזכיר") {
        var admin = document.querySelectorAll(".admin");
        for (var i = 0; i < admin.length; i++) {
            admin[i].style.display = "none";
        }
       
    }

}