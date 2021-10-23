using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static API.DTO.StatusDTO;

namespace API.Controllers
{
    public class CommonController : BaseApiController
    {

        private readonly IGenericRepository _genericRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CommonController(IGenericRepository genericRepository,
        IMapper mapper,
        IEmailSender emailSender,
        IPhotoService photoService)
        {
            _emailSender = emailSender;
            _mapper = mapper;

            _photoService = photoService;
            _genericRepository = genericRepository;
        }

     // Getting the LATEST update of the upcoming events in the temple
        [HttpGet("latest-update")]
        public async Task<List<LatestEvents>> GetLatestUpdateAsync()
        {
            string sheetName = CommonItem.LatestUpdateSheet;
            var service = _genericRepository.GoogleServiceIntialise();
            var data = await _genericRepository.GetListAsync<LatestEvents>(sheetName, service);
            data = data.OrderByDescending(l => l.EventDate).ToList();
            return data;
        }
        //Clarifications of the users.
        [HttpPost("clarification")]
        public async Task<ActionResult> CreateLatestNewsAsync(UserClarificationDTO userClarificationDTO)
        {
            string sheetName = CommonItem.UserClarificationSheet;
            var service = _genericRepository.GoogleServiceIntialise();
            var clarification = _mapper.Map<UserClarificationDTO, UserClarification>(userClarificationDTO);
            clarification.Id = CommonItem.GenerateUniqueId();
            // creating the record in the Googlesheets
            var status = await _genericRepository.CreateDataAsync<UserClarification>(sheetName, clarification, service);
            if (status) return Ok(new StatusDTO(Status.Success, StatusDTO.GetDescription((MessageData)(short)MessageData.RequestSubmitted)));
            return Ok(new StatusDTO(Status.Failure, StatusDTO.GetDescription((MessageData)(short)MessageData.NotProcessed)));
        }

        // Getting the List of Questions or suggestions posted by the user
        [HttpGet("clarification")]  
        public async Task<List<UserClarificationDTO>> GetUserClarificationsAsync()
        {
            string sheetName = CommonItem.UserClarificationSheet;
            var service = _genericRepository.GoogleServiceIntialise();
            var data = await _genericRepository.GetListAsync<UserClarification>(sheetName, service);
            data = data.OrderByDescending(l => l.CreatedDate).ToList();
            var clarification = _mapper.Map<List<UserClarification>, List<UserClarificationDTO>>(data);
            return clarification;
        }

        // Getting the seva List of the temple.
        [HttpGet("seva-list")]
        public async Task<List<SevaList>> GetSevaListsAsync()
        {
            string sheetName = CommonItem.SevaUpdateSheet;
            var service = _genericRepository.GoogleServiceIntialise();
            var data = await _genericRepository.GetListAsync<SevaList>(sheetName, service);

            return data;
        }
    }
}