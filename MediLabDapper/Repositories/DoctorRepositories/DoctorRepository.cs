using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using System.Data;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context): IDoctorRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();
        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            var query = "insert into Doctors (NameSurname, ImageUrl, Description, DepartmentId) values (@NameSurname" +
                ",@ImageUrl, @Description, @DepartmentId)";
            var parameters = new DynamicParameters(createDoctorDto);
            await _db.ExecuteAsync(query,parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var query = "delete from Doctors where DoctorId=@DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllDoctorAsync()
        {
            var query = "Select * From Doctors";
            return await _db.QueryAsync<ResultDoctorDto>(query);
        }

        public async Task<GetByIdDoctorDto> GetByIdDoctorAsync(int id)
        {
            var query = "Select * From Doctors where DoctorId=@DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", id);
            return await _db.QueryFirstOrDefaultAsync<GetByIdDoctorDto>(query);
        }

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetDoctorsWithDepartmentAsync()
        {
            var query = "Select DoctorId, NameSurname, ImageUrl, Doctors.Description, DepartmentName From Doctors Inner Join Departments on Doctors.DepartmentId = Departments.DepartmentId";
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            var query = "update doctors set NameSurname=@NameSurname, Description= @Description, ImageUrl= @ImageUrl, DepartmentId= @DepartmentId where DoctorId=@DoctorId";
            var parameters = new DynamicParameters(updateDoctorDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
