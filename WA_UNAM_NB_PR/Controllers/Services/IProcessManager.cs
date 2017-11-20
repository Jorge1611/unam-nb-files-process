using System.Threading.Tasks;

namespace WA_UNAM_NB_PR.Controllers.Services
{
    public interface IProcessManager
    {
        int Status { get; }

        Task Go();
        void Stop();
        void UpdateStatus(int value);
    }
}