using System;
using System.Collections.Concurrent;
namespace VigiothCapital.QuantTrader.Notifications
{
    public class NotificationManager
    {
        private int _count;
        private DateTime _resetTime;
        private const int _rateLimit = 30;
        private readonly bool _liveMode;
        public ConcurrentQueue<Notification> Messages
        {
            get; set;
        }
        public NotificationManager(bool liveMode)
        {
            _count = 0;
            _liveMode = liveMode;
            _resetTime = DateTime.Now;
            Messages = new ConcurrentQueue<Notification>();
        }
        private bool Allow()
        {
            if (DateTime.Now > _resetTime)
            {
                _count = 0;
                _resetTime = DateTime.Now.RoundUp(TimeSpan.FromHours(1));
            }
            if (_count < _rateLimit)
            {
                _count++;
                return true;
            }
            return false;
        }
        public bool Email(string address, string subject, string message, string data = "")
        {
            if (!_liveMode) return false;
            var allow = Allow();
            if (allow)
            {
                var email = new NotificationEmail(address, subject, message, data);
                Messages.Enqueue(email);
            }
            return allow;
        }
        public bool Sms(string phoneNumber, string message)
        {
            if (!_liveMode) return false;
            var allow = Allow();
            if (allow)
            {
                var sms = new NotificationSms(phoneNumber, message);
                Messages.Enqueue(sms);
            }
            return allow;
        }
        public bool Web(string address, object data = null)
        {
            if (!_liveMode) return false;
            var allow = Allow();
            if (allow)
            {
                var web = new NotificationWeb(address, data);
                Messages.Enqueue(web);
            }
            return allow;
        }
    }
}
