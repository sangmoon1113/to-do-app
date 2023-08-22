using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using to_do.Data;
using to_do.Layers._4.Infrastructure;

namespace to_do.Layers._2.Application;
public class ScheduleApplicationService
{
    private readonly ScheduleRepository _scheduleRepository;

    public ScheduleApplicationService(ScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public async Task<List<ScheduleData>> GetAllSchedulesAsync()
    {
        return await _scheduleRepository.GetSchedulesAsync();
    }

    public async Task AddSchedulesAsync(params ScheduleData[] datas)
    {
        foreach (var data in datas)
        {
            if (string.IsNullOrWhiteSpace(data.Key))
            {
                data.Key = Guid.NewGuid().ToString();
            }

            await _scheduleRepository.AddScheduleAsync(data);
        }
    }

    public async Task UpdateSchedulesAsync(params ScheduleData[] datas)
    {
        foreach (var data in datas)
        {
            await _scheduleRepository.UpdateScheduleAsync(data);
        }
    }

    public async Task DeleteSchedulesAsync(params ScheduleData[] datas)
    {
        foreach (var data in datas)
        {
            await _scheduleRepository.DeleteScheduleAsync(data);
        }
    }
}
