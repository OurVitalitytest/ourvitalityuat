$(document).ready(function() {
$(".modalbox").fancybox();
    $("#frmaddcircle").submit(function() {
        return false;
    });
    $("#Create").on("click", function() {
    var circlenameval = $("#circlename").val();
    var circleimgval = $("#circleimg").val();
    var circlepermissionsval = $("#circlepermissions").val();

    if (circlenameval!="") {
        $("#Create").replaceWith("<em>Please wait...</em>");
        
            $.ajax({
                type: 'POST',
                url: 'ucCircles.ascx',
                data: $("#frmaddcircle").serialize(),

                success: function(data) {
               
                    if (data != "") {
                        $("#frmaddcircle").fadeOut("fast", function() {
                            $(this).before("<p><strong>Success! Your custom circle has been created, thanks!</strong></p>");
                            setTimeout("$.fancybox.close()", 2000);
                        });
                    }
                }
         });

        }
 });
});