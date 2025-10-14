//Tomselect JS Sinlge Start
if (document.querySelector(".tomselect")) {
  var TomSelects = document.querySelectorAll(".tomselect");
  TomSelects.forEach(function (select) {
    new TomSelect(select, {
      create: true,
      sortField: {
        field: "text",
        direction: "asc",
      },
    });
  });
}
//Tomselect JS Sinlge End

//Tomselect JS Multiple Start

if (document.querySelector(".tomselect-multiple")) {
  var TomSelectsMultiple = document.querySelectorAll(".tomselect-multiple");
  TomSelectsMultiple.forEach(function (select) {
    new TomSelect(select, {
      plugins: ["remove_button"],
    });
  });
}
//Tomselect JS Multiple End

//Tomselect JS Unique Start

if (document.querySelector(".tomselect-unique")) {
  var TomSelectsUnique = document.querySelectorAll(".tomselect-unique");
  TomSelectsUnique.forEach(function (select) {
    new TomSelect(select, {
      create: true,
      plugins: ["drag_drop"],
      persist: false,
    });
  });
}
//Tomselect JS Unique End
