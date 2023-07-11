$(document).ready(function(){
$('#ElementTree').on('changed.jstree',function(e,data){
 var i, j, r = [];
    for(i = 0, j = data.selected.length; i < j; i++) {
      r=data.instance.get_node(data.selected[i]).id;
      parent=data.instance.get_parent(data.selected[i])
      pid=data.selected[i];
    }
    $('#elid').val(r);
    $('#elid1').val(r);
}).jstree({
      'core': {
          "check_callback": true,
          "themes": {
              "name":"default",
              "icons":true,
              "stripes": true
          },
            'data': {
                'url': '/Elements/GetAllElements'
                }
            },
           "plugins" : [ "wholerow" ],
           'multiple' : false
            
    });
})

    

    var checkForm=function(){
        if($('#elid').val()===""&&$('#elid1').val()===""){
            return false;
        }else{
            return true;
        }
    }
