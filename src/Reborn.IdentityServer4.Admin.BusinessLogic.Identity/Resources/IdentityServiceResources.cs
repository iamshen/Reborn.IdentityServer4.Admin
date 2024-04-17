using Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Helpers;

namespace Reborn.IdentityServer4.Admin.BusinessLogic.Identity.Resources;

public class IdentityServiceResources : IIdentityServiceResources
{
    public virtual ResourceMessage UserUpdateFailed() => new()
    {
        Code = nameof(UserUpdateFailed),
        Description = IdentityServiceResource.UserUpdateFailed
    };

    public virtual ResourceMessage UserRoleDeleteFailed() => new()
    {
        Code = nameof(UserRoleDeleteFailed),
        Description = IdentityServiceResource.UserRoleDeleteFailed
    };

    public virtual ResourceMessage UserRoleCreateFailed() => new()
    {
        Code = nameof(UserRoleCreateFailed),
        Description = IdentityServiceResource.UserRoleCreateFailed
    };

    public virtual ResourceMessage UserProviderDoesNotExist() => new()
    {
        Code = nameof(UserProviderDoesNotExist),
        Description = IdentityServiceResource.UserProviderDoesNotExist
    };

    public virtual ResourceMessage UserProviderDeleteFailed() => new()
    {
        Code = nameof(UserProviderDeleteFailed),
        Description = IdentityServiceResource.UserProviderDeleteFailed
    };

    public virtual ResourceMessage UserChangePasswordFailed() => new()
    {
        Code = nameof(UserChangePasswordFailed),
        Description = IdentityServiceResource.UserChangePasswordFailed
    };

    public virtual ResourceMessage UserDoesNotExist() => new()
    {
        Code = nameof(UserDoesNotExist),
        Description = IdentityServiceResource.UserDoesNotExist
    };

    public virtual ResourceMessage UserDeleteFailed() => new()
    {
        Code = nameof(UserDeleteFailed),
        Description = IdentityServiceResource.UserDeleteFailed
    };

    public virtual ResourceMessage UserCreateFailed() => new()
    {
        Code = nameof(UserCreateFailed),
        Description = IdentityServiceResource.UserCreateFailed
    };

    public virtual ResourceMessage UserClaimsDeleteFailed() => new()
    {
        Code = nameof(UserClaimsDeleteFailed),
        Description = IdentityServiceResource.UserClaimsDeleteFailed
    };

    public virtual ResourceMessage UserClaimsCreateFailed() => new()
    {
        Code = nameof(UserClaimsCreateFailed),
        Description = IdentityServiceResource.UserClaimsCreateFailed
    };

    public virtual ResourceMessage UserClaimsUpdateFailed() => new()
    {
        Code = nameof(UserClaimsCreateFailed),
        Description = IdentityServiceResource.UserClaimsUpdateFailed
    };

    public virtual ResourceMessage UserClaimDoesNotExist() => new()
    {
        Code = nameof(UserClaimDoesNotExist),
        Description = IdentityServiceResource.UserClaimDoesNotExist
    };

    public virtual ResourceMessage RoleUpdateFailed() => new()
    {
        Code = nameof(RoleUpdateFailed),
        Description = IdentityServiceResource.RoleUpdateFailed
    };

    public virtual ResourceMessage RoleDoesNotExist() => new()
    {
        Code = nameof(RoleDoesNotExist),
        Description = IdentityServiceResource.RoleDoesNotExist
    };

    public virtual ResourceMessage RoleDeleteFailed() => new()
    {
        Code = nameof(RoleDeleteFailed),
        Description = IdentityServiceResource.RoleDeleteFailed
    };

    public virtual ResourceMessage RoleCreateFailed() => new()
    {
        Code = nameof(RoleCreateFailed),
        Description = IdentityServiceResource.RoleCreateFailed
    };

    public virtual ResourceMessage RoleClaimsDeleteFailed() => new()
    {
        Code = nameof(RoleClaimsDeleteFailed),
        Description = IdentityServiceResource.RoleClaimsDeleteFailed
    };

    public virtual ResourceMessage RoleClaimsCreateFailed() => new()
    {
        Code = nameof(RoleClaimsCreateFailed),
        Description = IdentityServiceResource.RoleClaimsCreateFailed
    };

    public virtual ResourceMessage RoleClaimsUpdateFailed() => new()
    {
        Code = nameof(RoleClaimsCreateFailed),
        Description = IdentityServiceResource.RoleClaimsUpdateFailed
    };

    public virtual ResourceMessage RoleClaimDoesNotExist() => new()
    {
        Code = nameof(RoleClaimDoesNotExist),
        Description = IdentityServiceResource.RoleClaimDoesNotExist
    };

    public virtual ResourceMessage IdentityErrorKey() => new()
    {
        Code = nameof(IdentityErrorKey),
        Description = IdentityServiceResource.IdentityErrorKey
    };
}