/// <reference path="knockout-2.1.0.debug.js" />
/// <reference path="jquery-ui-1.8.22.js" />
/// <reference path="jquery-1.7.2.js" />
/// <reference path="ajax-util.js" />
/// <reference path="ko-protected-observable.js" />
/// <reference path="jquery.notifyBar.js" />

$(function () {
    $("#tagDialog").hide();


    var data =
        [
           { Id: 1, Name: "MVC" },
           { Id: 2, Name: "SignalR" },
           { Id: 3, Name: "KnockoutJS" },
           { Id: 4, Name: "RavenDB" },
           { Id: 5, Name: "Sql Server" },
           { Id: 6, Name: "Entity FrameWork" },
           { Id: 7, Name: "NodeJS" }
        ];

    $.getJSON("/tags/tags", function (data) {

        var viewModel = {
            //data
            tags: ko.observableArray(ko.toProtectedObservableItemArray(data)),
            tagToAdd: ko.observable(""),
            selectedTag: ko.observable(null),

            // behaviours
            addTag: function () {
                this.tags.push({ Name: this.tagToAdd() });
                this.tagToAdd("");
            },

            selectTag: function () {
                viewModel.selectedTag(this);
            },
        };

        $(".tag-delete").live("click", function () {
            var itemToRemove = ko.dataFor(this);
            viewModel.tags.remove(itemToRemove);
        });

        $(".tag-edit").live("click", function () {
            $("#tagDialog").dialog({
                buttons: {
                    Save: function () {
                        $(this).dialog("close");
                        viewModel.selectedTag().commit();
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        ko.applyBindings(viewModel);

    });
});