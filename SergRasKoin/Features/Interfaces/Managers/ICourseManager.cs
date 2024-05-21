using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Features.Interfaces.Managers
{
    public interface ICourseManager
    {
        Course UpdateCourse();

        Course GetLastCourse();
    }
}
