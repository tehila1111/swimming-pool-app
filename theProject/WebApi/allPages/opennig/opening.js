var path = 'https://localhost:44371/api/'
function createDaysDivs() {
    axios.get(path + 'OpenDays/GetOpenDays').then(
        (response) => {
            var result = response.data;
            var daysCont = document.getElementsByClassName("daysCont")[0];
            var weekDays = ["ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי"]


     
  
            var allDayDivs = document.getElementsByClassName("dayDetails");
            console.log(allDayDivs);
            for (var j = 0; j < result.length; j++) {
              
                for (var i = 0; i < weekDays.length; i++) {
                   
                    if (result[j].day === weekDays[i]&&result[j].status==="פעיל") {
                       
                        var shift = document.createElement("div");
                       
                        shift.innerHTML = "משמרת:" + "     " +result[j].shift_id;
                        var gender = document.createElement("div");
                        gender.innerHTML = "מגדר:"+"     "+result[j].gender;
                        
                        allDayDivs[i].appendChild(shift);
                        allDayDivs[i].appendChild(gender);
                        var line = document.createElement("div");
                        line.className = "line";
                        line.innerHTML = "- - - - - - - - - - -";
                        allDayDivs[i].appendChild(line);

                    }
                    
                        
            }
            }

            for (var i = 0; i < weekDays.length; i++) {

                if (allDayDivs[i].childElementCount == 1)
                {
                    allDayDivs[i].innerHTML += "יום השכרה";
                    var line = document.createElement("div");
                    line.className = "line";
                    line.innerHTML = "- - - - - - - - - - -";
                    allDayDivs[i].appendChild(line);
                    break;
                }
                    
            }





        },
        (error) => {
            console.log(error);
        }
    );

}

function getHours()
{

    axios.get(path + 'WorkShType/GetAllWSType').then(
        (response) => {
            var result = response.data;
            var hours = document.getElementsByClassName("hours")[0];
            for (var i = 0; i < result.length; i++) {
                var shiftDetails = document.createElement("div");
                shiftDetails.className = "shiftDetails";
                var line = document.createElement("div");
                line.className = "line";
                line.innerHTML = "................";
               
                shiftDetails.innerHTML += "משמרת:" + "     " + result[i].name;
                shiftDetails.appendChild(line);
                shiftDetails.innerHTML += "שעת התחלה:" + "     " + result[i].start_hour + "</br>";
                shiftDetails.innerHTML += "שעת סיום:" + "     " + result[i].end_hour;
         

                hours.appendChild(shiftDetails);


            }
        },
        (error) => {
            console.log(error);
        }
    );

}


function printPage()
{
    var header = document.getElementsByClassName("landing-page")[0];
    var print = document.getElementsByClassName("print")[0];
    header.style.display = "none";
    print.style.display = "none";
    window.print();

}