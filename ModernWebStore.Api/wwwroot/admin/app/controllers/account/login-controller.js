(function () {
    'use strict';

    angular.module('mwa').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = [];

    function LoginCtrl() {
        var vm = this;
        vm.login = {
            email: '',
            password: ''
        };

        activate();

        function activate() {

        }

        function login() {
            console.log(vm.login);
        }
    };
})();