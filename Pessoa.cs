using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO0_exp_modeloprotrabalho
{
    internal class Pessoa
    {
        private string cpf;
        private string nome;
        private double salario;

        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public double Salario { get => salario; set => salario = value; }

        public Pessoa(string cpf, string nome, double salario)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.salario = salario;
        }

        public double calcCredito()
        {

            return salario * 6;
        }


    }
}
