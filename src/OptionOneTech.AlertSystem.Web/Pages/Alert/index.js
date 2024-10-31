$(function () {
    var ViewModel = {
        StatusOptions: []
    };
    function loadStatusOptions() {
        $.ajax({
            url: '/api/status', 
            type: 'GET',
            success: function (data) {
                ViewModel.StatusOptions = data.map(status => ({ id: status.id, name: status.name }));
                dataTable.ajax.reload(); 
            },
            error: function () {
                abp.notify.error(l('FailedToLoadStatusOptions'));
            }
        });
    }

    loadStatusOptions();
    $("#AlertFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });
    var getFilter = function () {
        var input = {};
        $("#AlertFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/AlertFilter./g, ''))] = data.value;
                }
            });
        return input;
    };

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.alerts.alert;
    var createModal = new abp.ModalManager(abp.appPath + 'Alert/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Alert/EditModal');

    var dataTable = $('#AlertTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getNavigationList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items: [
                        {
                            text: l('Edit'),
                            visible: abp.auth.isGranted('AlertSystem.Alert.Update'),
                            action: function (data) {
                                editModal.open({ id: data.record.alert.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('AlertSystem.Alert.Delete'),
                            confirmMessage: function (data) {
                                return l('AlertDeletionConfirmationMessage', data.record.alert.title);
                            },
                            action: function (data) {
                                service.delete(data.record.alert.id)
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
                title: l('AlertTitle'),
                data: "alert.title"
            },
            {
                title: l('AlertBody'),
                data: "alert.body"
            },
            {
                title: l('AlertMessageId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.message && row.message.title) {
                        return row.message.title;
                    }
                    return '';
                }
            },
            {
                title: l('AlertRuleId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.rule && row.rule.alertTitle) {
                        return row.rule.alertTitle;
                    }
                    return '';
                }
            },
            {
                title: l('AlertDepartmentId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.department && row.department.name) {
                        return row.department.name;
                    }
                    return '';
                }
            },
            {
                title: l('AlertStatusId'),
                data: null,
                render: function (data, type, row, meta) {
                    let options = ViewModel.StatusOptions.map(option => {
                        return `<option value="${option.id}" ${row.status && row.status.id === option.id ? 'selected' : ''}>${option.name}</option>`;
                    }).join('');
                    return `<select class="form-control status-dropdown" data-alert-id="${row.alert.id}">${options}</select>`;
                }
            },
            {
                title: l('AlertLevelId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.level && row.level.name) {
                        return row.level.name;
                    }
                    return '';
                }
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAlertButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $(document).on('change', '.status-dropdown', function () {
        let alertId = $(this).data('alert-id');
        let newStatusId = $(this).val();

        $.ajax({
            url: `/api/alert/update-status`, 
            type: 'POST',
            data: JSON.stringify({ alertId: alertId, statusId: newStatusId }),
            contentType: 'application/json',
            success: function () {
                abp.notify.success(l('StatusUpdatedSuccessfully'));
                dataTable.ajax.reload();
            },
            error: function () {
                abp.notify.error(l('StatusUpdateFailed'));
            }
        });
    });
});

