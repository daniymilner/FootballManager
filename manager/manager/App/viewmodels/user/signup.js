﻿define(['plugins/router', 'httpWrapper', 'constants'],
    function (router, httpWrapper, constants) {

        var viewmodel =  {
            username: ko.observable(''),
            email: ko.observable(''),
            password: ko.observable(''),
            confirmPassword: ko.observable(''),
            skype: ko.observable(''),
            birthday: ko.observable(''),
            city: ko.observable(''),
            sex: ko.observable(''),
            aboutmyself: ko.observable(''),
            parentid: ko.observable(''),
            isUserNameExist: isUserNameExist,
            isEmailExist: isEmailExist, 
            loaderForUserName: ko.observable(false),
            loaderForEmail: ko.observable(false),
            activate: activate
        };

        viewmodel.username.isValid = ko.computed(function () {
            if (viewmodel.username().length == 0) {
                return true;
            }
            return constants.regex.loginRegex.test(viewmodel.username());
        });

        viewmodel.username.hasError = ko.observable(false);

        viewmodel.email.isValid = ko.computed(function () {
            if (viewmodel.email().length == 0) {
                return true;
            }
            return constants.regex.emailRegex.test(viewmodel.email());
        });

        viewmodel.email.hasError = ko.observable(false);

        viewmodel.password.isValid = ko.computed(function () {
            if (viewmodel.password().length == 0) {
                return true;
            }
            return constants.regex.passwordRegex.test(viewmodel.password());
        });

        viewmodel.confirmPassword.isValid = ko.computed(function () {
            if (viewmodel.confirmPassword().length == 0) {
                return true;
            }
            return viewmodel.password() == viewmodel.confirmPassword();
        });

        return viewmodel;

        function isUserNameExist() {
            if (!viewmodel.username.isValid()) {
                return;
            }
            viewmodel.loaderForUserName(true);
            httpWrapper.post('api/user/usernameexists', { username: viewmodel.username() }).then(function (response) {
                if (!response) {
                    viewmodel.username.hasError(true);
                }
            }).fin(function () {
                viewmodel.loaderForUserName(false);
            });
        }

        function isEmailExist() {
            if (viewmodel.email().length == 0) {
                return;
            }
            viewmodel.loaderForEmail(true);
            httpWrapper.post('api/user/emailexists', { email: viewmodel.email() }).then(function() {
                if (!response) {
                    viewmodel.email.hasError(true);
                }
            }).fin(function () {
                viewmodel.loaderForEmail(false);
            });
        }

        function activate() {
            
        }
    });