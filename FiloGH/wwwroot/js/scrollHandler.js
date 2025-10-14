
window.scrollFunctions = {
    addScrollListener: function (dotNetReference) {
        const scrollHandler = () => {
            // Retrieve the scroll position
            let scrollPosition = getVisibleSectionId();
            // Pass the scroll position back to the Blazor component
            dotNetReference.invokeMethodAsync('SetScrollPosition', scrollPosition);
        };
        
        // Add the scroll event listener
        window.addEventListener("scroll", scrollHandler);

        // Return the scroll handler function for detaching later
        return scrollHandler;
    },
    detachScrollListener: function () {
        // Remove the scroll event listener
        window.removeEventListener("scroll", scrollHandler);
    }
};

function getVisibleSectionId() {
    const sections = document.querySelectorAll('.section'); // Adjust this selector based on your HTML structure
    for (const section of sections) {
        const rect = section.getBoundingClientRect();

        // Check if the section is at least 50% visible on the screen
        if (rect.top <= window.innerHeight / 2 && rect.bottom >= window.innerHeight / 2) {
            return section.id;
        }
    }

    return null; // No section found
}