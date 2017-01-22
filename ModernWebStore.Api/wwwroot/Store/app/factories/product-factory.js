(function () {
    'use strict';

    angular.module('mwa').factory('ProductFactory', ProductFactory);

    ProductFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ProductFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove,
            getItem: getItem,
        };

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products', $rootScope.header);
        }

        function post(product) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/products', product, $rootScope.header);
        }

        function put(product) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/products/' + product.id, product, $rootScope.header);
        }

        function remove(product) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/products/' + product.id, $rootScope.header);
        }

        function getItem(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/' + id, $rootScope.header);
        } 
    }
})()