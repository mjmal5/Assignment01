$("#BookingDate").datepicker({
    beforeShowDay: $.datepicker.noWeekends,
    dateFormat: "dd/mm/yy",
})

//Fix for the date validation issue
$(function () {
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, "DD/MM/YYYY", true).isValid();
    }
});