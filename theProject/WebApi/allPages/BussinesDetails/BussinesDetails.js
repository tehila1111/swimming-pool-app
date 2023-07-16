var path = 'https://localhost:44371/api/'

//BusinessDetails --------------

//הצגת הפרטים
function GetAllDetails() {

    axios.get(path + 'BusinessDetails/Get').then(
        (response) => {
            console.log(response)
            var result = response.data;

            var body = document.getElementsByClassName("bodyb")[0];
            var table = document.createElement("table");
            table.className = "table table-bordered";


            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var th = document.createElement("th");
            //th.innerHTML = 'בחירה';
            //tr.appendChild(th);

            th = document.createElement("th");

            th.innerHTML = 'שם העסק';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'כתובת';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'יום קבוע להשכרה';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'מחיר ליום השכרה';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'שעת תחילת השכרה';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'שעת סיום השכרה';

            tr.appendChild(th);



            thead.appendChild(tr);
            table.appendChild(thead);

            var tbody = document.createElement("tbody");

            var tr = document.createElement("tr");


            //var td = document.createElement("INPUT");
            //td.setAttribute("type", "radio");
            //td.setAttribute("name", "choose");
            //td.setAttribute("value", 1);
            //td.className = "choose";
            //tr.appendChild(td);

            var td = document.createElement("td");
            td.innerHTML = result[0].BusinessName;
            tr.appendChild(td);

            var td = document.createElement("td");
            td.innerHTML = result[0].address;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = result[0].rentDay;
            tr.appendChild(td);
            var td = document.createElement("td");
            td.innerHTML = result[0].rentPrice;
            tr.appendChild(td);



            var td = document.createElement("td");
            td.innerHTML = result[0].RentStartHour;
            tr.appendChild(td);

            var td = document.createElement("td");
            td.innerHTML = result[0].RentEndHour;
            tr.appendChild(td);

            tbody.appendChild(tr);

            table.appendChild(tbody);
            body.appendChild(table);
            tbody.className = "MyTable";
        },



        (error) => {
            console.log(error);
        }
    );
}



//פתיחת טופס עידכון
function openUpdateBusiness() {

    var table = document.getElementsByClassName("MyTable")[0];
    var line = table.children[0];
    console.log(line)
    sessionStorage.bName = line.children[0].textContent;
    sessionStorage.address = line.children[1].textContent;
    sessionStorage.rentDay = line.children[2].textContent;
    sessionStorage.startH = line.children[3].textContent;
    sessionStorage.endH = line.children[4].value;
    sessionStorage.price = line.children[5].textContent;

    var modal = document.getElementById("myModalUpdate");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];


    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

    var name = document.getElementById("UPBusinessName");
    var adress = document.getElementById("UPaddress");
    var day = document.getElementById("UPday");
    //var start = document.getElementById("UPstartHour");
    //var end = document.getElementById("UPendHour");
    //var price = document.getElementById("UPprice");
    name.setAttribute('value', sessionStorage.bName);
    adress.setAttribute('value', sessionStorage.address);
    day.setAttribute('value', sessionStorage.rentDay);
    //start.setAttribute('value', sessionStorage.startH);
    //end.setAttribute('value', sessionStorage.endH);
    //price.setAttribute('value', sessionStorage.price);


}

//עידכון כל הפרטים
function updateDetails() {
    var name = document.getElementById("UPBusinessName").value;
    var adress = document.getElementById("UPaddress").value;
    var day = document.getElementById("UPday").value;
    var start = document.getElementById("UPstartHour").value;
    var end = document.getElementById("UPendHour").value;
    var price = document.getElementById("UPprice").value;

    if (name == '' || adress == '' || start == '' || end == '' || price == '' || day == ' ')
        alert("לא הזנת את כל הפרטים!")
    else {

        var obj = {
            BusinessName: name,
            address: adress,
            rentDay: day,
            rentPrice: price,
            RentStartHour: start,
            RentEndHour: end
            
        }
        axios.put(path + 'BusinessDetails/Put', obj).then(
            (response) => {
                console.log(response.data)
                var result = response.data;

            },

            (error) => {
                console.log(error);
            }
        );
    }
}

//------------------------------



//Users --------------

//שליפת כל המשתמשים
function GetAllUsers() {

    axios.get(path + 'Users/GetAll').then(
        (response) => {
            console.log(response)
            var result = response.data;

            var body = document.getElementsByClassName("bodyc")[0];
            var table = document.createElement("table");
            table.className = "table table-hover";


            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var th = document.createElement("th");
            th.innerHTML = 'בחירה';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'שם משתמש';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'הרשאה';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'סיסמא';
            tr.appendChild(th);



            thead.appendChild(tr);
            table.appendChild(thead);

            var tbody = document.createElement("tbody");

            thead.appendChild(tr);
            table.appendChild(thead);

            var tbody = document.createElement("tbody");

            for (var i = 0; i < result.length; i++) {
                var tr = document.createElement("tr");


                var td = document.createElement("INPUT");
                td.setAttribute("type", "radio");
                td.setAttribute("name", "choose");
                td.setAttribute("value", result[i].userId);
                td.className = "choose";
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].userName;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].position;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = result[i].password;
                tr.appendChild(td);

                tbody.appendChild(tr);

            }

            table.appendChild(tbody);
            body.appendChild(table);
            tbody.className = "MyTableUser";
        },
        (error) => {
            console.log(error);
        }
    );
}

//הוספת משתמש----------------------

//פתיחת מודל הוספה
function openAddModal() {
    var modal = document.getElementById("AddUser");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[1];


    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}

//הוספת משתמש חדש
function addNewUser() {
    var name = document.getElementById("userName").value;
    var psd = document.getElementById("password").value;
    var role = document.getElementById("selectRole").value;
    if (name != '' && psd != '' && role != '') {
        var quaryObj = { userName: name, position: role, password: psd };

        axios.post('https://localhost:44371/api/Users/Post', quaryObj).then(
            (response) => {
                console.log(response)
                var result = response.data;
                if (result != false) {
                    alert("המשתמש נוסף בהצלחה")
                    location.reload();
                }

            },
            (error) => {
                console.log(error);
            }
        );
    }
    else
        alert("ישנם פרטים חסרים!")

}



//עדכון משתמש ----------------------לבדוק!!!!!!!!!


//שמירת ערכי האובייקט שנבחר לעדכון
function saveDetails() {
    var d = document.getElementsByName('choose');
    sessionStorage.idChoose = null;
    sessionStorage.userIdChoose = null;
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            sessionStorage.idChoose = i;
            sessionStorage.userIdChoose = d[i].value;
            break;
        }
    }
    if (sessionStorage.idChoose != "null") {
        var table = document.getElementsByClassName("MyTableUser")[0];
        console.log(table)
        var line = table.children[sessionStorage.idChoose];
        console.log(sessionStorage.idChoose)
        console.log(line)
        sessionStorage.userName = line.children[1].textContent;
        sessionStorage.role = line.children[2].textContent;
        sessionStorage.psd = line.children[3].textContent;

    }


}

//פתיחת מודל עדכון
function openUpModal() {

    var modal = document.getElementById("updateUser");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[1];


    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

    var name = document.getElementById("upUserName");
    var psd = document.getElementById("upPassword");
    var role = document.getElementById("upSelectRole");

    name.setAttribute('value', sessionStorage.userName);
    psd.setAttribute('value', sessionStorage.psd);
    role.setAttribute('value', sessionStorage.role);

}

function sendToUpdate() {
    saveDetails();

    if (sessionStorage.idChoose == "null")
        alert("לא נעשתה בחירה!")
    else {
        openUpModal();
    }
}

function UpdateUser() {

    var userId = sessionStorage.userIdChoose;
    var name = document.getElementById("upUserName").value;
    var psd = document.getElementById("upPassword").value;
    var role = document.getElementById("upSelectRole").value;
    if (name != '' && psd != '' && role != '') {
        var quaryObj = { userId: userId, userName: name, position: role, password: psd };
        axios.put(path + 'Users/Put', quaryObj).then(
            (response) => {
                var result = response.data;
                if (result) {
                    alert("המשתמש עודכן בהצלחה!")
                    location.reload();

                }

            },


            (error) => {
                console.log(error);
            }
        );
    }

}
//מחיקת משתמש ---------------------

//אינדקס הבחירה
function indexChoose() {
    var d = document.getElementsByName('choose');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            return d[i].value;
        }
    }

}

//מחיקת הבחירה
function deleteChoose() {
    var id = indexChoose();
    if (id === undefined)
        alert("לא נעשתה בחירה!")
    else
        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'Users/Delete/' + id).then(
                (response) => {
                    console.log(response)
                    var result = response.data;

                    location.reload();
                    alert("נמחק בהצלחה!")


                },

                (error) => {
                    console.log(error);
                    alert("error")

                }
            );
        }
}

