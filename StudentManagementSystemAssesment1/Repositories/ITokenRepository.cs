using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystemAssesment1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser identityUser, List<string> roles);
    }
}
