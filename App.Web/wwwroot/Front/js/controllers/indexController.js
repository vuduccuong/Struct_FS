let indexController = {
    init: function () {
        indexController.resigter();
    },

    resigter: function () {
        indexController.event();
    },

    event: function () {
        //Bỏ hiệu ứng thanh menu
        $('.site-navbar').hasClass('position-relative') ?
            $('.site-navbar').removeClass('position-relative') :
            null;

        //Tạo hiệu ứng trượt

        $(document).on('click', '[toscroll]', function (e) {
            e.preventDefault();
            var link = $(this).attr('toscroll');
            if ($(link).length > 0) {
                var posi = $(link).offset().top - 30;
                $('body,html').animate({ scrollTop: posi }, 1000);
            }
        });

        //Check menu co da cap khong
        const thisParent = $('li.check-child ul');
        if (thisParent.length > 0) {
            thisParent.parent().addClass('has-children');
        }

        //Check active menu theo url
        const link = window.location.pathname;
        const tt = $("ul.site-menu >li > a[href='"+link+"']");
        $(tt[0]).parent().addClass('active');
        const tt1 = $("ul.dropdown >li > a[href='" + link + "']");
        $(tt1[0]).parent().addClass('active');
        $(tt1[0]).parent().parent().parent().addClass('active');
        
    }
};

$(document).ready(function () {
    indexController.init();
});