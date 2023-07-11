var treetypeproxy = $.connection.treeTypeHub;




treetypeproxy.client.ShowNewAttr = function (htmlstring) {
    $('#AttributeList').append(htmlstring);
}

var RegisterType=function(){
    var typename=$('#TypeName').val();
     $('#TypeName').val("");
    treetypeproxy.server.createType(typename);
  //  $('#TypeName').val("");
}


var addattribute=function () {
    //alert($('keyname').val());
    var keyname=$('#keyname').val();
    $('#keyname').val("");
    treetypeproxy.server.addKey(keyname, $('#attrtype').val(), $('#entitytypes').val());
    $('#keyname').val("");
}

//var AttrKeyProxy = connection.createHubProxy("TreeTypeHub");
$.connection.hub.start();//.done(function () { console.log('Now connected, connection ID=' + $.connection.hub.id); })
   // .fail(function () { console.log('Could not Connect!'); });


var TypeChanged= function(){
     if($('#attrtype').val()===3){
         opentTypes();
     }else{
         closetTypes();
     }
}

var opentTypes=function() {
      $('#ChooseEntityTypes').collapse("show");
}

var closetTypes=function() {
      $('#ChooseEntityTypes').collapse("hide");
}


treetypeproxy.client.ClearKeys=function(){
    $('#AttributeList').empty();
}
