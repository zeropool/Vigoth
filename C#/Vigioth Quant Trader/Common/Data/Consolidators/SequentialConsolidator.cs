using System;
namespace VigiothCapital.QuantTrader.Data.Consolidators
{
    public class SequentialConsolidator : IDataConsolidator
    {
        public IDataConsolidator First
        {
            get; private set;
        }
        public IDataConsolidator Second
        {
            get; private set;
        }
        public BaseData Consolidated
        {
            get { return Second.Consolidated; }
        }
        public BaseData WorkingData
        {
            get { return Second.WorkingData; }
        }
        public Type InputType
        {
            get { return First.InputType; }
        }
        public Type OutputType
        {
            get { return Second.OutputType; }
        }
        public void Update(BaseData data)
        {
            First.Update(data);
        }
        public void Scan(DateTime currentLocalTime)
        {
            First.Scan(currentLocalTime);
        }
        public event DataConsolidatedHandler DataConsolidated;
        public SequentialConsolidator(IDataConsolidator first, IDataConsolidator second)
        {
            if (!second.InputType.IsAssignableFrom(first.OutputType))
            {
                throw new ArgumentException("first.OutputType must equal second.OutputType!");
            }
            First = first;
            Second = second;
            first.DataConsolidated += (sender, consolidated) => second.Update(consolidated);
            second.DataConsolidated += (sender, consolidated) => OnDataConsolidated(consolidated);
        }
        protected virtual void OnDataConsolidated(BaseData consolidated)
        {
            var handler = DataConsolidated;
            if (handler != null) handler(this, consolidated);
        }
    }
}
