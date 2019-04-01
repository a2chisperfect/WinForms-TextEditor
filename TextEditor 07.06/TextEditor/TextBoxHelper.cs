using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TextEditor
{
    static class TextBoxHelper
    {
        public static int GetLine(RichTextBoxPrintCtrl.RichTextBoxPrint e)
        {
            return e.GetLineFromCharIndex(e.SelectionStart);

        }
        public static int GetColumn(RichTextBoxPrintCtrl.RichTextBoxPrint e)
        {
            return e.SelectionStart - e.GetFirstCharIndexFromLine(GetLine(e));
        }
        public static void OpenFile(RichTextBoxPrintCtrl.RichTextBoxPrint e, string filePath)
        {
            RichTextBoxStreamType ext = Path.GetExtension(filePath) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText;
            e.LoadFile(filePath, ext);
            e.Tag = filePath;
            e.Modified = false;
        }
        public static void SaveFile(RichTextBoxPrintCtrl.RichTextBoxPrint e, string filePath)
        {
            RichTextBoxStreamType ext = Path.GetExtension(filePath) == ".txt" ? RichTextBoxStreamType.PlainText : RichTextBoxStreamType.RichText;
            e.SaveFile(filePath, ext);
            e.Tag = filePath;
            e.Modified = false;
        }
        public static int Find(RichTextBoxPrintCtrl.RichTextBoxPrint e, string template, bool matchCase, bool searchDown)
        {
            int index;
            RichTextBoxFinds caseComparison = matchCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
            if (searchDown)
            {
                index = e.Find(template, e.SelectionStart + e.SelectionLength, caseComparison);
            }
            else
            {
                index = e.Find(template, 0, e.SelectionStart, caseComparison | RichTextBoxFinds.Reverse);
            }
            return index;
        }
        public static void Replace(RichTextBoxPrintCtrl.RichTextBoxPrint e, string template, string newTemplate, bool matchCase)
        {
            if(matchCase)
            {
                if (e.SelectedText == template && e.SelectedText != null)
                {
                    e.SelectedText = newTemplate;
                }
            }
            else
            {
                if (e.SelectedText.ToUpper() == template.ToUpper() && e.SelectedText != null)
                {
                    e.SelectedText = newTemplate;
                }
            }
            
        }
        public static void ReplaceAll(RichTextBoxPrintCtrl.RichTextBoxPrint e, string template, string newTemplate, bool matchCase)
        {
            int index = 0;
            e.SelectionStart = index;
            RichTextBoxFinds caseComparison = matchCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;
            while (index != -1)
            {
                index = TextBoxHelper.Find(e, template, matchCase, true);
                if (index != -1)
                {
                    e.Select(index, template.Length);
                    TextBoxHelper.Replace(e, template, newTemplate, matchCase);
                }
            }
            e.SelectionLength = 0;
            e.SelectionStart = 0;
        }
        public static bool PasteImage(RichTextBoxPrintCtrl.RichTextBoxPrint e, string filePath)
        {
            Bitmap image = new Bitmap(filePath);
            Clipboard.SetDataObject(image);
            DataFormats.Format myDataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            if (e.CanPaste(myDataFormat))
            {
                e.Paste(myDataFormat);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
