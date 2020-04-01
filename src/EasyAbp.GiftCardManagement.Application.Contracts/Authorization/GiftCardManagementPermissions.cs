using Volo.Abp.Reflection;

namespace EasyAbp.GiftCardManagement.Authorization
{
    public class GiftCardManagementPermissions
    {
        public const string GroupName = "GiftCardManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(GiftCardManagementPermissions));
        }
    }
}