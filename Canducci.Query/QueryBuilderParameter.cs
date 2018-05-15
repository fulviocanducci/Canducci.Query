using System;
namespace Canducci.Query
{
    public abstract class QueryBuilderParameter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public QueryBuilderParameter(object value, Type type)
        {
            Value = value;
            ParameterType = type;
        }
        /// <summary>
        /// 
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// 
        /// </summary>
        public Type ParameterType { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class QueryBuilderParameter<T> : QueryBuilderParameter
       where T : struct
    {
        /// <summary>
        /// Create QueryBuilderParamenter
        /// </summary>
        /// <param name="value"></param>
        public QueryBuilderParameter(T? value = default)
            : base(value, typeof(T?))
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal sealed class QueryBuilderParameterString : QueryBuilderParameter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public QueryBuilderParameterString(string value = default)
            : base(value, typeof(string))
        {
        }
    }
}
