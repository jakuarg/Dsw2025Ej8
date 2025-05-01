namespace Dsw2025Ej8.Domain;
using static Excepciones;
public class CuentaBancaria
{
    //public TipoCuenta _tipo { get; private set; }
    //public string _numero { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; set; }
    public Estado Estado { get; set; }
    //public string[] _titulares { get; private set; }
    public string[] Titulares { get; private set; }

    //public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        //_tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    /*#region Getters/Setters
    public string GetNumero()
    {
        return _numero;
    }

    public decimal GetSaldo()
    {
        return _saldo;
    }
    public TipoCuenta GetTipo()
    {
        return _tipo;
    }

    public Estado GetEstado()
    {
        return _estado;
    }

    public void SetEstado(Estado estado)
    {
        _estado = estado;
    }

    public decimal GetTasaDeInteres()
    {
        return _tasaDeInteres;
    }

    public void SetTasaDeInteres(decimal tasaDeInteres)
    {
        _tasaDeInteres = tasaDeInteres;
    }

    public decimal GetLimiteDeDescubierto()
    {
        return _limiteDeDescubierto;
    }

    public void SetLimiteDeDescubierto(decimal limiteDeDescubierto)
    {
        _limiteDeDescubierto = limiteDeDescubierto;
    }

    public decimal GetComision()
    {
        return _comision;
    }

    public void SetComision(decimal comision)
    {
        _comision = comision;
    }

    public string[] GetTitulares()
    {
        return _titulares;
    }
    #endregion*/

    /*Depositar y Retirar son métodos que permiten modificar el saldo de la cuenta.
public void Depositar(decimal monto)
{

    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo += monto;
    }
    else if (_tipo == TipoCuenta.CuentaCorriente)
    {
        monto -= monto * _comision;
        _saldo += monto;
    }
}

public void Retirar(decimal monto)
{
    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo -= monto;
    }
    else if (_tipo == TipoCuenta.CuentaCorriente)
    {
        if (_saldo - monto >= -_limiteDeDescubierto)
        {
            _saldo -= monto;
        }
        if (_saldo < 0)
        {
            _estado = Estado.Suspendida;
        }
    }
}

public void AplicarInteres()
{
    if (_tipo == TipoCuenta.CajaDeAhorro)
    {
        _saldo += _saldo * _tasaDeInteres;
    }
}*/
}
public class CajaAhorro : CuentaBancaria
{
    public decimal TasaDeInteres { get; internal set; }
    public CajaAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }
    public void Depositar(decimal monto)
    {
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva(Estado.ToString());
        if (monto <= 0)
            throw new MontoNoValido();
        Saldo += monto;
    }
    public void Retirar(decimal monto)
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado.ToString());
        }
        else
        {
            if (monto <= 0)
                throw new MontoNoValido();
            if (monto > Saldo)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
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
    public decimal LimiteDeDescubierto { get; internal set; }
    public decimal Comision { get; internal set; }
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }
    public void Depositar(decimal monto)
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado.ToString());
        }
        else
        {
            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            Saldo += monto - (monto * Comision);
        }
    }
    public void Retirar(decimal monto)
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado.ToString());
        }
        else
        {
            if (monto <= 0)
                throw new MontoNoValido();

            if (monto > monto - (Saldo + LimiteDeDescubierto))
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            else
            {
                Saldo -= monto;
            }
        }
    }
    public void AplicarLimite(decimal valor)
    {
        LimiteDeDescubierto = valor;
    }
}