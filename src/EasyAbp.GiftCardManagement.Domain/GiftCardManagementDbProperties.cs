namespace EasyAbp.GiftCardManagement
{
    public static class GiftCardManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "GiftCardManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "GiftCardManagement";
    }
}
