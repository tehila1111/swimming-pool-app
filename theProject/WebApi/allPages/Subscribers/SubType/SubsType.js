
var path = 'https://localhost:44371/api/'

//הצגת סוגי מנויים
function GetAllSubType() {
    axios.get(path + 'SubsType/GetSubType').then(
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
            th.className = "admin"
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'סוג';
            tr.appendChild(th);

            th = document.createElement("th");
            th.innerHTML = 'מספר כניסות';
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



                var td = document.createElement("INPUT");
                td.setAttribute("type", "radio");
                td.setAttribute("name", "chooseType");
                td.setAttribute("value", result[i].Subscription_type_id);
                td.className = "choose";
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].type;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].Num_of_entrances;
                tr.appendChild(td);

                var td = document.createElement("td");
                td.innerHTML = result[i].price;
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



//הוספת סוג מנוי
function AddSubType() {

    var types = document.getElementById("type").value;
    var num = document.getElementById("numEnter").value;
    var cost = document.getElementById("cost").value;
    var status = document.getElementById("status").value;

    var obj = { type: types, Num_of_entrances: num, price: cost, status: status };
    if (types != '' && num != '' && cost != '') {
        axios.post(path + 'SubsType/PostSubType', obj).then(

            (response) => {
                var result = response.data;
            },
            (error) => {
                console.log(error);
            }
        );
    }
    else
        alert("ישנפ פרטים חסרים")

}






//מחיקת הבחירה
function deleteChoose() {
    var id;
    var d = document.getElementsByName('chooseType');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            id = d[i].value;
            break;
        }
    }
   
    if (id == null)
        alert("לא נעשתה בחירה!")
    else
        if (confirm("האם אתה בטוח שברצונך למחוק?")) {
            axios.delete(path + 'SubsType/DeleteSubType/' + id).then(
                (response) => {
                    console.log(response)
                    var result = response.data;

                    if (result == false)
                        alert("המנוי עדיין בשימוש, אין אפשרות למחוק!");
                    else {

                        window.location.href = "Subscribed.html";
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


//הכנסה לטופס רישום מנוי - סוגי מנוי
function GetSubType() {
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


//פתיחת מודל הוספת סוג מנוי
function openAddModel() {
    var modal = document.getElementById("addSubType");



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


//--------------------------------------------------------
//עדכון סוג מנוי

function sendToUpdate() {
    idSelectChoose();

    if (sessionStorage.idsChoose == "null")
        alert("לא נעשתה בחירה!")
    else {

        openUpTypeForm();
    }
}


//קוד בחירה
function idSelectChoose() {
    var d = document.getElementsByName('chooseType');
    sessionStorage.idsChoose = null;
    sessionStorage.TypeIdChoose = null;
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            sessionStorage.idsChoose = i;
            sessionStorage.TypeIdChoose = d[i].value;
            break;
        }
    }
    if (sessionStorage.idsChoose != "null") {
        var table = document.getElementsByClassName("MyTable")[0];
        console.log(table)
        var line = table.children[sessionStorage.idsChoose];
        console.log(sessionStorage.idsChoose)
        console.log(line)
        sessionStorage.type = line.children[1].textContent;
        sessionStorage.num = line.children[2].textContent;
        sessionStorage.typePrice = line.children[3].textContent;
        sessionStorage.typeStatus = line.children[4].textContent;


    }

}
//פתיחת טופס עדכון
function openUpTypeForm() {
    var modal = document.getElementById("UpSubType");

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


    var UPtype = document.getElementById("UPtype");
    var UPnumEnter = document.getElementById("UPnumEnter");
    var UPcost = document.getElementById("UPcost");
    var UPstatus = document.getElementById("UPstatus");




    UPtype.setAttribute('value', sessionStorage.type);
    UPnumEnter.setAttribute('value', sessionStorage.num);
    UPcost.setAttribute('value', sessionStorage.typePrice);
    UPstatus.setAttribute('value', sessionStorage.typeStatus)


   
}




//עדכון בחירה
function UpObj() {
    var id = sessionStorage.TypeIdChoose;

    var type = document.getElementById("UPtype").value
    var sumOfEntries = document.getElementById("UPnumEnter").value
    var price = document.getElementById("UPcost").value
    var status = document.getElementById("UPstatus").value


    var obj = {
        Subscription_type_id: id,
        type: type,
        Num_of_entrances: sumOfEntries,
        price: price,
        status: status
    }

    axios.put(path + 'SubsType/Put/', obj).then(
        (response) => {
            console.log(response)
            var result = response.data;




        },
        (error) => {
            console.log(error);
            alert("error")

        }
    );
}


