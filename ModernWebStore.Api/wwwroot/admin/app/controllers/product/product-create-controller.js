(function () {
    'use strict';

    angular.module('mwa').controller('ProductCreateCtrl', ProductCreateCtrl);

    ProductCreateCtrl.$inject = ['$scope', '$location', 'ProductFactory', 'CategoryFactory'];

    function ProductCreateCtrl($scope, $location, ProductFactory, CategoryFactory) {
        var vm = this;
        vm.categories = [];
        vm.product = {
            title: '',
            category: 0,
            description: '',
            price: 0,
            image: '',
            quantityOnHand: 0
        };

        vm.croppedImage = '';
        vm.save = save;

        activate();

        function activate() {
            getCategories();
        }

        function getProducts() {

        }

        function getCategories() {
            CategoryFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.categories = response;
            }

            function fail(error) {
                console.log(error);
                if (error.status === 401)
                    toastr.error('You don"t have permission to see this page', 'Access denied');
                else
                    toastr.error('You requisition could not be processed!', 'Request failed');
            }
        }

        function save() {
            ProductFactory.post(vm.product)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Product <strong>' + response.title + '</strong> was saved!', 'Product saved');
                $location.path('/products');
            }

            function fail() {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }

            clearCategory();
        }

        var handleFileSelect = function(evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function(evt) {
                $scope.$apply(function($scope) {
                    vm.product.image = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };

        angular.element(document.querySelector('#file')).on('change', handleFileSelect);
    };
})();