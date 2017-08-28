$(function () {
    debugger;
    $("#grid").jqGrid
    ({
        url: "/JQGrid/GetValues",
        datatype: 'json',
        mtype: 'Get',
        //table header name   
        colNames: ['CustomerId', 'CustomerName', 'Address', 'MobileNo', 'PhoneNo', 'City', 'District', 'State'],
        //colModel takes the data from controller and binds to grid   
        colModel: [
          {
              key: true,
              hidden: true,
              name: 'CustomerId',
              index: 'CustomerId',
              editable: true
          }, {
              key: false,
              name: 'CustomerName',
              index: 'CustomerName',
              editable: true
          }, {
              key: false,
              name: 'Address',
              index: 'Address',
              editable: true
          }, {
              key: false,
              name: 'MobileNo',
              index: 'MobileNo',
              editable: true
          },
          {
              key: false,
              name: 'City',
              index: 'City',
              editable: true
          },
          {
              key: false,
              name: 'District',
              index: 'District',
              editable: true
          }, {
              key: false,
              name: 'State',
              index: 'State',
              editable: true,
          }],

        pager: jQuery('#pager'),
        rowNum: 10,
        rowList: [10, 20, 30, 40],
        height: '100%',
        viewrecords: true,
        caption: 'Jq grid sample Application',
        emptyrecords: 'No records to display',
        jsonReader:
        {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
        //pager-you have to choose here what icons should appear at the bottom  
        //like edit,create,delete icons  
    }).navGrid('#pager',
    {
        edit: true,
        add: true,
        del: true,
        search: false,
        refresh: true
    }, {
        // edit options  
        zIndex: 100,
        url: '/Jqgrid/Edit',
        closeOnEscape: true,
        closeAfterEdit: true,
        recreateForm: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    }, {
        // add options  
        zIndex: 100,
        url: "/Jqgrid/Create",
        closeOnEscape: true,
        closeAfterAdd: true,
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    }, {
        // delete options  
        zIndex: 100,
        url: "/Jqgrid/Delete",
        closeOnEscape: true,
        closeAfterDelete: true,
        recreateForm: true,
        msg: "Are you sure you want to delete this task?",
        afterComplete: function (response) {
            if (response.responseText) {
                alert(response.responseText);
            }
        }
    });
});



//$(function () {
//    $("#jqGrid").jqGrid({
//        url: "/Customer/GetStudents",
//        datatype: 'json',
//        mtype: 'Get',
//        colNames: ['CustomerId', 'Customer Name', 'Address', 'MobileNo', 'PhoneNo', 'City', 'District','State'],
//        colModel: [
//            { key: true, hidden: true, name: 'CustomerId', index: 'CustomerId', editable: true },
//            { key: false, name: 'Name', index: 'CustomerName', editable: true },
//            { key: false, name: 'Address', index: 'Address', editable: true },
//            { key: false, name: 'MobileNo', index: 'MobileNo', editable: true },
//            { key: false, name: 'PhoneNo', index: 'PhoneNo', editable: true},
//            { key: false, name: 'City', index: 'City', editable: true },
//            { key: false, name: 'District', index: 'District', editable: true },
//        { key: false, name: 'State', index: 'State', editable: true }
//        ],
//        pager: jQuery('#jqControls'),
//        rowNum: 10,
//        rowList: [10, 20, 30, 40, 50],
//        height: '100%',
//        viewrecords: true,
//        caption: 'User Records',
//        emptyrecords: 'No User Records are Available to Display',
//        jsonReader: {
//            root: "rows",
//            page: "page",
//            total: "total",
//            records: "records",
//            repeatitems: false,
//            Id: "0"
//        },
//        autowidth: true,
//        multiselect: false
//    });
//});
