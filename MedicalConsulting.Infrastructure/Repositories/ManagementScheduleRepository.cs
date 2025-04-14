using System.Text;
using Dapper;
using MedicalConsulting.Application.Interfaces;
using MedicalConsulting.Domain.Entities;
using MedicalConsulting.Domain.Enums;
using MedicalConsulting.Infrastructure.DbContext;

namespace MedicalConsulting.Infrastructure.Repositories
{
    public class ManagementScheduleRepository : IManagementScheduleRepository
    {
        private readonly IUnitOfWork _uow;

        public ManagementScheduleRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Schedule>> GetScheduleAsync(int userId)
        {
            StringBuilder query = new();

            query.Append($" SELECT                                          ");
            query.Append($"    m.Id         AS {nameof(Schedule.Id)},       ");
            query.Append($"    m.UserId     AS {nameof(Schedule.UserId)},   ");
            query.Append($"    m.DoctorId   AS {nameof(Schedule.DoctorId)}, ");
            query.Append($"    m.Date       AS {nameof(Schedule.Date)},     ");
            query.Append($"    m.Hour       AS {nameof(Schedule.Hour)},     ");
            query.Append($"    u.UserName   AS {nameof(Schedule.UserName)}, ");
            query.Append($"    m.Status     AS {nameof(Schedule.Status)}    ");
            query.Append($" FROM [dbo].[ScheduleMedical] m                  ");
            query.Append($" INNER JOIN [dbo].[User] u ON m.UserId = u.Id    ");
            query.Append($" WHERE UserId = @UserId                          ");

            using var conn = _uow.Connection;

            var result = (await conn.QueryAsync<Schedule>(query.ToString(),
                new
                {
                    UserId = userId
                })).ToList();

            return result;
        }

        public async Task<Schedule> GetScheduleByIdAsync(int Id)
        {
            StringBuilder query = new();

            query.Append($" SELECT                                          ");
            query.Append($"    m.Id         AS {nameof(Schedule.Id)},       ");
            query.Append($"    m.UserId     AS {nameof(Schedule.UserId)},   ");
            query.Append($"    m.DoctorId   AS {nameof(Schedule.DoctorId)}, ");
            query.Append($"    m.Date       AS {nameof(Schedule.Date)},     ");
            query.Append($"    m.Hour       AS {nameof(Schedule.Hour)},     ");
            query.Append($"    m.Status     AS {nameof(Schedule.Status)}    ");
            query.Append($" FROM [dbo].[ScheduleMedical] m                  ");
            query.Append($" WHERE Id = @Id                                  ");

            using var conn = _uow.Connection;

            var result = await conn.QueryFirstOrDefaultAsync<Schedule>(query.ToString(),
                new
                {
                    Id
                });

            return result;
        }

        public async Task ScheduleAsync(Schedule entity)
        {
            StringBuilder query = new();

            query.Append($" INSERT INTO [dbo].[SCHEDULEMEDICAL]  ");
            query.Append($" (                                    ");
            query.Append($"    UserId,                           ");
            query.Append($"    DoctorId,                         ");
            query.Append($"    Date,                             ");
            query.Append($"    Hour,                             ");
            query.Append($"    Status,                           ");
            query.Append($"    CreatedAt                         ");
            query.Append($" )                                    ");
            query.Append($" VALUES                               ");
            query.Append($" (                                    ");
            query.Append($"    @UserId,                          ");
            query.Append($"    @DoctorId,                        ");
            query.Append($"    @Date,                            ");
            query.Append($"    @Hour,                            ");
            query.Append($"    @Status,                          ");
            query.Append($"    @CreatedAt                        ");
            query.Append($" )                                    ");

            using var conn = _uow.Connection;

            await conn.ExecuteAsync(query.ToString(),
                new
                {
                    entity.UserId,
                    entity.DoctorId,
                    entity.Date,
                    entity.Hour,
                    entity.Status,
                    CreatedAt = DateTime.Now
                });
        }
    }
}

