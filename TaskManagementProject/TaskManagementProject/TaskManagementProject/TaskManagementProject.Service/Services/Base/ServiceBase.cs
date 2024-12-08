using Microsoft.AspNetCore.Http;
using TaskManagementProject.Data.Interfaces;
using TaskManagementProject.Infrastructure.AutoMapper;

namespace TaskManagementProject.Service.Services.Base
{
    public class ServiceBase
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly ITaskManagementProjectMapper _mapper;
        public readonly IHttpContextAccessor _httpContext;

        public ServiceBase(IUnitOfWork unitOfWork , ITaskManagementProjectMapper mapper, IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContext = httpContext; 
            
        }
    }
}
