window.showToast = function (message, type) {
    let backgroundColor;

    switch (type) {
        case 'success':
            backgroundColor = 'green';
            break;
        case 'failure':
            backgroundColor = 'red';
            break;
        case 'info':
            backgroundColor = 'blue';
            break;
        case 'warning':
            backgroundColor = 'orange';
            break;
        default:
            backgroundColor = 'gray'; // Default color
    }

    Toastify({
        text: message,
        duration: 3000, // Duration: 3 seconds
        close: true, // Show close button
        gravity: 'top', // Position: top
        position: 'right', // Align: right
        backgroundColor: backgroundColor
    }).showToast();
};
