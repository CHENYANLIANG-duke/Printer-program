using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32.SafeHandles;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        #region defined
        int i;
        int j;
        int k;
        String printername;
        List<List<String>> datatoprint = new List<List<String>>();  //以分號分開的陣列
        List<String> labeldata = new List<String>(); // 目標檔案夾內的所有.txt檔案陣列
        String todaytime;
        String today;
        String datapath = Path.GetDirectoryName(Application.UserAppDataPath); //設定檔路徑
        String datacfg;  //設定檔
        String zpldata;
        frm2 f2 = null;


        #endregion

        #region methond

        public void readdata()
        {
            labeldata.Clear();
            datatoprint.Clear();

            String[] filename = Directory.GetFiles(txtdatafolder.Text, "*.txt", SearchOption.AllDirectories); //SearchOption.AllDirectories 包含子資料夾

            if (txtdatafolder.Text == "")
            { MessageBox.Show("No connect path!!!"); }
            else
            {
                try  //防呆，預防目標資料夾內無txt檔
                {

                    for (i = 0; i < filename.Length; i++)
                    {
                        StreamReader sa = new StreamReader(filename[i]);
                        labeldata.Add(sa.ReadToEnd());   // list use add to load string
                        sa.Close();

                    }

                    for (i = 0; i < labeldata.Count; i++)
                    {
                        datatoprint.Add(labeldata[i].Split(';').ToList());  // 加到二維 (';')要 tolist

                        String S = String.Empty; //存放Replace後的字串
                        String A = zpldata;    // 保留原本的字串


                        for (j = 0; j < datatoprint.Capacity; j++) //讀取zpl版面自動替換 , list.capacity 可以讀出所有成員
                        {
                            A = A.Replace("ITEM" + j.ToString(), datatoprint[i][j]);
                            S = A;
                        }

                        f2.txtzpl.Text += S + "\r\n";
                        loginfo(S);

                        if (radlpt.Checked)
                        {
                            ZebraPrint.Print(S);
                        }
                        else if (radnet.Checked)
                        {
                            TCPIP(S);
                        }
                        else if (radusb.Checked)
                        {
                            RawPrinterHelper.SendStringToPrinter(comprint.SelectedItem.ToString(), S);
                            this.SelectNextControl(this.ActiveControl, true, true, true, true);
                        }
                    }

                }
                catch (Exception) { }
            }
        }

        public void printing()
        {
            for (i = 0; i < labeldata.Count; i++)
            {
                try
                {
                    string S = "^XA^LH0,0^FS  ";   //傳送字串給printer
                    S = S + "^LL600^FS";
                    S = S + "^FO 320,220 ^AEN, 56,30  ^FD" + datatoprint[i][3] + " ^FS";
                    S = S + "^FO 320,420 ^AEN, 56,30  ^FD" + datatoprint[i][2] + " ^FS";
                    S = S + "^XZ";

                    RawPrinterHelper.SendStringToPrinter(comprint.SelectedItem.ToString(), S);
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                catch (Exception) { }
            }
        }  //zpl版面寫死 

        public void saveconfig()
        {
            if ((txtdatafolder.Text == "") || (txtrecord.Text == "") || (comprint.SelectedItem == null) || (txtzpl.Text == ""))//若有一項無值時則無法紀錄
            {
                MessageBox.Show("請填寫完整");
            }
            else
            {
                StreamWriter sa = File.CreateText(Path.Combine(this.datapath, "unitechprint.cfg"));
                datacfg = txtdatafolder.Text + ";" + txtrecord.Text + ";" + comprint.SelectedItem.ToString() + ";" + txtzpl.Text;//將不同textbox寫成字串
                sa.Write(datacfg);
                sa.Flush();
                sa.Close();
                MessageBox.Show("save succesed!!");
            }
        }

        public void loadconfig()
        {
            try
            {
                StreamReader sa = File.OpenText(Path.Combine(this.datapath, "unitechprint.cfg"));
                datacfg = sa.ReadLine();
                String[] newdatacfg = datacfg.Split(';');//將讀出來的字串轉成陣列在塞回去
                txtdatafolder.Text = newdatacfg[0];
                txtrecord.Text = newdatacfg[1];
                comprint.SelectedItem = newdatacfg[2];
                txtzpl.Text = newdatacfg[3];
                sa.Close();

                StreamReader sb = new StreamReader(txtzpl.Text, Encoding.Default);  //載入zpl
                zpldata = sb.ReadToEnd();
                sb.Close();
                MessageBox.Show("ZPL Load Successful");
            }
            catch (Exception)
            { }
        }

        public void loginfo(String zpl)
        {
            DateTime date = DateTime.Now;
            today = date.ToString("yyyy-MM-dd");
            todaytime = date.ToString("yyyy-MM-dd HH:mm:ss");

            if (!Directory.Exists(txtrecord.Text + "\\Log"))      //新增log資料夾
            {
                Directory.CreateDirectory(txtrecord.Text + "\\Log");
            }
            File.AppendAllText(txtrecord.Text + "\\Log\\" + today + ".txt", "\r\n" + todaytime + "：" + "進行列印" + "\r\n" + zpl);//log資料夾路徑與內容
        }

        private void timer_memo_Tick(object sender, EventArgs e)
        {
            long data = Process.GetCurrentProcess().PeakWorkingSet64 / 1024; //取得巔峰記憶體用量
            txtmemorytime.Text = "記憶體用量:" + data / 1000 + "," + data % 1000 + "kb ";
        }

        private void timer_autorun_Tick(object sender, EventArgs e)
        {
            readdata();
            Deletedata();
        }

        public void Deletedata()  //刪除檔案
        {
            String[] filename = Directory.GetFiles(txtdatafolder.Text, "*.txt", SearchOption.AllDirectories);
            foreach (String filedelete in filename)
            { File.Delete(filedelete); }
        }

        private void TCPIP(String ZPLString)
        {
            string ipAddress = txtip.Text;

            // Printer IP Address and communication port
            int port = 9100;
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);

                // Write ZPL String to connection
                System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                // Catch Exception
            }
        } //tcpip

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }
            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        } //usb

        public static class ZebraPrint
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

            public static bool Print(String command)
            {
                bool isPrinter = false;
                // Command to be sent to the printer

                try
                {
                    // Create a buffer with the command
                    Byte[] buffer = new byte[command.Length];
                    buffer = System.Text.Encoding.ASCII.GetBytes(command);

                    // Use the CreateFile external func to connect to the LPT1 port
                    SafeFileHandle printer = CreateFile("LPT1:", FileAccess.Write, 0, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero);

                    // Test si imprimant valide
                    if (!printer.IsInvalid)
                    {
                        isPrinter = true;
                        // Open the filestream to the lpt1 port and send the command
                        FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
                        lpt1.Write(buffer, 0, buffer.Length);
                        // Close the FileStream connection
                        lpt1.Close();
                    }

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                return isPrinter;
            }
        } //LPT1 


        #endregion

        #region event

        private void btnfolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)    //path
            { txtdatafolder.Text = folderBrowserDialog1.SelectedPath; }
        }

        private void btnzpl_Click(object sender, EventArgs e)    //讀入zpl至zpldata
        {
            OpenFileDialog zpl = new OpenFileDialog();

            if (zpl.ShowDialog() == DialogResult.OK)
            {
                String filename = zpl.FileName;
                StreamReader sa = new StreamReader(filename, Encoding.Default);
                txtzpl.Text = filename;
                zpldata = sa.ReadToEnd();
                sa.Close();
                MessageBox.Show("ZPL Reading Successful");
            }
        }

        private void btnlogo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)  //path
            { txtrecord.Text = folderBrowserDialog2.SelectedPath; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            configbox.Enabled = false;
            groupprintmode.Enabled = false;

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printername = PrinterSettings.InstalledPrinters[i]; //列舉printer
                comprint.Items.Add(printername);
            }
            try
            {
                StreamReader sa = new StreamReader(txtzpl.Text, Encoding.Default);
                zpldata = sa.ReadToEnd();
                sa.Close();
            }
            catch (Exception) { }

            loadconfig();
        }

        private void btnautostart_Click(object sender, EventArgs e)
        {

            if (txtdatafolder.Text == "")
            {
                MessageBox.Show("請指定目錄");
            }
            else if (radusb.Checked == false && radnet.Checked == false && radlpt.Checked == false)
            {
                MessageBox.Show("請選擇傳輸介面");
            }
            else
            {
                if (btnautostart.Text == "AutoStart")
                {
                    if (txtip.Text == "" && radnet.Checked == true)
                    { MessageBox.Show("請輸入IP位置"); }
                    else
                    {
                        btnautostart.Text = "Pause";
                        configbox.Enabled = false;
                        btnstart.Enabled = false;

                        if (f2 == null)
                        {
                            f2 = new frm2();
                            f2.Disposed += new EventHandler(f2_Disposed);
                        }
                        f2.Show();
                        timer_autorun.Start();
                    }
                }
                else if (btnautostart.Text == "Pause")
                {
                    timer_autorun.Stop();
                    btnautostart.Text = "AutoStart";
                    configbox.Enabled = true;
                    btnstart.Enabled = true;
                }
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (txtlabelcount.Text == "")
            { MessageBox.Show("請輸入列印份數"); }
            else
            {
                if (txtdatafolder.Text == "")
                {
                    MessageBox.Show("請指定目錄");
                }
                else if (radusb.Checked == false && radnet.Checked == false && radlpt.Checked == false)
                {
                    MessageBox.Show("請選擇傳輸介面");
                }
                else
                {
                    if (btnstart.Text == "Start")
                    {
                        if (txtip.Text == "" && radnet.Checked == true)
                        { MessageBox.Show("請輸入IP位置"); }
                        else
                        {
                            btnstart.Text = "Pause";
                            configbox.Enabled = false;
                            btnautostart.Enabled = false;
                            txtip.Enabled = false;
                            txtlabelcount.Enabled = false;

                            if (f2 == null)
                            {
                                f2 = new frm2();
                                f2.Disposed += new EventHandler(f2_Disposed);
                            }
                            f2.Show();

                            for (k = 0; k < Convert.ToInt32(txtlabelcount.Text); k++)
                            {
                                readdata();
                            }
                            Deletedata();
                        }
                    }
                    else if (btnstart.Text == "Pause")
                    {
                        labeldata.Clear();
                        datatoprint.Clear();
                        btnstart.Text = "Start";
                        configbox.Enabled = true;
                        btnautostart.Enabled = true;
                        txtip.Enabled = true;
                    }
                }
            }
        }

        private void btnsaveseted_Click(object sender, EventArgs e)
        {
            saveconfig();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveconfig();
        }

        void f2_Disposed(object sender, EventArgs e)
        {
            f2 = null;   //Disposed 後把 f2 設為 null, 下次要用時再建新的 
        }

        private void radnet_CheckedChanged(object sender, EventArgs e)
        {
            if (radnet.Checked == false)
            {
                txtip.Visible = false;

            }
            else if (radnet.Checked == true)
            {
                txtip.Visible = true;
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {

            if (txtadmin.Text != "0000")
            {
                configbox.Enabled = false;
                groupprintmode.Enabled = false;

            }
            else
            {
                configbox.Enabled = true;
                groupprintmode.Enabled = true;

            }
        }

        #endregion

    }
}
