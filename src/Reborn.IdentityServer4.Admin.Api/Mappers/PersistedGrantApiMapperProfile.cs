﻿using AutoMapper;
using Reborn.IdentityServer4.Admin.Api.Dtos.PersistedGrants;
using Reborn.IdentityServer4.Admin.BusinessLogic.Dtos.Grant;

namespace Reborn.IdentityServer4.Admin.Api.Mappers;

public class PersistedGrantApiMapperProfile : Profile
{
    public PersistedGrantApiMapperProfile()
    {
        CreateMap<PersistedGrantDto, PersistedGrantApiDto>(MemberList.Destination);
        CreateMap<PersistedGrantDto, PersistedGrantSubjectApiDto>(MemberList.Destination);
        CreateMap<PersistedGrantsDto, PersistedGrantsApiDto>(MemberList.Destination);
        CreateMap<PersistedGrantsDto, PersistedGrantSubjectsApiDto>(MemberList.Destination);
    }
}