using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIXTradingExample
{
  public partial class TradesWindow : Form
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

    // delegate for the update functions
    delegate void updateCallback1(QuickFix44.ExecutionReport report);
    delegate void updateCallback2(QuickFix44.PositionReport report);

    private Dictionary<String, int> orderMap = new Dictionary<string, int>();
    private Dictionary<String, int> tradesMap = new Dictionary<string, int>();

    /**
     * Constructor
     */
    public TradesWindow()
    {
      InitializeComponent();
      grdOrders.Columns.Add("Account", "Account");
      grdOrders.Columns.Add("Status", "Status");
      grdOrders.Columns.Add("ID", "ID");
      grdOrders.Columns.Add("Instrument", "Instrument");
      grdOrders.Columns.Add("OpenID", "OpenID");
      grdOrders.Columns.Add("Open", "Open");
      grdOrders.Columns["Open"].DefaultCellStyle.Format = "N5";
      grdOrders.Columns["Open"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

      grdTrades.Columns.Add("Account", "Account");
      grdTrades.Columns.Add("Status", "Status");
      grdTrades.Columns.Add("ID", "ID");
      grdTrades.Columns.Add("Instrument", "Instrument");
      grdTrades.Columns.Add("OpenID", "OpenID");
      grdTrades.Columns.Add("CloseID", "CloseID");
      grdTrades.Columns.Add("Open", "Open");
      grdTrades.Columns["Open"].DefaultCellStyle.Format = "N5";
      grdTrades.Columns["Open"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      grdTrades.Columns.Add("Close", "Close");
      grdTrades.Columns["Close"].DefaultCellStyle.Format = "N5";
      grdTrades.Columns["Close"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      grdTrades.Columns.Add("PL", "PL");
      grdTrades.Columns["PL"].DefaultCellStyle.Format = "N2";
      grdTrades.Columns["PL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    /**
     * Update the DataGridView based on the given ExecutionReport, thread-safe
     */
    public void update(QuickFix44.ExecutionReport report)
    {
      if (grdOrders.InvokeRequired)
      {
        updateCallback1 d = new updateCallback1(update);
        this.Invoke(d, new object[] { report });
      }
      else
      {
        String reportID = report.getOrderID().getValue();
        // if the order is already in the DataGridView
        if (orderMap.ContainsKey(reportID))
        {
          // update the cells with the values that changed
          DataGridViewRow row = grdOrders.Rows[orderMap[reportID]];
          row.Cells["Status"].Value = report.getString(9051); // FXCMOrdStatus
          row.Cells["Open"].Value = report.getPrice().getValue();
          // scroll to the updated row
          grdOrders.CurrentCell = grdOrders[0, orderMap[reportID]];
        }
        else // otherwise add it to the DataGridView
        {
          orderMap.Add(reportID, orderMap.Count);
          grdOrders.Rows.Add(
            report.getAccount().getValue(),
            report.getString(9051), // FXCMOrdStatus
            reportID,
            report.getSymbol().getValue(),
            report.getOrderID().getValue(),
            report.getPrice().getValue()
          );
          // scroll to the added row
          grdOrders.CurrentCell = grdOrders[0, orderMap.Count - 1];
        }
        // force the interface to refresh
        Application.DoEvents();
      }
    }

    /**
     * Update the DataGridView based on the given PositionReport, thread-safe
     */
    public void update(QuickFix44.PositionReport report)
    {
      if (grdTrades.InvokeRequired)
      {
        updateCallback2 d = new updateCallback2(update);
        this.Invoke(d, new object[] { report });
      }
      else
      {
        String reportID = report.getString(9041); // FXCMPosID
        double pl = 0D;
        //try { pl = report.getDouble(9052); } // FXCMPosClosePNL
        //catch (Exception e) { }
        //String closeID = "";
        //try { closeID = report.getString(9054); }
        //catch (Exception e) { }
        //double close = 0D;
        //try { close = report.getDouble(9043); }
        //catch (Exception e) { }
        // if the position is already in the DataGridView
        if (tradesMap.ContainsKey(reportID))
        {
          // update the cells with the values that changed
          DataGridViewRow row = grdTrades.Rows[tradesMap[reportID]];
          row.Cells["Status"].Value = ((report.getPosReqType().getValue() == QuickFix.PosReqType.POSITIONS) ? "O" : "C");
          row.Cells["CloseID"].Value = 0;
          row.Cells["Open"].Value = report.getSettlPrice().getValue();
          row.Cells["Close"].Value = 0;
          row.Cells["PL"].Value = pl;
          // scroll to the updated row
          grdTrades.CurrentCell = grdTrades[0, tradesMap[reportID]];
        }
        else // otherwise add it to the DataGridView
        {
          tradesMap.Add(reportID, tradesMap.Count);
          grdTrades.Rows.Add(
            report.getAccount().getValue(),
            ((report.getPosReqType().getValue() == QuickFix.PosReqType.POSITIONS) ? "O" : "C"),
            reportID,
            report.getSymbol().getValue(),
            report.getString(37), // OrderID
            0,
            report.getSettlPrice().getValue(),
            0,
            pl
          );
          // scroll to the added row
          grdTrades.CurrentCell = grdTrades[0, tradesMap.Count - 1];
        }
        // force the interface to refresh
        Application.DoEvents();
      }
    }
 }
}
