


$(document).ready(function(){
    $('#Tree').on('changed.jstree',function(e,data){
    var i, j, r = [];
    for(i = 0, j = data.selected.length; i < j; i++) {
      r=data.instance.get_node(data.selected[i]).id;
      parent=data.instance.get_parent(data.selected[i])
      pid=data.selected[i];
    }
  //  alert(r);
    $('#elemid').val(r);
   
    $('#elementid').val(r);
     $('#getelinfo').ajaxSubmit({
          resetForm: true,
          target:'#info'
    })
}).jstree({
      'core': {
          "check_callback": true,
          "themes": {
              "name":"default",
              "icons":true,
              "stripes": true
          },
            'data': {
                'url':'/TreeElement/GetTree',
                'data':function (node) {
                   return { 'id' : node.id,'rootid':$('#Treeid').val() };
                },
               
            }
            },
           "plugins" : [ "wholerow" ],
           'multiple' : false
            
    })


    $("#CreateElForm").ajaxForm({
         resetForm: true,
         success:function(){
            $("#Tree").jstree(true).refresh();
        }
    })
})






















