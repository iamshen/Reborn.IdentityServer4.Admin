﻿window.addEventListener("load",
    function() {
        const a = document.querySelector("a.PostLogoutRedirectUri");
        if (a) {
            window.location = a.href;
        }
    });