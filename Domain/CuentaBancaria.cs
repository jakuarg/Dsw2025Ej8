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

