using Aplication.Client.API.DTO;

namespace Aplication.Client.API.Services
{
    public interface ITutor
    {
        public Task<int> TutorRegister(TutorRegister tutorData);
    }
}
