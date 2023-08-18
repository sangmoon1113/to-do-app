using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do.Data;
public class Appointment
{
    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public string Text { get; set; }

    public object Data { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Appointment data &&
               Start == data.Start &&
               End == data.End &&
               Text == data.Text &&
               EqualityComparer<object>.Default.Equals(Data, data.Data);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End, Text, Data);
    }
}
