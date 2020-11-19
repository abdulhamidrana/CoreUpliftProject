app.service('myService', function ($http) {

    this.categoryList = function () {
        var response = $http.get('CategoryNgjs/CategoryList');
        return response;
    };

    this.addCategory = function (category) {
        //alert(category);
        var response = $http({
            method: 'post',
            url: 'CategoryNgjs/AddCategory',
            data: JSON.stringify(category)
        });
        return response;
    };

    this.updateCategory = function (category) {
        //alert(category);
        var response = $http({
            method: 'post',
            url: 'CategoryNgjs/UpdateCategory',
            data: JSON.stringify(category),
        });
        return response;
    };

    this.deleteCategory = function (id) {
        var response = $http({
            method: 'post',
            url: 'CategoryNgjs/DeleteCategory',
            params: { Id: JSON.stringify(id) }
        });
        return response;
    };

});
