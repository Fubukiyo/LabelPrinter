using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Drawing.Printing;
using System.IO;
using System.Printing;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace printConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            string toPrint;

            while( true )
            {
                Console.WriteLine("Scan your barcode:");
                input = Console.ReadLine();
                toPrint = "${" + Environment.NewLine + "CT~~CD,~CC^~CT~" + Environment.NewLine + "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR2,2~SD30^JUS^LRN^CI0^XZ" + Environment.NewLine + "^XA" + Environment.NewLine + "^MMT" + Environment.NewLine + "^PW609" + Environment.NewLine + "^LL0203" + Environment.NewLine + "^LS-14" + Environment.NewLine + "^BY2,3,50^FT85,150^BCN,,N,N" + Environment.NewLine + "^fd>:" + input + "^fs" + Environment.NewLine + "^FT75,65^A0N,40,40^FH\\^FD" + input + "^fs" +Environment.NewLine + "^PQ2,0,1,Y^XZ" + Environment.NewLine + "}$";

                System.IO.File.WriteAllText("label.txt", toPrint);
                
                /*
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("label.txt", true))
                {
                    file.WriteLine(toPrint);
                }
                */

                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("label.txt");
                psi.Verb = "print";

                Process.Start(psi);
                /*
                PowerShell shell = PowerShell.Create();
                shell.AddCommand("Get-Content");
                shell.AddArgument("label.txt");
                shell.AddCommand("Out-Printer");
                shell.Invoke();
                */
            }
        }
    }
}
