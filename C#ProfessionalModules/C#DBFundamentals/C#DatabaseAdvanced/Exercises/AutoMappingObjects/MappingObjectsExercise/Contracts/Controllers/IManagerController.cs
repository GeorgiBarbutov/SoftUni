using MappingObjectsExercise.Dtos;

namespace MappingObjectsExercise.Contracts.Controllers
{
    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int managerId);
    }
}
