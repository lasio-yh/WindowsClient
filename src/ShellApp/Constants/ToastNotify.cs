using Core.Model;
using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace ShellApp.Constants
{
    public class ToastNotify
    {
        public static Notifier Notifier;
        public static int LifeSecond = 3;
        public static int FromCount = 5;
        public static void Create()
        {
            Notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.BottomRight,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(LifeSecond),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(FromCount));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        /// <summary>
        /// Toast 객체 지우기
        /// </summary>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel Dispose()
        {
            try
            {
                if (Notifier == null)
                    return new ResultMapModel { ResultId = "0x01", ResultMessage = "Fail" };

                Notifier.Dispose();

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 알림 일반
        /// </summary>
        /// <param name="message">알림 메시지</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowInfo(string message)
        {
            try
            {
                if (Notifier == null)
                    return new ResultMapModel { ResultId = "0x01", ResultMessage = "Fail" };

                Notifier.ShowInformation(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 알림 적용
        /// </summary>
        /// <param name="message">알림 메시지</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowOk(string message)
        {
            try
            {
                if (Notifier == null)
                    return new ResultMapModel { ResultId = "0x01", ResultMessage = "Fail" };

                Notifier.ShowSuccess(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 알림 경고
        /// </summary>
        /// <param name="message">알림 메시지</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowWarn(string message)
        {
            try
            {
                if (Notifier == null)
                    return new ResultMapModel { ResultId = "0x01", ResultMessage = "Fail" };

                Notifier.ShowWarning(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 알림 오류
        /// </summary>
        /// <param name="message">알림 메시지</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowError(string message)
        {
            try
            {
                if (Notifier == null)
                    return new ResultMapModel { ResultId = "0x01", ResultMessage = "Fail" };

                Notifier.ShowError(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }
    }
}
