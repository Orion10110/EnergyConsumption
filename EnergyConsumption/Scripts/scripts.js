$(document).ready(function () {
    $("a.Edit").click(function (e) {
        e.preventDefault();
        alert("as");
        a = $(this).parent().parent().children();
        var newElem = '<tr><td><input class="form-control text-box single-line" id="Name" name="Name" type="text" value="' + $.trim($(a[0]).text()) + '"></td>';
        newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Number должно быть число."' +
            'data-val-required="Требуется поле Number." id="Number" name="Number" type="number" value="' + $.trim($(a[1]).text()) + '"></td>';
        newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля W должно быть число."' +
            ' data-val-required="Требуется поле W." id="W" name="W" type="number" value="' + $.trim($(a[2]).text()) + '"></td>';
        newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Hour должно быть число."' +
            'data-val-required="Требуется поле Hour." id="Hour" name="Hour" type="text" value="' + $.trim($(a[3]).text()) + '"></td>';
        newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Day должно быть число."' +
            'data-val-required="Требуется поле Day." id="Day" name="Day" type="text" value="' + $.trim($(a[4]).text()) + '"></td>';
        newElem += '<td><input type="button" value="Save" class="btn btn-default g"></td></tr>';
        $(this).parent().parent().replaceWith(newElem);
            //alert($.trim($(a[i]).text()));
        
        
        $('.g').bind('click', SaveResult);
        
        

    })
});

function SaveResult() {
    
    alert("Всем - привет!");
    
}