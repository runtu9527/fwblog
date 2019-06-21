import $ from 'jquery'

var root = "https://localhost:44335/api/";

var net = {
    getOption: function (requestType,path, callback) {
        var option = {
            type: requestType,
            url: "/",
            data: "",
            contentType:"application/json; charset=utf-8",
            dataType:"json",
            async: true,
            success: function (data) {
                var objData = null;
                var result = "";
                if (data && data.code == 0) {
                    objData = data.data;
                } else {
                    result = "请求失败";
                    if (data && data.msg) {
                        result = data.msg;
                    }
                }
                callback(result, objData);
            },
            complete: function (XMLHttpRequest, status) {
                if (status == "timeout") {
                    //超时
                    console.log("请求["+root+path+"]数据超时");
                    callback("请求数据超时", null);
                }
        
                if (status == "error") {
                    //出错
                    console.log("请求["+root+path+"]数据出错");
                    callback("请求数据出错", null);
                }
            }
        };
        return option;
    },

    doRequest: function (requestType,path, params, callback) {
        console.log("发送" + requestType + "请求，path:" + path);

        var option = this.getOption(requestType,path,callback);
        option.url = root + path;
        option.data = params;
        $.ajax(option);
    },

};


export default {
    get: function (path, params, callback) {
        net.doRequest("Get",path, params, callback);
    },
    post: function (path, params, callback) {
        net.doRequest("Post",path, params, callback);
    },
    put: function (path, params, callback) {
        net.doRequest("Post",path, params, callback);
    },
    delete: function (path, params, callback) {
        net.doRequest("Post",path, params, callback);
    }
}