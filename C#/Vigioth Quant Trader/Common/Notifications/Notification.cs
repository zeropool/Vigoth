namespace VigiothCapital.QuantTrader.Notifications
{
    public abstract class Notification
    {
        public virtual void Send()
        {
        }
    }
    public class NotificationWeb : Notification
    {
        public string Address;
        public object Data;
        public NotificationWeb(string address, object data = null)
        {
            Address = address;
            Data = data;
        }
    }
    public class NotificationSms : Notification
    {
        public string PhoneNumber;
        public string Message;
        public NotificationSms(string number, string message)
        {
            PhoneNumber = number;
            Message = message;
        }
    }
    public class NotificationEmail : Notification
    {
        public string Address;
        public string Subject;
        public string Message;
        public string Data;
        public NotificationEmail(string address, string subject, string message, string data)
        {
            Message = message;
            Data = data;
            Subject = subject;
            Address = address;
        }
    }
}
