(function () {
    'use strict';

    angular.module('mwa').controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = [];

    function HomeCtrl($scope) {
        var vm = this;

        vm.activate = activate;

        activate();

        function activate() {

        }
    }
})();