namespace Api.Domain.Entities
{
    public class Adicional : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int TempoDePreparo { get; set; }
    }
}