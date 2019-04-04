(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state','$stateParams', 'commonService'];

    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        //đối tượng product
        $scope.product = {};
        //hình ảnh nhiều của sản phẩm
        $scope.moreImages = [];
        //setting ckeditor
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        //chọn hình ảnh
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        //chọn nhiều hình ảnh

        //chuyển tên thành tên seo
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        //cập nhật sản phẩm
        $scope.UpdateProduct = UpdateProduct;

        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('/api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.');
            });
        }

        //load product for edit by id
        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            },function (error) {
                notificationService.displayError(error.data);
            });
        }
        //load category cho sản phẩm
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        //load nhiều hình ảnh sản phẩm
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }


        //gọi hàm
        loadParentCategory();
        loadProductDetail();
    }
    
})(angular.module('petProject.products'))