$(async function () {
    var options = { includeInactive: true }
    var statusService = optionOneTech.alertSystem.statuses.status;
    var allStatusesResponse = await fetchAll(statusService.getLookup, options); 
    var allStatuses = allStatusesResponse.items;


    var activeStatuses = allStatuses.filter(status => status.active === true);
    var inactiveStatuses = allStatuses.filter(status => status.active === false);

    console.log("Toate statusurile:", allStatuses);
    console.log("Statusuri active:", activeStatuses);
    console.log("Statusuri inactive:", inactiveStatuses);


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
                    var statuses = "";

                    for (var i = 0; i < activeStatuses.length; i++) {
                        var status = activeStatuses[i];

                        if (row.alert.statusId === status.id) {
                            statuses += `<option value="${status.id}" selected>${status.name}</option>`;
                        } else {
                            statuses += `<option value="${status.id}">${status.name}</option>`;
                        }
                    }

                    for (var i = 0; i < inactiveStatuses.length; i++) {
                        var status = inactiveStatuses[i];

                        if (row.alert.statusId === status.id) {
                            statuses += `<option value="${status.id}" selected disabled>${status.name} (Inactiv)</option>`;
                        } 
                    }

                    return `
                       <select class="status-select form-control" alert-id="${row.alert.id}">
                           ${statuses}
                       </select>
                   `;
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

    function NotifyOnStatusChanges() {
        var selectedValue = $(this).val();
        var alertId = $(this).attr('alert-id');
        service.updateStatus(alertId, selectedValue)
    }
    $(document).on('change', '.status-select', NotifyOnStatusChanges);
});
