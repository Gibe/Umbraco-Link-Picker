angular.module("umbraco").controller("Gibe.LinkPickerController", function ($scope, assetsService) {

	var ngi = angular.element('body').injector();
	var uDialogService = ngi.get('dialogService');

	// choose internal link
	$scope.chooseLink = function () {
		$scope.model.value = null;
		uDialogService.linkPicker({
			callback: function (e) {
				// set model
				$scope.model.value = {
					id: e.id || 0,
					name: e.name || '',
					url: e.url,
					target: e.target || '_self'
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

	assetsService.loadCss("/App_Plugins/GibeLinkPicker/picker.css");
});