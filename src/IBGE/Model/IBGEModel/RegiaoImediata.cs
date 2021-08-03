namespace IBGE.Model.IBGEModel
{
    public class RegiaoImediata
    {
        public int id { get; set; }
        public string nome { get; set; }
        public RegiaoIntermediaria regiaointermediaria { get; set; }
    }
}
