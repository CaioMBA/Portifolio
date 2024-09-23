document.addEventListener("DOMContentLoaded", () => {
    enablingTypingAnimation();
});

//#region TypeAnymation
function enablingTypingAnimation() {
    var typed = undefined;

    typed = new Typed(".typing", {
        strings: ["Software Engineer", "Software Architect", "Tech Leader"],
        typeSpeed: 20,
        backSpeed: 50,
        loop: true
    });
}

//#endregion TypeAnymation

//#region side-bar
const navToggleButton = document.querySelector(".side-bar .navigation-toggler");
const sideBar = document.querySelector(".side-bar");

navToggleButton.addEventListener("click", () => {
    sideBarSectionTogglerBtn();
});

function sideBarSectionTogglerBtn() {
    sideBar.classList.toggle("open");
    navToggleButton.classList.toggle("open");
}

//#endregion side-bar
