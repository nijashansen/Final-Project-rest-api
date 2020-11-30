using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Entity
{
    public class Process
    {
        public int Id { get; set; }

        public String ProcessName { get; set; }

        public List<Error> Errors { get; set; }
    }
}
