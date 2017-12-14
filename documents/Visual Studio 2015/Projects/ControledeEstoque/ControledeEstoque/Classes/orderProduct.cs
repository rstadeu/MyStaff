using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControledeEstoque.Classes
{
    class orderProduct
    {

        private long orderProductID;
        private int _quantity;
        private Produto _produto;

        #region Encapsulated Data
       
        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

        public Produto Produto
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

        public long OrderProductID
        {
            get
            {
                return orderProductID;
            }

            set
            {
                orderProductID = value;
            }
        }

        #endregion
    }
}
