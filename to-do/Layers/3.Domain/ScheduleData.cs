using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do.Data;
public class ScheduleData
{
    public string? Key { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? Finish { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public override bool Equals(object obj)
    {
        return obj is ScheduleData data &&
               Key == data.Key &&
               EqualityComparer<string?>.Default.Equals(Key, data.Key);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Key);
    }
}
