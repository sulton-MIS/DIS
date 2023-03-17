var SITE_URL = window.location.href;
var BASE_URL = window.location.origin;

/**
 * added by ark.deden
 * @param msg_id  
 * @param param_1 
 * @param param_2 
 * @param param_3 
 * @param param_4 
 * @param success : callback to be called if generateMessageFromDB success, 
 *                  it will pass the message obj as param
 *                  the message obj itself contains fields { sts, type, message }
 *                  =====
 *                  sts : flag (true/false)
 *                  type : the messge type 
 *                  message: the text message
 *                  =====
 * @param isAsync : flag for async (true/false), false is the default value (sync)
 * 
 * usage ex : 
 *  generateMessageFromDB("PIS000006", "created", "", "", "", function(message) {
 *      console.log(message.message);
 *  });
 */
function generateMessageFromDB(msg_id,
                               param_1,
                               param_2,
                               param_3,
                               param_4,
                               success,
                               isAsync) {
    $.ajax({
        type: 'POST',
        url: BASE_URL + '/ErrExcMessage/Generate',
        async: isAsync ? isAsync : false,
        data: {
            MSG_ID: msg_id,
            p_PARAM1: param_1,
            p_PARAM2: param_2,
            p_PARAM3: param_3,
            p_PARAM4: param_4
        },
        success: function (opt) {
            if (success)
                success(opt);
        }
    });
}