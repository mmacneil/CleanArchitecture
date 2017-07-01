
using System.Collections.Generic;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Contracts
{
    public interface ICourseRepository
    {
        Course GetByCode(string code);
        List<Course> GetAll();
    }
}
