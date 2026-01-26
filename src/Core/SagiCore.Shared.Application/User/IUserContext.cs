namespace SagiCore.Shared.Application.User
{
    public interface IUserContext
    {
        bool IsAuthenticated();
        int GetIdEmpresa();
        string GetUserEmail();
    }
}
