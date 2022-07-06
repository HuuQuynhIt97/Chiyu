using AutoMapper;
using Chiyu.DTO;
using Chiyu.DTO.auth;
using Chiyu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiyu.Helpers.AutoMapper
{
    public class EFToDtoMappingProfile : Profile
    {
        public EFToDtoMappingProfile()
        {

            CreateMap<Account, AccountDto>();
           
            CreateMap<Mailing, MailingDto>();
            CreateMap<Account, UserForDetailDto>();

            CreateMap<OC, OCDto>();
            CreateMap<OCUser, OcUserDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group_Terminal, Group_TeminalDto>();
            CreateMap<Terminal, TerminalDto>();
            CreateMap<Door, DoorDto>();
            CreateMap<DoorLog, DoorLogDto>();

        }
    }
}
