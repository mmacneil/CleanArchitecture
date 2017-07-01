
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Contracts
{
    public interface ICourseRepository
    {
        Course GetByCode(string code);
    }
}
