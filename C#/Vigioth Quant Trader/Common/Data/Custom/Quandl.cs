using System;
using System.Collections.Generic;
using System.Globalization;
namespace VigiothCapital.QuantTrader.Data.Custom
{
    public class Quandl : DynamicData
    {
        private bool _isInitialized;
        private readonly List<string> _propertyNames = new List<string>();
        private readonly string _valueColumn;
        private static string _authCode = "";
        public static bool IsAuthCodeSet
        {
            get;
            private set;
        }
        public override DateTime EndTime
        {
            get { return Time + Period; }
            set { Time = value - Period; }
        }
        public TimeSpan Period
        {
            get { return VigiothCapital.QuantTrader.Time.OneDay; }
        }
        public Quandl()
        {
            _valueColumn = "Close";
        }
        protected Quandl(string valueColumnName)
        {
            _valueColumn = valueColumnName;
        }
        public override BaseData Reader(SubscriptionDataConfig config, string line, DateTime date, bool isLiveMode)
        {
            var data = (Quandl) Activator.CreateInstance(GetType());
            data.Symbol = config.Symbol;
            var csv = line.Split(',');
            if (!_isInitialized)
            {
                _isInitialized = true;
                foreach (var propertyName in csv)
                {
                    var property = propertyName.TrimStart().TrimEnd();
                    data.SetProperty(property, 0m);
                    _propertyNames.Add(property);
                }
                return null;
            }
            data.Time = DateTime.ParseExact(csv[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            for (var i = 1; i < csv.Length; i++)
            {
                var value = csv[i].ToDecimal();
                data.SetProperty(_propertyNames[i], value);
            }
            data.Value = (decimal)data.GetProperty(_valueColumn);
            return data;
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            var source = @"https://www.quandl.com/api/v1/datasets/" + config.Symbol.Value + ".csv?sort_order=asc&exclude_headers=false&auth_token=" + _authCode;
            return new SubscriptionDataSource(source, SubscriptionTransportMedium.RemoteFile);
        }
        public static void SetAuthCode(string authCode)
        {
            _authCode = authCode;
            IsAuthCodeSet = true;
        }
    }
}
