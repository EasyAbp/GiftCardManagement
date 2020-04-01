$(function () {

    var l = abp.localization.getResource('GiftCardManagement');

    var service = easyAbp.giftCardManagement.giftCardTemplates.giftCardTemplate;
    var createModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCardTemplates/GiftCardTemplate/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCardTemplates/GiftCardTemplate/EditModal');

    var dataTable = $('#GiftCardTemplateTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('GiftCardTemplateDeletionConfirmationMessage', data.record.id);
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
            { data: "name" },
            { data: "displayName" },
            { data: "description" },
            { data: "tenantAllowed" },
            { data: "duration" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGiftCardTemplateButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});