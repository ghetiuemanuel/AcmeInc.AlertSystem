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
                                editModal.open({ id: data.record.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('AlertSystem.Message.Delete'),
                            action: function (data) {
                                const recordId = data.record.id;

                                abp.message.confirm(
                                    l('MessageDeletionConfirmationMessage', data.record.title),
                                    null,
                                    (isConfirmed) => {
                                        if (isConfirmed) {
                                            service.delete(recordId).then(function () {
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
                title: l('MessageSource'), 
                data: null, 
                render: function (data, type, row) {
                    const sources = [];
                    if (row.webhookMessageSource && row.webhookMessageSource.title) {
                        sources.push(row.webhookMessageSource.title);
                    }
                    if (row.emailMessageSource && row.emailMessageSource.title) {
                        sources.push(row.emailMessageSource.title);
                    }
                    return sources.length ? sources.join(', ') : 'N/A'; 
                }
            },
            {
                title: l('MessageSourceType'),
                data: "message.sourceType"
            },
            {
                title: l('MessageBody'),
                data: "message.body"
            },
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
