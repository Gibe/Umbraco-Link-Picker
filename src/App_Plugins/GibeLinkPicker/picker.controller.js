angular.module("umbraco").controller("Gibe.LinkPickerController", function ($scope, assetsService) {

	var ngi = angular.element('body').injector();
	var uDialogService = ngi.get('dialogService');

    // choose internal link
	$scope.chooseLink = function () {
	    $scope.model.value = null;
	    uDialogService.open({
	        template: '../App_Plugins/GibeLinkPicker/Dialogs/linkpicker.html',
	        show: true,
	        dialogData: $scope.model.config,
	        callback: function(e) {
	            // set model
	            $scope.model.value = {
	                id: e.id || 0,
	                name: e.name || '',
	                url: e.url,
	                target: e.target || '_self',
	                hashtarget: e.hashtarget || ''
	            };
	            // close dialog
	            uDialogService.close();
	        }
	    });
	};

	$scope.editLink = function () {
	    var linkPickerModel = angular.copy($scope.model);
	    uDialogService.open({
	        template: '../App_Plugins/GibeLinkPicker/Dialogs/linkpicker.html',
	        show: true,
	        dialogData: linkPickerModel.config,
	        target: linkPickerModel.value,
	        callback: function (e) {
	            // set model
	            $scope.model.value = {
	                id: e.id || 0,
	                name: e.name || '',
	                url: e.url,
	                target: e.target || '_self',
	                hashtarget: e.hashtarget || ''
	            };
	            // close dialog
	            uDialogService.close();
	        }
	    });
	};

	// remove link
	$scope.removeLink = function () {
		$scope.model.value = null;
	};

	assetsService.loadCss("../App_Plugins/GibeLinkPicker/picker.css");
});