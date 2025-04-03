using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _dapperContext;

        public DepartmentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            string query = "insert into departments(DepartmentName, DepartmentDesc) values(@DepartmentName, @DepartmentDesc) ";
            var parameters = new DynamicParameters(createDepartmentDto);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            string query = "delete from departments where DepartmentId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentAsync()
        {
            string query = " select * from departments ";
            var connection = _dapperContext.CreateConnection();

            return await connection.QueryAsync<ResultDepartmentDto>(query);
        }

        public async Task<GetDepartmentByIdDto> GetDepartmenByIdAsync(int id)
        {
            string query = "select * from departments where DepartmentId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetDepartmentByIdDto>(query, parameters);
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "update departments set DepartmentName=@DepartmentName, DepartmentDesc=@DepartmentDesc where DepartmentId=@DepartmentId";
            var parameters = new DynamicParameters(updateDepartmentDto);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
