using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using to_do.Data;

namespace to_do.Layers._4.Infrastructure;
public class ScheduleRepository
{
    private readonly AppDbContext _appDbContext;

    public ScheduleRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<ScheduleData>> GetSchedulesAsync()
    {
        return await _appDbContext.Schedules.Select(x => new ScheduleData
        {
            Key = x.Key,
            Start = x.Start,
            End = x.End,
            Data = x.Data,
            Text = x.Text,
        }).ToListAsync();
    }

    public async Task AddScheduleAsync(ScheduleData data)
    {
        await _appDbContext.Schedules.AddAsync(new ScheduleEntity { 
            Key = data.Key,
            Start = data.Start, 
            End = data.End,
            Data = data.Data,
            Text = data.Text,
        });

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateScheduleAsync(ScheduleData data)
    {
        var entity = await _appDbContext.Schedules.Where(x => x.Key == data.Key).FirstOrDefaultAsync();
        if (entity != null)
        {
            entity.Start = data.Start;
            entity.End = data.End;
            entity.Text = data.Text;
            entity.Data = data.Data;

            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteScheduleAsync(ScheduleData data)
    {
        var entity = await _appDbContext.Schedules.Where(x => x.Key == data.Key).FirstOrDefaultAsync();
        if (entity != null)
        {
            _appDbContext.Schedules.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}
