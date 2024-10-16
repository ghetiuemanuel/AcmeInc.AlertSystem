$(function () {
    var l = abp.localization.getResource('AlertSystem');
    var service = optionOneTech.alertSystem.messages.message;

    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Message/CreateModal',
        scriptUrl: '/Pages/Message/edit.js',
        modalClass: 'messageEdit'
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'Message/EditModal',
        scriptUrl: '/Pages/Message/edit.js',
        modalClass: 'messageEdit'
    });

    var dataTable = $('#MessageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getNavigationList),
        columnDefs: [
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('AlertSystem.Message.Update'),
                            action: function (data) {
                                editModal.open({ id: data.record.message.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('AlertSystem.Message.Delete'),
                            action: function (data) {
                                abp.message.confirm(
                                    l('MessageDeletionConfirmationMessage', data.record.message.title),
                                    null,
                                    function (isConfirmed) {
                                        if (isConfirmed) {
                                            service.delete(data.record.message.id).then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                        }
                                    }
                                );
                            }
                        }
                    ]
                }
            },
            {
                title: l('MessageTitle'),
                data: "message.title"
            },
            {
                title: l('MessageFrom'),
                data: "message.from"
            },
            {
                title: l('MessageSourceId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.webhookMessageSource && row.webhookMessageSource.title) {
                        return row.webhookMessageSource.title;
                    }
                    if (row.message && row.message.sourceId) {
                        return row.message.sourceId;
                    }
                    return '';
                }
            },
            {
                title: l('MessageSourceType'),
                data: "message.sourceType"
            },
            {
                title: l('MessageBody'),
                data: "message.body"
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMessageButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
