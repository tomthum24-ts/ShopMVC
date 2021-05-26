var homeController = {
    init: function () {
        homeController.loadData();
        homeController.registerEvent();
    },
    registerEvent: function () {

    },
    loadData: function () {
        $.ajax({
            url: '/Admin/ProCategory',
            type: 'GET',
            dataType: 'json',
            sucuess: function () {
                if (reponse.status) {
                    //var data = reponse.data;
                    //var html = '';
                    //var template = $('#data-template').html();
                    //$.each(data, function (i, item) {
                    //    html += Mustache.render(template, {
                    //        ID: item.ID,
                    //        Name: item.Name,
                    //        ParentID: item.ParentID,
                    //        CreatedDate: item.CreatedDate,
                    //        Status: item.Status == true ? "<span class=\"label label-success\">Actived</span>" : "<span class=\"label label-danger\">Locked</span>"
                    //    });
                    //});
                    //$('#tblData').html(html);
                    alert(1);
                }
            }
        })
    }
}