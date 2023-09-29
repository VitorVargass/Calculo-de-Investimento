


using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Investimento investimento = new Investimento();
        investimento.Ler();
        investimento.Calcular();
        investimento.Mostrar();
    }
}
class Investimento
{
    private double valorP;
    private double taxa;
    private int meses;
    private double resultado_final;
    private double resgate;
    private string verify;
    private int numMes;
    private double rendimento_restante;
    private double saldo_restante;
    private double resultado_mes;
    private double resultado_tabela;



    public void Ler()
    {
        Console.WriteLine("Digite o valor presente:");
        valorP = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a taxa de juros:");
        taxa = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o período em meses:");
        meses = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Haverá resgate? Aperte Y(yes) ou N(no):");
        verify = Console.ReadLine();

        if (verify == "y" || verify == "Y")
        {
            Console.WriteLine("Digite o valor do resgate:");
            resgate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite em qual mes sera feito resgate:");
            numMes = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Prosseguindo sem resgate.");
            numMes = Convert.ToInt32(meses);
            resgate = 0;
        }
    }
    
    public void Calcular()
    {
        //  F = p * ( 1 + i ) ^n

        // valor calculado até o mes 5 
        resultado_mes = valorP * Math.Pow(1 + taxa / 100, numMes); // 1159

        // valor do 5 mes com resgate
        saldo_restante = resultado_mes - resgate; // 659

        // rendimento calculado 
        rendimento_restante = resultado_mes - valorP;

        // resultado final da aplicaçao
        resultado_final = valorP * Math.Pow(1 + taxa / 100, meses);


        Console.WriteLine($"Saldo liquido restante : {saldo_restante:C} "); // quanto sobrou dps do resgate
        Console.WriteLine($"Rendimento restante: {rendimento_restante:C}"); // quanto rendeu
        Console.WriteLine($"Resultado final: {resultado_final:C} "); // resultado final sem nada

    }
    public void Mostrar()
    {
        Console.WriteLine("--------------------------------------------------------------------------------------");
        Console.WriteLine("| Valor Investido | Taxa de Juros | Rendimento |    Mês    |  Resgate  |    Saldo    |");
        Console.WriteLine("--------------------------------------------------------------------------------------");
        int aux = 0;
        for (int i = 0; i < numMes; i++)
        {
            resultado_tabela = valorP * Math.Pow(1 + taxa / 100, i);
            Console.WriteLine($"| {valorP, -15:C} | {taxa,12:F2}% | { resultado_tabela - valorP,-10:C} | {i,-9} | {aux,-9:C} | {resultado_tabela,-12:C} |");  
        }
        for(int i = numMes;i <= meses; i++)
        {
            resultado_tabela = valorP * Math.Pow(1 + taxa / 100, i);
            string resgateStr = i == numMes ? resgate.ToString("C") : "R$ 0,00";
            double saldo_lq = resultado_tabela - resgate;
            Console.WriteLine($"| {valorP,-15:C} | {taxa,12:F2}% | {saldo_lq - valorP,-10:C} | {i,-9} | {resgateStr,-9:C} | {saldo_lq,-12:C} |");
        }
        Console.WriteLine("--------------------------------------------------------------------------------------");
    }
}