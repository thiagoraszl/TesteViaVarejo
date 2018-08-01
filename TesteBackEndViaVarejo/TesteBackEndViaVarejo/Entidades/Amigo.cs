using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackEndViaVarejo.Entidades
{
    public class Amigo
    {
        private readonly Localizacao _localizacao;
        private string _nome;
        private int _id;

        public Amigo(Localizacao localizacao)
        {
            _localizacao = localizacao;
        }

        public Amigo(int id,string nome, Localizacao localizacao)
        {
            _id = id;
            _nome = nome;
            _localizacao = localizacao;
        }

        public Localizacao localizacao
        {
            get { return _localizacao; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
