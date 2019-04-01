using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace RichTextBoxPrintCtrl
{
    public class RichTextBoxPrint : RichTextBox
    {
        //Convert the unit used by the .NET framework (1/100 inch) 
        //and the unit used by Win32 API calls (twips 1/1440 inch)
        private const double anInch = 14.4;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;         //First character of range (0 for start of doc)
            public int cpMax;           //Last character of range (-1 for end of doc)
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;             //Actual DC to draw on
            public IntPtr hdcTarget;       //Target DC for determining text formatting
            public RECT rc;                //Region of the DC to draw to (in twips)
            public RECT rcPage;            //Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;         //Range of text to draw (see earlier declaration)
        }

        private const int WM_USER = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;

        [DllImport("USER32.dll")]
        //private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, ref FORMATRANGE lp);

        // Render the contents of the RichTextBox for printing
        //Return the last character printed + 1 (printing start from this point for next page)
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            //Calculate the area to render and print
            RECT rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

            //Calculate the size of the page
            RECT rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * anInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.Left = (int)(e.PageBounds.Left * anInch);
            rectPage.Right = (int)(e.PageBounds.Right * anInch);

            IntPtr hdc = e.Graphics.GetHdc();

            FORMATRANGE fmtRange = new  FORMATRANGE();
            fmtRange.chrg.cpMax = charTo;//Indicate character from to character to 
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.hdc = hdc;                    //Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc;              //Point at printer hDC
            fmtRange.rc = rectToPrint;             //Indicate the area on page to print
            fmtRange.rcPage = rectPage;            //Indicate size of page

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1); //Specifies whether to render the text. If this parameter is not zero, the text is rendered. Otherwise, the text is just measured.
            /*
            //Get the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            //Marshal Provides a collection of methods for allocating unmanaged memory, copying unmanaged memory blocks, and converting managed to unmanaged types, 
            //as well as other miscellaneous methods used when interacting with unmanaged code.
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));//returns an integer representing the address of the block of memory allocated. 
            Marshal.StructureToPtr(fmtRange, lparam, false);// Marshals data from a managed object to an unmanaged block of memory.
            //lparam - A FORMATRANGE structure containing information about the output device, or NULL to free information cached by the control.
            //Send the rendered data for printing 
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam);
            */
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, ref fmtRange);
            //Free the block of memory allocated
            //Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);

            //Return last + 1 character printer
            return res.ToInt32();
        }

    }
}