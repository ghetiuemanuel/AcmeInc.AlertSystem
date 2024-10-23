$(function () {
    $("#RuleFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    var getFilter = function () {
        var input = {};
        $("#RuleFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value !== '') {
                    input[abp.utils.toCamelCase(data.name.replace(/RuleFilter\./g, ''))] = data.value;
                }
            });
        return input;
    };

    var l = abp.localization.getResource('AlertSystem');

    var service = optionOneTech.alertSystem.rules.rule;
    var createModal = new abp.ModalManager(abp.appPath + 'Rule/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Rule/EditModal');

    var dataTable = $('#RuleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                            visible: abp.auth.isGranted('AlertSystem.Rule.Update'),
                            action: function (data) {
                                editModal.open({ id: data.record.rule.id });
                            }
                        },
                        {
                            text: l('Delete'),
                            visible: abp.auth.isGranted('AlertSystem.Rule.Delete'),
                            confirmMessage: function (data) {
                                return l('RuleDeletionConfirmationMessage', data.record.rule.name);
                            },
                            action: function (data) {
                                service.delete(data.record.rule.name)
                                    .then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    });
                            }
                        }
                    ]
                }
            },
            //{
            //    title: l('RuleFromRegex'),
            //    data: "rule.fromRegex",
            //},
            //{
            //    title: l('RuleTitleRegex'),
            //    data: "rule.titleRegex"
            //},
            //{
            //    title: l('RuleBodyRegex'),
            //    data: "rule.bodyRegex"
            //},
            //{
            //    title: l('RuleAnyCondition'),
            //    data: "rule.anyCondition"
            //},
            {
                title: l('RuleAlertTitle'),
                data: "rule.alertTitle"
            },
            //{
            //    title: l('RuleAlertBody'),
            //    data: "rule.alertBody"
            //},
            //{
            //    title: l('RuleAlertDepartmentId'),
            //    data: null,
            //    render: function (data, type, row, meta) {
            //        if (row.department && row.department.name) {
            //            return row.department.name;
            //        }
            //        return '';
            //    }
            //},
            //{
            //    title: l('RuleAlertStatusId'),
            //    data: null,
            //    render: function (data, type, row, meta) {
            //        if (row.status && row.status.name) {
            //            return row.status.name;
            //        }
            //        return '';
            //    }
            //},
            {
                title: l('RuleAlertLevelId'),
                data: null,
                render: function (data, type, row, meta) {
                    if (row.level && row.level.name) {
                        return row.level.name;
                    }
                    return '';
                }
            },
            {
                title: l('RuleTriggerCount'),
                data: "rule.triggerCount"
            },
            //{
            //    title: l('RuleTriggerWindowDuration'),
            //    data: "rule.triggerWindowDuration"
            //},
            //{
            //    title: l('RuleTriggersRequired'),
            //    data: "rule.triggersRequired"
            //},
            {
                title: l('RuleTriggerTimestamp'),
                data: "rule.triggerTimestamp"
            },
            {
                title: l('RuleActive'),
                data: "rule.active",
                render: function (data) {
                    return data ? l('Yes') : l('No');
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

    $('#NewRuleButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
