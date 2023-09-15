using FluentValidator;
using K2_Domain.Handlers.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2_Domain.Handlers.Base
{
    public abstract class BaseHandler : Notifiable, IHandler
    {
        IReadOnlyCollection<Notification> IHandler.Notifications() => this.Notifications;
    }
}
