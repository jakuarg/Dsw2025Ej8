using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new("0001", 1232.10m, TipoCuenta.CajaDeAhorro, ["Juan Perez", "Maria Lopez"])
            {
                _tasaDeInteres = 0.05m,
            };
        }
    }
}
