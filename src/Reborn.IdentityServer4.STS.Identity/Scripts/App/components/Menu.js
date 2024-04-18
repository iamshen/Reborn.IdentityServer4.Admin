var Menu = {
    init: function() {
        document.addEventListener('DOMContentLoaded', function() {
            Menu.itemClick();
        });
    },

    itemClick: function() {
        var menuButtons = document.querySelectorAll('.menu-button');
        menuButtons.forEach(function(button) {
            button.addEventListener('click', function(e) {
                e.preventDefault();
                
                var menuItems = document.querySelectorAll('.menu-item');
                menuItems.forEach(function(item) {
                    var isVisible = item.style.display !== 'none' && item.style.display !== '';
                    if (isVisible) {
                        item.style.display = 'none';
                    } else {
                        item.style.display = '';
                    }
                });
            });
        });
    }
};

Menu.init();
