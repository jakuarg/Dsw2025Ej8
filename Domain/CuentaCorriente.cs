using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
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
                if (monto > Saldo + LimiteDeDescubierto)
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
}
