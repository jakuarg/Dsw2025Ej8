using Dsw2025Ej8.Domain;
using System.Security.Cryptography;

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
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al sistema de cuentas bancarias");
                    Console.WriteLine("Qué cuenta desea operar? [0 para Caja de Ahorro y 1 para Cuenta Corriente]");
                    int? opcion = int.Parse(s: Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Caja de Ahorro");
                            ParteAhorro();
                            break;
                        case 1:
                            Console.WriteLine("Cuenta Corriente");
                            ParteCorriente();
                            break;
                        default:
                            Console.WriteLine("Operación no válida");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("Ingrese una tecla para seguir");
                    Console.ReadKey();
                }

            }
        }
        static void ParteAhorro()
        {
            CajaAhorro ca = new CajaAhorro("01", 0, ["Juan", "Pedro", "David"]);
            ca._tasaDeInteres = 0.05m;
            // Crear una nueva cuenta de ahorro
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Caja De Ahorro");
                Console.WriteLine($"La tasa de interés actual es: {ca._tasaDeInteres * 100}%");
                Console.WriteLine($"Numero de cuenta: {ca._numero}");
                for (int i = 0; i < ca._titulares.Length; i++)
                {
                    Console.WriteLine($"Nombre {i + 1} : {ca._titulares[i]}");
                }
                Console.WriteLine($"Su saldo es: ${ca._saldo}");
                Console.WriteLine("Ingrese la operación [0 para Depositar, y 1 para Retirar] ");
                int? opcion = int.Parse(s: Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Ingrese el monto a depositar: ");
                        decimal montoDeposito = Convert.ToDecimal(Console.ReadLine());
                        ca.Depositar(montoDeposito);
                        Console.WriteLine($"Su nuevo saldo es: ${ca._saldo}");
                        break;
                    case 1:
                        Console.WriteLine("Ingrese el monto a retirar: ");
                        decimal montoRetiro = Convert.ToDecimal(Console.ReadLine());
                        ca.Retirar(montoRetiro);
                        Console.WriteLine($"Su nuevo saldo es: ${ca._saldo}");
                        break;
                    default:
                        Console.WriteLine("Operación no válida");
                        break;
                }
                Console.WriteLine("¿Desea realizar otra operación? [S/N]");
            }
        }
        static void ParteCorriente()
        {
            CuentaCorriente cc = new CuentaCorriente("02", 0, ["Martina", "Daniela", "Estefania", "Belen"]);
            //cc._tasaDeInteres = 0.05m;
            cc._limiteDeDescubierto = 10000;
            // Crear una nueva cuenta de ahorro
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Cuenta Corriente");
                //Console.WriteLine($"La tasa de interés actual es: {cc._tasaDeInteres * 100}%");
                Console.WriteLine($"El limite de descubierto es: ${cc._limiteDeDescubierto}");
                Console.WriteLine($"Numero de cuenta: {cc._numero}");
                for (int i = 0; i < cc._titulares.Length; i++)
                {
                    Console.WriteLine($"Nombre {i + 1} : {cc._titulares[i]}");
                }
                Console.WriteLine($"Su saldo es: ${cc._saldo}");
                Console.WriteLine("Ingrese la operación [0 para Depositar, y 1 para Retirar] ");
                int? opcion = int.Parse(s: Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("Ingrese el monto a depositar: ");
                        decimal montoDeposito = Convert.ToDecimal(Console.ReadLine());
                        cc.Depositar(montoDeposito);
                        Console.WriteLine($"Su nuevo saldo es: ${cc._saldo}");
                        break;
                    case 1:
                        Console.WriteLine("Ingrese el monto a retirar: ");
                        decimal montoRetiro = Convert.ToDecimal(Console.ReadLine());
                        cc.Retirar(montoRetiro);
                        Console.WriteLine($"Su nuevo saldo es: ${cc._saldo}");
                        break;
                    default:
                        Console.WriteLine("Operación no válida");
                        break;
                }
                Console.WriteLine("¿Desea realizar otra operación? [S/N]");
            }
        }
    }
}
