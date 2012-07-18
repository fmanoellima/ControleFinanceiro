/// <reference path="../jquery-1.7.2.js" />

$(function () {
    
});
function ConfigureFormValidation(_form, _jsonValidationSettings,_addSuccessClass) {

    _jsonValidationSettings["highlight"] = function (element, errorClass) {
        $(element).closest('.control-group').switchClass('success', 'error','fast');
    };

    _jsonValidationSettings["unhighlight"] = function (element, errorClass) {
        $(element).closest('.control-group').removeClass('error');
    };
    
    if (_addSuccessClass){

        _jsonValidationSettings["success"] = function(label) {
            label
                .text('OK!').addClass('valid')
                .closest('.control-group').switchClass('error', 'success', 'fast');
        };

        _jsonValidationSettings["error"] = function (label) {
            label.closest('.control-group').removeClass('success');
        };
    }

    
    _jsonValidationSettings["errorElement"] = 'span';
    _jsonValidationSettings["errorClass"] = 'help-inline';

    return $(_form).validate(_jsonValidationSettings);
}