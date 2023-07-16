var path = 'https://localhost:44371/api/'

//הצגת סוגי משמרות
function getWorkShifts() {


    axios.get(path + 'WorkShType/GetAllWSType').then(
        (response) => {
            var result = response.data;


            var body = document.getElementsByClassName("bodya")[0];
            var table = document.createElement("table");
            table.className = "table table-hover";


            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var th = document.createElement("th");

            th.innerHTML = 'בחירה';
            tr.appendChild(th);



            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'משמרת';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'שעת התחלה';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'שעת סיום';
            tr.appendChild(th);




            thead.appendChild(tr);
            table.appendChild(thead);

            var tbody = document.createElement("tbody");
            for (var i = 0; i < result.length; i++) {

                var tr = document.createElement("tr");

                var td = document.createElement("INPUT");
                td.setAttribute("type", "radio");
                td.setAttribute("name", "chooseShift");
                td.setAttribute("value", result[i].shift_id);
                td.className = "chooseShift";
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].name;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].start_hour;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].end_hour;
                tr.appendChild(td);




                tbody.appendChild(tr);


            }


            table.appendChild(tbody);
            body.appendChild(table);
            tbody.className = "MyTable2";






        },
        (error) => {
            console.log(error);
        }
    );
}

//פתיחת טופס הוספת משמרת
function AddShift() {
    var modal = document.getElementById("myModal2");



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

}

//הוספת משמרת
function addWorkShift() {
    var workShift = document.getElementById("name").value;
    var start = document.getElementById("start").value;
    var end = document.getElementById("end").value;
    var obj = { name: workShift, start_hour: start, end_hour: end };
    if (workShift != '' && start != '' && end != '') {
        axios.post(path + 'WorkShType/PostAddType', obj).then(
            (response) => {
                var result = response.data;

            },
            (error) => {
                console.log(error);
            }
        );
    }
    else {
        alert("ישנם פרטים חסרים")
    }
}





function sendToUpShift() {
    shiftSelectChoose();

    if (sessionStorage.idsChoose == "null")
        alert("לא נעשתה בחירה!")
    else {

        openUpdateShift();
    }
}


//קוד בחירה
function shiftSelectChoose() {
    var d = document.getElementsByName('chooseShift');
    sessionStorage.idsChoose = null;
    sessionStorage.shiftIdChoose = null;
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            sessionStorage.idsChoose = i;
            sessionStorage.shiftIdChoose = d[i].value;
            break;
        }
    }
    if (sessionStorage.idsChoose != "null") {
        var table = document.getElementsByClassName("MyTable2")[0];
        console.log(table)
        var line = table.children[sessionStorage.idsChoose];
        console.log(sessionStorage.idsChoose)
        console.log(line)
        sessionStorage.shiftName = line.children[1].textContent;
        sessionStorage.startHour = line.children[2].textContent;
        sessionStorage.endHour = line.children[3].textContent;



    }

}
//פתיחת טופס עדכון משמרת
function openUpdateShift() {
    var modal = document.getElementById("myModal3");



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
    var workShift = document.getElementById("Uname");
    var start = document.getElementById("Ustart");
    var end = document.getElementById("Uend");


    workShift.setAttribute("value", sessionStorage.shiftName);
    start.setAttribute("value", sessionStorage.startHour);
    end.setAttribute("value", sessionStorage.endHour);




}

//עידכון משמרת
function UpdateShift() {
    var workShift = document.getElementById("Uname").value;
    var start = document.getElementById("Ustart").value;
    var end = document.getElementById("Uend").value;
    var shiftId = sessionStorage.shiftIdChoose;

    var obj = { shift_id: shiftId, name: workShift, start_hour: start, end_hour: end };

    axios.put(path + 'WorkShType/Put/', obj).then(
        (response) => {
            var result = response.data;
            console.log(result)
        },
        (error) => {
            console.log(error);
        }
    );
}




//אינדקס הבחירה
function indexChoose() {
    var d = document.getElementsByName('choose');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            return d[i].value;
        }
    }

}

//מחיקת משמרת
function deleteChoose() {
    var id;

    var d = document.getElementsByName('chooseShift');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            id = d[i].value;
            break;
        }
    }

    if (id == undefined)
        alert("לא נעשתה בחירה!")
    else
        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'WorkShType/DeleteType/' + id).then(
                (response) => {
                    console.log(response)
                    var result = response.data;

                    if (result == false)
                        alert("הערך בשימוש אין אפשרות למחוק!");
                    else {

                        window.location.href = "open_days.html";
                        alert("נמחק בהצלחה!")
                    }

                },

                (error) => {
                    console.log(error);
                    alert("error")

                }
            );
        }
}