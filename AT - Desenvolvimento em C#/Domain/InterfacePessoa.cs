using System;
using System.Collections.Generic;


namespace Domain
{
    interface InterfacePessoa
    {
        void addPessoa(string nome, string date, string matri, string cp);
        List<Pessoa> BuscarPessoa();
        void delPessoa(Pessoa id);
    }
}
