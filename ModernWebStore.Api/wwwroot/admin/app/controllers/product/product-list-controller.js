(function () {
    'use strict';

    angular.module('mwa').controller('ProductListCtrl', ProductListCtrl);

    ProductListCtrl.$inject = ['ProductFactory'];

    function ProductListCtrl(ProductFactory) {
        var vm = this;
        vm.products = [];
        vm.removeProduct = removeProduct;

        activate();

        function activate() {
            getProducts();
        }

        function getProducts() {
            ProductFactory.get()
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