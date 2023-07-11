$(document).ready(function(){
$('#Tree').on('changed.jstree',function(e,data){
 var i, j, r = [];
    for(i = 0, j = data.selected.length; i < j; i++) {
      r=data.instance.get_node(data.selected[i]).id;
      parent=data.instance.get_parent(data.selected[i])
      pid=data.selected[i];
    }
    $('#treeelement').val(r);
    $('#models').load('/Models/GetModel/'+r);
 //   $('#elid1').val(r);
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
