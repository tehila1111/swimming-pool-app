function subEnter() {
    var first = document.getElementById("fname").value;
    var last = document.getElementById("lname").value;
    var phone = document.getElementById("phone").value;
    var d = new Date();

    // בדיקה האם זה יום שלישי
    if (d.getDay() == 2)
        alert("הבריכה אינה פתוחה כרגע")

    axios.get('https://localhost:44371/api/Customers/GetByNamePhone/?name=' + first + '&name2=' + last + '&name3=' + phone).then(
        (response) => {
            console.log(response)
            var result = response.data;
            alert("heyyy")
        },
        (error) => {
            console.log(error);
        }
    );