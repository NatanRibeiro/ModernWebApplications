(function() {
    'use strict';

    angular.module('mwa').constant('SETTINGS',
    {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'mwa-token',
        'AUTH_USER': 'mwa-user',
        'SERVICE_URL': '/',
        'CART_ITEMS': 'mwa-cart'
});

    angular.module('mwa').run(function($rootScope, $location, SETTINGS) {
        var user = localStorage.getItem(SETTINGS.AUTH_USER);
        var token = localStorage.getItem(SETTINGS.AUTH_TOKEN);
        var cart = localStorage.getItem(SETTINGS.CART_ITEMS);

        $rootScope.user = null;
        $rootScope.token = null;
        $rootScope.header = null;
        $rootScope.cart = [];

        if (token && user) {
            $rootScope.user = user;
            $rootScope.token = token;
            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer' + $rootScope.token
                }
            }
        }

        if (cart) {
            var items = angular.fromJson(cart);
            angular.forEach(items, function(value, key) {
                $rootScope.cart.push(value);
            });
        }

        $rootScope.$on("$routeChangeStart", function(event, next, current) {
            if ($rootScope.user === null) {
                $location.path('/login');
            }
        });
    });
})();