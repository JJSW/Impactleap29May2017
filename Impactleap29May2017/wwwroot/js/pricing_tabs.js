$(document).ready(function() {
  $("#tab1").click(function(){
    $("#tab11").removeClass("nodisplay1");
    $("#tab12").addClass("nodisplay2");
    $("#tab13").addClass("nodisplay3");
  });
  $("#tab2").click(function(){
    $("#tab11").addClass("nodisplay1");
    $("#tab12").removeClass("nodisplay2");
    $("#tab13").addClass("nodisplay3");
  });
  $("#tab3").click(function(){
    $("#tab11").addClass("nodisplay1");
    $("#tab12").addClass("nodisplay2");
    $("#tab13").removeClass("nodisplay3");
  });
});
