$(function () {

    $("#EmailMessageSourceFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#EmailMessageSourceCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#EmailMessageSourceFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/EmailMessageSourceFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.messageSources.emailMessageSource;
    var createModal = new abp.ModalManager(abp.appPath + 'EmailMessageSource/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'EmailMessageSource/EditModal');

    var dataTable = $('#EmailMessageSourceTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('AlertSystem.EmailMessageSource.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('AlertSystem.EmailMessageSource.Delete'),
                                confirmMessage: function (data) {
                                    return l('EmailMessageSourceDeletionConfirmationMessage', data.record.hostname);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('EmailMessageSourceHostname'),
                data: "hostname"
            },
            {
                title: l('EmailMessageSourcePort'),
                data: "port"
            },
            {
                title: l('EmailMessageSourceSSL'),
                data: "ssl"
            },
            {
                title: l('EmailMessageSourceUsername'),
                data: "username"
            },
            {
                title: l('EmailMessageSourcePassword'),
                data: "password"
            },
            {
                title: l('EmailMessageSourceFolder'),
                data: "folder"
            },
            {
                title: l('EmailMessageSourceDeleteAfterDownload'),
                data: "deleteAfterDownload"
            },
            {
                title: l('EmailMessageSourceActive'),
                data: "active"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmailMessageSourceButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
