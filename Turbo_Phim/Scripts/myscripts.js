
$(document).ready(function () {
    $('.popup-with-zoom-anim').magnificPopup({
        type: 'inline',
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in'
    });
});

$(function () {
    $(".knob").knob();
});
$(function () {
    var match = document.cookie.match(new RegExp('color=([^;]+)'));
    if (match) var color = match[1];
    if (color) {
        $('body').removeClass(function (index, css) {
            return (css.match(/\btheme-\S+/g) || []).join(' ')
        })
        $('body').addClass('theme-' + color);
    }

    $('[data-popover="true"]').popover({ html: true });

});

$(function () {
    var uls = $('.sidebar-nav > ul > *').clone();
    uls.addClass('visible-xs');
    $('#main-menu').append(uls.clone());
});

$("[rel=tooltip]").tooltip();
$(function () {
    $('.demo-cancel-click').click(function () { return false; });
});


//$('#confirmDeleteModal').on('show.bs.modal', function (e) {
//    var myGenreID = $(e.relatedTarget).data('data-genre-id');
//    $(e.currentTarget).find('input[name="bookId"]').val(myGenreID);
//    // As pointed out in comments,
//    // it is superfluous to have to manually call the modal.
//    // $('#addBookDialog').modal('show');
//});

$(function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
    $("#imgInp").change(function () {
        readURL(this);
    });
});






