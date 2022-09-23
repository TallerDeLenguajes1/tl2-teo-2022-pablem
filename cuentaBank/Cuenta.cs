public class Cuenta
{
    protected const double COTIZACION = 145.44; //23-09-2022 
    private int saldo;
    public int Saldo { get => saldo; set => saldo = value; }

    public Cuenta(int saldo) {
        this.saldo = saldo;
    }

    public virtual int Extraccion(int monto, TipoExtracion tipo)
    {
        return 0;
    }

    void Insercion(int monto)
    {
        Saldo += monto;
    }
}

public class CuentaCorrientePeso : Cuenta
{
    public CuentaCorrientePeso(int saldo) : base(saldo) {
    }

     public override int Extraccion(int monto, TipoExtracion tipo) {
        if(Saldo-monto>=-5000 || (tipo == TipoExtracion.CajeroAutomatico && monto > 20000)) {
            Console.WriteLine("No se pudo extraer.");
            return 0;
        }
        Saldo -= monto;
        return monto;
    }
}

public class CuentaCorrienteDolar : Cuenta
{
    public CuentaCorrienteDolar(int saldo) : base(saldo) {
    }

    public override int Extraccion(int monto, TipoExtracion tipo) {
        monto = (int)(monto / COTIZACION);
        if(monto<Saldo || (tipo == TipoExtracion.CajeroAutomatico && monto > 200)) {
            Console.WriteLine("No se pudo extraer.");
            return 0;
        }
        Saldo -= monto;
        return monto;
    }
}

public class CajaDeAhorro: Cuenta
{
    public CajaDeAhorro(int saldo) : base(saldo) {
    }

    public override int Extraccion(int monto, TipoExtracion tipo) {
        if(monto<Saldo || (tipo == TipoExtracion.CajeroAutomatico && monto > 10000)) {
            Console.WriteLine("No se pudo extraer.");
            return 0;
        }
        Saldo -= monto;
        return monto;
    }
}