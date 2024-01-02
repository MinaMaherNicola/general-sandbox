window.ShowToastr = (type, message) => {
    if (type.toLowerCase() === "success") {
        toastr.success(message, 'Operation Successful', { timeOut: 5000 });
    }
    if (type.toLowerCase() === "error") {
        toastr.error(message, 'Operation Failed', { timeOut: 5000 });
    }
}