using System;
using System.Collections.Generic;

namespace Domain
{
    public class Pessoa
    {
        private string name { get; set; }
        private DateTime date { get; set; }
        private int nextDate { get; set; }
        private int idadeatual { get; set; }
        private int matricula { get; set; }
        private int cpf { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int NextDate
        {
            get { return nextDate; }
            set { nextDate = value; }
        }

        public int IdadeAtual
        {
            get { return idadeatual; }
            set { idadeatual = value; }
        }
        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public int Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }



        public void idadeAtual(Pessoa p)
        {
            DateTime today = DateTime.Today;
            DateTime birthdate = new DateTime(p.Date.Year, p.Date.Month, p.Date.Day);

            int idade = today.Year - birthdate.Year;

            if (today.Month < p.Date.Month || (today.Month == p.Date.Month && today.Day < p.Date.Day))
                idade--;

            p.IdadeAtual = idade;
        }

        public void proxAniversario(Pessoa p)

        {
            DateTime today = DateTime.Today;
            DateTime birthdate = new DateTime(today.Year, p.Date.Month, p.Date.Day);

            if (birthdate < today)
                birthdate = birthdate.AddYears(1);
            int dias = (birthdate - today).Days;

            p.NextDate = dias;

        }
    }
}

