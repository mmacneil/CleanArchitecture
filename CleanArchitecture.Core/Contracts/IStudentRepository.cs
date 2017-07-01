 

using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Contracts
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        void Save(Student student);
    }
}
