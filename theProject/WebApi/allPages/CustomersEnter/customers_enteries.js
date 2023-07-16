var path = 'https://localhost:44371/api/'

//כניסת לקוחות מזדמנים- הצגה
function GetAllOther() {

    getOtherShiftName();
    setTimeout(function () {
        axios.get(path + 'OtherEnter/GetAllEnter').then(
            (response) => {
                console.log(response)
                var result = response.data;
                var OtherNames = JSON.parse(sessionStorage.OtherShiftName);

                var body = document.getElementsByClassName("bodyOther")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");

                th.innerHTML = 'בחירה';
                tr.appendChild(th);


                th = document.createElement("th");
                th.innerHTML = 'תאריך כניסה';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'משמרת';
                tr.appendChild(th);



                thead.appendChild(tr);
                table.appendChild(thead);

                var tbody = document.createElement("tbody");

                for (var i = 0; i < result.length; i++) {
                    var tr = document.createElement("tr");



                    var td = document.createElement("INPUT");
                    td.setAttribute("type", "radio");
                    td.setAttribute("name", "chooseOther");
                    td.setAttribute("value", result[i].other_enter);
                    td.className = "chooseOther";
                    tr.appendChild(td);



                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].date);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = OtherNames[i];
                    tr.appendChild(td);


                    tbody.appendChild(tr);

                }

                table.appendChild(tbody);
                body.appendChild(table);
                tbody.className = "MyTableOther";
            },
            (error) => {
                console.log(error);
            }
        );
    }, 1000)

}

//כניסת לקוח מזדמן
function otherEnter() {

    var shift;



    axios.get(path + 'OpenDays/GetCurrentOpenDays').then(
        (response) => {
            var openObj = response.data;
            if (openObj == null)
                alert("הבריכה אינה פתוחה כעת")
            else {
                shift = openObj.shift_id;
                axios.post(path + 'OtherEnter/Post/' + shift).then(
                    (response) => {

                        var result = response.data;
                        alert("הכניסה נוספה בהצלחה!")
                        window.location.href = 'customers_enter.html';
                    },

                    (error) => {
                        console.log(error);
                        alert("erorr");

                    }


                );
            }

        },

        (error) => {
            console.log(error);
        }
    );

}


//מחיקת לקוח מזדמן
function deleteOther() {
    var otherId;
    var d = document.getElementsByName('chooseOther');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            otherId = d[i].value;
            break;
        }
    }


    axios.delete(path + 'OtherEnter/Delete/' + otherId).then(
        (response) => {
            var result = response.data;

            if (result != null)
                location.reload();
            alert("נמחק בהצלחה!")

        },
        (error) => {
            console.log(error);
        }
    );



}

//שליפת שמות משמרות
function getOtherShiftName() {
    axios.get(path + 'OtherEnter/getOtherShiftsName').then(
        (response) => {
            var result = response.data;

            sessionStorage.OtherShiftName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}

//------------------------------



//הצגת כל כניסות מנויים
function GetAllEnter() {


    getSubName();
    getShiftsName();
    setTimeout(function () {
        axios.get(path + 'CustEnter/GetAllEnter').then(
            (response) => {
                console.log(response)
                var result = response.data;
                var SubsNames = JSON.parse(sessionStorage.SubsName);
                var shiftNames = JSON.parse(sessionStorage.shiftsName);
                var body = document.getElementsByClassName("bodyb")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");

                th.innerHTML = 'בחירה';
                tr.appendChild(th);

                th = document.createElement("th");

                th.innerHTML = 'שם';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'תאריך כניסה';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'משמרת';
                tr.appendChild(th);



                thead.appendChild(tr);
                table.appendChild(thead);

                var tbody = document.createElement("tbody");

                for (var i = 0; i < result.length; i++) {
                    var tr = document.createElement("tr");



                    var td = document.createElement("INPUT");
                    td.setAttribute("type", "radio");
                    td.setAttribute("name", "choose");
                    td.setAttribute("value", result[i].enter_id);
                    td.className = "choose";
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = SubsNames[i];
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].date);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = shiftNames[i];
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

function getSubName() {

    axios.get(path + 'CustEnter/getSubNames').then(
        (response) => {
            var result = response.data;
            console.log(result);
            sessionStorage.SubsName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}

function getShiftsName() {

    axios.get(path + 'CustEnter/getShiftNames').then(
        (response) => {
            var result = response.data;
            console.log(result);
            sessionStorage.shiftsName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}





//-----------------------------------------

//פתיחת טופס הוספת כניסת מנוי
function OpenAddSubForm() {

    var modal = document.getElementById("openMyModal");



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

//הצגת כל המנויים הפעילים 
function GetAllActiveSubs() {
    let thePath = 'https://localhost:44371/api/Customers/GetAllActiveSubs';
    axios.get(thePath).then(
        (response) => {

            var result = response.data;
            console.log(result);
            var select = document.getElementById("subList")
            var selectElement = document.getElementById("subDetails");

            select.addEventListener('change', (event) => {
                var selectedIndex = select.selectedIndex;
                var phone = result[selectedIndex].telephone;
                selectElement.innerHTML = selectElement.innerHTML = "מספר טלפון מנוי:" + " " + phone;
            });

            selectElement.innerHTML = "מספר טלפון מנוי:" + " " + result[0].telephone;
            for (var i = 0; i < result.length; i++) {
                var opt = document.createElement("option")
                opt.innerHTML = result[i].first_name + ' ' + result[i].last_name;
                opt.setAttribute('value', result[i].cust_id);
                select.appendChild(opt);

            }

        },

        (error) => {
            console.log(error);
        }
    );
}

//הוספת כניסת מנוי
function GetTheSubObj() {
    var selector = document.getElementById("subList")
    var selectIndex = selector.selectedIndex;
    var custId = selector[selectIndex].value;

    axios.get(path + 'Subscribers/GetSubByCustId/' + custId).then(
        (response2) => {
            var subObj = response2.data;

            sessionStorage.theSubId = subObj.Subscription_id;



            var CurrentShift = sessionStorage.CurrentShift;
            var subId = sessionStorage.theSubId;
            //הוספת כניסת מנוי
            axios.post(path + 'CustEnter/PostSub?id=' + subId + '&id2=' + CurrentShift).then(
                (response3) => {
                    var addResult = response3.data;
                    if (addResult == true) {
                        alert("הכניסה נוספה בהצלחה!")
                        location.reload()
                    }
                    else
                        alert("מנוי זה כבר נכנס לבריכה")
                    location.reload()
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

//------------------------------------

//מספר הבחירה
function indexChoose() {
    var d = document.getElementsByName('choose');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            return d[i].value;
        }
    }

}

//אישור מחיקת כניסת מנוי
function confirmRemove() {
    var id = indexChoose();
    if (id != null) {


        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'CustEnter/DeleteSubEnter?id=' + id).then(
                (response) => {
                    console.log(response)
                    var result = response.data;

                    alert("נמחק בהצלחה")
                    location.reload();
                },
                (error) => {
                    console.log(error);
                    alert("אופססס")

                }
            );


        }


    }
    else
        alert("לא נעשתה בחירה")

}

//המרת תאריך לתצוגה 
function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
}


//כפתור הוספה- מנוי או השכרה

function otherOrSub() {
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
}

function showTime() {

    let time = new Date();
    let hour = time.getHours();
    let min = time.getMinutes();
    let sec = time.getSeconds();
    am_pm = "AM";

    if (hour > 12) {
        hour -= 12;
        am_pm = "PM";
    }
    if (hour == 0) {
        hr = 12;
        am_pm = "AM";
    }

    hour = hour < 10 ? "0" + hour : hour;
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    let currentTime = hour + ":"
        + min + ":" + sec;
    var h = document.getElementById("hour");
    h.innerHTML = currentTime;

}
//קטע מידע
function GetCurrentOpen() {
    axios.get(path + 'OpenDays/GetCurrentOpenDays').then(
        (response) => {
            var openObj = response.data;

            if (openObj != null) {
                sessionStorage.CurrenGender = openObj.gender;
                sessionStorage.CurrentShift = openObj.shift_id;
                var theShift = openObj.shift_id;
                var theGender = openObj.gender;
                var s = document.getElementById("shift");
                var g = document.getElementById("gender");
                var d = document.getElementById("date");

                var date = new Date();
                date = getdate(date)
                s.innerHTML = theShift;
                g.innerHTML = theGender;
                d.innerHTML = date;
                setInterval(showTime, 1000);
                showTime()




            }
            else {

                var det = document.getElementById("subEnterCont");
                det.innerHTML = 'הבריכה סגורה - אין אפשרות להיכנס';
                var rentForm = document.getElementById("submitBtn");
                rentForm.innerHTML = '';
                var rentForm = document.getElementsByClassName("details")[0];
                rentForm.innerHTML = "הבריכה סגורה"


            }

        },

        (error) => {
            console.log(error);
        }
    );

}


//כניסת משכיר------------------------------------------------

//פתיחת טופס כניסה

function OpenRentForm() {

    var modal = document.getElementById("openRentModal");



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

//הצגת המשכיר הנוכחי

function GetCurrentRent() {

    OpenRentForm();
    setTimeout(function () {
        var rentName = document.getElementById("rentName");
        var rentDetails = document.getElementById("rentDetails");

        let thePath = 'https://localhost:44371/api/Customers/GetCurrentRent';
        axios.get(thePath).then(
            (response) => {
                var result = response.data;
                if (result != null) {
                    rentName.innerHTML = result.first_name + " " + result.last_name;
                    rentDetails.innerHTML = result.telephone;
                }
                else
                    rentName.innerHTML = "ביום זה אין משכיר פעיל";

            },

            (error) => {
                console.log(error);
            }
        );
    }, 1)

}
//הוספת כניסת משכיר
function AddRentEnter() {
    let thePath = 'https://localhost:44371/api/CustEnter/addRentEnter';
    axios.post('https://localhost:44371/api/CustEnter/addRentEnter').then(
        (response) => {
            var result = response.data;
            console.log(result);
            if (result != null) {
                alert("כניסת המשכיר נקלטה בהצלחה!")
                location.reload();
            }


        },

        (error) => {
            console.log(error);
        }
    );
}