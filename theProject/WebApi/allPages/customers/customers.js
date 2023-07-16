
var path = 'https://localhost:44371/api/'
var sum;

//הצגת הלקוחות
function GetCustomers() {

    axios.get(path + 'Customers/GetCust').then(
        (response) => {
            console.log(response)
            var result = response.data;


            var body = document.getElementsByClassName("bodyb")[0];
            var table = document.createElement("table");
            table.className = "table table-hover";


            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var th = document.createElement("th");
            th.innerHTML = 'בחירה';
            tr.appendChild(th);

            th = document.createElement("th");

            th.innerHTML = 'שם פרטי';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'שם משפחה';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'טלפון';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'מייל';

            tr.appendChild(th);
            th = document.createElement("th");
            th.innerHTML = 'תאריך לידה';

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
                td.setAttribute("value", result[i].cust_id);
                td.className = "choose";
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].first_name;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].last_name;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = result[i].telephone;
                tr.appendChild(td);
                var td = document.createElement("td");
                td.innerHTML = result[i].email;
                tr.appendChild(td);


                var td = document.createElement("td");
                td.innerHTML = getdate(result[i].birthdate);
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
}

//פתיחת טופס מנוי או השכרה
function RentOrSub() {
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

//פתיחת טופס הוספת מנוי
function openFormSub() {
    var modal = document.getElementById("addSub");

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



    axios.get(path + 'SubsType/GetSubType').then(
        (response) => {
            console.log(response)
            var result = response.data;
            var subType = document.getElementById("sub-type");
            for (var i = 0; i < result.length; i++) {
                var opt = document.createElement("Option");
                opt.innerHTML = result[i].type;
                opt.value = result[i].Subscription_type_id
                subType.appendChild(opt);
            }

        },
        (error) => {
            console.log(error);
        }
    );
}

//פתיחת טופס הוספת השכרה
function openRent() {

    var modal = document.getElementById("addRent");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[3];

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

//קוד בחירה
function idSelectChoose() {
    var d = document.getElementsByName('choose');
    sessionStorage.idsChoose = null;
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            sessionStorage.idsChoose = i;
            sessionStorage.custIdChoose = d[i].value;
            break;
        }
    }
    if (sessionStorage.idsChoose != "null") {
        var table = document.getElementsByClassName("MyTable")[0];
        console.log(table)
        var line = table.children[sessionStorage.idsChoose];
        console.log(sessionStorage.idsChoose)
        console.log(line)
        sessionStorage.first = line.children[1].textContent;
        sessionStorage.last = line.children[2].textContent;
        sessionStorage.phone = line.children[3].textContent;
        sessionStorage.email = line.children[4].textContent;
        sessionStorage.birth = line.children[5].textContent;
        sessionStorage.gender = line.children[6].textContent;


    }

}


//-----------------------------

//פתיחת טופס עדכון
function openUpdateCust() {
    var modal = document.getElementById("updateCust");

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



    var firstInput = document.getElementById("first");
    var lastInput = document.getElementById("last");
    var phoneInput = document.getElementById("telephone");
    var emailInput = document.getElementById("mail");
    var birthInput = document.getElementById("birth");
    var genderInput = document.getElementById("selectOpt");

    firstInput.setAttribute('value', sessionStorage.first);
    lastInput.setAttribute('value', sessionStorage.last);
    phoneInput.setAttribute('value', sessionStorage.phone);
    emailInput.setAttribute('value', sessionStorage.email);

    var strSplit = sessionStorage.birth.split(".");
    if (strSplit[1].length == 1) {
        var month = strSplit[1];
        strSplit[1] = '0' + month;
    }
    if (strSplit[0].length == 1) {
        var day = strSplit[0];
        strSplit[0] = '0' + day;
    }
    var reversArry = strSplit.reverse();
    var joinArry = reversArry.join("-");

    birthInput.setAttribute('value', joinArry);


    var selectGender = document.getElementById("selectOpt");
    for (var i = 0; i < selectGender.length; i++) {
        if (sessionStorage.gender == selectGender[i].value) {
            selectGender.selected = "selected";
            break;
        }

    }


}

//שליחה לעדכון
function sendToUpdate() {
    idSelectChoose();

    if (sessionStorage.idsChoose == "null")
        alert("לא נעשתה בחירה!")
    else {

        openUpdateCust();
    }
}

//עדכון לקוח
function UpCust() {

    var id = sessionStorage.custIdChoose;
    var first = document.getElementById("first").value;
    var last = document.getElementById("last").value;
    var phone = document.getElementById("telephone").value;
    var email = document.getElementById("mail").value;
    var birth = document.getElementById("birth").value;
    var gender = document.getElementById("selectOpt").value




    var birthdated = birth.split('-');
    var queryObj = [{
        year: parseInt(birthdated[0]),
        month: parseInt(birthdated[1]),
        day: parseInt(birthdated[2])
    },
    {
        cust_id: id,
        first_name: first,
        last_name: last,
        telephone: phone,
        email: email,
        gender: gender,
    }]

    if (first != '' && last != '' && phone != '' && email != '' && birth != '' && gender != '') {

        /*     בדיקת תקינות*/
        sessionStorage.checkDate = null;
        sessionStorage.checkPhone = null;
        var birthdate = birth;
        var varDate = new Date(birthdate); //dd-mm-YYYY
        var today = new Date();
        today.setDate(today.getDate() - 730)
        today.setHours(0, 0, 0, 0);
        varDate.setHours(0, 0, 0, 0);

        if (varDate < today) {
            sessionStorage.checkDate = "true";
        }


        var checkPhone = document.getElementById("phone").value;
        if (checkPhone.length == 10 || checkPhone.length == 9) {

            for (var i = 0; i < checkPhone.length; i++) {
                if (checkPhone[i] >= "0" && checkPhone[i] <= "9")
                    sessionStorage.checkPhone = "true";
                else {
                    sessionStorage.checkPhone = null;
                    break;
                }

            }
        }
        if (sessionStorage.checkDate != "null" || sessionStorage.checkPhone != "null") {
            axios.put(path + 'Customers/Put', queryObj).then(
                (response) => {
                    var result = response.data;
                    alert("הפרטים עודכנו בהצלחה")
                    location.reload();

                },


                (error) => {
                    console.log(error);
                }
            );
        }
        else {
            var str = "";
            if (sessionStorage.checkDate == "null")
                str += "ישנה בעיה בתאריך!";
            if (sessionStorage.checkPhone == "null")
                str += " ישנה בעיה במספר הטלפון ";
            alert(str);
        }
    }
    else alert("ישנם פרטים חסרים");
}




//מחיקת לקוח
function DeleteCust() {
    if (confirm("האם ברצונך לשלוח לארכיון לקוח זה?")) {
        idSelectChoose();

        if (sessionStorage.idsChoose == "null")
            alert("לא נעשתה בחירה!")
        else {
            var id = sessionStorage.custIdChoose;
            setTimeout(function () {
                axios.delete(path + 'Customers/DeleteCust?id=' + id).then(
                    (response) => {
                        console.log(response)
                        var result = response.data;
                        alert("הלקוח נמחק בהצלחה")
                        location.reload();
                    },
                    (error) => {
                        console.log(error);

                    }
                );
            }, 1000)
        }
    }


}

//------------------------------------


//כפתור הוספה- מנוי או השכרה

function RentOrSub() {
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

//המרת תאריך לתצוגה 
function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
}

//------------הוספת מנוי-------------------------------------
//הוספת מנוי
function tryAdd() {
    var subType = document.getElementById("sub-type").value;
    sessionStorage.subTypeId = subType;

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
        check();

        if (sessionStorage.checkDate != "null" && sessionStorage.checkPhone != "null" && sessionStorage.checkEmail!="null") {
            //הוספת לקוח לטבלת לקוחות
            setTimeout(function () {
                axios.post('https://localhost:44371/api/Customers/Postsub', queryObj).then(
                    (response) => {
                        var result = response.data;
                        if (result == -1) {
                            alert("ישנו מנוי פעיל בשם זה, אין אפשרות לכפילות מנויים ")
                        }
                        else
                            if (result == 0)
                                AddSubDetails();
                            else
                                if (result != 0 || result != -1)
                                    AddUpdateSub(result);

                    },
                    (error) => {
                        console.log(error);
                        alert("שגיאה")
                    }
                );
            }, 1000)
        }
        else {
            var str = "";
            if (sessionStorage.checkDate == "null")
                str += "ישנה בעיה בתאריך!";
            if (sessionStorage.checkPhone == "null")
                str += " ישנה בעיה במספר הטלפון ";
            if (sessionStorage.checkEmail == "null")
                str+="כתובת האימייל אינה תקינה"
            alert(str);

        }
    }
    else
        alert("ישנם פרטים חסרים");
}

//כמות כניסות לסוג מנוי
function GetSumOfSubType() {
    var subType = parseInt(sessionStorage.subTypeId);
    axios.get(path + 'SubsType/GetNumEnter/?id=' + subType).then(
        (response) => {
            console.log(response)
            var result = response.data;
            sessionStorage.sum = result;

        },
        (error) => {
            console.log(error);
        }
    );
}

//הוספת מנוי לטבלת מנויים
function AddSubDetails() {
    GetSumOfSubType();

    setTimeout(function () {
        var subType = parseInt(sessionStorage.subTypeId);
        var s = parseInt(sessionStorage.sum);
        axios.post('https://localhost:44371/api/Subscribers/PostSubDetails/?id=' + subType + '&id2=' + s).then(

            (response) => {
                var theRusult = response.data;
                alert("המנוי נוסף בהצלחה")
                location.reload();
            },
            (error) => {
                console.log(error);
                alert("שגיאה")
            }
        );
    }, 1000)

}





function AddUpdateSub(id) {
    GetSumOfSubType();
    setTimeout(function () {
        var subType = parseInt(sessionStorage.subTypeId);
        var s = parseInt(sessionStorage.sum);
        axios.post('https://localhost:44371/api/Subscribers/UpdateSubDetails/?id=' + subType + '&id2=' + s + '&id3=' + id).then(

            (response) => {
                var theRusult = response.data;
                alert("המנוי נוסף בהצלחה")
                location.reload();
            },
            (error) => {
                console.log(error);
                alert("שגיאה")
            }
        );
    }, 1000)
}

//---------------
//הוספת השכרה
function AddRent() {

    var first = document.getElementById("rfname").value;
    var last = document.getElementById("rlname").value;
    var phone = document.getElementById("rphone").value;
    var email = document.getElementById("remail").value;
    var birth = document.getElementById("rbirthd").value;
    var gender;

    if (document.getElementById("rmen").checked === true)
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
        sessionStorage.checkDate = null;
        sessionStorage.checkPhone = null;
        sessionStorage.checkEmail = null;
        var birthdate = birth;
        var varDate = new Date(birthdate); //dd-mm-YYYY
        var today = new Date();
        today.setDate(today.getDate() - 730)
        today.setHours(0, 0, 0, 0);
        varDate.setHours(0, 0, 0, 0);

        if (varDate < today) {
            sessionStorage.checkDate = "true";
        }

        var checkPhone = phone;
        if (checkPhone.length == 10 || checkPhone.length == 9) {

            for (var i = 0; i < checkPhone.length; i++) {
                if (checkPhone[i] >= "0" && checkPhone[i] <= "9")
                    sessionStorage.checkPhone = "true";
                else {
                    sessionStorage.checkPhone = null;
                    break;
                }

            }
        }
        var email = email;
        if (isValidEmail(email))
            sessionStorage.checkEmail = "true"


        if (sessionStorage.checkDate != "null" && sessionStorage.checkPhone != "null" && sessionStorage.checkEmail != "null") {
            alert("הפרטים נקלטו, כעת המשך לקבוע תאריכים");
            window.location.href = '../Rentals/Dates/dates.html';
        }
        else {
            var str = "";
            if (sessionStorage.checkDate == "null")
                str += "ישנה בעיה בתאריך!";
            if (sessionStorage.checkPhone == "null")
                str += " ישנה בעיה במספר הטלפון ";
            if (sessionStorage.checkEmail == "null")
                str += "כתובת האימייל אינה תקינה"
            alert(str);

        }

    }
    else
        alert("חסרים פרטים!")
}
//בדיקת תקינות--------------------------------------------
function check() {
    sessionStorage.checkDate = null;
    sessionStorage.checkPhone = null;
    sessionStorage.checkEmail = null;
    var birthdate = document.getElementById("birthd").value;
    var varDate = new Date(birthdate); //dd-mm-YYYY
    var today = new Date();
    today.setDate(today.getDate() - 730)
    today.setHours(0, 0, 0, 0);
    varDate.setHours(0, 0, 0, 0);

    if (varDate < today) {
        sessionStorage.checkDate = "true";
    }

    var checkPhone = document.getElementById("phone").value;
    if (checkPhone.length == 10 || checkPhone.length == 9) {

        for (var i = 0; i < checkPhone.length; i++) {
            if (checkPhone[i] >= "0" && checkPhone[i] <= "9")
                sessionStorage.checkPhone = "true";
            else {
                sessionStorage.checkPhone = null;
                break;
            }

        }
    }
    var email = document.getElementById("email").value;
    if (isValidEmail(email))
        sessionStorage.checkEmail = "true"


}

function isValidEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}

//שליחה לארכיון-------------------------------------------

function sendToArchive() {

    if (confirm("האם ברצונך לשלוח לארכיון לקוח זה?"))
        alert("ok")
}

