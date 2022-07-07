﻿using Windows.UI.Notifications;

namespace Windows_Template.Contracts.Services
{
    public interface IToastNotificationsService
    {
        public abstract void ShowToastNotification(ToastNotification toastNotification);

        public abstract void ShowToastNotificationSample();
    }
}
