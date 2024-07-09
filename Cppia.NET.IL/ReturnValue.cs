namespace Cppia.NET
{
    internal class ReturnValue
    {
        public bool IsValueType { get; }

        public ReturnValue(bool isValueType)
        {
            IsValueType = isValueType;
        }
    }
}
