using EmilyLilyApi.Models;

namespace EmilyLilyApi.Services
{
    public interface IMessenger
    {
        void SendMessage(IMessage message);
    }
}
