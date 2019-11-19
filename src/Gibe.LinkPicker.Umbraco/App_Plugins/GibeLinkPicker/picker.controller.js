angular.module("umbraco").controller("Gibe.LinkPickerController", function ($scope, assetsService, editorService, entityResource, iconHelper) {

	$scope.chooseLink = function () {
		$scope.model.value = null;
		var options = {
			submit: function (e) {
				$scope.model.value = loadExtraDetails({
					id: e.target.id || 0,
					udi: e.target.udi || '',
					name: e.target.name || '',
					url: e.target.url,
					target: e.target.target || '_self',
					hashtarget: e.target.anchor || '',
					isMedia: e.target.isMedia,
				});

				editorService.close();
			},
			close: function () {
				editorService.close();
			}
		}

		editorService.linkPicker(options);
	};

	$scope.editLink = function () {
		var linkPickerModel = angular.copy($scope.model);
		var options = {
			currentTarget: map(linkPickerModel.value),
			submit: function (e) {

				$scope.model.value = loadExtraDetails({
					id: e.target.id || 0,
					udi: e.target.udi || '',
					name: e.target.name || '',
					url: e.target.url,
					target: e.target.target || '_self',
					hashtarget: e.target.anchor || '',
					isMedia: e.target.isMedia,
					icon: e.icon // TODO
				});
				editorService.close();
			},
			close: function () {
				editorService.close();
			}
		};

		editorService.linkPicker(options);
	};

	function loadExtraDetails(link) {
		if (link.udi) {
			var entityType = link.isMedia ? "Media" : "Document";

			entityResource.getById(link.udi, entityType).then(function (data) {
				link.icon = iconHelper.convertFromLegacyIcon(data.icon);
			});
		} else {
			link.icon = "icon-link";
		}
		return link;
	}


	function map(model) {
		return {
			id: model.id,
			udi: model.udi,
			name: model.name,
			url: model.url,
			target: model.target,
			anchor: model.anchor
		};
	}

	// remove link
	$scope.removeLink = function () {
		delete $scope.model.value;
	};

	assetsService.loadCss("../App_Plugins/GibeLinkPicker/picker.css");
});