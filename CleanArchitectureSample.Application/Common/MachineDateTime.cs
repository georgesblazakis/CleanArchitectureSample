using System;
using CleanArchitectureSample.Application.Common.Interfaces;

namespace CleanArchitectureSample.Application.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public int CurrentYear => DateTime.Now.Year;
    }
}
