using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XC.Configuration.Util
{
    public class DataItem<Type>
    {
        /// <summary>
        /// Stores the data.
        /// </summary>
        protected Type data;

        public DataItem()
        {

        }

        /// <summary>
        /// Getter to data-object
        /// </summary>
        /// <returns></returns>
        public Type GetData()
        {
            return data;
        }

        /// <summary>
        /// Sets the data-object
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Type data)
        {
            this.data = data;
        }

        /// <summary>
        /// Check if the data is in range.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual bool IsValidData(Type data)
        {
            throw new NotImplementedException();
        }

    }

    public class DataString : DataItem<string>
    {

    }

    public enum DataType{
        String,
        Integer,
        Double,
        Class
    }
}
