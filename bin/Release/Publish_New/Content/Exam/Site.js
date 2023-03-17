var minutes, seconds, hours;

$(document).ready(function () {
    $('#map_exam').hide();
});

function goBack(ctl) {
    document.getElementById("v-pills-" + (ctl - 1) + "-tab").click(); // Click on the checkbox
}

function submitAnswer() {

    var sel = $('#nData').val();

    var resultQuiz = [], countQuestion = parseInt(sel), question = {}, j = 1;

    for (var i = 1; i <= countQuestion; i++) {
        ExamAnswerDTO = {
            Id: parseInt($('#Id-' + i).val()),
            No: i,
            AnswerUserChoose: $("input[name='AnswerUserChoose-" + i + "']:checked").val()
        }

        resultQuiz.push(ExamAnswerDTO);
    }

    var subjek = $('#SubjectId').val();
    var user = $('#UserId').val();
    var time = seconds + (minutes * 60) + (hours * 3600);

    var dataToSend = {
        answerList: resultQuiz,
        subjectId: parseInt(subjek),
        userId: parseInt(user),
        timeElapased: time
    }

    $.ajax({

        type: 'POST',
        url: 'WP03007/Step',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataToSend),
        success: function (response) {
            location.href = "WP03007/Finish?UserId=" + parseInt(user);
        }
    });
}

function countDown(duration, display) {
    var timer = duration * 60;
    setInterval(function () {
        hours = parseInt((timer / 3600) % 24, 10);
        minutes = parseInt((timer / 60) % 60, 10);
        seconds = parseInt(timer % 60, 10);

        hours = hours < 10 ? "0" + hours : hours;
        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.textContent = hours + ":" + minutes + ":" + seconds;

        if (--timer < 0) {
            submitAnswer();
        }
    }, 1000);
}

function goNext(ctl) {

    if (ctl == 0) {
        $('#map_exam').show();

        var fiveMinutes = parseInt($('#ExamDuration').val()),
            display = document.querySelector('#countDown');
        countDown(fiveMinutes, display);
    }

    document.getElementById("v-pills-" + (ctl + 1) + "-tab").click(); // Click on the checkbox
}

