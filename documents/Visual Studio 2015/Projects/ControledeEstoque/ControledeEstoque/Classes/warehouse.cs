using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControledeEstoque.Classes
{
    class warehouse
    {
        #region Attributes
        private int _warehouseID;
        private bool _isWarehouseParent;
        private string _warehouseDescription;
        private List<int> _warehouseChildrens;
        #endregion
        #region Encapsulated Attributes
        public int WarehouseID
        {
            get
            {
                return _warehouseID;
            }

            set
            {
                _warehouseID = value;
            }
        }

        public bool IsWarehouseParent
        {
            get
            {
                return _isWarehouseParent;
            }

            set
            {
                _isWarehouseParent = value;
            }
        }

        public string WarehouseDescription
        {
            get
            {
                return _warehouseDescription;
            }

            set
            {
                _warehouseDescription = value;
            }
        }

        public List<int> WarehouseChildrens
        {
            get
            {
                return _warehouseChildrens;
            }

            set
            {
                _warehouseChildrens = value;
            }
        }
        #endregion


    }
}
