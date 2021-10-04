$('.owl-carousel').owlCarousel({
  loop:true,
  margin:10,
  nav:true,
  responsive:{
      0:{
          items:1
      },
      600:{
          items:3
      },
      1000:{
          items:5
      }
  }
})


function aparecerTexto() {
  document.getElementById("div").innerHTML = "Texto";
}
function reset() {
  document.getElementById("div").innerHTML = "";
}