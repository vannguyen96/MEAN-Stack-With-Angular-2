/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module("petProject.product_categories", ["petProject.common"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            parent: 'base',
            templateUrl: "/app/components/product_category/productCategoryView.html",
            controller: "productCategoryController"
        }).state('add_product_category', {
            url: "/add_product_category",
            parent: 'base',
            templateUrl: "/app/components/product_category/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('edit_product_category', {
            url: "/edit_product_category/:id",
            parent: 'base',
            templateUrl: "/app/components/product_category/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });
    }
})();