using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do.Layers._4.Infrastructure;

[Table("appointment")]
public class ScheduleEntity
{
    [Key]
    [Column("key")]
    public string? Key
    {
        get; set;
    }

    [Column("start")]
    public DateTime? Start
    {
        get; set;
    }

    [Column("end")]
    public DateTime? End
    {
        get; set;
    }

    [Column("text")]
    public string? Text
    {
        get; set;
    }

    [Column("data")]
    public string? Data
    {
        get; set;
    }
}
