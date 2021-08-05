using Newtonsoft.Json;

namespace IBGE.Model.IBGEModel
{
    public class City
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Microrregiao microrregiao { get; set; }
        public RegiaoImediata regiaoimediata { get; set; }
    }
}
