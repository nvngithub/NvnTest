$(function() {
    $('#scheduledlg').dialog({
        autoOpen: false,
        width: 400,
        buttons: {
            "Submit": function() {
                var response = $('#recaptcha_response_field').val();
                var challenge = $('#recaptcha_challenge_field').val();
                var email = $('#email').val();
                var firstName = $('#firstName').val();
                var lastName = $('#lastName').val();
                var experience = $('#experience').val();
                var locationPreference = $('#locationpref').val();
                var technologyPreference = $('#technologypref').val();
                
                $.ajax({ url: "Services/ProgrammerService.asmx/ScheduleTest",
                    data: "{\"email\":\"" + email + "\",\"firstName\":\"" + firstName + "\",\"lastName\":\"" + lastName + "\",\"experience\":\"" + experience + "\",\"locationPreference\":\"" + locationPreference +"\",\"technologyPreference\":\"" + technologyPreference + "\",\"response\":\"" + response + "\",\"challenge\":\"" + challenge + "\"}",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg) {
                        if (msg == '') {
                            $('#scheduledlg').dialog("close");
                            $('#scheduleconfirmdlg').dialog('open');
                            return false;
                        } else {
                            $('#errormessage').html(msg);
                            Recaptcha.reload();
                        }
                    },
                    error: function(a) {
                        alert('unexpected error occured');
                    }
                });
            },
            "Cancel": function() {
                $(this).dialog("close");
            }
        }
    });

    $('#scheduleconfirmdlg').dialog({
        autoOpen: false,
        width: 500,
        buttons: {
            "Close": function() {
                $(this).dialog("close");
            }
        }
    });
});