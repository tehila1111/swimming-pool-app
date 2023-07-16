

var path = 'https://localhost:44371/api/'



//--------------------------ימי פתיחה    

//הצגת ימי פתיחה
function AllOpenDate() {

    getShiftName();

    setTimeout(function () {
        axios.get(path + 'OpenDays/GetOpenDays').then(
            (response) => {
                var result = response.data;
                var shiftNames = JSON.parse(sessionStorage.ShiftName);

                var body = document.getElementsByClassName("bodyb")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");

                th.innerHTML = 'בחירה';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'יום';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'משמרת';


                tr.appendChild(th);


                th = document.createElement("th");
                th.innerHTML = 'מגדר';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'סטטוס';
                tr.appendChild(th);

                thead.appendChild(tr);
                table.appendChild(thead);

                var tbody = document.createElement("tbody");
                for (var i = 0; i < result.length; i++) {

                    var tr = document.createElement("tr");

                    var td = document.createElement("INPUT");
                    td.setAttribute("type", "radio");
                    td.setAttribute("name", "choose");
                    td.setAttribute("value", result[i].open_id);
                    td.className = "choose";
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = result[i].day;
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = shiftNames[i];
                    tr.appendChild(td);



                    var td = document.createElement("td");
                    td.innerHTML = result[i].gender;
                    tr.appendChild(td);


                    var td = document.createElement("td");
                    td.innerHTML = result[i].status;
                    tr.appendChild(td);
                    tbody.appendChild(tr);


                }


                table.appendChild(tbody);
                body.appendChild(table);
                tbody.className = "MyTable";


            },
            (error) => {
                console.log(error);
            }
        );

    }, 1000)
   

}

//שליפת שמות משמרות
function getShiftName()
{
    axios.get(path + 'WorkShType/getShiftName').then(
        (response) => {
            var result = response.data;

            sessionStorage.ShiftName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}

//פתיחת מודל הוספת יום פתיחה
function addOp() {
    
    var modal = document.getElementById("myModal");



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

    //הכנסת מידע לטופס הוספה
    axios.get('https://localhost:44371/api/BusinessDetails/Get').then(
        (response) => {
            console.log(response)
            var result = response.data;
            var days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי'];
            var AllDays = document.getElementById("day");
            AllDays.innerHTML = ' ';
            var rent_day = result[0].rentDay;
            for (var i = 0; i < days.length; i++) {
                if (days[i] != rent_day) {
                    var opt = document.createElement("Option");
                    opt.innerHTML = days[i];
                    AllDays.appendChild(opt);
                }
                
            }

            axios.get(path + 'WorkShType/GetAllWSType').then(
                (response) => {
                    console.log(response)
                    var result = response.data;
                    var shiftType = document.getElementById("shift");
                    shiftType.innerHTML = ' ';
                    for (var i = 0; i < result.length; i++) {
                        var opt = document.createElement("Option");
                        opt.value = result[i].shift_id;
                        opt.innerHTML = result[i].name;
                        shiftType.appendChild(opt);
                    }

                },
                (error) => {
                    console.log(error);
                }
            );
        },
        (error) => {
            console.log(error);
        }
    );


    

}


//הוספת יום פתיחה
function addOpenDay() {
    var shift = document.getElementById("shift").value;
    var day = document.getElementById("day").value;
    var gender = document.getElementById("gender").value;
    var status = document.getElementById("status").value;


    var obj = { shift_id: shift, day: day, gender: gender, status: status };
    axios.post(path + 'OpenDays/Post', obj).then(

        (response) => {
            var result = response.data;
        },
        (error) => {
            console.log(error);
        }
    );


}
//------------------------------------


//מחיקת יום פתיחה ---------------------

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
function deleteOpenChoose() {
    var id = indexChoose();
    if (id === undefined)
        alert("לא נעשתה בחירה!")
    else
        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'OpenDays/Delete/' + id).then(
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
//------------------------------------------------------------------------


function sendToUpdate() {
    idSelectChoose();

    if (sessionStorage.idsChoose == "null")
        alert("לא נעשתה בחירה!")
    else {

        openUpDayForm();
    }
}


//קוד בחירה
function idSelectChoose() {
    var d = document.getElementsByName('choose');
    sessionStorage.idsChoose = null;
    sessionStorage.openIdChoose = null;
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            sessionStorage.idsChoose = i;
            sessionStorage.openIdChoose = d[i].value;
            break;
        }
    }
    if (sessionStorage.idsChoose != "null") {
        var table = document.getElementsByClassName("MyTable")[0];
        console.log(table)
        var line = table.children[sessionStorage.idsChoose];
        console.log(sessionStorage.idsChoose)
        console.log(line)
        sessionStorage.day = line.children[1].textContent;
        sessionStorage.shift = line.children[2].textContent;
        sessionStorage.gender = line.children[3].textContent;
        sessionStorage.statusActive = line.children[4].textContent;
     

    }

}


//פתיחת טופס עדכון
function openUpDayForm()
{
    var modal = document.getElementById("myUpModal");

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

    //הכנסת מידע לטופס הוספה
    axios.get('https://localhost:44371/api/BusinessDetails/Get').then(
        (response) => {
            console.log(response)
            var result = response.data;
            var days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי'];
            var AllDays = document.getElementsByClassName("day")[0];
            AllDays.innerHTML = ' ';
            var rent_day = result[0].rentDay;
            for (var i = 0; i < days.length; i++) {
                if (days[i] != rent_day) {
                    var opt = document.createElement("Option");
                    opt.innerHTML = days[i];
                    AllDays.appendChild(opt);
                }

            }
            var shift = document.getElementsByClassName("shift")[0];
            var day = document.getElementsByClassName("day")[0];
            var gender = document.getElementsByClassName("gender")[0];
            var status = document.getElementsByClassName("status")[0];



            shift.setAttribute('value', sessionStorage.day);
            day.setAttribute('value', sessionStorage.shift);
            gender.setAttribute('value', sessionStorage.gender);
            status.setAttribute('value', sessionStorage.statusActive)


            axios.get(path + 'WorkShType/GetAllWSType').then(
                (response) => {
                    console.log(response)
                    var result = response.data;
                    var shiftType = document.getElementsByClassName("shift")[0];
                    shiftType.innerHTML = ' ';
                    for (var i = 0; i < result.length; i++) {
                        var opt = document.createElement("Option");
                        opt.value = result[i].shift_id;
                        opt.innerHTML = result[i].name;
                        shiftType.appendChild(opt);
                    }

                },
                (error) => {
                    console.log(error);
                }
            );
        },
        (error) => {
            console.log(error);
        }
    );

   ;
   
}
//עדכון יום פתיחה
function UpdateOpenDay() {
    var shift = document.getElementsByClassName("shift")[0].value;
    var day = document.getElementsByClassName("day")[0].value;
    var gender = document.getElementsByClassName("gender")[0].value;
    var status = document.getElementsByClassName("status")[0].value;
    var openId = sessionStorage.openIdChoose;

    var obj = { open_id: openId, shift_id: shift, day: day, gender: gender, status: status };
    axios.put(path + 'OpenDays/Put', obj).then(

        (response) => {
            var result = response.data;
            if (result != null)
                location.reload();
        },
        (error) => {
            console.log(error);
        }
    );


}












