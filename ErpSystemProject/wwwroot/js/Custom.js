$(document).redy(function () {
    alert("Hello, World!");
})

    < script src = "https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" ></script >
        <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
   
    const AddCourse = async () => {
    debugger;
    var st = {
        "CourseName": document.getElementById("txtname").value,
        "CourseCode": document.getElementById("txtcode").value,
        "Description": document.getElementById("txtdes").value
    }
    const url = '@Url.Action("AddCourse", "Course", new { area = "Developer" })';
    const response = await fetch(url, {
        method: 'post',

        body: JSON.stringify(st),
        headers: {
            'content-type': 'application/json'
        }

    });
    const result = await response.json();
    alert("Course Added Successfully");
    window.location.reload();
    Display();
}
const Display = async () => {

    const response = await fetch("/Developer/Course/GetCourses");
    const co = await response.json();
    console.log(co);
    var data = "";
    co.forEach(function (d, k) {
        data += "<tr><td>" + (k + 1) + "</td><td>" + d.courseName + "</td><td>" + d.courseCode + "</td><td>" + d.description + "</td><td><input type='button' value='View' class='btn btn-info' onclick='EditData(" + d.courseId + ")'/></td></tr>"
    })
    document.getElementById("tbldata").innerHTML = data;
}

Display();
