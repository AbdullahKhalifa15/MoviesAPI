let seeDetailsBtns = document.querySelectorAll(".seeMore");
let popup = document.querySelector(".pop-up");
let popupData = document.querySelector(".pop-up .data");
let popupOverlay = document.querySelector(".pop-up .overlay");
let cancelBtn = document.getElementById("cancel");

seeDetailsBtns.forEach((element) => {
  element.onclick = (e) => {
    popup.classList.toggle("active");
    e.stopPropagation();
  };
});
document.addEventListener("click", (e) => {
  if (e.target === popupOverlay) {
    // if (popup.classList.contains("active")) {
    //   popup.classList.toggle("active");
    // }
    console.log("click");
  }
});
popup.onclick = function (e) {
  e.stopPropagation();
};
cancelBtn.onclick = () => {
  popup.classList.toggle("active");
};

// seeDetailsBtns.forEach((e) => {
//   e.onclick = () => {
//     popup.classList.add("active");
//   };
// });
// cancelBtn.onclick = () => {
//   popup.classList.remove("active");
// };
