$(function () {
    var l = abp.localization.getResource('AlertSystem');

    var service = acmeInc.alertSystem.messageSources.webhookMessageSource;
    var createModal = new abp.ModalManager(abp.appPath + 'WebhookMessageSource/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'WebhookMessageSource/EditModal');

    var websiteUrl = window.location.protocol + '//' + window.location.host;

    var dataTable = $('#WebhookMessageSourceTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('AlertSystem.WebhookMessageSource.Update'),
                            action: function (data) {
                                editModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('AlertSystem.WebhookMessageSource.Delete'),
                            confirmMessage: function (data) {
                                return l('WebhookMessageSourceDeletionConfirmationMessage', data.record.title);
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
                title: l('WebhookMessageSourceTitle'),
                data: "title"
            },
            {
                title: l('WebhookMessageSourceFrom'),
                data: "from"
            },
            {
                title: l('WebhookMessageSourceBody'),
                data: "body"
            },
            {
                title: l('WebhookMessageSourceURL'),
                data: null,
                render: function (data, type, row, meta) {
                    return `${websiteUrl}/webhook/${row.id}`;
                }
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewWebhookMessageSourceButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});

