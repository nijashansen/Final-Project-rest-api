using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Static.Data
{
    class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Error> Errors = new List<Error>();
    }
}
