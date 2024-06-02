namespace CleanArc_Kevin.Core.Abstractions.UsersManagement;

public class FakeUserInfoService : IUserInfoService
{
    private readonly string _defaultUserId;

    public FakeUserInfoService() : this("1")
    {
    }

    public FakeUserInfoService(string defaultUserId)
    {
        _defaultUserId = defaultUserId;
    }

    public string? GetClaim(string claimType) => claimType;

    public string GetFirstName() => "FirstName";

    public string GetLastName() => "LastName";

    public string GetUserAgent() => "1";

    public string GetUserIp() => "0.0.0.0";

    public string GetUsername() => "Username";

    public bool HasAccess(string access) => true;

    public bool IsCurrentUser(string userId) => true;

    public string UserId() => "1";

    public string UserIdOrDefault() => _defaultUserId;

    public string UserIdOrDefault(string defaultValue) => defaultValue;
}