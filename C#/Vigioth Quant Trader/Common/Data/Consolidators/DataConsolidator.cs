using System;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public abstract class DataConsolidator<TInput> : IDataConsolidator
        where TInput : class, IBaseData
    {
        public void Update(BaseData data)
        {
            var typedData = data as TInput;
            if (typedData == null)
            {
                throw new ArgumentNullException("data", "Received type of " + data.GetType().Name + " but expected " + typeof(TInput).Name);
            }
            Update(typedData);
        }
        public abstract void Scan(DateTime currentLocalTime);
        public event DataConsolidatedHandler DataConsolidated;
        public BaseData Consolidated
        {
            get; private set;
        }
        public abstract BaseData WorkingData
        {
            get;
        }
        public Type InputType
        {
            get { return typeof (TInput); }
        }
        public abstract Type OutputType
        {
            get;
        }
        public abstract void Update(TInput data);
        protected virtual void OnDataConsolidated(BaseData consolidated)
        {
            var handler = DataConsolidated;
            if (handler != null) handler(this, consolidated);
            Consolidated = consolidated;
        }
    }
}