namespace EasyAbp.GiftCardManagement
{
    public static class GiftCardManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpGiftCardManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpGiftCardManagement";
    }
}
