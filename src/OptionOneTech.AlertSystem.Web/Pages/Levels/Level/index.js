$(function () {

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.levels.level;
    var createModal = new abp.ModalManager(abp.appPath + 'Levels/Level/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Levels/Level/EditModal');

    var dataTable = $('#LevelTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('AlertSystem.Level.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('AlertSystem.Level.Delete'),
                                confirmMessage: function (data) {
                                    return l('LevelDeletionConfirmationMessage', data.record.name);
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
                title: l('LevelName'),
                data: "name"
            },
            {
                title: l('LevelDescription'),
                data: "description"
            },
            {
                title: l('LevelActive'),
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

    $('#NewLevelButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
