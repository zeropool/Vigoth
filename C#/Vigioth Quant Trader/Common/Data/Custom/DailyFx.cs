using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VigiothCapital.QuantTrader.Data.UniverseSelection;
namespace VigiothCapital.QuantTrader.Data.Custom
{
    public class DailyFx : BaseData
    {
        JsonSerializerSettings _jsonSerializerSettings;
        [JsonProperty(PropertyName = "title")]
        public string Title;
        [JsonProperty(PropertyName = "displayDate")]
        public DateTimeOffset DisplayDate; 
        [JsonProperty(PropertyName = "displayTime")]
        public DateTimeOffset DisplayTime;
        [JsonProperty(PropertyName = "importance")]
        public FxDailyImportance Importance;
        [JsonProperty(PropertyName = "better")]
        [JsonConverter(typeof(DailyFxMeaningEnumConverter))]
        public FxDailyMeaning Meaning;
        [JsonProperty(PropertyName = "currency")]
        public string Currency;
        [JsonProperty(PropertyName = "actual")]
        public string Actual;
        [JsonProperty(PropertyName = "forecast")]
        public string Forecast;
        [JsonProperty(PropertyName = "previous")]
        public string Previous;
        [JsonProperty(PropertyName = "daily")]
        public bool DailyEvent;
        [JsonProperty(PropertyName = "commentary")]
        public string Commentary;
        [JsonProperty(PropertyName = "language")]
        public string Language;
        public DailyFx()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind
            };
        }
        public override SubscriptionDataSource GetSource(SubscriptionDataConfig config, DateTime date, bool isLiveMode)
        {
            var url = "https://content.dailyfx.com/getData?contenttype=calendarEvent&description=true&format=json_pretty";
            if (!isLiveMode)
            {
                url += GetQuarter(date);
            }
            return new SubscriptionDataSource(url, SubscriptionTransportMedium.Rest, FileFormat.Collection);
        }
        public override BaseData Reader(SubscriptionDataConfig config, string content, DateTime date, bool isLiveMode)
        {
            var dailyfxList = JsonConvert.DeserializeObject<List<DailyFx>>(content, _jsonSerializerSettings);
            foreach (var dailyfx in dailyfxList)
            {
                dailyfx.Time = dailyfx.DisplayDate.Date.AddHours(dailyfx.DisplayTime.TimeOfDay.TotalHours);
                dailyfx.Value = 0;
                try
                {
                    if (!string.IsNullOrEmpty(Actual))
                    {
                        dailyfx.Value = Convert.ToDecimal(RemoveSpecialCharacters(Actual));
                    }
                }
                catch
                {
                }
            }
            return new BaseDataCollection(date, config.Symbol, dailyfxList);
        }
        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
        private string GetQuarter(DateTime date)
        {
            var start = date.ToString("yyyy", CultureInfo.InvariantCulture);
            var end = start;
            if (date.Month < 4)
            {
                start += "0101";
                end += "03312359"; 
            }
            else if (date.Month < 7)
            {
                start += "0401";
                end += "06302359";
            }
            else if (date.Month < 10)
            {
                start += "0701";
                end += "09302359";
            }
            else
            {
                start += "1001";
                end += "12312359";
            }
            return string.Format("&startdate={0}&enddate={1}", start, end);
        }
        public override string ToString()
        {
            return string.Format("DailyFx [{0} {1} {2} {3} {4}]", Time.ToString("u"), Title, Currency, Importance, Meaning);
        }
    }
    public enum FxDailyImportance
    {
        [JsonProperty(PropertyName = "low")]
        Low,
        [JsonProperty(PropertyName = "medium")]
        Medium,
        [JsonProperty(PropertyName = "high")]
        High
    }
    public enum FxDailyMeaning
    {
        [JsonProperty(PropertyName = "NONE")]
        None,
        [JsonProperty(PropertyName = "TRUE")]
        Better,
        [JsonProperty(PropertyName = "FALSE")]
        Worse
    }
    public class DailyFxMeaningEnumConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            FxDailyMeaning? meaning = null;
            switch (enumString)
            {
                case "TRUE":
                    meaning = FxDailyMeaning.Better;
                    break;
                case "FALSE":
                    meaning = FxDailyMeaning.Worse;
                    break;
                default:
                case "NONE":
                    meaning = FxDailyMeaning.None;
                    break;
            }
            return meaning;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("DailyFx Enum Converter is ReadOnly");
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
