

window.onload = function () {
    var tmp = getObjectFromMyBasketCookie();

    

    if (tmp == null) {
        setMyBasketButtonValue();
        return; //coookie not exists
    }

    var nTotalItems = 0;
    tmp.forEach(function (e) {

        nTotalItems += e.CNT;

        var eNumber = document.getElementById('AmountOf_EAN_' + e.EAN);
        if (eNumber != null) {
            eNumber.value = e.CNT;
            //e.classList.add("btn-warning");
            //ButtonAddToBasket_EAN_@item.EAN
        }

        setBasketButtonToValue(e.EAN, e.CNT);
        
    });
    setMyBasketButtonValue();
}
//the globalButton
//===============================================================================================
function setMyBasketButtonValue() {
    var tmp = getObjectFromMyBasketCookie();
    var btnMyBasket = document.getElementById('btnMyBasket');

    if (btnMyBasket == null) return;//button is niet op deze pagina

    var nTotalItems = 0;

    if (tmp == null) {
        //do niets
    }
    else {
        tmp.forEach(function (e) {

            nTotalItems += e.CNT;

            var eNumber = document.getElementById('AmountOf_EAN_' + e.EAN);
            if (eNumber != null) {
                eNumber.value = e.CNT;
                //e.classList.add("btn-warning");
                //ButtonAddToBasket_EAN_@item.EAN
            }

            setBasketButtonToValue(e.EAN, e.CNT);

        });

    }
    if (nTotalItems === 0) {
        btnMyBasket.innerHTML = 'My Basket <i class="fas fa-baby-carriage"> (empty) </i>';
    }
    else {
        btnMyBasket.innerHTML = 'My Basket <i class="fas fa-baby-carriage"> (' + nTotalItems + ') </i>';
    }
    
}
//===============================================================================================
//de buttons per product
function setBasketButtonToValue(sEan, nCount) {
    var eButtonAddBasket = document.getElementById('ButtonAddToBasket_EAN_' + sEan);
    if (eButtonAddBasket != null) {
        //console.log(eButtonAddBasket);
        eButtonAddBasket.classList.remove("btn-danger");
        eButtonAddBasket.classList.add("btn-warning");

        eButtonAddBasket.innerHTML = '<i class="fas fa-baby-carriage"></i> (' + nCount + ')';
    }
}




//===============================================================================================
//asp.netcore kan geen cookie lezen als er een " of een , in staat, daarom deze 
//replacen, in de actionmethode vd controller replacen we het terug om de string
//te kunnen deserializen
//===============================================================================================
function convertToCookie(cookieContent) {
    var _cookieContent = cookieContent.replaceAll('"', '$');
    _cookieContent = _cookieContent.replaceAll(',', '#');
    return _cookieContent;
}
function convertFromCookie(cookieContent) {
    var _cookieContent = cookieContent.replaceAll('$', '"');
    _cookieContent = _cookieContent.replaceAll('#', ',');
    return _cookieContent;
}



//===============================================================================================
function deletFromBasketCookie(Ean, bRefresh) {
    console.log(bRefresh);
    var tmp = getObjectFromMyBasketCookie();
    if (tmp == null) {
        setMyBasketButtonValue();
        return; //do nothint, 
    }

    var tmp = tmp.filter((item) => item.EAN !== Ean);

    //console.log(tmp);

    if (tmp.length == 0) {
        clearCookie("MyBasket"); //verwijderd het cookie
    }
    else {
        var jsonBasket = JSON.stringify(tmp);
        setCookie("MyBasket", convertToCookie(jsonBasket), 2);
    }


    setMyBasketButtonValue();

    //terug naar basketpage navigeren (refreshen) om de pagina terug op te bouwen
    if (bRefresh == undefined) return;
    if (bRefresh==true) {
        location.reload(); 
        //window.location.replace('/Basket');
    }
}

//===============================================================================================
function setToBasketCookie(Ean, bRefresh) {

    //get the selected numbers by getElementById
    var numberSelected = parseInt( document.getElementById('AmountOf_EAN_' + Ean).value);

    //test 
    //console.log("EAN_" + Ean + "___numbers_" + numberSelected);
    //test
    //console.log(getObjectFromMyBasketCookie());
    //test
    //console.log(numberSelected);

    var tmp = getObjectFromMyBasketCookie();

    if (tmp == null) {
        //make a array with one item
        tmp = [{ EAN: Ean, CNT: numberSelected }];
    }
    else {
        var founded = false;
        for (var i in tmp) {
            //change the value
            if (tmp[i].EAN == Ean) {
                tmp[i].CNT = numberSelected;
                founded = true;
                break; //Stop this loop, we found it!
            }
        }
        //added if not exist
        if (founded == false) {
            tmp.push({ EAN: Ean, CNT: numberSelected });
        }
    }
    //change the buttonValue (only in the mainpage, this buttons are not exist in the basketpage)
    setBasketButtonToValue(Ean, numberSelected);

    //change the content of the cookie, if there not a cookie then make new
    var jsonBasket = JSON.stringify(tmp);
    setCookie("MyBasket", convertToCookie(jsonBasket), 2);


    setMyBasketButtonValue();

    //(refreshen) om de pagina terug op te bouwen
    console.log(bRefresh);
    if (bRefresh == undefined) return;
    if (bRefresh == true) {
        location.reload();
        //window.location.replace('/Basket');
    }
}


//=========================================================================================
// this method give a array of objects, in this format, if the cookie not exist, 
// it returns null
//    [
//        { EAN: "8888888888888", CNT: 22 },
//        { EAN: "33333333333333", CNT: 33 },
//        { EAN: "44444444444", CNT: 44 }
//    ];

//=========================================================================================
function getObjectFromMyBasketCookie() {
    var cookieContent = getCookie("MyBasket");
    if (cookieContent == undefined) return null;

    cookieContent = convertFromCookie(cookieContent);
    //console.log(cookieContent);
    return JSON.parse(cookieContent);
}


