$(document).ready(function () {
    $("a.Edit").click(function (e) {
        e.preventDefault();
        alert("as");
        a = $(this).parent().parent().children();
        for (var i = 0; i < a.length - 1; i++) {
            alert(($(a[i])).text());
        }
        
    })
});