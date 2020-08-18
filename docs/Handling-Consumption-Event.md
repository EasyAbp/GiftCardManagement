# Handling Consumption Event
When a gift card is consumed, it will publish a distributed event with `GiftCardConsumedEto`, so other modules can provide services to the consumer by handling this event.

## How to Handle?
We have a sample to show you how to handle the event. See: [GiftCardConsumedEventHandler](https://github.com/EasyAbp/GiftCardManagement/blob/master/sample/MyProject/aspnet-core/src/MyProject.Domain/UserGifts/GiftCardConsumedEventHandler.cs).

## Advanced Usage
Sometimes your case is complicated.

### Consumption with ExtraProperties
For example: You want to create a new tenant by consuming a gift card, you need to input `TenantName`.
1. When you are consuming, input the `ExtraProperties` with `TenantName` in the ConsumeGiftCardDto.
2. The GiftCardConsumedEto will carry the information as `GiftCardExtraProperties`.

### Allow Anonymous Consuming
1. Set property `AnonymousConsumptionAllowed` of the entity GiftCardTemplate to `true`.
2. Do not use the default consumption page (since it requires the permission and do not support customizing the ExtraProperties).

### Customization
You can almost override everything. See the ABP document: [Customizing the Existing Modules](https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Guide).
