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

using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace TradingClientSample
{
    public partial class SecurityDefinitionsViewControl : UserControl
    {
		public SecurityDefinitionsViewControl()
        {
            InitializeComponent();
        }

		public void ProcessSecurityDefinition(MarketDataHandler.SecurityDefinitionArgs securityDefinition)
		{
			DataGridViewRow row;
			if (symbol2dataGridViewRow.ContainsKey(securityDefinition.Symbol))
			{
				row = symbol2dataGridViewRow[securityDefinition.Symbol];
			}
			else
			{
				int index = dataGridView.Rows.Add();
				row = dataGridView.Rows[index];
				symbol2dataGridViewRow.Add(securityDefinition.Symbol, row);
				row.Cells[symbolColumn.Index].Value = securityDefinition.Symbol;
			}
		}

        public void Reset()
        {
            Invoke(new EventHandler(SafeReset));
        }

        private void SafeReset(object sender, EventArgs args)
        {
            symbol2dataGridViewRow.Clear();
            dataGridView.Rows.Clear();
        }

		private Dictionary<string, DataGridViewRow> symbol2dataGridViewRow = new Dictionary<string, DataGridViewRow>();
	}
}
