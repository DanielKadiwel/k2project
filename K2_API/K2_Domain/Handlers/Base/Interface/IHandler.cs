using FluentValidator;

namespace K2_Domain.Handlers.Base.Interface
{
    public interface IHandler
    {
        IReadOnlyCollection<Notification> Notifications();
    }
}
