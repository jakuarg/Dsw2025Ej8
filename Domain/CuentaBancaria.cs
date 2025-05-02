namespace Dsw2025Ej8.Domain;
using static Excepciones;
public abstract class CuentaBancaria
{
    //Propiedades
    public TipoCuenta _tipo { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; set; }
    public Estado Estado { get; set; }
    public string[] Titulares { get; private set; }
    //Constructor
    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        _tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    //Métodos
    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
}
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
public class CuentaCorriente : CuentaBancaria
{
    //Propiedades
    public decimal LimiteDeDescubierto { get; internal set; }
    public decimal Comision { get; internal set; }
    //Constructor
    public CuentaCorriente(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
        : base(numero, saldo, tipo, titulares) { }
    //Métodos
    public override void Depositar(decimal monto)
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
            {
                throw new MontoNoValido();
            }
            //Si no hay excepción, se deposita el monto menos la comisión
            Saldo += monto - (monto * Comision);
        }
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
            //Excepcion => Si el monto es mayor al saldo + limite de descubierto => la cuenta queda suspendida
            if (monto > monto - (Saldo + LimiteDeDescubierto))
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            else
            {
                //Si no se generó ninguna excepción, retiro el monto
                Saldo -= monto;
            }
        }
    }
    public void AplicarLimite(decimal valor)
    {
        LimiteDeDescubierto = valor;
    }
}