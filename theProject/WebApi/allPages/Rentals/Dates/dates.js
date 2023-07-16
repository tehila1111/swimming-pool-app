
var path = 'https://localhost:44371/api/'


function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
}

//שליפת כל התאריכי השכרה הפנויים
function GetAllFreeDates() {
    axios.get(path + 'rentals_details/GetAllFreeDates').then(
        (response) => {
            var result = response.data;

            var dateCont = document.getElementsByClassName("dateOption")[0];



            for (var i = 0; i < result.length; i++) {

                var d = document.createElement("div");
                d.className = "dateDiv";

                d.innerText = getdate(result[i]);


                d.addEventListener("click", function (e) {
                    if (e.target.style.backgroundColor == "rgb(255, 188, 188)") {

                        e.target.style.backgroundColor = "white"
                    }

                    else {
                        var add = document.createElement("div");
                        add.innerHTML = e.target.innerText;

                        e.target.style.backgroundColor = "#ffbcbc";
                    }

                })
                dateCont.appendChild(d)
            }
        },
        (error) => {
            console.log(error);
        }
    );
}


function addRentCust() {
   
    var Cust = JSON.parse(sessionStorage.CustRentObj);
    console.log(Cust);
    axios.post('https://localhost:44371/api/Customers/PostRentCust', Cust).then(
        (response) => {
            console.log(response)
            var result = response.data;
        },


        (error) => {
            console.log(error);
            alert("שגיאה")
        }
    );
}

function addRentToRentals(obj) {
    console.log(JSON.parse(sessionStorage.CustRentObj))
    addRentCust();
    console.log(JSON.parse(sessionStorage.CustRentObj))
    setTimeout(function () {
        axios.post('https://localhost:44371/api/Rentals/PostRent', obj).then(
            (response) => {
                var result1 = response.data;
                console.log(result1);
            },


            (error) => {
                console.log(error);
                alert("שגיאה")
            }
        );
    }, 1000)
    //הוספת משכיר לטבלת משכירים
   
}

function addRentAndDetails() {
    var dateCont = document.getElementsByClassName("dateOption")[0];
    var DatesArr = new Array();
    for (var i = 0; i < dateCont.childElementCount; i++) {
        var childColor = dateCont.children[i].style.backgroundColor;
        if (childColor === "rgb(255, 188, 188)")
            DatesArr.push(dateCont.children[i].textContent);
    }
    var firstDate = DatesArr[0];
    var lastDate = DatesArr[DatesArr.length - 1];
    firstDate = firstDate.split("/");
    lastDate = lastDate.split("/");

    var Cust = JSON.parse(sessionStorage.CustRentObj);
    console.log(Cust);

    var queryObj = [{
        year: parseInt(firstDate[2]),
        month: parseInt(firstDate[1]),
        day: parseInt(firstDate[0])
    },
    {
        year: parseInt(lastDate[2]),
        month: parseInt(lastDate[1]),
        day: parseInt(lastDate[0])
    },
    {
        numOfRents: DatesArr.length

    }
    ]

    addRentToRentals(queryObj);
    setTimeout(function () {
        //הוספת פרטי השכרות למשכיר
        axios.post('https://localhost:44371/api/rentals_details/PostRentDet', DatesArr).then(
            (response) => {
                var result2 = response.data;
                console.log(result2)
                alert("פרטי ההשכרה נשמרו במערכת")
                window.location.href ='../../Rentals/rentals_details.html'
            },

            (error) => {
                console.log(error);
                alert("שגיאה")
            }
        );
    }, 2000)
}