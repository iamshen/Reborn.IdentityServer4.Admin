window.onload = function() {
    const cultureSelect = document.getElementById("cultureSelect");
    var cultureForm = document.getElementById("selectLanguageForm");


    if (cultureSelect && cultureForm) {
        cultureSelect.onchange = function() {
            cultureForm.submit();
        };
    }
};