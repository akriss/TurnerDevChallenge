var ViewModel = function () {
    var self = this;
    self.titles = ko.observableArray();
    self.error = ko.observable();

    var titlesUri = '/api/titles/';

    function getAllTitles() {
        search = document.getElementById('SearchString').value;
        param = jQuery.param({ searchString: search });
        $.ajax({
            type: 'GET',
            url: titlesUri,
            dataType: 'json',
            contentType: 'application/json',
            data: param
        })
            .done(function (data) {
            self.titles(data);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    // Get the data
    getAllTitles();
    self.detail = ko.observable();
};

ko.applyBindings(new ViewModel());