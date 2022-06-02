using Core.Model;
using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace ShellApp.Constants
{
    public class ToastService
    {
        public static Notifier Notifier;
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
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="message">디렉토리 경로</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel Dispose()
        {
            try
            {
                Notifier.Dispose();

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }

        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="message">디렉토리 경로</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowInfo(string message)
        {
            try
            {
                Notifier.ShowInformation(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="message">디렉토리 경로</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowOk(string message)
        {
            try
            {
                Notifier.ShowSuccess(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="message">디렉토리 경로</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowWarn(string message)
        {
            try
            {
                Notifier.ShowWarning(message);

                return new ResultMapModel { ResultId = "0x00", ResultMessage = "Succes" };
            }
            catch (Exception ex)
            {
                return new ResultMapModel { ResultId = "0x01", ResultMessage = ex.Message };
            }
        }


        /// <summary>
        /// 파일 저장하기
        /// </summary>
        /// <param name="message">디렉토리 경로</param>
        /// <returns>ResultMapModel</returns>
        public static ResultMapModel ShowError(string message)
        {
            try
            {
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
