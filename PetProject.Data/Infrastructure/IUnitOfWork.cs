using System;


namespace PetProject.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
