var timer;

$(".dropdown").on("mouseover", function () {
    clearTimeout(timer);
    $(".dropdown-menu").addClass("show");
}).on("mouseleave", function () {
    timer = setTimeout(function () {
        $(".dropdown-menu").removeClass("show");
    }, 500);
});