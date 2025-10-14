window.interop = window.interop || {};

window.interop.PopoverManager = (function() {
  const ANIMATION_DURATION = 300;
  const sidebar = document.getElementById("sidebar");
  const slideHasSub = document.querySelectorAll(".nav > ul > .slide.has-sub");

  class PopperObject {
    constructor(reference, popperTarget) {
        this.init(reference, popperTarget);
    }
    
    init(reference, popperTarget) {
        this.reference = reference;
        this.popperTarget = popperTarget;
        this.instance = Popper.createPopper(this.reference, this.popperTarget, {
          placement: "bottom",
          strategy: "relative",
          resize: true,
          modifiers: [
            {
              name: "computeStyles",
              options: {
                adaptive: false,
              },
            },
          ],
        });
        document.addEventListener("click", (e) => this.clicker(e, this.popperTarget, this.reference), false);
        const ro = new ResizeObserver(() => { this.instance.update(); });
        ro.observe(this.popperTarget);
        ro.observe(this.reference);
    }

    clicker(event, popperTarget, reference) {
      if ( sidebar.classList.contains("collapsed") && !popperTarget.contains(event.target) && !reference.contains(event.target)) {
        this.hide();
      }
    }

    hide() {
      this.popperTarget.style.visibility = "hidden";
    }
  }

  class Poppers {
    subMenuPoppers = [];
  
    constructor() {
      this.init();
    }

    init() {
        slideHasSub.forEach((element) => {
            this.subMenuPoppers.push(
                new PopperObject(element, element.lastElementChild)
            );
            this.closePoppers();
        });
    }
    togglePopper(target) {
      const style = window.getComputedStyle(target);
      if (style.visibility === "hidden" || style.visibility === "") {
        slideDown(target, ANIMATION_DURATION).then(() => {
            target.style.visibility = "visible";
            this.updatePoppers();
          });
      } else {
        target.style.visibility = "hidden";
      }
      this.updatePoppers();
    }

    updatePoppers() {
        this.subMenuPoppers.forEach((element) => {
            element.instance.state.elements.popper.style.display = "none";
            element.instance.update();
        });
    }

    closePoppers() {
      this.subMenuPoppers.forEach((element) => {
        element.hide();
      });
    }
  }

  let popperInstance = null;

  return {
    init: function () {
      popperInstance = new Poppers();
    },
    togglePopper: function (element) {
      if (!popperInstance) {
        popperInstance = new Poppers();
      }
      popperInstance.togglePopper(element);
    },
    updatePoppers: function () {
      if (popperInstance) {
        popperInstance.updatePoppers();
      }
    },
    closePoppers: function () {
      if (popperInstance) {
        popperInstance.closePoppers();
      }
    },
  };
})();
