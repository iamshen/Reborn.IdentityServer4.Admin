//Based on this article
//https://sebnilsson.com/blog/display-local-datetime-with-moment-js-in-asp-net/

$(function() {

    $(".local-datetime").each(function() {
        const $this = $(this);
        const utcDate = parseInt($this.attr("data-utc"), 10) || 0;

        if (!utcDate) {
            return;
        }

        const local = moment.utc(utcDate).local();
        const formattedDate = local.format("DD MMM YYYY HH:mm");
        $this.text(formattedDate);
    });

    $('[data-toggle="tooltip"]').tooltip();

});