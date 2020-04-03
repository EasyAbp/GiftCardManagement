using Volo.Abp.Reflection;

namespace EasyAbp.GiftCardManagement.Authorization
{
    public class GiftCardManagementPermissions
    {
        public const string GroupName = "GiftCardManagement";

        public class GiftCards
        {
            public const string Default = GroupName + ".GiftCard";
            
            public const string Consume = Default + ".Consume";
            
            public const string Create = Default + ".Create";
            
            public const string Update = Default + ".Update";
            
            public const string Delete = Default + ".Delete";
        }
        
        public class GiftCardTemplates
        {
            public const string Default = GroupName + ".GiftCardTemplate";
            
            public const string Create = Default + ".Create";
            
            public const string Update = Default + ".Update";
            
            public const string Delete = Default + ".Delete";
        }
        
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(GiftCardManagementPermissions));
        }
    }
}