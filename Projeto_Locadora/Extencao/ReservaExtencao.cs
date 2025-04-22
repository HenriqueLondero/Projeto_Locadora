using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Locadora.Entidade
{
    public static class ReservaExtencao
    {
        public static string InformacoesReserva(this Reserva reserva)
        {
            string informacoes = "";

            informacoes += "Informações das Reservas \n" +
                $"Nome Completo: {reserva.NomeCompleto}\n" +
                $"Cpf: {reserva.Cpf}\n" +
                $"Data De Estima: {reserva.DataEstimada}\n" +
                $"Valor a ser pago: {reserva.ValorEstimado}\n";


            return informacoes;
        }
    }
}
