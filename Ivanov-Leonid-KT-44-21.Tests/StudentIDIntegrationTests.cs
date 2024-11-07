using Ivanov_Leonid_KT_44_21.Database;
using Ivanov_Leonid_KT_44_21.Interfaces;
using Ivanov_Leonid_KT_44_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivanov_Leonid_KT_44_21.Tests
{
    public class StudentIDIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIDIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByIDAsync_KT4421_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentGroupIdFilter
            {
                GroupId = 3
            };
            var studentsResult = await studentService.GetStudentsByGroupIdAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(3, studentsResult.Length);
        }
    }
}
