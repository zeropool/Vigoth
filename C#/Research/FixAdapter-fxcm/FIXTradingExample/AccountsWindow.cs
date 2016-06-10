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
  public partial class AccountsWindow : Form
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
    delegate void updateCallback(QuickFix44.CollateralReport report);

    private Dictionary<QuickFix.Account, int> map = new Dictionary<QuickFix.Account, int>();

    /**
     * Constructor
     */
    public AccountsWindow()
    {
      InitializeComponent();
      // configure and format the DataGridView
      grdAccounts.Columns.Add("AccountID", "AccountID");
      grdAccounts.Columns.Add("Balance", "Balance"); // endcash
      grdAccounts.Columns["Balance"].DefaultCellStyle.Format = "N";
      grdAccounts.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      grdAccounts.Columns.Add("UsedMargin", "UsedMargin"); //FXCMUsedMargin 9038
      grdAccounts.Columns["UsedMargin"].DefaultCellStyle.Format = "N";
      grdAccounts.Columns["UsedMargin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    /**
     * Return an array of QuickFix.Account
     */
    public QuickFix.Account[] accounts()
    {
      return map.Keys.ToArray<QuickFix.Account>();
    }

    /**
     * Update the DataGridView based on the given CollateralReport, thread-safe
     */
    public void update(QuickFix44.CollateralReport report)
    {
      if (grdAccounts.InvokeRequired)
      {
        updateCallback d = new updateCallback(update);
        this.Invoke(d, new object[] { report });
      }
      else
      {
        QuickFix.Account account = report.getAccount();
        double balance = 0D, used = 0D;
        // try to set the balance and used margin values from the report, if they exist
        try
        {
          balance = report.getEndCash().getValue();
          used = report.getDouble(9038); // FXCMUsedMargin
        }
        catch (Exception e) {}
        // if the account is already in the DataGridView
        if (map.ContainsKey(account))
        {
          // update the cells with the values that changed
          DataGridViewRow row = grdAccounts.Rows[map[account]];
          row.Cells["Balance"].Value = balance;
          row.Cells["UsedMargin"].Value = used;
        }
        else // otherwise add it to the DataGridView
        {
          map.Add(account, map.Count);
          grdAccounts.Rows.Add(
            account.getValue(),
            balance,
            used
          );
        }
        // force the interface to refresh
        Application.DoEvents();
      }
    }
  }
}
