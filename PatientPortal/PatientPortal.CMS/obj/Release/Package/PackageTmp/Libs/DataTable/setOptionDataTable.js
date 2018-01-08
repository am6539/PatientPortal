
//Init view - delete Column Defs DataTable
function getVDColumnDefs(className, indexColumn, viewTitle, viewClass, deleteTitle, deleteClass) {
    var object =
    {
        "className": className,
        "targets": indexColumn,
        "data": null,
        "defaultContent": '<a href="#" class="btn btn-sm btn-view btn-primary" title="' + viewTitle + '" style="padding:1px 5px 1px 5px;"><i class="' + viewClass + '" aria-hidden="true"></i></a> '
                        + '<a href="#" class="btn btn-sm btn-delete btn-danger" title="' + deleteTitle + '" style="padding:1px 5px 1px 5px;"><i class="' + deleteClass +'" aria-hidden="true"></i></a>'
    }
    return object;
}


//Init view column Defs DataTable
function getViewColumnDefs(className, indexColumn, viewTitle, viewClass)
{
    var object =
       {
           "className": className,
           "targets": indexColumn,
           "data": null,
           "defaultContent": '<a href="#" class="btn btn-sm btn-view btn-primary" title="' + viewTitle + '" style="padding:1px 5px 1px 5px;"><i class="' + viewClass + '" aria-hidden="true"></i></a> '
       }
    return object;
}

function getCrudColumnDefs(className, indexColumn, hrefContent) {
    var object =
       {
           "className": className,
           "targets": indexColumn,
           "data": null,
           "defaultContent": hrefContent
       }
    return object;
}
