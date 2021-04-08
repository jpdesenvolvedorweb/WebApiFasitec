using System;
using System.Collections.Generic;
using WebAppFasitec.Entities;

namespace WebAppFasitec.Trade
{
    public static class ContratoTrade
    {
        private static List<Parcela> list = new List<Parcela>();


        public static void Oper(int cod, Contrato contrato, Pessoa pessoa)
        {
            const int mes = 1;
            const int oper = 2;

            TimeSpan tempoDeDias = new TimeSpan(20,00,00,00);
            TimeSpan tempoDeDiasMes = new TimeSpan(30,00,00,00);

            DateTime data = contrato.Datacadastro;
            DateTime dtUltimoDiaMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            DateTime dataDiaPessoa = dtUltimoDiaMes.AddDays(pessoa.DiaCobranca);


            decimal valorParcela = contrato.Valor / contrato.QtdeParcelas;
                   
            for (int i = 1; i <= contrato.QtdeParcelas; i++)
            {
                TimeSpan result = dataDiaPessoa.Subtract(contrato.Datacadastro);

                if (result <= tempoDeDias)
                    dataDiaPessoa = dataDiaPessoa.AddMonths(mes);

                if (!(result <= tempoDeDias) && !(result > tempoDeDiasMes) && (i == oper))
                    dataDiaPessoa = dataDiaPessoa.AddMonths(mes);

                if (result > tempoDeDiasMes)
                    dataDiaPessoa = dataDiaPessoa.AddMonths(mes);

                Parcela parcela = new Parcela();
                parcela.NumeroParcela += i;
                parcela.Valor = valorParcela;
                parcela.DataFechamento = dataDiaPessoa;
                parcela.IdContrato = cod;
                list.Add(parcela);
            }
        }

        public static List<Parcela> parcelas()
        {
            return list;
        }
    }
}

