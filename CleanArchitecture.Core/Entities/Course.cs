

using System;
using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.Core.Entities
{
    public class Course : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
