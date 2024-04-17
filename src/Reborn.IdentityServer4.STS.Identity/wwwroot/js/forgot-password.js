$(function() {
    $('input[name="Policy"]').change(function() {
        const selectedLoginPolicy = $("[name=Policy]:checked").val();
        $(".resetPasswordBy").hide();
        $(`#resetPasswordBy${selectedLoginPolicy}`).show();
    });

    $(".resetPasswordBy").hide();
});