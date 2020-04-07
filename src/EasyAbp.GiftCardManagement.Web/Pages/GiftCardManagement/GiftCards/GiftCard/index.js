$(function () {

    var l = abp.localization.getResource('GiftCardManagement');

    var service = easyAbp.giftCardManagement.giftCards.giftCard;
    var createModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCards/GiftCard/CreateModal');
    var createBatchModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCards/GiftCard/CreateBatchModal');
    var editModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCards/GiftCard/EditModal');

    var dataTable = $('#GiftCardTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function() {
            return { giftCardTemplateId: templateId };
        }),
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
                                    return l('GiftCardDeletionConfirmationMessage', data.record.id);
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
            { data: "code" },
            { data: "expiration" },
            { data: "consumptionTime" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    createBatchModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGiftCardButton').click(function (e) {
        e.preventDefault();
        createModal.open({ giftCardTemplateId: templateId });
    });

    $('#NewGiftCardButtonInBatch').click(function (e) {
        e.preventDefault();
        createBatchModal.open({ giftCardTemplateId: templateId });
    });
});