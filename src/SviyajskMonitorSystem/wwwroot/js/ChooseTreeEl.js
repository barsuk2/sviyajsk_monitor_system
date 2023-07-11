var pid=-10;
var filesid="#photos"
var check=function(){
if(pid==-10){
    alert('Элемент не выбран. Данные внесены не будут.');
    return false;
}
if($(filesid).length>0){
if($(filesid).val()==""){
    $('#ErrorMessage').collapse("show");
    return false;
}
}
}

$(document).ready(function () {
  
    $("#eltree").on('changed.jstree', function (e, data) {
        var i, j, r = [];
        for(i = 0, j = data.selected.length; i < j; i++) {
            r=data.instance.get_node(data.selected[i]).id;
            pid=data.selected[i];
        }
        $('#ElId').val(r);
    }).jstree({
        'core': {
            "check_callback": true,
            "themes": {
                "name":"default",
                "icons":true,
                "stripes": true
            },
            'data': {
                'url': '/BuildingElements/GetElements',
                'data': function (node) {
                    return { 'pid': node.id };
                }
            },
            "plugins" : [ "wholerow" ],
            'multiple' : false

        }
    })
})




var hide=function(id){
    $('#'+id).collapse("hide");
}

var ImagesPreview = function (files) {
    $('#ImagesPreview').empty();
    for(var i=0,f;f=files[i];i++){
        var reader = new FileReader();
        if (!f.type.match('image.*')) {
            continue;
        }
     //  alert(i);
        reader.onload =  function (e) {
               // alert(i);
               var element=document.createElement("img");
               $('#ImagesPreview').append(element);
               element.width=200;
               element.height=200;
               element.src=e.target.result;
            }

        reader.readAsDataURL(f);
    }
}
