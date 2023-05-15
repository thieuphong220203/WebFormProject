/*!
* Start Bootstrap - Shop Homepage v5.0.6 (https://startbootstrap.com/template/shop-homepage)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-shop-homepage/blob/master/LICENSE)
*/
// This file is intentionally blank
// Use this file to add JavaScript to your project

// ======================<<slider>>=======================

let slideIndex = 0

function nextImg() {
    if (slideIndex >= document.getElementsByClassName('slide-show__img').length - 1) {
        slideIndex = -1
    }

    let imgItems = document.getElementsByClassName('slide-show__img')[++slideIndex];
    // console.log(imgItems)

    for (let i = 0; i < document.getElementsByClassName('slide-show__img').length; i++) {
        let imgD_none = document.getElementsByClassName('slide-show__img')[i];
        if (!imgD_none.classList.contains('d-none')) {
            imgD_none.classList.add('d-none');
        }
    }

    if (imgItems.classList.contains('d-none')) {
        imgItems.classList.remove('d-none');
    }

}

function backImg() {
    if (slideIndex <= 0) {
        slideIndex = document.getElementsByClassName('slide-show__img').length;
    }

    let backImgItems = document.getElementsByClassName('slide-show__img')[--slideIndex];

    for (let i = 0; i < document.getElementsByClassName('slide-show__img').length; i++) {
        let imgD_none = document.getElementsByClassName('slide-show__img')[i];
        if (!imgD_none.classList.contains('d-none')) {
            imgD_none.classList.add('d-none');
        }
    }

    if (backImgItems.classList.contains('d-none')) {
        backImgItems.classList.remove('d-none');
    }

}

function setIntervalSlider() {
    return setInterval(() => {
        nextImg()
    }, 3000)
}

