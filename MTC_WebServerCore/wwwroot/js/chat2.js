
    //minimalizeren chatbox
    $('.chat-body').slideToggle(0);


    var clientId = document.getElementById('chatUserId').value;//read from the hidden field
    var chatUserName = document.getElementById('chatUserName').value; //read from the hidden field
    var adminOnlineImage = document.getElementById('adminOnline');
    var newMessageImage = document.getElementById('newMessage');
    var isReadedAllChatMessages = document.getElementById('isReadedAllChatMessages').value;
    var chatContent = document.getElementsByClassName('chat-body')[0];



    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub/").build();
    //document.getElementById('btnSendMessage').disabled = true;

    console.log(isReadedAllChatMessages);
        if (!isReadedAllChatMessages) {
        newMessageImage.src = '/images/led_red.png';
        }


        connection.on("receiveMessage", function (oMessage) {
        console.log(oMessage);
            oMessage.message = oMessage.message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

//cliendId: "8e445865-a24d-4543-a6c6-9443d048cdb9"
//client: null
//dateTime: "2021-08-28T13:34:15.2455799+02:00"
//id: 19
//isFromAdmin: false
//isReaded: false
//message: "ik bn hier graag"
//userNameReceiver: ""
//usernameSender: "Super"

if (oMessage.isFromAdmin) {
    $('.msg-insert').append("<div class='msg-send'>" + oMessage.message + "</div>");
    newMessageImage.src = '/images/led_red.png';
}
else {
    $('.msg-insert').append("<div class='msg-receive'>" + oMessage.message + "</div>");
}
//scrollen tot beneden
chatContent.scrollTop = chatContent.scrollHeight;
console.log(chatContent);
        });

connection.on("adminsConnected", function (bIsConnectedSomeAdmin) {
    //console.log(bIsConnectedSomeAdmin);


    if (bIsConnectedSomeAdmin === true) {
        adminOnlineImage.src = '/images/led_green.png';
        adminOnlineImage.title = "af employee of MTC online";
    }
    else {
        adminOnlineImage.src = '/images/led_off.png';
        adminOnlineImage.title = "no employee of MTC online";
    }
});



connection.start().then(function () {
    //document.getElementById('btnSendMessage').disabled = false;
    connection.invoke("Connect", clientId, false).catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});



        var arrow = $('#toggleExpandChatbox');
var textarea = $('.chat-text input');


arrow.on('click', function () {
    var src = arrow.attr('src');

    $('.chat-body').slideToggle('fast', function () {
        //scrollen tot beneden
        chatContent.scrollTop = chatContent.scrollHeight;
        console.log(chatContent);
    });
    if (src == 'https://maxcdn.icons8.com/windows10/PNG/16/Arrows/angle_down-16.png') {
        arrow.attr('src', 'https://maxcdn.icons8.com/windows10/PNG/16/Arrows/angle_up-16.png');

        if (newMessageImage.getAttribute('src') == '/images/led_red.png') {
            newMessageImage.src = '/images/led_off.png';
            connection.invoke("SetAllAdminMessagesAsReaded", clientId).catch(function (err) {
                return console.error(err.toString());
            });
        }
    }
    else {
        arrow.attr('src', 'https://maxcdn.icons8.com/windows10/PNG/16/Arrows/angle_down-16.png');
    }
});

textarea.keypress(function (event) {
    var $this = $(this);

    if (event.keyCode == 13) {
        var msg = $this.val();
        $this.val('');

        //verzenden naar de hub
        const ChatMessage = {
            "UsernameSender": chatUserName,
            "UserNameReceiver": '',
            "Message": msg,
            "CliendId": clientId,
            "isFromAdmin": false,
        };
        console.log(ChatMessage);
        connection.invoke("SendMessage", ChatMessage).catch(function (err) {
            return console.error(err.toString());
        });
    }
});
textarea.click(function (event) {
    if (newMessageImage.getAttribute('src') == '/images/led_red.png') {
        newMessageImage.src = '/images/led_off.png';
        connection.invoke("SetAllAdminMessagesAsReaded", clientId).catch(function (err) {
            return console.error(err.toString());
        });
    }
});

