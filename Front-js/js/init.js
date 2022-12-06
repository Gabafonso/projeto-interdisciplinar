(function($){
  $(function(){

    $('.sidenav').sidenav();

  }); // end of document ready
})(jQuery); // end of jQuery name space

  // Or with jQuery

  $(document).ready(function(){
    $('.carousel').carousel({
      numVisible: 3,
      padding: 100
    });
  });

  $(".dropdown-trigger").dropdown();