using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;


namespace Domain
{
    public class Function : InterfacePessoa
    {

        // STREAM READER 

        string path = @"d:\StreamReader.txt"; // Colocar  na unidade de HD d:\  ou colocar o caminho do arquivo txt que vem com o programa.

        public void StreamReaderCheck()
        {
            using (StreamReader sr = new StreamReader(path))
            {             
                 string json = sr.ReadToEnd();

                 if (json == "") {

                    List<Pessoa> pessoas = new List<Pessoa>();
                    pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(json);

                    }else{

                    pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                }
            }
        }

        // ADICIONAR PESSOA

        public List<Pessoa> pessoas = new List<Pessoa>();

        public void addPessoa(string nome, string date, string matri, string cp)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Name = nome;
            pessoa.Date = DateTime.Parse(date, CultureInfo.InvariantCulture);
            pessoa.Matricula = int.Parse(matri, CultureInfo.InvariantCulture);
            pessoa.Cpf = int.Parse(cp, CultureInfo.InvariantCulture);
            pessoa.idadeAtual(pessoa);
            pessoa.proxAniversario(pessoa);
            pessoas.Add(pessoa); ;

            string json = JsonConvert.SerializeObject(pessoas.ToArray());
            System.IO.File.WriteAllText(@"d:\StreamReader.txt", json); // Colocar  na unidade de HD d:\  ou colocar o caminho do arquivo txt que vem com o programa.

        }

        //BUSCAR PESSOA

        public List<Pessoa> BuscarPessoa()
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    List<Pessoa> id = JsonConvert.DeserializeObject<List<Pessoa>>(json);
                    return id;
                }
            }

        //DELETAR PESSOA

        public void delPessoa(Pessoa id)
        {
            pessoas.Remove(id);

            string json = JsonConvert.SerializeObject(pessoas.ToArray());
            System.IO.File.WriteAllText(path, json);

        }

        //EDITAR PESSOA


    }

 }

 

