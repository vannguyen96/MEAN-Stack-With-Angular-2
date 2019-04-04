(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$filter', '$ngBootbox'];

    function productListController($scope, apiService, notificationService, $filter, $ngBootbox) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProduct = getProduct;
        $scope.keyword = '';

        $scope.search = search;

        //delete 1 danh mục
        $scope.deleteProduct = deleteProduct;
        //delete nhiều danh mục
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có muốn xóa các sản phẩm này').then(function () {
                var config = {
                    params: {
                        listItem: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/product/deletemulti', config, function (result) {
                    notificationService.displaySuccess("Đã xóa thành công " + result.data + " danh mục");
                    search();
                }, function () {
                    notificationService.displayError("Xóa không thành công");
                });
            });
            
        }


        $scope.selectAll = selectAll;
        //select danh muc
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);
        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn muốn xóa danh mục này?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/product/delete', config, function () {
                    notificationService.displaySuccess("Xóa thành công");
                    search();
                }, function () {
                    notificationService.displayError("Xóa không thành công");
                })
            });
        }

        function search() {
            getProduct();
        }

        function getProduct(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load products failed.');
            });
        }

        $scope.getProduct();
    }
})(angular.module('petProject.products'))