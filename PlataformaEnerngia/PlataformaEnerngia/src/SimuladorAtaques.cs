using System;

namespace PlataformaEnergia
{
    public class SimuladorAtaque : Evento
    {
        public string TipoAtaque { get; set; }

        public SimuladorAtaque(string tipo) : base("Simulando ataque cibernético")
        {
            TipoAtaque = tipo;
        }

        public override void ExibirResumo()
        {
            Console.WriteLine($"[{DataHora}] - Ataque simulado: {TipoAtaque}");
        }
    }
}