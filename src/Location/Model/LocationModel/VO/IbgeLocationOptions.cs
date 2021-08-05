namespace IBGE.Model.IBGEModel
{
    public class IbgeLocationOptions
    {
        public static string Instance { get; } = "IBGE";
        public string BaseAddress { get; set; }
        public string RequestUriCity { get; set; }
    }
}
