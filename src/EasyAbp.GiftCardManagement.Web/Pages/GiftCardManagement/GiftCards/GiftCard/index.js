$(function () {

    var l = abp.localization.getResource('GiftCardManagement');

    var service = easyAbp.giftCardManagement.giftCards.giftCard;
    var createModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCards/GiftCard/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'GiftCardManagement/GiftCards/GiftCard/EditModal');

    var dataTable = $('#GiftCardTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                            // Todo: should be removed.
                            {
                                text: l('Consume'),
                                action: function (data) {
                                    service.consume({
                                        code: data.record.code,
                                        password: '123456'
                                    }).then(function () {
                                        abp.notify.info(l('SuccessfullyDeleted'));
                                        dataTable.ajax.reload();
                                    });
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
            { data: "giftCardTemplateId" },
            { data: "code" },
            { data: "passwordHash" },
            { data: "expiration" },
            { data: "consumptionUserId" },
            { data: "consumptionTime" },
            { data: "extraProperties" }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGiftCardButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});