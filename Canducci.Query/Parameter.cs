namespace Canducci.Query
{
    public static class Parameter
    {
        public static QueryBuilderParameter NullValue<T>(T? value = default) where T : struct
        {
            return new QueryBuilderParameter<T>(value);
        }

        public static QueryBuilderParameter NullValue(string value = default)
        {
            return new QueryBuilderParameterString(value);
        }
    }
}
