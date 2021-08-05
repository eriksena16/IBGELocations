namespace IBGE.Model.IBGEModel
{
    public class UF1
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao1 regiao { get; set; }
    }
}
