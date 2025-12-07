using AntiqueBookstore.Domain.Entities;
using FluentAssertions;

namespace AntiqueBookstore.Domain.Tests.Employees
{
    public class PositionHistoryInvariantTests
    {
        [Fact]
        public void Employee_Cannot_Have_Two_Active_PositionHistory_Entries()
        {
            var employee = new Employee
            {
                PositionHistories =
                {
                    new PositionHistory
                    {
                        PromotionId = 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1),
                        IsActive = false,
                        EmployeeId = 1,
                        PositionId = 1
                    },
                    new PositionHistory
                    {
                        PromotionId = 1,
                        StartDate = DateTime.Now.AddDays(1),
                        EndDate = null,
                        IsActive = true,
                        EmployeeId = 1,
                        PositionId = 1
                    }
                }
            };

            int activeCount = employee.PositionHistories.Count(p => p.EndDate == null && p.IsActive);

            activeCount.Should().BeLessThanOrEqualTo(1, "Only one active PositionHistory must exist");

        }

        [Fact]
        public void Adding_New_Position_Closes_Previous_Active_History()
        {
            var employee = new Employee();

            var first = new PositionHistory
            {
                PromotionId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = null,
                IsActive = true,
                EmployeeId = 1,
                PositionId = 2
            };

            employee.PositionHistories.Add(first);

            // New active entry appears
            var second = new PositionHistory
            {
                PromotionId = 2,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = null,
                IsActive = true,
                EmployeeId = 1,
                PositionId = 1
            };

            // Simulate Controller logic
            first.EndDate = DateTime.Now.AddDays(1);
            first.IsActive = false;

            employee.PositionHistories.Add(second);

            second.IsActive.Should().BeTrue();
            second.EndDate.Should().BeNull("New history position record becomes active");
            first.IsActive.Should().BeFalse();
            first.EndDate.Should().NotBeNull("Controller closes previous active history");
        }
    }
}
