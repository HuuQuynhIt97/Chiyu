using AutoMapper;
using AutoMapper.QueryableExtensions;
using ESS_API.Helpers;
using Microsoft.EntityFrameworkCore;
using Chiyu.Constants;
using Chiyu.Data;
using Chiyu.DTO;
using Chiyu.Helpers;
using Chiyu.Models;
using Chiyu.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chiyu.Services
{
    public interface IOCService: IServiceBase<OC, OCDto>
    {
        // Task<List<OCDto>> GetAllByObjectiveId(int objectiveId);
        // Task<OCDto> GetFisrtByObjectiveId(int objectiveId, int createdBy);
        Task<IEnumerable<HierarchyNode<OCDto>>> GetAllAsTreeView();
        Task<List<AccountDto>> GetUserByOCname(string name);
        Task<List<OcUserDto>> GetUserByOcID(int ocID);
        Task<List<ResultDto>> GetResultByGroup(int groupID , DateTime min , DateTime max);
        Task<object> MappingUserOC(OcUserDto OcUserDto);
        Task<object> GetAllTerminal310409();
        Task<object> GetAllGroup104574();
        Task<object> MappingRangeUserOC(Group_TeminalDto model);
        Task<object> RemoveUserOC(OcUserDto OcUserDto);
    }
    public class OCService : ServiceBase<OC, OCDto>, IOCService
    {
        private OperationResult operationResult;

        private readonly IRepositoryBase<OC> _repo;
        private readonly IRepositoryBase<OCUser> _repoOcUser;
        private readonly IRepositoryBase<Account> _repoAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        private readonly DataContext _context; // 10.4.0.9 chiyu3
        private readonly DataContext2 _context2; // 10.4.5.174 chiyu3
        private readonly DataContext3 _context3; // 10.4.0.9 chiyu
        public OCService(
            IRepositoryBase<OC> repo, 
            IRepositoryBase<OCUser> repoOcUser,
            IRepositoryBase<Account> repoAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DataContext context,
            DataContext2 context2,
            DataContext3 context3,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper,  configMapper)
        {
            _repo = repo;
            _repoOcUser = repoOcUser;
            _repoAccount = repoAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
            _context = context;
            _context2 = context2;
            _context3 = context3;
        }
        
        public async Task<List<ResultDto>> GetResultByGroup(int groupID , DateTime min , DateTime max)
        {
            var month = min.Month;
            var result = new List<ResultDto>();
            int[] array = new int[] { 2,6,7 };
            bool status = Array.Exists(array, element => element == groupID);
            if(status)
            {
                var group_teminal = await _context2.Group_Terminals
                    .Where(x => x.Group_ID == groupID)
                    .Select(x => x.Terminal_ID).ToListAsync();
                foreach (var item in group_teminal)
                {
                    var door_log = await _context3.DoorLog.Where(
                        x => x.TerminalID == item 
                        && x.LogArrivalDateTime.Date >= min.Date 
                        && x.LogArrivalDateTime.Date <= max.Date).Select(x => new ResultDto {

                        GuestID = x.EmployeeID,
                        CardNo = x.CardNo,
                        GuestName = _context3.Person.FirstOrDefault(y => y.EmployeeID == x.EmployeeID).Name,
                        Department = _context3.Person.FirstOrDefault(y => y.EmployeeID == x.EmployeeID).Department,
                        Date = x.LogArrivalDateTime.Date.ToString("yyyy-MM-dd"),
                        Time = x.LogArrivalDateTime.ToString("HH:mm:ss"),
                        EntryDoor = _context3.Terminal.FirstOrDefault(y => y.TerminalID == x.TerminalID).Name + ':' + x.TerminalID,
                        EventDescription = x.EventAlarmCode,
                        VerificationSource = x.VerificationSource


                    }).ToListAsync();
                    foreach (var items in door_log)
                    {
                        if (items.Department == "")
                        {
                            items.Department = null;
                        }
                        if (items.GuestID == "")
                        {
                            items.GuestID = null;
                        }
                        if (items.GuestName == "")
                        {
                            items.GuestName = null;
                        }
                        result.Add(items);
                    }
                }
            } 
            else
            {
                var group_teminal = await _context2.Group_Terminals
                    .Where(x => x.Group_ID == groupID)
                    .Select(x => x.Terminal_ID).ToListAsync();
                foreach (var item in group_teminal)
                {
                    var door_log = await _context.DoorLog.Where(
                        x => x.TerminalID == item 
                        && x.LogArrivalDateTime.Date >= min.Date 
                        && x.LogArrivalDateTime.Date <= max.Date).Select(x => new ResultDto {
                        
                        GuestID = x.EmployeeID,
                        CardNo = x.CardNo,
                        GuestName = _context.Person.FirstOrDefault(y => y.EmployeeID == x.EmployeeID).Name,
                        Department = _context.Person.FirstOrDefault(y => y.EmployeeID == x.EmployeeID).Department,
                        Date = x.LogArrivalDateTime.Date.ToString("yyyy-MM-dd"),
                        Time = x.LogArrivalDateTime.ToString("HH:mm:ss"),
                        EntryDoor = _context.Terminal.FirstOrDefault(y => y.TerminalID == x.TerminalID).Name + ':' + x.TerminalID,
                        EventDescription = x.EventAlarmCode,
                        VerificationSource = x.VerificationSource

                    }).ToListAsync();
                    foreach (var items in door_log)
                    {
                        if (items.Department == "")
                        {
                            items.Department = null;
                        }
                        if (items.GuestID == "")
                        {
                            items.GuestID = null;
                        }
                        if (items.GuestName == "")
                        {
                            items.GuestName = null;
                        }
                        result.Add(items);
                    }
                }
            }

            result.RemoveAll(item => item.VerificationSource == "Card"  && Convert.ToDateTime(item.Date).Month < 10);
           
            return result.Where(x => x.GuestID != null && x.GuestName != null && x.Department != null ).OrderBy(x => x.Date).ThenByDescending(x => x.Time).ToList();
        }

        public async Task<object> GetAllTerminal310409()
        {
            return await _context.Terminal.ProjectTo<TerminalDto>(_configMapper).ToListAsync();
        }

        public async Task<object> GetAllGroup104574()
        {
            return await _context2.Groups.ProjectTo<GroupDto>(_configMapper).ToListAsync();
        }
        public async Task<IEnumerable<HierarchyNode<OCDto>>> GetAllAsTreeView()
        {
            var lists = (await _repo.FindAll().ProjectTo<OCDto>(_configMapper).OrderBy(x => x.Name).ToListAsync()).AsHierarchy(x => x.Id, y => y.ParentId);
            return lists;
        }

        public async Task<List<AccountDto>> GetUserByOCname(string name)
        {
            return await _repoAccount.FindAll().Where(x=> x.RoleOC.Contains(name.ToUpper())).ProjectTo<AccountDto>(_configMapper).ToListAsync();
        }

        public async Task<object> MappingUserOC(OcUserDto OcUserDto)
        {
            var item = await _repoOcUser.FindAll().FirstOrDefaultAsync(x => x.UserID == OcUserDto.UserID && x.OCID == OcUserDto.OCID);
            if (item == null)
            {
                _repoOcUser.Add(new OCUser { 
                    UserID = OcUserDto.UserID,
                    OCID = OcUserDto.OCID
                });
                try
                {
                    await _repoOcUser.SaveAll();
                    return new
                    {
                        status = true,
                        message = "Mapping Successfully!"
                    };
                }
                catch (Exception)
                {
                    return new
                    {
                        status = false,
                        message = "Failed on save!"
                    };
                }
            } 
            else
            {

                return new
                {
                    status = false,
                    message = "The User belonged with other building!"
                };
            }
            
        }

        public async Task<object> RemoveUserOC(OcUserDto OcUserDto)
        {
            var item = await _repoOcUser.FindAll().FirstOrDefaultAsync(x => x.UserID == OcUserDto.UserID && x.OCID == OcUserDto.OCID);
            if (item != null)
            {
                _repoOcUser.Remove(item);
                try
                {
                    await _repoOcUser.SaveAll();
                    return new
                    {
                        status = true,
                        message = "Delete Successfully!"
                    };
                }
                catch (Exception)
                {
                    return new
                    {
                        status = false,
                        message = "Failed on delete!"
                    };
                }
            }
            else
            {

                return new
                {
                    status = false,
                    message = "Failed on delete"
                };
            }
            
        }

        public async Task<object> MappingRangeUserOC(Group_TeminalDto model)
        {
            try
            {
                foreach (var item in model.TerminalID_List)
                {
                    var items = await _context2.Group_Terminals.FirstOrDefaultAsync(x => x.Terminal_ID == item && x.Group_ID == model.Group_ID);
                    if (items == null)
                    {
                        _context2.Group_Terminals.Add(new Group_Terminal { 
                            Terminal_ID = item,
                            Group_ID = model.Group_ID
                        });
                        await _context2.SaveChangesAsync();
                    } 
                    else
                    {
                        return new
                        {
                            status = false,
                            message = $"Errors"
                        };
                    }
                    
                }
                return new
                {
                    status = true,
                    message = "Mapping Successfully!"
                };
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<List<OcUserDto>> GetUserByOcID(int ocID)
        {
            return await _repoOcUser.FindAll().Where(x=>x.OCID == ocID).ProjectTo<OcUserDto>(_configMapper).ToListAsync();
        }

       

        
    }
}
