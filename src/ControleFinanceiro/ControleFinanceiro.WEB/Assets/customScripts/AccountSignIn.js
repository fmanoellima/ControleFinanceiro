/// <reference path="../jquery-1.7.2.js" />
$(function () {

    $("#btnOpenSignInModal").click(function (e) {
        LoadLogOnValidationRules();
    });

    $("#btnSignIn").click(function (e) {
        LogOn();
    });

    $("#Password").keypress(function (e) {
        code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            e.preventDefault();
            LogOn();
        }
    });
    $("#UserName").keypress(function (e) {
        code = (e.keyCode ? e.keyCode : e.which);
        if (code == 13) {
            e.preventDefault();
            $("#Password").focus();
        }
    });

});


function LogOn() {

    if ($("#formModalLogOn").valid()) {

        ToggleStateSignInButton(true);
        var queries = GetUrlQueries();
        
        $.ajax({
            url: $.fn.appAccountControllerPath + 'LogOnAjax',
            dataType: 'json',
            type: 'POST',
            data: {
                UserName: $('#UserName').val(),
                Password: $('#Password').val(),
                RememberMe: $('#RememberMe').is(':checked')
            },
            success: function(_data, _textstatus, _xmlhttprequest) {
                if (_data.Status == 0) {

                    if (_data.Message.length == 0) {
                        window.location.href = (typeof(queries.ReturnUrl) !== 'undefined' ? queries["ReturnUrl"].toString() : ($.fn.appRootDomainPath + "Home"));
                    }
                    else {
                        LogonAlert(window.Resources.LabelsResource.Attention, _data.Message[0]);
                    }

                } else {
                    LogonAlert(window.Resources.MessagesResource.AnErrorOccurred, _data.Message[0]);
                }
                ToggleStateSignInButton(false);
               
            },
            error: function(_xmlhttprequest, _textstatus, _error) {
                LogonAlert(window.Resources.MessagesResource.AnErrorOccurred, _error,true);
                ToggleStateSignInButton(false);
            }
        });

    }
   
}


function LogonAlert(_Title, _Message, _isError) {

    var alertLogonSpan = $('#AlertLogon span');
    var alertContainer = $('#AlertLogon');
    if (_isError)
        alertContainer.addClass('alert-error');
    if (_Title.length > 0)
        alertContainer.children('h4').html(_Title);

    alertLogonSpan.html(_Message);
    alertContainer.fadeIn("slow").delay(2000).fadeOut("slow");

}


function LoadLogOnValidationRules() {
    
    $.ajax({
        url: $.fn.appAccountControllerPath + 'GetLogOnValidationRules',
        dataType: 'json',
        type: 'POST',
        success: function (_data, _textstatus, _xmlhttprequest) {
            if (_data.Status == 0) {

                if (_data.Message.length == 0) {

                    var validationSettings = $.parseJSON(_data.Output);

                    ConfigureFormValidation($("#formModalLogOn"), validationSettings);

                } else {
                    LogonAlert(window.Resources.LabelsResource.Attention, _data.Message[0]);
                }

            } else {
                LogonAlert(window.Resources.MessagesResource.AnErrorOccurred, _data.Message[0]);
            }
            ToggleStateSignInButton(false);

        },
        error: function (_xmlhttprequest, _textstatus, _error) {
            LogonAlert(window.Resources.MessagesResource.AnErrorOccurred, _error, true);
            ToggleStateSignInButton(false);
        }
    });
}


function ToggleStateSignInButton(isDisabled) {
    var btnSignIn = $("#btnSignIn");
    /*Desabilita temporariamente o evento definido*/
    if (isDisabled) 
        btnSignIn.button('loading').offtmp('click'); 
    else 
        btnSignIn.button('reset').ontmp('click'); 
            
}