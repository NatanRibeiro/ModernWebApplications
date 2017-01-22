(function () {
    'use strict';

    angular.module('mwa').controller('ProductEditCtrl', ProductEditCtrl);

    ProductEditCtrl.$inject = ['$routeParams', 'ProductFactory'];

    function ProductEditCtrl($routeParams, ProductFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.removeProduct = removeProduct;
        vm.products = {};

        activate();

        function activate() {
            getProduct();
        }

        function getProduct(id) {
            ProductFactory.getItem(id)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.products = response;
            }

            function fail(error) {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }
        }

        function removeProduct(product) {
            ProductFactory.remove(product)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('The product <strong>' + response.title + '</strong> was removed!', 'Product Removed');
                var index = vm.products.indexOf(product);
                vm.products.splice(index, 1);
            }

            function fail(error) {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }
        }
    };
})();