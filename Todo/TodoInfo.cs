using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class TodoInfo
    {
        public string Task { get; set; }
        public string Due { get; set; }
        public int Difficulty { get; set; }
        public string Status { get; set; }
        public TodoInfo(string task, string due, int difficulty, string status)
        {
            Task = task;
            Due = due;
            Difficulty = difficulty;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Task} by {Due} / {Difficulty}, {Status}";
        }
    }
}
