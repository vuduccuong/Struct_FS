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
    }
};

$(document).ready(function () {
    indexController.init();
});