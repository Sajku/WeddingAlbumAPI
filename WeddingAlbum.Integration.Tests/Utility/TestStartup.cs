using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeddingAlbum.Api;
using WeddingAlbum.Common.Auth;

namespace WeddingAlbum.Integration.Tests.Utility
{
    //public class TestStartup : Startup
    //{
    //    //public TestStartup(IConfiguration configuration) : base(configuration)
    //    //{
    //    //}

    //    //public override void ConfigureAuth(IServiceCollection services)
    //    //{
    //    //    services.AddAuthentication(options =>
    //    //    {
    //    //        options.DefaultAuthenticateScheme = "Test Scheme";
    //    //        options.DefaultChallengeScheme = "Test Scheme";
    //    //    }).AddTestAuth(o => { });

    //    //    services.AddAuthorization(options =>
    //    //    {
    //    //        options.AddPolicy(Policies.ApiReader, policy => policy.RequireClaim("scope", Scopes.WeddingAlbumApi));
    //    //        options.AddPolicy(Policies.Consumer, policy => policy.RequireClaim(ClaimTypes.Role, Roles.Consumer));
    //    //    });
    //    //}
    //}
}
