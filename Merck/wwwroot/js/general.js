$.ajaxSetup({
    headers: { 'Authorization': 'Bearer ' + getCookie("token") }
});
$(document).ajaxError(function myErrorHandler(event, xhr, ajaxOptions, thrownError) {

    if (xhr.status == 401 || xhr.status == 0) {
        showErrorToas("Your Session has Expired. Please Login again.");
        setCookie("token", "expired", 1);
        setTimeout(function () {
            window.location.href = '/Authentication/Login'
        }, 2000);
    }
});
function setCookie(cName, cValue, expDays) {
    localStorage.setItem(cName, cValue);
    let date = new Date();
    date.setTime(date.getTime() + (expDays * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = cName + "=" + cValue + "; " + expires + "; path=/";
}
function getCookie(cName) {
    return localStorage.getItem(cName);
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie);
    const cArr = cDecoded.split('; ');
    let res;
    cArr.forEach(val => {
        if (val.indexOf(name) === 0) res = val.substring(name.length);
    })
    return res;
}
function showErrorToas(err) {
    $("#err_toast_body").text(err)
    const toast = bootstrap.Toast.getOrCreateInstance(document.getElementById('kt_err_toast'));
    toast.show();
}
function showSuccessToas(msg) {
    $("#success_toast_body").text(msg)
    const toast = bootstrap.Toast.getOrCreateInstance(document.getElementById('kt_success_toast'));
    toast.show();
}