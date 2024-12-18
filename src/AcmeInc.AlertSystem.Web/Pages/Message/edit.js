﻿var abp = abp || {};

abp.modals.messageEdit = function () {
    var initModal = function (publicApi, args) {
        var webhookMessageSourceService = acmeInc.alertSystem.messageSources.webhookMessageSource;
        var emailMessageSourceService = acmeInc.alertSystem.messageSources.emailMessageSource;

        publicApi.onOpen(async function () {
            var form = publicApi.getForm();
            var $sourceType = form.find('[name="ViewModel.SourceType"]');
            var $sourceId = form.find('[name="ViewModel.SourceId"]');
            $sourceType.on('change', async function () {
                $sourceId.empty();
                var selectedType = $sourceType.val();
                var newOptions = await getSourceIdOptions(selectedType);

                $.each(newOptions, function (index, option) {
                    $sourceId.append($('<option></option>').val(option.value).text(option.text));
                });
            });

            async function getSourceIdOptions(sourceType) {
                if (sourceType === '2') { //webhook
                    var result = await fetchAll(webhookMessageSourceService.getLookup);
                    return result.items.map(item => ({
                        value: item.id,
                        text: item.name
                    }));                  
                } else if (sourceType === '1') {//email
                    var result = await fetchAll(emailMessageSourceService.getLookup);
                    return result.items.map(item => ({
                        value: item.id,
                        text: item.name
                    }));
                }
                return [];
            }
        });
    }

    return {
        initModal: initModal
    };
}
