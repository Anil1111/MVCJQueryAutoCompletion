(function () {

    $('.autocomplet').on('input', function () {
        var ctl = $(this);
        var source = ctl.data('autocompletion');

        $.ajax({
            url: source,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: '{"name":"' + ctl.val() + '"}',
            dataType: 'json',


            beforeSend: function () {
                ctl.addClass('loading');
                var container = ctl.next('div');
                if (container && container.length) {
                    ctl.next('div').remove();
                }
            },
            complete: function () {
                ctl.removeClass('loading');
            },
            success: function (data) {

                $('<div></div>').insertAfter(ctl);

                var container = ctl.next('div');

                if (container && container.length) {
                    if (data) {
                        $('<ul></ul>').appendTo(container);
                        $.each(data, function (key, value) {
                            container.children('ul').append('<li>' + value + '</li>');
                        });
                    }
                    else container.append(ctl.data('Empty'));
                }
            },
            error: function (data) {

                $('<div></div>').insertAfter(ctl);
                var container = ctl.next('div');

                if (container && container.length) {
                    container.append(ctl.data('Error'));
                }

                console.log(data);
            }
        });

    });
})(jQuery);