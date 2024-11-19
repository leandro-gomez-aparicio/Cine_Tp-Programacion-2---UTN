namespace Cine_Tp.Repositories.Utils
{
    public class ParameterSQL
    {
        public ParameterSQL(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
