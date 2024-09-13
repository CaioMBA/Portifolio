using AutoMapper;
using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioCore.Interfaces;

namespace PortifolioServices.MainServices
{
    public class HomeService : IHomeService
    {
        private Utils _utils;
        private IMapper _mapper;
        private AppSettingsModel _appSettings;
        public HomeService(Utils utils, IMapper mapper, AppSettingsModel appSettings)
        {
            _utils = utils;
            _mapper = mapper;
            _appSettings = appSettings;
        }


    }
}
