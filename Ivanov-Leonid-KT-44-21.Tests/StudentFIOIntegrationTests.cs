using Ivanov_Leonid_KT_44_21.Database;
using Ivanov_Leonid_KT_44_21.Interfaces;
using Ivanov_Leonid_KT_44_21.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivanov_Leonid_KT_44_21.Tests
{
    public class StudentFIOIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentFIOIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByFIOAsync_KT4421_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.StudentFIOFilter
            {
                FirstName = "a",
                LastName = "a",
                MiddleName = "a"
            };
            var studentsResult = await studentService.GetStudentsByFioAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, studentsResult.Length);
        }
    }
}
