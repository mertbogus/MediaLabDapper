using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<ResultDoctorDto>> GetAllDoctorAsync();

        Task<IEnumerable<ResultDoctorWithDepartmentDto>> GetDoctorsWithDepartmentAsync();
        Task<GetByIdDoctorDto> GetByIdDoctorAsync(int id);

        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto);

        Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto);

        Task DeleteDoctorAsync(int id);
    }
}
