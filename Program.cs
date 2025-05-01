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
            CajaAhorro ca1 = new CajaAhorro("01", 0, ["Juan", "Pedro", "David"]);
            CajaAhorro ca2 = new CajaAhorro("02", 100, ["Gabriel", "José"]);
            CuentaCorriente cc1 = new CuentaCorriente("03", 50, ["Martina", "Daniela", "Estefania", "Belen"]);
            CuentaCorriente cc2 = new CuentaCorriente("04", 200, ["Agustín"]);
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al sistema de cuentas bancarias");
                    Console.WriteLine("Qué cuenta desea operar? ");
                    Console.WriteLine("\n 1: -Caja de Ahorro 1 \n 2: -Caja de Ahorro 2");
                    Console.WriteLine("\n 3: -Cuenta Corriente 1 \n 4: -Cuenta Corriente 2");
                    Console.WriteLine("----------------------------------------------------");
                    int? opcion = int.Parse(s: Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Caja de Ahorro 1");
                            ParteAhorro(ca1);
                            break;
                        case 2:
                            Console.WriteLine("Caja de Ahorro 2");
                            ParteAhorro(ca2);
                            break;
                        case 3:
                            Console.WriteLine("Cuenta Corriente 1");
                            ParteCorriente(cc1);
                            break;
                        case 4:
                            Console.WriteLine("Cuenta Corriente 2");
                            ParteCorriente(cc2);
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
        static void ParteAhorro(CajaAhorro ca)
        {
            
            ca._tasaDeInteres = 0.05m;
            // Crear una nueva cuenta de ahorro
            while (true)
            {
                Console.Clear();
                if(ca._estado == Estado.Suspendida)
                {
                    Console.WriteLine("La cuenta fue suspendida por falta de saldo");
                }
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
        static void ParteCorriente(CuentaCorriente cc)
        {
            
            //cc._tasaDeInteres = 0.05m;
            cc._limiteDeDescubierto = 100;
            cc._comision = 0.07m;
            // Crear una nueva cuenta de ahorro
            while (true)
            {
                Console.Clear();
                if (cc._estado == Estado.Suspendida)
                {
                    Console.WriteLine("La cuenta fue suspendida por falta de saldo");
                }
                Console.WriteLine("Cuenta Corriente");
                Console.WriteLine($"La comisión es de {cc._comision * 100}%");
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
