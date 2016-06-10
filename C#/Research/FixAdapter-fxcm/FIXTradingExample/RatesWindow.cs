using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace FIXTradingExample
{
    public partial class RatesWindow : Form
    {
        #region Disable Close Button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        #endregion

        // delegate for the update function
        delegate void updateCallback(QuickFix44.MarketDataSnapshotFullRefresh snapshot);

        private Dictionary<QuickFix.Symbol, int> map = new Dictionary<QuickFix.Symbol, int>();
        Timer t = new Timer();
        Timer ts = new Timer();


        /**
         * Constructor
         */
        public RatesWindow()
        {
            InitializeComponent();
            t = new Timer();
            t.Tick += T_Tick;
            t.Interval = 1000;
            t.Start();
            ts = new Timer();
            ts.Tick += Ts_Tick;
            ts.Interval = 1000;
            ts.Start();


            // create and format the columns of the DataGridView
            grdRates.Columns.Add("Instrument", "Instrument");
            grdRates.Columns.Add("Updated", "Updated");
            grdRates.Columns["Updated"].DefaultCellStyle.Format = "HH:mm:ss dd MMM yy";
            grdRates.Columns.Add("Bid", "Bid");
            grdRates.Columns["Bid"].DefaultCellStyle.Format = "N5";
            grdRates.Columns["Bid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdRates.Columns.Add("Ask", "Ask");
            grdRates.Columns["Ask"].DefaultCellStyle.Format = "N5";
            grdRates.Columns["Ask"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdRates.Columns.Add("Volume", "Volume");
            grdRates.Columns["Volume"].DefaultCellStyle.Format = "N5";
            grdRates.Columns["Volume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdRates.Columns.Add("MinQuantity", "MinQuantity");
        }

        private void Ts_Tick(object sender, EventArgs e)
        {

        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (grdRates != null)
            {
                if (grdRates.Rows.Count > 0)
                {
                    foreach (var r in grdRates.Rows as dynamic)
                    {
                        var tick = DateTime.Now;
                        Global.AddTick(Convert.ToString(r.Cells["Instrument"].Value), new TimeMarker
                        {
                            Ask = Convert.ToDouble(r.Cells["Ask"].Value),
                            Bid = Convert.ToDouble(r.Cells["Bid"].Value),
                            TimeStamp = tick
                        }, tick);
                    };

                    StringBuilder sb = new StringBuilder();
                    foreach (var r in grdRates.Rows as dynamic)
                        sb.Append(String.Format("Insert FX Values ( '{0}','{1}',{2},{3},0 )" + Environment.NewLine, r.Cells["Instrument"].Value, DateTime.Now, r.Cells["Bid"].Value, r.Cells["Ask"].Value));

                    System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection("server=sql1.epicservers.com; database=epicdev; uid=sa; pwd=exigorules");
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sb.ToString(), cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    cmd.Dispose();
                    cnn.Dispose();

                }
            }
        }

     
        public QuickFix.Symbol[] symbols()
        {
            return map.Keys.ToArray<QuickFix.Symbol>();
        }
        public double minQty(QuickFix.Symbol symbol)
        {
            return Convert.ToDouble(grdRates.Rows[map[symbol]].Cells["MinQuantity"].Value);
        }

        

        public void update(QuickFix44.MarketDataSnapshotFullRefresh snapshot)
        {
            if (grdRates.InvokeRequired)
            {
                updateCallback d = new updateCallback(update);
                this.Invoke(d, new object[] { snapshot });
            }
            else
            {
                QuickFix.Symbol instrument = snapshot.getSymbol();
                double minQty = 0D;
            
                // if the currency is already in the DataGridView
                if (map.ContainsKey(instrument))
                {
                    // update only the cells of the row that have changed
                    DataGridViewRow row = grdRates.Rows[map[instrument]];
                    row.Cells["Updated"].Value = getClose(snapshot);
                    row.Cells["Bid"].Value = getPrice(snapshot, "0", Convert.ToDouble(row.Cells["Bid"].Value));
                    row.Cells["Ask"].Value = getPrice(snapshot, "1", Convert.ToDouble(row.Cells["Ask"].Value));
                    row.Cells["MinQuantity"].Value = minQty;
                }
                else // otherwise add it to the DataGridView
                {
                    map.Add(instrument, map.Count);
                    grdRates.Rows.Add(
                      instrument,
                      getClose(snapshot),
                      getPrice(snapshot, "0", 0D),
                      getPrice(snapshot, "1", 0D),
                      minQty
                    );
                }
                // force the interface to refresh
                //Application.DoEvents();
            }
        }

        private void grdRates_DataError(object sender, DataGridViewDataErrorEventArgs e) { }
        private double getPrice(QuickFix44.MarketDataSnapshotFullRefresh mds, String p, double previous)
        {
            double price = previous;
            try
            {
                // grab the market data entries from the snapshot
                QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries group = new QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries();
                // go through the entries
                for (uint i = 1; i <= mds.getNoMDEntries().getValue(); i++)
                {
                    group = (QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries)mds.getGroup(i, group);
                    //if the entry type is the price requested, set the price to the value of the entry price
                    if (group.getMDEntryType().getValue().Equals(p[0])) price = group.getMDEntryPx().getValue();
                }
            }
            catch (Exception e) { } // ignore errors
            return price; // if not found, return the previous rate
        }
        private DateTime getClose(QuickFix44.MarketDataSnapshotFullRefresh mds)
        {
            DateTime close = new DateTime(0L);
            try
            {
                DateTime last = new DateTime(0L);
                QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries group = new QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries();
                for (uint i = 1; i < mds.getNoMDEntries().getValue(); i++)
                {
                    group = (QuickFix44.MarketDataSnapshotFullRefresh.NoMDEntries)mds.getGroup(i, group);
                    if (group.getMDEntryTime().getValue() != null)
                    {
                        last = new DateTime(group.getMDEntryDate().getValue().Ticks + group.getMDEntryTime().getValue().Ticks);
                        close = ((close.Ticks > last.Ticks) ? close : last);
                    }
                }
            }
            catch (Exception e) { }
            return TimeZoneInfo.ConvertTime(close, TimeZoneInfo.Utc, TimeZoneInfo.Local);
        }
    }
}
