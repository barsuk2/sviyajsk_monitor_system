var evalueproxy=$.connection.entityValueHub;


evalueproxy.client.ShowNewValue=function( htmlstring){
    $('#valuetable').append(htmlstring);
}

var addvalue=function(){
    var value=$('#value').val();
    $('#value').val("");
    evalueproxy.server.addValue(value,$('#typeid').val());
}

$.connection.hub.start();