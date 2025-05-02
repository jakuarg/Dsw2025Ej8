using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CajaAhorro : CuentaBancaria
    {
        //Propiedades
        public decimal TasaDeInteres { get; internal set; }
        //Constructor
        public CajaAhorro(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
            : base(numero, saldo, tipo, titulares) { }
        //Métodos
        public override void Depositar(decimal monto)
        {
            //Excepcion => Si la cuenta no está activa
            if (Estado != Estado.Activa)
                throw new CuentaNoActiva(Estado.ToString());
            //Excepcion => Si el monto es menor o igual a 0
            if (monto <= 0)
                throw new MontoNoValido();
            //Si no se generó ninguna excepción, deposito el monto
            Saldo += monto;
        }
        public override void Retirar(decimal monto)
        {
            //Excepcion => Si la cuenta no está activa
            if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado.ToString());
            }
            else
            {
                //Excepcion => Si el monto es menor o igual a 0
                if (monto <= 0)
                    throw new MontoNoValido();
                //Excepcion => Si el monto es mayor al saldo => la cuenta queda suspendida
                if (monto > Saldo)
                {
                    Estado = Estado.Suspendida;
                    throw new SaldoInsuficiente();
                }
                //Si no se generó ninguna excepción, retiro el monto
                Saldo -= monto;
            }

        }
        public void AplicarInteres()
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
}
