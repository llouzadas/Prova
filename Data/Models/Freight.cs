// Models/Freight.cs
using System.Diagnostics;

#pragma warning disable IDE0130 // O namespace não corresponde à estrutura da pasta
namespace FreightSystem.Models
#pragma warning restore IDE0130 // O namespace não corresponde à estrutura da pasta
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class YourModelClass
    {
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
        // Definição da classe
    }
}
public class Freight
{
    public int Id { get; set; }
    public int Distance { get; set; }
    public decimal BasePrice { get; set; }
    public decimal FinalPrice { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Status { get; set; }
}
