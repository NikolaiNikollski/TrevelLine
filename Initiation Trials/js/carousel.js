"use strict"
function run() {
  const
    leftButton = document.getElementById('left_carrosel_button'),
    rightButton = document.getElementById('right_carrosel_button'),
    filmArr = document.getElementsByClassName('article'),
    filmQuantity = filmArr.length,
    articleIndent = ['0', '305px', '610px', '915px'];
  let firstSlide = 0;
  leftButton.addEventListener('click', showPrev);
  rightButton.addEventListener('click', showNext);

  refreshMovieBlock(firstSlide);
 
  function showNext() {
    let slideToDelete = firstSlide;
    firstSlide++; 
    if (firstSlide === filmQuantity) { //контротль переполнения
      firstSlide = 0;
    }
    refreshMovieBlock(firstSlide, slideToDelete);
  }

  function showPrev() {
    let slideToDelete = firstSlide + 3;       
    firstSlide--;
    if (firstSlide < 0) {             //контротль переполнения
      firstSlide = filmQuantity - 1;
    } 
    refreshMovieBlock(firstSlide, slideToDelete);
  }
  
  function refreshMovieBlock(firstSlide, slideToDelete) {
    let slideNumber;
    
    if (slideToDelete !== undefined) {
      if (slideToDelete >= filmQuantity) { //коктроль переполнения 
        slideToDelete = slideToDelete - filmQuantity;
      }
      filmArr[slideToDelete].style.display = 'none';
    }
           
    for (let position = 0; position !== 4; position++) {
      slideNumber = firstSlide + position;
      if (slideNumber >= filmQuantity){
        slideNumber = slideNumber - filmQuantity;
      } 
      filmArr[slideNumber].style.display = 'inline-block';
      filmArr[slideNumber].style.left = articleIndent[position];
    } 
  }  
}
window.onload = run;



