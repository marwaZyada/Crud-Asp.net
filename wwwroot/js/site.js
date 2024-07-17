// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#color').change(function () {
    value = $(this).val()
   

    console.log(value.split('-'));
    var styles = value.split('-')
    console.log(styles[0])
    console.log($('#dashboard'))

    //if (value == "white") {
    //    $("td:not(:first-child)").css("color", "black")

    //}
    if (styles[0] == "red") {
        changecolor(styles, "4px")
    }
    if (styles[0] == "yellow") {
        changecolor(styles, "8px")
    }
    else if (styles[0] == "white") {
        changecolor(styles, "1px");

        $("tr:not(:last-child)").css({
            
            "border-bottom-color": "black"
        });
        $("#dashboard").css({
            "background-color": "black",

        });
      
    }


});

function changecolor( color, width) {
    $("#dashboard").css({
        "background-color": color[0],
      
    });

    $("tr:not(:last-child)").css({

        "border-bottom-width": width,
        "border-bottom-color": color[2],
    });
    $("th").css({
        "background-color": "#000",
        "color": "#fff",
    });
    $("#table").css({
        "background-color": color[0],
        //"font-weight": "bold",
    });

    $("td:not(:first-child)").css({
        //"background-color": "#000",
        //"color": "#fff",
        /*  "padding": "60px",*/
        "color": color[3],
        "border-left-width": width,
        "border-left-color": color[1],
    });
}
$(document).ready(function () {
    $("#table").css("border", "2px solid");
});