var det;

var elem;
$(document).ready(function () {//попыька применить jquery ajax запрос тупо ну ладно
    $("a.Edit").bind('click', Edit);
    $("a.Delete").bind('click', Delet);
    $("#Create").bind('click',Creat)
});


function Creat(e) {
    e.preventDefault();
    url = $(this).data('request-url');
    $.ajax({
        type: "GET",
        url: url,
        async: false,
        success: function (text) {
            $('.table tr td').parent().parent().append(text);
        }
    });
   

}

function Edit(e){
    e.preventDefault();
    a = $(this).parent().parent().children();
    var f = $(this).attr('href');
    var id = (f.split('/'))[3];
    var elem = $(a[5]).clone();
    var newElem = '<td><input class="form-control text-box single-line" id="Name" name="Name" type="text" value="' + $.trim($(a[0]).text()) + '"></td>';
    newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Number должно быть число."' +
        'data-val-required="Требуется поле Number." id="Number" name="Number" type="number" value="' + $.trim($(a[1]).text()) + '"></td>';
    newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля W должно быть число."' +
        ' data-val-required="Требуется поле W." id="W" name="W" type="number" value="' + $.trim($(a[2]).text()) + '"></td>';
    newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Hour должно быть число."' +
        'data-val-required="Требуется поле Hour." id="Hour" name="Hour" type="text" value="' + $.trim($(a[3]).text()) + '"></td>';
    newElem += '<td><input class="form-control text-box single-line" data-val="true" data-val-number="Значением поля Day должно быть число."' +
        'data-val-required="Требуется поле Day." id="Day" name="Day" type="text" value="' + $.trim($(a[4]).text()) + '"></td>';
    newElem += '<td><input type="button" value="Save" class="btn btn-default g"></td>';
    $(this).parent().parent().children().not($(this).parent()).remove();
    $(this).parent().parent().append(newElem);
       
    //alert($.trim($(a[i]).text()));
       
    $($(this).parent().parent().children().last().children()).bind('click',{index:id , element:elem}, SaveResult);
        $(this).parent().remove();
        

    }
function SaveResult(e) {
       a = $(this);
       datVal = a.parent().parent();
       $.ajax({

           type: 'post',//тип запроса: get,post либо head

           url: 'http://localhost:7342/Device/EditJ',

           data: { 'Id': e.data.index, 'Name': datVal.find('#Name').val(), 'Number': datVal.find('#Number').val(), 'W': datVal.find('#W').val(), 'Hour': datVal.find('#Hour').val(), 'Day': datVal.find('#Day').val() },//параметры запроса

           response: 'text',//тип возвращаемого ответа text либо xml

           success: function (data) {//возвращаемый результат от сервера


               var rez = "<td>" + datVal.find('#Name').val() + "</td><td>" + datVal.find('#Number').val() + "</td><td>" + datVal.find('#W').val() + "</td><td>" + datVal.find('#Hour').val() + "</td><td>" + datVal.find('#Day').val() + "</td>";

               a.parent().parent().children().not(a.parent()).remove();
               a.parent().parent().append(rez).append(e.data.element);
               a.parent().remove();
               $("a.Edit").bind('click', Edit);
               $("a.Delete").bind('click', Delet);
           }

       });
}

function Delet(e) {   
        e.preventDefault();
        var f = $(this).attr('href');
        var id = (f.split('/'))[3];
        $("#Delet").val(id);
        $("#Delet").bind('click', { st: $(this) }, DeletElem);
        $("#butModal").click();
}
function DeletElem(e) {
    $.ajax({

        type: 'post',//тип запроса: get,post либо head

        url: 'http://localhost:7342/Device/DeleteJ',

        data: { 'Id': $(this).val()},//параметры запроса

        response: 'text',//тип возвращаемого ответа text либо xml

        success: function (data) {//возвращаемый результат от сервера


            e.data.st.parent().parent().remove();
            $(".md-close").click();
        }

    });
}