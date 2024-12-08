using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Data.Interfaces;
using TaskManagementProject.Data.Models;
using TaskManagementProject.Domain.Dto;
using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Domain.Interfaces;
using TaskManagementProject.Infrastructure.AutoMapper;
using TaskManagementProject.Service.Interfaces;
using TaskManagementProject.Service.Services.Base;

namespace TaskManagementProject.Service.Services
{
    public class TaskService : ServiceBase, ITaskService<t_TaskDto, t_Task>
    {
        public TaskService(IUnitOfWork unitOfWork, ITaskManagementProjectMapper mapper, IHttpContextAccessor httpContext) : base(unitOfWork, mapper, httpContext)
        {
        }

        public async Task<t_TaskDto> AddAsync(t_TaskDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "Task data cannot be null.");
            }

            var taskEntity = new t_Task
            {
                Title = dto.Title,
                CreatedAt = DateTime.UtcNow,
                Description = dto.Description // Description null olabilir, bu durumda sorun olmaz
            };

            await _unitOfWork.TaskRepository.AddAsync(taskEntity);
            await _unitOfWork.CommitChangesAsync();

            var resultDto = _mapper.Map<t_TaskDto>(taskEntity);

            return resultDto;
        }

        public async Task<bool> DeleteByAsync(t_TaskDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var taskEntity = await _unitOfWork.TaskRepository.GetByIdAsync(dto.Id);

            if (taskEntity == null)
            {
                throw new KeyNotFoundException($"Task with ID {dto.Id} was not found.");
            }

            await _unitOfWork.TaskRepository.DeleteByIdAsync(taskEntity.Id);
            var result = await _unitOfWork.CommitChangesAsync();

            return result > 0;
        }

    
        public async Task<ICollection<t_TaskDto>> GetAllAsync(Func<IEntity, bool> filter = null)
        {
            var tasks = await _unitOfWork.TaskRepository.GetAllAsync();

            //if (filter != null)
            //{
            //    tasks = tasks.Where(filter).ToList();
            //}

            var taskDtos = _mapper.Map<ICollection<t_TaskDto>>(tasks);

            return taskDtos;
        }

        public async Task<t_TaskDto> GetByIdAsync(int id)
        {
            var taskEntity = await _unitOfWork.TaskRepository.GetByIdAsync(id);

            if (taskEntity == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} was not found.");
            }

            var taskDto = _mapper.Map<t_TaskDto>(taskEntity);

            return taskDto;
        }

        public async Task<t_TaskDto> UpdateAsync(t_TaskDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var taskEntity = await _unitOfWork.TaskRepository.GetByIdAsync(dto.Id);

            if (taskEntity == null)
            {
                throw new KeyNotFoundException($"Task with ID {dto.Id} was not found.");
            }

            taskEntity.Title = dto.Title;
            taskEntity.Description = dto.Description;

            await _unitOfWork.TaskRepository.UpdateAsync(taskEntity);
            await _unitOfWork.CommitChangesAsync();

            var resultDto = _mapper.Map<t_TaskDto>(taskEntity);

            return resultDto;
        }
    }
}
