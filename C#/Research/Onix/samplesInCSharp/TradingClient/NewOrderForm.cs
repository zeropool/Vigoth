#region Copyright
/*
* Copyright Onix Solutions Limited [OnixS]. All rights reserved.
*
* This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
* and international copyright treaties.
*
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting
* a non-assignable, non-transferable and non-exclusive license to use the software
* for it's own data processing purposes under the terms defined in the Agreement.
*
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited.
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with
* the terms of the Agreement is a violation of copyright law.
*/
#endregion

using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;

namespace TradingClientSample
{
    public partial class NewOrderForm : Form
    {
        private TradingManager tradingManager;
        private MainForm mainForm;

        public NewOrderForm(TradingManager tradingManager, MainForm mainForm, Onixs.FixControls.ILogger logger)
        {
            this.tradingManager = tradingManager;
            this.mainForm = mainForm;
            logger_ = logger;

            InitializeComponent();

            cmbOrderType.Items.AddRange(Enum.GetNames(typeof (Order.OrderType)));
            cmbSide.Items.AddRange(Enum.GetNames(typeof(Order.OrderSide)));

            Left = mainForm.Left + (mainForm.Width - Width)/2;
            Top = mainForm.Top + (mainForm.Height - Height)/2;

            mainForm.OnConnect += new EventHandler(mainForm_OnConnect);
            mainForm.OnDisconnect += new EventHandler(mainForm_OnDisconnect);

            cmbOrderType.SelectedIndex = 1;
            cmbSide.SelectedIndex = 0;
            cmbSymbol.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;

            txtClOrdID.Text = TradingManager.GetNextClientOrderID();
        }

        Onixs.FixControls.ILogger logger_;

        public NewOrderForm(TradingManager tradingManager, MainForm mainForm, Order orderToModify, Onixs.FixControls.ILogger logger)
            : this(tradingManager, mainForm, logger)
        {
            this.orderToModify = orderToModify;
            
            Text = "Modify Order";            

            txtClOrdID.Text = orderToModify.ClientOrderID;
            txtClOrdID.ReadOnly = true;

            txtClOrdID.Text = TradingManager.GetNextClientOrderID();

            cmbOrderType.Text = orderToModify.Type.ToString();
            cmbOrderType.Enabled = false;

            cmbSide.Text = orderToModify.Side.ToString();
            cmbSide.Enabled = false;

            cmbSymbol.Text = orderToModify.Symbol;
            cmbSymbol.Enabled = false;

            cmbOrderType.Text = orderToModify.Type.ToString();
            cmbOrderType.Enabled = false;

            cmbCurrency.Text = orderToModify.Currency;
            cmbCurrency.Enabled = false;

			txtQuantity.Text = orderToModify.Quantity.ToString(CultureInfo.InvariantCulture);
			txtPrice.Text = orderToModify.Price.ToString(CultureInfo.InvariantCulture);
        }

        private Order orderToModify;

        private void mainForm_OnDisconnect(object sender, EventArgs e)
        {
            buttonSend.Enabled = false;
        }

        private void mainForm_OnConnect(object sender, EventArgs e)
        {
            buttonSend.Enabled = true;
        }       

        private void buttonClose_Click(object sender, EventArgs e)
        {
            mainForm.OnConnect -= new EventHandler(mainForm_OnConnect);
            mainForm.OnDisconnect -= new EventHandler(mainForm_OnDisconnect);
            Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                bool detectedErrors = false;
                if (string.IsNullOrEmpty(txtClOrdID.Text))
                {
                    errorProvider.SetIconPadding(txtClOrdID, 4);
                    errorProvider.SetError(txtClOrdID, "ClOrdID must be specified");
                    detectedErrors = true;
                }

                if (! tradingManager.IsClientOrderIdUnique(txtClOrdID.Text))
                {
                    errorProvider.SetIconPadding(txtClOrdID, 4);
                    errorProvider.SetError(txtClOrdID, "ClOrdID must be unique");
                    detectedErrors = true;
                }

                if (string.IsNullOrEmpty(cmbSymbol.Text))
                {
                    errorProvider.SetIconPadding(cmbSymbol, 4);
                    errorProvider.SetError(cmbSymbol, "Symbol must be specified");
                    detectedErrors = true;
                }

                double price;
                if (!double.TryParse(txtPrice.Text, NumberStyles.Currency, CultureInfo.InvariantCulture, out price))
                {
                    errorProvider.SetIconPadding(txtPrice, 4);
                    errorProvider.SetError(txtPrice, "Price must be specified as correct number");
                    detectedErrors = true;
                }

                double quantity;
                if (!double.TryParse(txtQuantity.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out quantity))
                {
                    errorProvider.SetIconPadding(txtQuantity, 4);
                    errorProvider.SetError(txtQuantity, "Quantity must be specified as correct number");
                    detectedErrors = true;
                }

                if (detectedErrors)
                {
                    return;
                }
                
                Order order;
                if (null == orderToModify)
                {
                    Order.OrderType orderType = (Order.OrderType) Enum.Parse(typeof (Order.OrderType), cmbOrderType.Text);
                    Order.OrderSide orderSide = (Order.OrderSide) Enum.Parse(typeof (Order.OrderSide), cmbSide.Text);

                    order = new Order(txtClOrdID.Text, orderType, orderSide, cmbSymbol.Text);
                    
                    order.ClientOrderID = txtClOrdID.Text;

                    if (!string.IsNullOrEmpty(cmbCurrency.Text))
                    {
                        order.Currency = cmbCurrency.Text;
                    }

                }
                else
                {
                    order = orderToModify;
                }

                if (!string.IsNullOrEmpty(txtText.Text))
                {
                    order.Text = txtText.Text;
                }

                order.TransactTime = DateTime.Now;
                order.Quantity = double.Parse(txtQuantity.Text, System.Globalization.CultureInfo.InvariantCulture);
                if (Order.OrderType.Market != order.Type && Order.OrderType.ForeignExchangeMarketOrder != order.Type)
                {
                    order.Price = price;
                }

                if (null == orderToModify)
                {
                    tradingManager.SendNewOrder(order);
                }
            }
            catch (Exception ex)
            {
                logger_.LogError("Cannot Send Order: " + ex.Message);
                Trace.TraceError("Cannot Send Order: " + ex.Message);
                MessageBox.Show(this, ex.Message, "Cannot Send Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtClOrdID.Text = TradingManager.GetNextClientOrderID();
        }

        private void textBoxClOrdID_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((Control) sender, "");
        }

        private void comboBoxOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            if (0 == comboBox.Text.IndexOf(Order.OrderType.Market.ToString(), StringComparison.Ordinal) 
                || 0 == comboBox.Text.IndexOf(Order.OrderType.ForeignExchangeMarketOrder.ToString(), StringComparison.Ordinal) )
            {
                txtPrice.Enabled = false;
            }
            else
            {
                txtPrice.Enabled = true;
            }
        }
    }
}