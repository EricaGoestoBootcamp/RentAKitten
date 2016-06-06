$(document).ready(function () {

    //test
    console.log("Hi");

    // Activate Carousel
    $("#myCarousel").carousel({ interval: false, wrap: true });

    // Enable Carousel Indicators
    //$(".item").click(function () {
    //    $("#myCarousel").carousel(1);
   // });

    // Enable Carousel Controls
    $(".left").click(function () {
        $("#myCarousel").carousel("prev");
    });

 
});