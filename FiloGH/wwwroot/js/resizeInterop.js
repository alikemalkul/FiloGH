window.resizeFunctions = {
    addresizeListener: function (dotNetReference) {
        window.resizeFunctions.resizeHandler = () => {
            // Pass the scroll position back to the Blazor component
            dotNetReference.invokeMethodAsync('OnWindowResize', window.innerWidth);
        };
        
        // Add the scroll event listener
        window.addEventListener("resize", window.resizeFunctions.resizeHandler);

        // Return the scroll handler function for detaching later
        return window.resizeFunctions.resizeHandler;
    },
    detachScrollListener: function () {
        // Remove the scroll event listener
        window.removeEventListener("resize", window.resizeFunctions.resizeHandler);
    }
};
