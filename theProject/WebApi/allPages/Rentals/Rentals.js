
var path = 'https://localhost:44371/api/'


//הצגת כל המשכירים
function GetAllRent() {
    getRentalsNames();
    setTimeout(function () {
        axios.get(path + 'Rentals/GetAllRentals').then(
            (response) => {
                console.log(response)
                var result = response.data;
                var RentalNames = JSON.parse(sessionStorage.RentalsName);

                var body = document.getElementsByClassName("bodyb")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                //var th = document.createElement("th");
                //th.innerHTML = 'בחירה';
                //tr.appendChild(th);

                th = document.createElement("th");

                th.innerHTML = 'שם משכיר';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'תאריך התחלה';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'תאריך סיום';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'מחיר';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'סטטוס';
                tr.appendChild(th);


                thead.appendChild(tr);
                table.appendChild(thead);

                var tbody = document.createElement("tbody");

                for (var i = 0; i < result.length; i++) {
                    var tr = document.createElement("tr");


                    //var td = document.createElement("INPUT");
                    //td.setAttribute("type", "radio");
                    //td.setAttribute("name", "choose");
                    //td.setAttribute("value", result[i].cust_id);
                    //td.className = "choose";
                    //tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = RentalNames[i];
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].start_date);
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].end_date);
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = result[i].price;
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = result[i].Payment_status;
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
},1000)
   
}


function getRentalsNames()
{
    axios.get(path + 'Rentals/getRentalsName').then(
        (response) => {
            var result = response.data;

            sessionStorage.RentalsName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}

//פתיחת טופס השכרה
function openRentForm()
{
    var modal = document.getElementById("addRent");

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

//שמירת פרטי משכיר ושליחה לטופס תאריכים
function AddRentCust() {
    sessionStorage.CustRentObj = null;
    var first = document.getElementById("fname").value;
    var last = document.getElementById("lname").value;
    var phone = document.getElementById("phone").value;
    var email = document.getElementById("email").value;
    var birth = document.getElementById("birthd").value;
    var gender;

    if (document.getElementById("men").checked === true)
        gender = 'זכר';
    else
        gender = 'נקבה';

    var birthdated = birth.split('-');
    var queryObj = [{
        year: parseInt(birthdated[0]),
        month: parseInt(birthdated[1]),
        day: parseInt(birthdated[2])
    },
    {

        first_name: first,
        last_name: last,
        telephone: phone,
        email: email,
        gender: gender,

    }]
   
    if (first != '' && last != '' && phone != '' && email != '' && birth != '' && gender != '') {
        sessionStorage.CustRentObj = JSON.stringify(queryObj);
        alert("הפרטים נקלטו, כעת המשך לקבוע תאריכים");
        window.location.href = 'Dates/dates.html';

    }
    else {
        alert("חסרים פרטים!")
        sessionStorage.CustRentObj = null;
}
        
}
//----------------------------------------

//הצגת כל פרטי ההשכרות
function GetAllRentDetails() {

    getRentDetailNames();
    setTimeout(function () {
        axios.get(path + 'rentals_details/GetAllRentalsDetails').then(
            (response) => {
                console.log(response)
                var result = response.data;
                var rentalsDet = JSON.parse(sessionStorage.RentalDetName);

                var body = document.getElementsByClassName("bodyc")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");
                th.innerHTML = 'בחירה';
                tr.appendChild(th);

                th = document.createElement("th");

                th.innerHTML = 'שם משכיר';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'תאריך';
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
                    td.setAttribute("value", result[i].RentalDetails_id);
                    td.className = "choose";
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = rentalsDet[i];
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].date);
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
        ); },1000)
   
}

function getRentDetailNames()
{
    axios.get(path + 'rentals_details/getRentName').then(
        (response) => {
            var result = response.data;

            sessionStorage.RentalDetName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );
}

//------------------------------------
function GetRentByRentId()
{
    var rentId = indexChoose();
    setTimeout(function () {

        axios.delete('https://localhost:44371/api/rentals_details/GetRentByRentId?id='+ rentId).then(
            (response) => {
                var result = response.data;
                console.log(result);



            },


            (error) => {
                console.log(error);
                alert("שגיאה")
            }
        )


    }, 1000)
}

//המרת תאריך לתצוגה 
function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
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



//מחיקת פרטי השכרה


//מחיקת הבחירה
function deleteDetailsChoose() {
    var id = indexChoose();
    if (id === undefined)
        alert("לא נעשתה בחירה!")
    else
        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'rentals_details/Delete/' + id).then(
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

