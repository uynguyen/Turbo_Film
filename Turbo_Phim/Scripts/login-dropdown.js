
function dropdownLogin(b) {
    if (b == null) {
        $("#login-message").html("Vui lòng đăng nhập trước đã!");
        $("#login-dropdown").addClass('open');
    }
    else {
        $("#login-message").html("Đăng nhập để viết bài và bình luận!");
    }
}


$(".rq-login").click(function () {

    $.ajax({
        url: $(this).href,
        contentType: 'application/html',
        data: { returnurl: window.location.href },
        success: function (content) {
           
        },
        error: function (e) { alert("Failure!"); }
    });
});