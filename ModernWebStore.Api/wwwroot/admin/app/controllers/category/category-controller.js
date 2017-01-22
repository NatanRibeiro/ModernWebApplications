(function () {
    'use strict';

    angular.module('mwa').controller('CategoryCtrl', CategoryCtrl);

    CategoryCtrl.$inject = ['CategoryFactory'];

    function CategoryCtrl(CategoryFactory) {
        var vm = this;
        vm.categories = [];
        vm.category = {
            id: 0,
            title: ''
        };


        vm.loadCategory = loadCategory;
        vm.saveCategory = saveCategory;
        vm.cancelEdit = cancelEdit;
        vm.removeCategory = removeCategory;

        activate();

        function activate() {
            getCategories();
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

        function addCategory() {
            CategoryFactory.post(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.categories.push(response);
            }

            function fail() {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }

            clearCategory();
        }

        function updateCategory() {
            CategoryFactory.put(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Category <strong>' + response.title + '</strong> was updated!', 'Category Updated');
                clearCategory();
            }

            function fail() {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }
        }

        function removeCategory(category) {
            loadCategory(category);
            CategoryFactory.remove(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Category <strong>' + response.title + '</strong> was removed!', 'Caterogy Removed');
                var index = vm.categories.indexOf(category);
                vm.categories.splice(index, 1);
            }

            function fail() {
                toastr.error('You requisition could not be processed!', 'Request failed');
            }

            clearCategory();
        }

        function clearCategory() {
            vm.category = {
                id: 0,
                title: ''
            }
        }

        function loadCategory(category) {
            vm.category = category;
        }

        function saveCategory() {
            if (vm.category.id === 0) {
                addCategory();
            } else {
                updateCategory();
            }
        }

        function cancelEdit() {
            clearCategory();
        }
    };
})();