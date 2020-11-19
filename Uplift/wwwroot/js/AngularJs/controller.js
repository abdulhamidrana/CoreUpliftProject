app.controller('myController', function ($scope, myService) {
    CategoryList();


    $scope.newCategory = {};
    $scope.clickedCategory = {};
    $scope.message = "";

    function CategoryList() {
        myService.categoryList().then(function (result) {
            $scope.Categories = result.data;
            console.log(result.data);
        });
    };

    $scope.addCategory = function () {
        myService.addCategory($scope.newCategory)
            .then(function (result) {
                $scope.newCategory = {};
                $scope.message = "Data saved successfully";
                CategoryList()
                //console.log(result.data);
            });

        //, function (result) {
        //    alert(result)
        //}
        //);

    };

    $scope.selectedCategory = function (category) {
        $scope.clickedCategory = category;
    };

    $scope.updateCategory = function () {


        myService.updateCategory($scope.clickedCategory).then(function (result) {
            $scope.message = "Data Update successfully";
            $scope.Categories = result;
            CategoryList();
        }, function (result) {
            alert(result);
        });

    };

    $scope.deleteCategory = function () {
        myService.deleteCategory($scope.clickedCategory.Id).then(function (result) {
            $scope.message = "Data Delete successfully";
            CategoryList();
        }, function (result) {
            alert(result);
        });

    };

    $scope.clearInfo = function () {
        $scope.message = "";
    };

});

