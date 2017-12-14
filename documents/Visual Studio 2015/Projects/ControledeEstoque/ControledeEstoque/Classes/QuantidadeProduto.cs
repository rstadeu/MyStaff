using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControledeEstoque.Classes
{
    class QuantidadeProduto
    {
        private int _id;
        private long _quantidade;
        private string _produto;

        public long Quantidade
        {
            get
            {
                return _quantidade;
            }

            set
            {
                _quantidade = value;
            }
        }

        public string Produto
        {
            get
            {
                return _produto;
            }

            set
            {
                _produto = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}
