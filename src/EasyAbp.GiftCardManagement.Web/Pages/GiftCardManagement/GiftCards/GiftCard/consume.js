$(function () {

    var l = abp.localization.getResource('EasyAbpGiftCardManagement');

    var service = easyAbp.giftCardManagement.giftCards.giftCard;

    $("form").submit(function (e) {
        e.preventDefault();

        if (!$(e.currentTarget).valid()) {
            return;
        }

        var input = $(e.currentTarget).serializeFormToObject();
        abp.log.info(input);
        service.consume(input.consumeGiftCard)
            .then(function (result) {
                abp.message.success(l("SuccessfullyConsumed"));
            });
    });
});