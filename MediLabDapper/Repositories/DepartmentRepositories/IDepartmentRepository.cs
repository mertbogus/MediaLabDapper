using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmentRepositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentAsync();

        Task<GetDepartmentByIdDto> GetDepartmenByIdAsync(int id);

        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);

        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);

        Task DeleteDepartmentAsync(int id);
    }
}
