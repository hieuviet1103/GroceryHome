var nowTemp = new Date();
var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);
var files;
var storedFiles = [];
var upc = 0;
var filesAttatch;
var storedFilesAttatch = [];
var upcAttatch = 0;

$(function () {

    $(":file").attr('title', '  ');
    var $loading = $('#loadingDiv').hide();

    $("input[id='fileHtml']").change(function (e) {
        doReCreate(e);
    });

    selDiv = $("#selectedFiles");
});

function doReCreate(e) {
    upc = upc + 1;
    handleFileSelect(e);

    $("input[id^='fileHtml']").hide();

    $('<input>').attr({
        type: 'file',
        multiple: 'multiple',
        id: 'fileHtml' + upc,
        class: 'form-control',
        name: 'fileHtml',
        style: 'float: left',
        title: '  ',
        onchange: "doReCreate(event)"

    }).appendTo('#uploaders');
}

function handleFileSelect(e) {

    //selDiv.innerHTML = ""; storedFiles = [];
    selDiv = document.querySelector("#selectedFiles");

    if (!e.target.files) return;

    //selDiv.innerHTML = "";
    files = e.target.files;

    for (var i = 0; i < files.length; i++) {
        //if (i == 0) { selDiv.innerHTML = ""; storedFiles = []; }
        var f = files[i];
        selDiv.innerHTML += "<div class='upload-item'>" + f.name + "<a style='cursor: pointer; float: right;' onclick='removeAtt(this)'> <i class='fa fa-times'></i></a></div>";
        storedFiles.push(f.name);
    }
    $('#ListImage').val(storedFiles);
}

function removeAtt(t) {
    var serEle = $(t).parent().text().slice(0, -1);

    var index = storedFiles.indexOf(serEle);
    if (index !== -1) {
        storedFiles.splice(index, 1);
    }
    $(t).parent().remove();

    $('#ListImage').val(storedFiles);
}