window.interop = {
  log:function(elementRef){
    console.log(elementRef)
  },
  getElement: function (elementRef) {
    console.log(elementRef);
    
    // Function to get the CSS selector for the given element reference
    return new Promise((resolve, reject) => {
      try {
        const selector = document.querySelector(elementRef);
        if (selector) {
          resolve(true);
        } else {
          reject(false);
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  isEleExist: function (elementRef) {
    // Function to get the CSS selector for the given element reference
    const selector = document.querySelector(elementRef);
    if (selector) {
      return true;
    } else {
      return false;
    }
  },
  getBoundry: function (elementRef) {
    const rect = elementRef?.getBoundingClientRect();
    return rect;
  },
  inner: function (arg) {
    if (arg == "innerWidth") {
      return window.innerWidth ?? 992;
    }
    if (arg == "innerHeight") {
      return window.innerHeight ?? 992;
    }
    return 0
  },
  MenuNavElement: function (elementRef) {
    // Function to get the width of the given element reference
    return new Promise((resolve, reject) => {
      try {
        const element = document.querySelector(elementRef);
        if (element) {
          const scrollWidth = element.scrollWidth; // Get the scrollWidth of the element
          const marginInlineStart = Math.ceil(
            Number(
              window.getComputedStyle(element).marginInlineStart.split("px")[0]
            )
          ); // Get the scrollWidth of the element
          resolve({ scrollWidth, marginInlineStart }); // Return both element and width
        } else {
          reject("Element not found");
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  MenuNavmarginInlineStart: function (selector, value) {
    // Function to get the width of the given element reference
    return new Promise((resolve, reject) => {
      try {
        const element = document.querySelector(selector);
        if (element) {
          element.style.marginInlineStart = value;
          resolve(element); // Return both element and width
        } else {
          reject("Element not found");
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  mainSidebarOffset: function (elementRef) {
    // Function to get the width of the given element reference
    return new Promise((resolve, reject) => {
      try {
        const element = document.querySelector(elementRef);
        if (element) {
          const mainSidebarOffset = element.offsetWidth; // Get the scrollWidth of the element
          resolve(mainSidebarOffset); // Return both element and width
        } else {
          reject("Element not found");
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  addClass: function (elementRef, className) {
    const element = document.querySelector(elementRef);
    if (element) {
      element.classList.add(className);
    }
  },
  removeClass: function (elementRef, className) {
    const element = document.querySelector(elementRef);
    if (element) {
      element.classList.remove(className);
    }
  },
  removeStyle: async function (elementRef) {
    const element = document.querySelector(elementRef);
    if (element) {
      await this.slideUp(element);
      element.style = "";
    }
  },
  addClassToHtml: (className) => {
    document.documentElement.classList.add(className);
  },
  setclearCssVariables: function () {
    document.documentElement.style = "";
  },
  setCssVariable: function (variableName, value) {
    document.documentElement.style.setProperty(variableName, value);
  },
  removeCssVariable: function (variableName, value) {
    document.documentElement.style.removeProperty(variableName, value);
  },
  setCustomCssVariable: function (element, variableName, value) {
    let ele = document.querySelector(element);
    if (ele) {
      ele.style.setProperty(variableName, value);
    }
  },
  removeClassFromHtml: (className) => {
    document.documentElement.classList.remove(className);
  },
  getAttributeToHtml: (attributeName) => {
    return document.documentElement.getAttribute(attributeName);
  },
  addAttributeToHtml: (attributeName, attributeValue) => {
    document.documentElement.setAttribute(attributeName, attributeValue);
  },
  removeAttributeFromHtml: (attributeName) => {
    document.documentElement.removeAttribute(attributeName);
  },
  getAttribute: function (elementRef, attributeName) {
    return new Promise((resolve, reject) => {
      try {
        const selector = document.querySelector(elementRef);
        if (selector) {
          resolve(selector.getAttribute(attributeName));
        } else {
          reject("Element not found");
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  setAttribute: function (elementRef, attributeName, attributeValue) {
    return new Promise((resolve, reject) => {
      try {
        const selector = document.querySelector(elementRef);
        if (selector) {
          resolve(selector.setAttribute(attributeName, attributeValue));
        } else {
          reject("Element not found");
        }
      } catch (error) {
        reject(error);
      }
    });
  },
  setLocalStorageItem: function (key, value) {
    localStorage.setItem(key, value);
  },
  removeLocalStorageItem: function (key) {
    localStorage.removeItem(key);
  },
  getAllLocalStorageItem: function () {
     return localStorage;
  },
  getLocalStorageItem: function (key) {
    return localStorage.getItem(key);
  },
  clearAllLocalStorage: function () {
    localStorage.clear();
  },
  directionChange: function (dataId) {
    let element = document.querySelector(`[data-id="${dataId}"]`);
    let html = document.documentElement;
    if (element) {
      const listItem = element.closest("li");
      if (listItem) {
        // Find the first sibling <ul> element
        const siblingUL = listItem.querySelector("ul");
        let outterUlWidth = 0;
        let listItemUL = listItem.closest("ul:not(.main-menu)");
        while (listItemUL) {
          listItemUL = listItemUL.parentElement.closest("ul:not(.main-menu)");
          if (listItemUL) {
            outterUlWidth += listItemUL.clientWidth;
          }
        }
        if (siblingUL) {
          // You've found the sibling <ul> element
          let siblingULRect = listItem.getBoundingClientRect();
          if (html.getAttribute("dir") == "rtl") {
            if (
              siblingULRect.left - siblingULRect.width - outterUlWidth + 150 <
                0 &&
              outterUlWidth < window.innerWidth &&
              outterUlWidth + siblingULRect.width + siblingULRect.width <
                window.innerWidth
            ) {
              return true;
            } else {
              return false;
            }
          } else {
            if (
              outterUlWidth + siblingULRect.right + siblingULRect.width + 50 >
                window.innerWidth &&
              siblingULRect.right >= 0 &&
              outterUlWidth + siblingULRect.width + siblingULRect.width <
                window.innerWidth
            ) {
              return true;
            } else {
              return false;
            }
          }
        }
      }
    }
    return false;
  },
  groupDirChange: function () {
    let elemList = {
      added: [],
      removed: [],
      clearNavDropdown: false,
    };
    if (
      document.querySelector("html").getAttribute("data-nav-layout") ===
        "horizontal" &&
      window.innerWidth > 992
    ) {
      let activeMenus = document.querySelectorAll(".slide.has-sub.open > ul");
      activeMenus.forEach((e) => {
        let target = e;
        let html = document.documentElement;

        const listItem = target.closest("li");
        // Get the position of the clicked element
        var dropdownRect = listItem.getBoundingClientRect();
        var dropdownWidth = target.getBoundingClientRect().width;

        // Calculate the right edge position
        var rightEdge = dropdownRect.right + dropdownWidth;
        var leftEdge = dropdownRect.left - dropdownWidth;

        if (html.getAttribute("dir") == "rtl") {
          // Check if moving out to the right
          if (e.classList.contains("child1")) {
            if (dropdownRect.left < 0) {
              elemList.clearNavDropdown = true;
            }
          }
          if (leftEdge < 0) {
            elemList.added.push(
              target.previousElementSibling.getAttribute("data-id")
            );
          } else {
            if (
              listItem.closest("ul").classList.contains("force-left") &&
              rightEdge < window.innerWidth
            ) {
              elemList.added.push(
                target.previousElementSibling.getAttribute("data-id")
              );
            } else {
              // Reset classes and position if not moving out
              elemList.removed.push(
                target.previousElementSibling.getAttribute("data-id")
              );
            }
          }
        } else {
          // Check if moving out to the right
          if (e.classList.contains("child1")) {
            if (dropdownRect.right > window.innerWidth) {
              elemList.clearNavDropdown = true;
            }
          }
          if (rightEdge > window.innerWidth) {
            elemList.added.push(
              target.previousElementSibling.getAttribute("data-id")
            );
          } else {
            if (
              listItem.closest("ul").classList.contains("force-left") &&
              leftEdge > 0
            ) {
              elemList.added.push(
                target.previousElementSibling.getAttribute("data-id")
              );
            }
            // Check if moving out to the left
            else if (leftEdge < 0) {
              elemList.removed.push(
                target.previousElementSibling.getAttribute("data-id")
              );
            } else {
              elemList.removed.push(
                target.previousElementSibling.getAttribute("data-id")
              );
            }
          }
        }
      });
      let leftForceItem = document.querySelector(
        ".slide-menu.active.force-left"
      );
      if (leftForceItem) {
        if (document.querySelector("html").getAttribute("dir") != "rtl") {
          let check = leftForceItem.getBoundingClientRect().right;
          if (check < innerWidth) {
            elemList.removed.push(
              leftForceItem.previousElementSibling.getAttribute("data-id")
            );
          } else if (leftForceItem.getBoundingClientRect().left < 0) {
            if (
              document.documentElement.getAttribute("data-nav-style") ==
                "menu-hover" ||
              document.documentElement.getAttribute("data-nav-style") ==
                "icon-hover" ||
              window.innerWidth > 992
            ) {
              elemList.removed.push(
                leftForceItem.previousElementSibling.getAttribute("data-id")
              );
            }
          }
        } else {
          let check =
            leftForceItem.getBoundingClientRect().left -
            leftForceItem.parentElement.closest(".slide-menu")?.clientWidth -
            leftForceItem.getBoundingClientRect().width;
          if (check > 0) {
            if (
              document.documentElement.getAttribute("data-nav-style") ==
                "menu-hover" ||
              document.documentElement.getAttribute("data-nav-style") ==
                "icon-hover" ||
              window.innerWidth > 992
            ) {
              elemList.removed.push(
                leftForceItem.previousElementSibling.getAttribute("data-id")
              );
            }
          }
        }
      }

      let elements = document.querySelectorAll(".main-menu .has-sub ul");
      elements.forEach((e) => {
        if (isElementVisible(e)) {
          let ele = e.getBoundingClientRect();
          if (document.documentElement.getAttribute("dir") == "rtl") {
            if (ele.left < 0) {
              if (e.classList.contains("child1")) {
                elemList.removed.push(
                  e.previousElementSibling.getAttribute("data-id")
                );
              } else {
                elemList.added.push(
                  e.previousElementSibling.getAttribute("data-id")
                );
              }
            }
          } else {
            if (ele.right > innerWidth) {
              if (e.classList.contains("child1")) {
                elemList.removed.push(
                  e.previousElementSibling.getAttribute("data-id")
                );
              } else {
                elemList.added.push(
                  e.previousElementSibling.getAttribute("data-id")
                );
              }
            }
          }
        }
      });
    }

    elemList.added = [...new Set(elemList.added)];
    elemList.removed = [...new Set(elemList.removed)];
    return elemList;
  },
  updateScrollVisibility : function(dotnetHelper) {
    window.onscroll = function() {
        var scrollHeight = window.scrollY;
        dotnetHelper.invokeMethodAsync('UpdateScrollVisibility', scrollHeight);
    }
  },
  scrollToTop : function() {
    window.scrollTo({
        top: 0,
        behavior: "smooth"
    });
  },
  registerScrollListener: function (dotnetHelper) {
      window.addEventListener('scroll', function () {
          var scrollY = window.scrollY || window.pageYOffset;
          dotnetHelper.invokeMethodAsync("SetStickyClass", scrollY);
      });

    // Trigger initial check
    var scrollY = window.scrollY || window.pageYOffset;
    dotnetHelper.invokeMethodAsync("SetStickyClass", scrollY);
  },
  initCardRemove: function () {
    let DIV_CARD = ".card";
    let cardRemoveBtn = document.querySelectorAll('[data-bs-toggle="card-remove"]');
    cardRemoveBtn.forEach((ele) => {
        ele.addEventListener("click", function (e) {
            e.preventDefault();
            let $this = this;
            let card = $this.closest(DIV_CARD);
            card.remove();
            return false;
        });
      });
  },
  initCardFullscreen: function () {
      let DIV_CARD = ".card";
      let cardFullscreenBtn = document.querySelectorAll('[data-bs-toggle="card-fullscreen"]');
      cardFullscreenBtn.forEach((ele) => {
          ele.addEventListener("click", function (e) {
              let $this = this;
              let card = $this.closest(DIV_CARD);
              card.classList.toggle("card-fullscreen");
              card.classList.remove("card-collapsed");
              e.preventDefault();
              return false;
          });
      });
  },
  slideUp: function (element, duration = 300) {
    return new Promise((resolve) => {
      element.style.height = element.scrollHeight + 'px';
      element.style.overflow = 'hidden';
      element.style.transition = `height ${duration}ms ease`;
      requestAnimationFrame(() => {
        element.style.height = '0px';
      });
      element.addEventListener('transitionend', function handler() {
        element.style.display = 'none';
        element.style.removeProperty('height');
        element.style.removeProperty('overflow');
        element.style.removeProperty('transition');
        element.removeEventListener('transitionend', handler);
        resolve();
      });
    });
  },
  slideDown: function (element, duration = 300) {
    return new Promise((resolve) => {
      element.style.removeProperty('maxHeight');
      element.style.removeProperty('display');
      let display = window.getComputedStyle(element).display;
      if (display === 'none') display = 'block';
      element.style.display = display;
      const height = element.scrollHeight;
      element.style.overflow = 'hidden';
      element.style.height = '0px';
      element.style.transition = `height ${duration}ms ease`;
      requestAnimationFrame(() => {
        element.style.height = height + 'px';
      });
      element.addEventListener('transitionend', function handler() {
        element.style.removeProperty('height');
        element.style.removeProperty('overflow');
        element.style.removeProperty('transition');
        element.removeEventListener('transitionend', handler);
        resolve();
      });
    });
  },
  initializeTooltips: function() {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map((tooltipTriggerEl) => new bootstrap.Tooltip(tooltipTriggerEl));
  },
};

function isElementVisible(element) {
  const computedStyle = window.getComputedStyle(element);
  return computedStyle.display != "none";
}
