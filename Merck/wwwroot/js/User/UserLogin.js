//"use strict";
//var KTSigninGeneral = function () {
//    var t, e, i;
//    return {
//        init: function () {
//            t = document.querySelector("#sign_in_form"), e = document.querySelector("#user_sign_in_submit"), i = $('form[id="sign_in_form"]').validate(t, {
//                rules: {
//                    userName: {
//                        validators: {
//                            notEmpty: {
//                                message: "Email address is required"
//                            },
//                            emailAddress: {
//                                message: "The value is not a valid email address"
//                            }
//                        }
//                    },
//                    password: {
//                        validators: {
//                            notEmpty: {
//                                message: "The password is required"
//                            }
//                        }
//                    }
//                },
//            }), e.addEventListener("click", (function (n) {
//                n.preventDefault(), i.validate().then((function (i) {
//                    "Valid" == i ? (e.setAttribute("data-kt-indicator", "on"), e.disabled = !0, userLogin()) : Swal.fire({
//                        text: "Sorry, looks like there are some errors detected, please try again.",
//                        icon: "error",
//                        buttonsStyling: !1,
//                        confirmButtonText: "Ok",
//                        customClass: {
//                            confirmButton: "btn btn-primary"
//                        }
//                    })
//                }))
//            }))
//        }
//    }
//}();
//$(document).ready(function () {
//    KTSigninGeneral.init()
//});
$(function () {
    $("#submit").click(function () {
        var usrObj = {
            UserName: $('#userName').val(),
            Password: $('#password').val(),
        };
        $.ajax({
            url: "/Auth/AuthMethod",
            data: JSON.stringify(usrObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);

                setCookie("token", result.token, 1);
                setCookie("session_user", JSON.stringify(result.user_details), 1);
                if (result.user_details.user_role == 1) {
                    window.location.href = '/AdminDashboard/';
                }
                else {
                    window.location.href = '/';
                }
            },
            error: function (errormessage) {
                Swal.fire({
                    text: "Invalid username/password, please try again.",
                    icon: "error",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok",
                    customClass: {
                        confirmButton: "btn btn-primary"
                    }
                })
            }
        });
    });
    })

$(".toggle-password").click(function () {

    $(this).toggleClass("fa-eye fa-eye-slash");
    var input = $($(this).attr("toggle"));
    if (input.attr("type") == "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
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