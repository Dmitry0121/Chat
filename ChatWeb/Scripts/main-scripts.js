function SendMessage()
{
    var message = GetMessage();
    $.ajax({
        url: '/Home/SendMessage',
        type: "POST",
        data: JSON.stringify(message),
        contentType: "application/json;charset=utf-8",
        success: function (id)
        {
            $(".text-mess ul").append('<li data-messageid="' + id + '" class="sent"><div class="time-mess">' +
                message.DateTimeSend + '</div><div>' + $('#messege').val() + "</div></li>");
            $('#messege').val("");
        }
    });
}

function Listener()
{
    var mes_ul = $('.text-mess-ul');
    var childs = mes_ul.children('li');
    var count = childs.length;
    var id = childs.eq(count - 1).data('messageid');
    if (id > 0) {
        $.ajax({
            url: '/Home/GetNewMessages/',
            type: "GET",
            data:
            {
                currentUserId: id
            },
            success: function (data)
            {
                WriteResponse(data);
            }
        });
    }
}

function GetAllMessages() {
    $.ajax({
        url: '/Home/GetMessages/',
        type: "GET",
        success: function (data)
        {
            WriteResponse(data);
        }
    });
}

function WriteResponse(list)
{
    if (list.length > 0)
    {
        var id = $("#userId").val();
        $.each($.parseJSON(list), function (index, message)
        {
            if (message.UserId == id)
            {
                $(".text-mess ul").append('<li data-messageid="' + message.Id + '" class="sent"><div class="time-mess">' +
                    message.DateTimeSend + '</div><div>' + message.Text + "</div></li>");
            }
			else
            {
                $(".text-mess ul").append('<li data-messageid="' + message.Id + '" class="take"><div class="time-mess">' +
                    message.DateTimeSend + '</div><div>' + message.Text + "</div></li>");
            }
        });
    }
}

function GetMessage()
{
    var date = GetTimeFormat();
    var message =
    {
        UserId: $("#userId").val(),
        Text: $('#messege').val(),
        DateTimeSend: date
    };
    return message;
 }

function GetTimeFormat()
{
    return new Date(Date.now());
}