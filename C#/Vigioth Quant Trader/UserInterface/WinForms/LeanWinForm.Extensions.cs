

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VigiothCapital.QuantTrader.Views.WinForms
{
    /// <summary>
    /// Public extensions methods for the forms.
    /// Credit: http://stackoverflow.com/questions/1926264/color-different-parts-of-a-richtextbox-string/1926822#1926822
    /// </summary>
    public static class Extensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text + Environment.NewLine);
            box.SelectionColor = box.ForeColor;
            box.ScrollToCaret();
        }

        /// <summary>
        /// Cross thread invokation
        /// </summary>
        public static TResult SafeInvoke<T, TResult>(this T isi, Func<T, TResult> call) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired)
            {
                IAsyncResult result = isi.BeginInvoke(call, new object[] { isi });
                object endResult = isi.EndInvoke(result);
                return (TResult)endResult;
            }
            else
                return call(isi);
        }
    }
}
