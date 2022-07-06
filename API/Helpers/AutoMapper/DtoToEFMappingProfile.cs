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
    public class DtoToEFMappingProfile : Profile
    {
        public DtoToEFMappingProfile()
        {
            CreateMap<AccountDto, Account>();
           
            CreateMap<MailingDto, Mailing>();
            
            CreateMap<UserForDetailDto, Account>();

            CreateMap<OCDto, OC>();
            CreateMap<OcUserDto, OCUser>();
            CreateMap<GroupDto, Group>();
            CreateMap<Group_TeminalDto, Group_Terminal>();
            CreateMap<TerminalDto, Terminal>();
            CreateMap<DoorDto, Door>();
            CreateMap<DoorLogDto, DoorLog>();

        }
    }
}
