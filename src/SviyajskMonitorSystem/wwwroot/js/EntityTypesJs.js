var entitytypeproxy=$.connection.entityTypeHub;

entitytypeproxy.client.ShowNewType=function(htmlstring){
  //  alert(htmlstring);
    $('#TypeTable').append(htmlstring);
}


var AddType=function(){
    var name=$('#listid').val();
    $('#listid').val("");
    entitytypeproxy.server.addEType(name);
}


$.connection.hub.start();