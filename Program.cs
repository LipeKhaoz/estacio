using System;
using System.Collections.Generic;
public class Veiculo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public DateTime HoraEntrada { get; set; }
}

public class Estacionamento
{
    private List<Veiculo> vagas = new List<Veiculo>();
    private decimal taxaInicial = 5.0M; // Valor para estacionar
    private decimal taxaPorHora = 2.0M; // Valor por hora estacionada

    public void Estacionar(Veiculo veiculo)
    {
        veiculo.HoraEntrada = DateTime.Now;
        vagas.Add(veiculo);
        Console.WriteLine($"Veículo {veiculo.Modelo} com placa {veiculo.Placa} estacionado com sucesso.");
    }

    public void Retirar(string placa)
    {
        Veiculo veiculo = vagas.Find(v => v.Placa == placa);
        if (veiculo != null)
        {
            DateTime horaSaida = DateTime.Now;
            TimeSpan tempoEstacionado = horaSaida - veiculo.HoraEntrada;
            decimal valorPagar = taxaInicial + (decimal)tempoEstacionado.TotalHours * taxaPorHora;

            Console.WriteLine($"Veículo {veiculo.Modelo} com placa {veiculo.Placa} estacionado por {tempoEstacionado.TotalHours} horas.");
            Console.WriteLine($"Valor a pagar: R$ {valorPagar:F2}");
            
            vagas.Remove(veiculo);
        }
        else
        {
            Console.WriteLine("Veículo não encontrado no estacionamento.");
        }
    }
}

class Program
{
    static void Main()
    {
        Estacionamento estacionamento = new Estacionamento();

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Estacionar");
            Console.WriteLine("2 - Retirar");
            Console.WriteLine("0 - Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.Write("Digite a placa do veículo: ");
                    string placa = Console.ReadLine();
                    Console.Write("Digite o modelo do veículo: ");
                    string modelo = Console.ReadLine();
                    Veiculo novoVeiculo = new Veiculo { Placa = placa, Modelo = modelo };
                    estacionamento.Estacionar(novoVeiculo);
                    break;

                case 2:
                    Console.Write("Digite a placa do veículo a ser retirado: ");
                    string placaRetirar = Console.ReadLine();
                    estacionamento.Retirar(placaRetirar);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
