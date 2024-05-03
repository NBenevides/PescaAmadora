using System.Threading.Tasks.Dataflow;

const double maximoContinental = 10;
const double maximoMarinho = 15;

const decimal multaFixa = 1000; 
const decimal multaQuilo = 20;

ConsoleColor cor;

Console.Clear();

Console.WriteLine("---Pesca Amadora---\n");
Console.Write("Peso (em kg): ");
double peso = Convert.ToDouble(Console.ReadLine());

Console.Write("Águas [c]ontinentais ou [m]arinhas? ");
string local = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if(local != "C" && local != "M")
{
    cor = ConsoleColor.Red; 
    Console.ForegroundColor = cor;
    Console.WriteLine("Local não reconhecido");
    Console.ResetColor();
    return;
}
if(local == "C" && peso <= maximoContinental ||
    local == "M" && peso <= maximoMarinho)
{
    cor = ConsoleColor.Green;
    Console.ForegroundColor = cor;
    Console.WriteLine("Pescaria dentro dos limites legais.");
    Console.ResetColor();
    return;
}


double pesoAutorizado = local == "C" ? maximoContinental :maximoMarinho;
double pesoExcedido = peso - pesoAutorizado;
decimal multa = multaFixa + multaQuilo * Convert.ToDecimal(pesoExcedido);

cor = ConsoleColor.Blue;
Console.ForegroundColor = cor;
Console.WriteLine($"Pescaria excede os limites legais em {pesoExcedido}kg.\nSujeito a multa de {multa:C}.");
Console.ResetColor();
return;