/**

 @Title: layui.upload 文件上传
 @Author: 贤心
 @License：MIT

 */

layui.define('layer', function (exports) {

    var $ = layui.$
        , layer = layui.layer
        , MOD_NAME = 'config'
        , config = {
            apiUrl: 'http://localhost:8022/',
            fileUrl: "http://localhost:8022/fileUpload/"
        }

    //操作当前实例 
    exports(MOD_NAME, config);
});

