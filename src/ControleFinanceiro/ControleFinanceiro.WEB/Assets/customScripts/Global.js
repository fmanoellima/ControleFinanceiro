/// <reference path="../jquery-1.7.2.js" />

$.validator.addMethod(
        "regex",
        function (value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
       window.Resources.MessagesResource.InvalidFieldValueMessage
);

        
$.validator.addMethod("greaterthan", function (value, element, param) {

    var valuetocompare = $(param).val();
    return this.optional(element) || (value > valuetocompare);
            
},
window.Resources.MessagesResource.InvalidFieldValueMessage
);

$.validator.addMethod("notequalto", function (value, element, param) {

    var valuetocompare = $(param).val().toString().toLowerCase();

    return this.optional(element) || (value.toString().toLowerCase() == valuetocompare);
},
window.Resources.MessagesResource.InvalidFieldValueMessage
);



function urldecode(str) {
    return decodeURIComponent((str + '').replace(/\+/g, '%20'));
}


function GetUrlQueries() {
    var urlQueries = { };
    var urlParameters = document.location.search.substr(1).split('&');

    if (urlParameters[0].length > 0) {
        $.each(urlParameters, function(c, q) {
            var i = q.split('=');
            urlQueries[i[0].toString()] = urldecode(i[1].toString());
        });
    }
    return urlQueries;
}