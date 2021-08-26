function setCookie(naam, waarde, dagen) {
    /*plaatst een cookie
     
    naam: cookienaam;
    waarde: de inhoud van het cookie
    dagen: optioneel, het aantal dagen dat het cookie geldig blijft vanaf nu
    indien afwezig wordt het een session cookie
    */
    var vandaag = new Date();
    var verval = "";
    if (dagen) {
        //vandaag global bovenaan deze lib;
        var vervalDatum = new Date(vandaag.getTime() + dagen * 24 * 60 * 60 * 1000);
        verval = vervalDatum.toUTCString();
    }

    document.cookie = naam + "=" + waarde + ";expires=" + verval + ";Path=/";
}


function getCookie(naam) {
    var zoek = naam + "=";
    if (document.cookie.length > 0) {
        var begin = document.cookie.indexOf(zoek);
        if (begin != -1) {
            begin += zoek.length;
            var einde = document.cookie.indexOf(";", begin);
            if (einde == -1) {
                einde = document.cookie.length;
            }
            return document.cookie.substring(begin, einde);
        }
    }
}

function clearCookie(naam) {
    /*
    verwijdert een cookie
     
    naam: cookienaam
    */
    setCookie(naam, "", -1);
}