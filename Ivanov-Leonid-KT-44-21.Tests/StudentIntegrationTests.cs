using Ivanov_Leonid_KT_44_21.Database;
using Ivanov_Leonid_KT_44_21.Interfaces;
using Ivanov_Leonid_KT_44_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivanov_Leonid_KT_44_21.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4421_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var groups = new List<Group>
            {
                new Group
                {
                    GroupName = "KT-44-21"
                },
                new Group
                {
                    GroupName = "KT-42-21"
                },
                new Group
                {
                    GroupName = "KT-43-21"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(groups);

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "a",
                    LastName = "a",
                    MiddleName = "a",
                    GroupId = 1,
                },
                new Student
                {
                    FirstName = "a",
                    LastName = "a",
                    MiddleName = "b",
                    GroupId = 2,
                },
                new Student
                {
                    FirstName = "a",
                    LastName = "a",
                    MiddleName = "b",
                    GroupId = 3,
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentGroupFilter
            {
                GroupName = "KT-44-21"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);
        }
    }
}
