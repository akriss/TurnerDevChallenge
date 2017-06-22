
app = angular.module('DetailsApp', []);
app.controller('DetailsController', function ($scope, $http) {

    var detailsUrl = '/api/details/';

    function getDetails() {
        titleId = getParameterByName("titleId");
        param = jQuery.param({ titleId: titleId });

        $http({
            method: "GET",
            url: detailsUrl,
            params: { titleId: titleId },
        }).then(function (response) {
            data = response.data;
            
            $scope.model = {
                title: data.TitleName,
                releaseYear: data.ReleaseYear,
                genres: data.GenreNames,
                processedDateTime: data.ProcessedDateTimeUTC,
            }

            $scope.model.storyLines = [];
            angular.forEach(data.StoryLine, function (value, key) {
                $scope.model.storyLines.push({ description: value.Description, type: value.Type, language: value.Language });
            });

            $scope.model.awards = [];
            angular.forEach(data.Award, function (value, key) {
                var award = { awardCompany: value.AwardCompany, awardName: value.AwardName, awardYear: value.AwardYear };
                if (value.AwardWon == true) {
                    award.awardWon = "Won";
                }
                else {
                    award.awardWon = "Nominated";
                }
                $scope.model.awards.push(award);
            });

            $scope.model.otherNames = [];
            angular.forEach(data.OtherName, function (value, key) {
                $scope.model.otherNames.push({ name: value.TitleName, type: value.TitleNameType, language: value.TitleNameLanguage });
            });
            
            $scope.model.participants = [];
            angular.forEach(data.TitleParticipant, function (value, key) {
                var participant = { name: value.Participant.Name, type: value.Participant.ParticipantType, roleType: value.RoleType };
                if (value.IsKey == true) {
                    participant.isKey = "True";
                }
                else {
                    participant.isKey = "False";
                }
                if (value.IsOnScreen == true) {
                    participant.isOnScreen = "True";
                }
                else {
                    participant.isOnScreen = "False";
                }
                $scope.model.participants.push(participant);
            });

            console.log($scope.model.participants)

            $scope.IsVisible = false;
            $scope.ShowHide = function () {
                $scope.IsVisible = $scope.IsVisible ? false : true;
                $scope.showButtonText = $scope.IsVisible ? "Show Fewer" : "Show More";
            };
            $scope.showButtonText = "Show More";
        }, function myError(response) {
            alert("error");
        });
    }

    getDetails();
});

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}