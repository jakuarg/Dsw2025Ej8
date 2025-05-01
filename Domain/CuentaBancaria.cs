namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta _tipo { get; private set; }
    public string _numero { get; private set; }
    public decimal _saldo { get; set; }
    public Estado _estado { get; private set; }
    public decimal _tasaDeInteres { get; set; }
    public decimal _limiteDeDescubierto { get; set; }
    public decimal _comision { get; set; }
    public string[] _titulares { get; private set; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _tipo = tipo;
        _estado = Estado.Activa;
        _titulares = titulares;
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
    public CajaAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
    {
    }
    private void Depositar(decimal monto)
    {
        _saldo += monto;
    }
    private void Retirar(decimal monto)
    {
        _saldo -= monto;
    }
    private void AplicarInteres()
    {
        _saldo += _saldo * _tasaDeInteres;
    }
}
public class CuentaCorriente : CuentaBancaria
{
    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
    {
    }
    private void Depositar(decimal monto)
    {
        monto -= monto * _comision;
        _saldo += monto;
    }
    private void Retirar(decimal monto)
    {
        _saldo -= monto;
    }
}