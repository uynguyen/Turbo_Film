
function dropdownLogin(b) {
    if (b == null) {
        $("#login-message").html("Vui lòng đăng nhập trước đã!");
        $("#login-dropdown").addClass('open');
    }
    else {
        $("#login-message").html("Đăng nhập để viết bài và bình luận!");
    }
}