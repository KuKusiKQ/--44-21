﻿using Ivanov_Leonid_KT_44_21.Database;
using Ivanov_Leonid_KT_44_21.Filters;
using Ivanov_Leonid_KT_44_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivanov_Leonid_KT_44_21.Interfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFioAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }

        public Task<Student[]> GetStudentsByFioAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => (w.FirstName == filter.FIO) || (w.MiddleName == filter.FIO) || (w.LastName == filter.FIO)).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}