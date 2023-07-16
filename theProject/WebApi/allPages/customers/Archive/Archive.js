

var path = 'https://localhost:44371/api/'


//הצגת לקוחות ארכיון
function getArchiveCust() {
    axios.get(path + 'Customers/GetArchiveCust').then(
        (response) => {
            console.log(response)
            var result = response.data;


            var body = document.getElementsByClassName("bodyx")[0];
            var table = document.createElement("table");
            table.className = "table table-hover";


            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
          
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
            tbody.className = "MyTableArchive";
        },
        (error) => {
            console.log(error);
        }
    );
}



//המרת תאריך לתצוגה 
function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
}