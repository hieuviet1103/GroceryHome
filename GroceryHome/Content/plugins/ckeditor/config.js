/**
 * @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    var url = 'http://' + location.host;

    config.enterMode = CKEDITOR.ENTER_BR;
    config.filebrowserBrowseUrl = url + '/Content/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = url + '/Content/plugins/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = url + '/Content/plugins/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = url + '/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = url + '/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = url + '/Content/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.width = "100%";
    config.height = "300px"
};

CKEDITOR.on('dialogDefinition', function (ev) {
    var dialogName = ev.data.name;
    var dialogDefinition = ev.data.definition;
    var dialog = dialogDefinition.dialog;
    var editor = ev.editor;

    if (dialogName == 'image') {
        dialogDefinition.onOk = function (e) {
            var imageSrcUrl = e.sender.originalElement.$.src;
            var width = e.sender.originalElement.$.width;
            var height = e.sender.originalElement.$.height;
            var imgHtml = CKEDITOR.dom.element.createFromHtml('<img src="' + imageSrcUrl + '" alt="" style="width:100%; height: auto;" />');
            editor.insertElement(imgHtml);
        };
    }
});

var editor;
function createEditor(languageCode, id) {
    var editor = CKEDITOR.replace(id, { language: languageCode });
}