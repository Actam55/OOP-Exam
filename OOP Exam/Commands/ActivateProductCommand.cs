﻿using OOP_Exam.Interfaces;
using OOP_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam.Commands
{
    public class ActivateProductCommand : ICommand
    {
        private readonly ITallysystemUI _ui;
        private readonly ITallysystem _tallySystem;
        private int _productId;
        public ActivateProductCommand(ITallysystemUI ui, ITallysystem tallySystem, int productId)
        {
            _ui = ui;
            _tallySystem = tallySystem;
            _productId = productId;
        }

        public void Execute()
        {
            Product product = _tallySystem.GetProductByID(_productId);
            if (product != null)
            {
                product.Active = true;
            }
            else
            {
                _ui.DisplayProductNotFound(_productId.ToString());
            }
        }
    }
}
