$(function () {

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.messages.message;
    var createModal = new abp.ModalManager(abp.appPath + 'Message/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Message/EditModal');

    var dataTable = $('#MessageTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                    items:
                        [
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
                                confirmMessage: function (data) {
                                    return l('MessageDeletionConfirmationMessage', data.record.title);
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
                title: l('MessageTitle'),
                data: "title"
            },
            {
                title: l('MessageFrom'),
                data: "from"
            },
            {
                title: l('MessageSourceId'),
                data: "sourceId"
            },
            {
                title: l('MessageSourceType'),
                data: "sourceType"
            },
            {
                title: l('MessageBody'),
                data: "body"
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
