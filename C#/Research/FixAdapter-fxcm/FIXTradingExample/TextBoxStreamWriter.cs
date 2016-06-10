using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FIXTradingExample
{
  class TextBoxStreamWriter : TextWriter
  {
    private LoginWindow output;
    public TextBoxStreamWriter(LoginWindow output)
    {
      this.output = output;
    }
    public override void Write(char value)
    {
      output.SetText(value.ToString());
      base.Write(value);
    }
    public override Encoding Encoding
    {
      get { return System.Text.Encoding.UTF8; }
    }
  }
}
