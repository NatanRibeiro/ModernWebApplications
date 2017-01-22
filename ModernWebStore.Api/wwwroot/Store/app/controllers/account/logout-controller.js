(function () {
    'use strict';

    angular.module('mwa').controller('LogoutCtrl', LogoutCtrl);

    LogoutCtrl.$inject = ['$rootScope', '$location', 'SETTINGS'];

    function LogoutCtrl($rootScope, $location, SETTINGS) {
        var vm = this;

        logout();

        function logout() {
            $rootScope.user = null;
            $rootScope.token = null;
            localStorage.removeItem(SETTINGS.AUTH_TOKEN);
            localStorage.removeItem(SETTINGS.AUTH_USER);

            $location.path('/login');
        }
    };
})();