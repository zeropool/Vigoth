
using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Data;

namespace VigiothCapital.QuantTrader.Engine.DataFeeds
{
    /// <summary>
    /// Transport type for algorithm update data. This is intended to provide a
    /// list of base data used to perform updates against the specified target
    /// </summary>
    /// <typeparam name="T">The target type</typeparam>
    public class UpdateData<T>
    {
        /// <summary>
        /// The target, such as a security or subscription data config
        /// </summary>
        public readonly T Target;

        /// <summary>
        /// The data used to update the target
        /// </summary>
        public readonly IReadOnlyList<BaseData> Data;

        /// <summary>
        /// The type of data in the data list
        /// </summary>
        public readonly Type DataType;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateData{T}"/> class
        /// </summary>
        /// <param name="target">The end consumer/user of the dat</param>
        /// <param name="dataType">The type of data in the list</param>
        /// <param name="data">The update data</param>
        public UpdateData(T target, Type dataType, IReadOnlyList<BaseData> data)
        {
            Target = target;
            Data = data;
            DataType = dataType;
        }
    }
}