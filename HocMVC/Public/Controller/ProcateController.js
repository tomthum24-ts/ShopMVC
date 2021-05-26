var homeController = {
    init: function () {
        homeController.registerEvent();
        homeController.loadData(); 
        
    },
    registerEvent: function () {
        
    },

    loadData: function (changePageSize) {
        $.ajax({
            url: '/ProCategory/loadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                //alert(2);
                if (response.status) {
                    var d = new Date();
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        var dateString = item.CreatedDate.substr(6);
                        var currentTime = new Date(parseInt(dateString));
                        var month = currentTime.getMonth() + 1;
                        var day = currentTime.getDate();
                        var year = currentTime.getFullYear();
                        var date1 = day + "/" + month + "/" + year;
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            ParentID: item.ParentID,
                            //CreatedDate: moment.utc('/Date(1530144000000+0530)/'),
                            CreatedDate: date1,
                            Status: item.Status == true ? "\"checkbox\" checked" : "\"checkbox\""
                        });

                    });
                    $('#tblData').html(html);
                    //homeController.paging(response.total, function () {
                    //    homeController.loadData();
                    //}, changePageSize);
                    homeController.registerEvent();
                    //alert(2);
                }
                else {
                    alert("Không tải được dữ liệu");
                }
            }
        },)
    },
    changestatus: function () {
        alert(2)
        $('.trangthai').on('click', function (e) {
            alert(click)
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            alert(2);
            $.ajax({
                url: "/Admin/ProCategory/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    //console.log(response);
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khoá');
                    }
                }
            });
        });
    },
    

}
homeController.init();
