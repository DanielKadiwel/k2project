using FluentValidator;
using K2_Domain.Commands.Base.Interface;

namespace K2_Domain.Commands.Base
{
    public abstract class BaseCommand : Notifiable, ICommand
    {
        public virtual bool IsValid()
        {
            return base.Valid;
        }
    }
}