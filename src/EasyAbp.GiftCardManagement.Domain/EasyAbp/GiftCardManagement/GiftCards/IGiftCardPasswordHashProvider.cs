namespace EasyAbp.GiftCardManagement.GiftCards
{
    public interface IGiftCardPasswordHashProvider
    {
        string GetPasswordHash(string password);
    }
}