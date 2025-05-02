using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            // Crear cuentas
            var cuentas = new List<CuentaBancaria>
            {
                new CajaAhorro      ("01", 0,   TipoCuenta.CajaDeAhorro,    new[] { "Juan",     "Pedro",    "David" })
                    { TasaDeInteres = 0.05m },
                new CajaAhorro      ("02", 100, TipoCuenta.CajaDeAhorro,    new[] { "Gabriel",  "José" })
                    { TasaDeInteres = 0.03m },
                new CuentaCorriente ("03", 50,  TipoCuenta.CuentaCorriente, new[] { "Martina",  "Daniela", "Estefania", "Belen" })
                    { LimiteDeDescubierto = 100, Comision = 0.07m },
                new CuentaCorriente ("04", 200, TipoCuenta.CuentaCorriente, new[] { "Agustín" })
                    { LimiteDeDescubierto = 200, Comision = 0.05m }
            };

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al sistema de cuentas bancarias");
                    Console.WriteLine("Seleccione una cuenta para operar:");
                    for (int i = 0; i < cuentas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {cuentas[i]._tipo}");
                    }
                    Console.WriteLine("----------------------------------------------------");

                    int opcion = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Entrada inválida"));
                    if (opcion < 1 || opcion > cuentas.Count)
                    {
                        Console.WriteLine("Operación no válida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        continue;
                    }

                    OperarCuenta(cuentas[opcion - 1]);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }

        static void OperarCuenta(CuentaBancaria cuenta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Su cuenta es de tipo: {cuenta._tipo}");
                Console.WriteLine($"Número de cuenta: {cuenta.Numero}");
                Console.WriteLine("Titulares:");
                for (int i = 0; i < cuenta.Titulares.Length; i++)
                {
                    Console.WriteLine($"-{cuenta.Titulares[i]}");
                }
                Console.WriteLine($"Saldo: ${cuenta.Saldo}");
                if(cuenta._tipo == TipoCuenta.CajaDeAhorro)
                {
                    Console.WriteLine($"Tasa de interés: {((CajaAhorro)cuenta).TasaDeInteres}");
                }
                else if (cuenta._tipo == TipoCuenta.CuentaCorriente)
                {
                    Console.WriteLine($"Límite de descubierto: ${((CuentaCorriente)cuenta).LimiteDeDescubierto}");
                    Console.WriteLine($"Comisión: {((CuentaCorriente)cuenta).Comision}");
                }

                if (cuenta.Estado == Estado.Suspendida)
                {
                    Console.WriteLine("La cuenta fue suspendida por falta de saldo.");
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("Seleccione una operación:");
                Console.WriteLine("0: Depositar");
                Console.WriteLine("1: Retirar");
                Console.WriteLine("2: Salir");
                Console.WriteLine("----------------------------------------------------");

                int opcion = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Entrada inválida"));
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Ingrese el monto a depositar:");
                        decimal montoDeposito = Convert.ToDecimal(Console.ReadLine());
                        cuenta.Depositar(montoDeposito);
                        Console.WriteLine($"Depósito exitoso. Su nuevo saldo es: ${cuenta.Saldo}");
                        break;
                    case 1:
                        Console.WriteLine("Ingrese el monto a retirar:");
                        decimal montoRetiro = Convert.ToDecimal(Console.ReadLine());
                        cuenta.Retirar(montoRetiro);
                        Console.WriteLine($"Retiro exitoso. Su nuevo saldo es: ${cuenta.Saldo}");
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Operación no válida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }
    }
}
