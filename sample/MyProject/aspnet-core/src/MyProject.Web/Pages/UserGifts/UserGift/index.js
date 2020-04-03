$(function () {

    var l = abp.localization.getResource('MyProject');

    var service = myProject.userGifts.userGift;
    var createModal = new abp.ModalManager(abp.appPath + 'UserGifts/UserGift/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'UserGifts/UserGift/EditModal');

    var dataTable = $('#UserGiftTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                    return l('UserGiftDeletionConfirmationMessage', data.record.id);
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
            { data: "userId" },
            { data: "giftId" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewUserGiftButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});