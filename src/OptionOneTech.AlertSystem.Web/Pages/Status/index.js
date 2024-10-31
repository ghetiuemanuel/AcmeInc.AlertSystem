$(function () {

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.statuses.status;
    var createModal = new abp.ModalManager(abp.appPath + 'Status/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Status/EditModal');

    var dataTable = $('#StatusTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('AlertSystem.Status.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id});
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('AlertSystem.Status.Delete'),
                                confirmMessage: function (data) {
                                    return l('StatusDeletionConfirmationMessage', data.record.name);
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
                title: l('StatusName'),
                data: "name"
            },
            {
                title: l('StatusDescription'),
                data: "description"
            },
            {
                title: l('StatusActive'),
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

    $('#NewStatusButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
