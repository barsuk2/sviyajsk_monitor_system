var pid=-10;
var parent=-10;
var deselect=function(){
     pid=-10;
     parent=-10;
     $("#ElTree").jstree(true).deselect_all()
    $('#parentid').val(-1);
    $('#elid').val(-1);
}
$(document).ready(function () {
    $("#ElTree").on('changed.jstree', function (e, data) {
    var i, j, r = [];
    for(i = 0, j = data.selected.length; i < j; i++) {
      r=data.instance.get_node(data.selected[i]).id;
      parent=data.instance.get_parent(data.selected[i])
      pid=data.selected[i];
    }
    $('#parentid').val(r);
    $('#elid').val(r);
  }).jstree({
      'core': {
          "check_callback": true,
          "themes": {
              "name":"default",
              "icons":true,
              "stripes": true
          },
            'data': {
                'url': 'Elements/GetJson',
                'data': function (node) {
                    return { 'pid': node.id };
                }
            },
           "plugins" : [ "wholerow" ],
            'multiple' : false
            
        }
    })

    $("#DeleteElementform").ajaxForm({
        resetForm: true,
        beforeSubmit:function(){
          if(pid===-10){
              alert("Выберите Элемент")
              return false;
          }else{return true;}
        },
        success:function(){
            $("#ElTree").jstree(true).refresh();
        }
    })
    $("#elementform").ajaxForm({
        resetForm: true,
        success:function(){
            $("#ElTree").jstree(true).refresh();
        }
    })
})