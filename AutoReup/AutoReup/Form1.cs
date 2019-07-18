using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace AutoReup
{
    public partial class Form1 : Form
    {
        BackgroundWorker bwReup;
        private bool stop;
        private bool stopByError;
        CShop shop;
        int build;
        bool flag = false;    //danh dau doi pass that bai
        info infoform = new info();
        int currentPtxtLog = 0;
        int countss;
        bool checkError=true;           //check xem đã click xem acc lỗi chưa



        public Form1()
        {
            InitializeComponent();
            bwReup = new BackgroundWorker();
            bwReup.WorkerReportsProgress = true;
            bwReup.WorkerSupportsCancellation = true;
            bwReup.DoWork += bwReup_DoWork;
            //bwReup.ProgressChanged += bwReup_ProgressChanged;
            bwReup.RunWorkerCompleted += bwReup_RunWorkerCompleted;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            build =5;

            switch (build)
            {
                case 0:
                    Form2 pass = new Form2();
                    pass.ShowDialog();
                    txtRentAccID.Enabled = true;
                    if (!pass.isRightPass())
                        this.Close();
                    else
                    {
                        session_time.Interval = 1000 * 60*5;
                        session_time.Start();
                    }

                    string content = "huydwayne+ahaha@gmail.com";
                    int StartName = content.IndexOf("huydwayne+", 0) + "huydwayne+".Length;
                    int EndName = content.IndexOf("@gmail.com", 0);
                    string idGetFromMail = content.Substring(StartName, EndName - StartName);

                    break;
                case 1:
                    this.Text += " Yan Shop (Rentpubg)";
                    this.Location = new System.Drawing.Point(100, 50);
                    txtRentAccID.Text = "yanshop0027@gmail.com";
                    txtRentAccPass.Text = "tranluudOngTien711";
                    txtToken.Text = "hYG88rJWX8sK5eBv";
                    txtEmailID.Text = "khacdoan27@gmail.com";
                    txtEmailPass.Text = "tranluuD0ngTien27";
                    infoform.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 246, 25);
                    nico.Text += " (Yan)";
                    break;
                case 2:
                    this.Text += " Tien Shop (Rentpubg)";
                    this.Location = new System.Drawing.Point(100, 50);
                    txtRentAccID.Text = "dongtien0711@gmail.com";
                    txtRentAccPass.Text = "tranluudOngTien711";
                    txtToken.Text = "z4Thold1PxRkWao7";
                    txtEmailID.Text = "dongtien0711@gmail.com";
                    txtEmailPass.Text = "tranluuD0ngTien27";
                    infoform.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 246, 25);
                    nico.Text += " (Tien)";
                    break;
                case 3:
                    this.Text += " Vit Shop";
                    this.Location = new System.Drawing.Point(1100, 650);
                    txtRentAccID.Text = "vitcon0027@gmail.com";
                    txtRentAccPass.Text = "yanshop9436";
                    txtToken.Text = "o8aRhkYM8Rabg3lh";
                    txtEmailID.Text = "vitcon0027@gmail.com";
                    txtEmailPass.Text = "demainoicho9596";
                    break;
                case 4:
                    txtRentAccID.Text = "huydwayne@yahoo.com";
                    txtRentAccPass.Text = "huy@$*(&$!%(^#";
                    txtEmailID.Text = "huydwayne@gmail.com";
                    txtEmailPass.Text = "anhhuy2489&$!%(^#";
                    infoform.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 246, 0);
                    break;
                case 5:
                    this.Text += " Kawaii Shop";
                    this.Location = new System.Drawing.Point(100, 50);
                    txtRentAccID.Text = "0976746715";
                    txtRentAccPass.Text = "hoangduatcute";
                    txtEmailID.Text = "dongtien0711@gmail.com";
                    txtEmailPass.Text = "tranluuD0ngTien27";
                    infoform.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - 246, 25);
                    break;


            }
            this.Text += " - Ver ";
            this.Text += new FileInfo(Application.ExecutablePath).LastWriteTime.ToString("yy.MM.dd");

        }
        private void session_Tick(object sender, EventArgs e)
        {
       

        }

        void bwReup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (stopByError==true)
            {
                //InboxAdmin("Tool tạm dừng(line78)!");
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                cmdStart.Text = "START";
                cmdStart.BackColor = Color.White;
                cmdStart.Enabled = true;
                timer.Stop();
                txtEmailID.ReadOnly = false;
                txtEmailPass.ReadOnly = false;
                txtRentAccID.ReadOnly = false;
                txtRentAccPass.ReadOnly = false;
            });
        }



        void bwReup_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    cmdStart.Enabled = false;

                    txtEmailID.ReadOnly = true;
                    txtEmailPass.ReadOnly = true;
                    txtRentAccID.ReadOnly = true;
                    txtRentAccPass.ReadOnly = true;
                });

                REUP();
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n";
                WriteBugLog(log);
            }
        }

        void REUP2()
        {
            try
            {

            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n";
                WriteBugLog(log);
            }
        }

        void REUP()
        {
            int i;
            try
            {
                shop.RentPubgConstructer(chkShowBrowser.Checked);
                shop.LoginRentPubgByFacebook();
                shop.ConnectMail();

                bool firstTimeNoReup = false;
                while (stop == false)
                {

                    if (chkUpdateTotal.Checked == true)
                    {
                        shop.UpdateTotal();
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            lblRevenue.Text = "Doanh thu: " + shop.GetRevenue();
                            lblNumberOfRent.Text = "Lượt thuê: " + shop.GetNumberOfRent();
                            lblEnd.Text = "Reup: " + shop.GetEnd();
                            lblError.Text = "Lỗi: " + shop.GetError();
                            lblReady.Text = "Sẵn sàng: " + shop.GetReady();
                            lblRent.Text = "Đang được thuê: " + shop.GetRent();
                            string tmp1, tmp2;
                            tmp1 = ((float.Parse(shop.GetRent()) / (int.Parse(shop.GetRent()) + int.Parse(shop.GetReady()))) * 100).ToString();
                            try
                            {
                                tmp1 = tmp1.Remove(tmp1.IndexOf(','));
                            }
                            catch { }
                            tmp2 = ((float.Parse(shop.GetRentWeb()) / (int.Parse(shop.GetRentWeb()) + int.Parse(shop.GetReadyWeb()))) * 100).ToString();
                            try
                            {
                                tmp2 = tmp2.Remove(tmp2.IndexOf(','));
                            }
                            catch { }
                            lblRateRent.Text = "S/W: " + tmp1 + "% / " + tmp2 + "%";

                            infoform.UpdateTotal(shop.GetRevenue(), shop.GetNumberOfRent(), shop.GetError(), shop.GetEnd(), shop.GetRent(), shop.GetReady(), shop.GetRentWeb(), shop.GetReadyWeb(), tmp2, tmp1);
                        });
                    }
                    else
                    {
                        shop.NotUpdateTotal();
                    }
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        if (shop.getCountErrorList() < int.Parse(shop.GetError()))
                        {
                            nico.Visible = true;
                            string numberban = (int.Parse(shop.GetError()) - shop.getCountErrorList()).ToString();
                            nico.ShowBalloonTip(99999999, "Thông báo từ Rentpubg!", "Phát hiện " + numberban + " acc lỗi.", ToolTipIcon.Warning);
                            nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\warning.ico");
                            checkError = false;
                            shop.UPDATEERRORLIST();
                        }

                       
                    });


                    i = 0;


                    if (firstTimeNoReup == false||shop.GetEnd()!="0")
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            lbltime.Text = "00";
                            timer.Start();
                        });
                    }


                    if (shop.GetReupInfoRentPubg())
                    {
                        firstTimeNoReup = false;
                        this.Invoke((MethodInvoker)delegate ()
                        {

                            txtLog.Text += " - " + shop.GetCurrentSteamID() + "\r\n";
                            lblCurrentIDSteam.Text = shop.GetCurrentSteamID();
                            lblWorking.Text = "Lấy reup info thành công.";
                            progressbar.Value = 0;
                            PERFORMSTEPTO(ref progressbar, 10);
                        });
                       


                        flag = false;
                        trychangepass:
                        string error_content;
                        shop.ConstructerSteam(chkShowBrowser.Checked);
                        error_content = shop.LoginSteam();
                        tryloginsteam:
                        if (error_content == "Success")
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                if (i != 0)
                                {
                                    lblCurrentIDSteam.Text = shop.GetCurrentSteamID() + " lần " + i.ToString();
                                }
                                txtLog.Text += " - Login Steam thành công.\r\n";
                                lblWorking.Text = "Login Steam thành công.";
                                PERFORMSTEPTO(ref progressbar, 20);
                            });
                            error_content = shop.SkipSendMessage();
                            if (error_content == "Success")
                            {
                                error_content = shop.SendMail();
                                if (error_content == "Success")
                                {
                                    this.Invoke((MethodInvoker)delegate ()
                                    {
                                        txtLog.Text += " - Gửi mail thành công.\r\n";
                                        lblWorking.Text = "Gửi mail thành công.";
                                        PERFORMSTEPTO(ref progressbar, 30);
                                    });
                                    error_content = shop.GetVerificationCode();
                                    if (error_content == "Success")
                                    {
                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            txtLog.Text += " - Lấy CODE thành công.\r\n";
                                            lblWorking.Text = "Lấy CODE thành công.";
                                            PERFORMSTEPTO(ref progressbar, 50);
                                        });
                                        error_content = shop.FillVerificationCode();
                                        if (error_content == "Success")
                                        {
                                            this.Invoke((MethodInvoker)delegate ()
                                            {
                                                txtLog.Text += " - Điền CODE thành công.\r\n";
                                                lblWorking.Text = "Điền CODE thành công.";
                                                PERFORMSTEPTO(ref progressbar, 70);
                                            });
                                           
                                            error_content = shop.FillNewPassword();
                                            string log = String.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now) + lbltime.Text + "s\r\n" + shop.GetCurrentInfo() + "\r\n";
                                            shop.WriteLog("Reup" + txtRentAccID.Text + ".txt", log);
                                            if (error_content == "Success")
                                            {
                                                this.Invoke((MethodInvoker)delegate ()
                                                {
                                                    txtLog.Text += " - Đổi password thành công.\r\n";
                                                    lblWorking.Text = "Đổi password thành công.";
                                                    PERFORMSTEPTO(ref progressbar, 90);

                                                });
                                            }
                                            else
                                            {
                                                this.Invoke((MethodInvoker)delegate ()
                                                {
                                                    txtLog.Text += " - Đổi password thất bại.\r\n";
                                                    lblWorking.Text = "Đổi password thất bại.";
                                                    PERFORMSTEPTO(ref progressbar, 90);
                                                });
                                            }
                                        }
                                        else
                                        {
                                            this.Invoke((MethodInvoker)delegate ()
                                            {
                                                txtLog.Text += " - Điền CODE thất bại.\r\n";
                                                lblWorking.Text = "Điền CODE thất bại.";
                                                PERFORMSTEPTO(ref progressbar, 70);
                                            });
                                        }
                                    }
                                    else
                                    {
                                        this.Invoke((MethodInvoker)delegate ()
                                        {
                                            txtLog.Text += " - Lấy CODE thất bại.\r\n";
                                            lblWorking.Text = "Lấy CODE thất bại.";
                                            PERFORMSTEPTO(ref progressbar, 50);
                                        });
                                    }
                                }
                                else
                                {
                                    this.Invoke((MethodInvoker)delegate ()
                                    {
                                        txtLog.Text += " - Gửi mail thất bại.\r\n";
                                        lblWorking.Text = "Gửi mail thất bại.";
                                        PERFORMSTEPTO(ref progressbar, 30);
                                    });
                                }
                            }
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                txtLog.Text += " - Login Steam thất bại.\r\n";
                                lblWorking.Text = "Login Steam thất bại.";
                                PERFORMSTEPTO(ref progressbar, 20);
                            });
                            System.Threading.Thread.Sleep(1000);
                            
                            //lay pass từ list làm newpass, nhưng newpass trên web # pass ở list
                            //khi f5 thì sẽ ra pass mới nên k dùng đoạn này 
                            //if (error_content.Contains( "WrongIDPW"))
                            //{
                            //    error_content = shop.LoginSteam(shop.GetNew);
                            //    if (error_content == "Success")
                            //    {
                            //        this.Invoke((MethodInvoker)delegate ()
                            //        {
                            //            txtLog.Text += " - Login Steam bằng mật khẩu mới thành công.\r\n";
                            //            lblWorking.Text = "Login Steam bằng mật khẩu mới thành công.";
                            //            PERFORMSTEPTO(ref progressbar, 20);
                            //        });
                            //    }
                            //}

                        }

                        shop.QUITDRIVER();

                        if (error_content == "Success")
                        {
                            Console.WriteLine("REUP ACCOUNT");
                            shop.ReupAccountRentPubg();
                            shop.SetGiaAccount();

                            //string log = String.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now) + lbltime.Text + "s\r\n" + shop.GetCurrentInfo() + "\r\n";
                            //shop.WriteLog("Reup" + txtRentAccID.Text + ".txt", log);
                            //error_content = shop.FillNewPassword();
                            //if (error_content == "Success")
                            //{
                            //    this.Invoke((MethodInvoker)delegate ()
                            //    {
                            //        txtLog.Text += " - Đổi password thành công.\r\n";
                            //        lblWorking.Text = "Đổi password thành công.";
                            //        PERFORMSTEPTO(ref progressbar, 90);

                            //    });
                            //}
                            //else
                            //{
                            //    this.Invoke((MethodInvoker)delegate ()
                            //    {
                            //        txtLog.Text += " - Đổi password thất bại.\r\n";
                            //        lblWorking.Text = "Đổi password thất bại.";
                            //        PERFORMSTEPTO(ref progressbar, 90);
                            //    });
                            //    shop.Changepass();
                            //}

                            //shop.QUITDRIVER();






                            this.Invoke((MethodInvoker)delegate ()
                            {
                                timer.Stop();
                                txtLog.Text += " - Reup thành công trong " + lbltime.Text + "s.\r\n\n\r\n\n";
                                lblWorking.Text = "Reup thành công.";
                                PERFORMSTEPTO(ref progressbar, 100);
                            });
                        }
                        else if (error_content.Contains("NotChanged") || error_content.Contains("ChaBietBiGi") || error_content.Contains("IPMailError") || error_content.Contains("IPLoginError") || error_content.Contains("WrongIDPW"))
                        {

                            string e = "";
                            if (error_content.Contains("IPMailError"))
                                e = "IPMailError";
                            if (error_content.Contains("IPLoginError"))
                                e = "IPLoginError";
                            if (error_content.Contains("WrongIDPW"))
                                e = "WrongIDPW";
                            if (error_content.Contains("ChaBietBiGi"))
                                e = "ChaBietBiGi";
                            if (error_content.Contains("NotChanged"))
                                e = "NotChanged";
                            string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + e + "\r\n" + shop.GetCurrentInfo() + "\r\n";
                            shop.WriteLog("Stop" + txtRentAccID.Text + ".txt", log);

                            //if (e == "WrongIDPW")
                            //{
                            //    Console.WriteLine("STOP ACCOUNT");
                            //    shop.StopAccountRentPubg();
                            //    this.Invoke((MethodInvoker)delegate ()
                            //    {
                            //        timer.Stop();
                            //        lblWorking.Text = "Stop thành công.";
                            //        txtSkipLog.Text += log + "\n";
                            //        PERFORMSTEPTO(ref progressbar, 100);
                            //    });
                            //}
                            //else if (e != "WrongIDPW")

                            {
                                Console.WriteLine("SKIP ACCOUNT");
                                shop.AddSkipList(shop.GetCurrentSteamID());
                                nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\error.ico");
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    timer.Stop();
                                    lblWorking.Text = "Skip thành công.";
                                    txtSkipLog.Text += log + "\r\n\n";
                                    PERFORMSTEPTO(ref progressbar, 100);
                                });
                            }

                            //shop.QUITDRIVER();

                        }
                        else
                        {
                            //shop.QUITDRIVER();

                            this.Invoke((MethodInvoker)delegate ()
                            {
                                progressbar.Value = 20;
                            });
                            if (i++ < 3)
                            {
                                goto trychangepass;
                            }
                            else
                            {
                                nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\error.ico");
                                shop.AddSkipList(shop.GetCurrentSteamID());
                            }
                        }
                    }
                    else
                    {
                        if (shop.GetEnd() == "0")
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                firstTimeNoReup = true;
                                txtLog.Text += " - Không có acc cần reup.\r\n";
                                lblCurrentIDSteam.Text = "Không có acc cần reup.";
                                nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\refresh.ico");
                                lblWorking.Text = "Do nothing.";
                                progressbar.Value = 0;
                            });
                            System.Threading.Thread.Sleep(60000);
                            shop.RefreshRentPubg();
                            System.Threading.Thread.Sleep(5000);
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                txtLog.Text += " - Chờ acc hết lỗi!\r\n";
                                lblCurrentIDSteam.Text = "Chờ acc hết lỗi!";
                                lblWorking.Text = "Do nothing.";
                                progressbar.Value = 0;
                            });
                            System.Threading.Thread.Sleep(60000);
                            shop.RefreshRentPubg();
                            System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + ".\r\n";
                WriteBugLog(log);
            }
        }

        void Ping(string content)
        {
            trysendmes:
            try
            {
                string curPath = Directory.GetCurrentDirectory();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(curPath + "\\chromedriver");
                service.HideCommandPromptWindow = true;
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("headless");
                option.AddArgument("--no-sandbox");
                IWebDriver mes = new ChromeDriver(service, option);
                mes.Url = "https://www.facebook.com/";
                mes.Navigate();

                mes.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys("phan.nguyen504");
                mes.FindElement(By.XPath("//*[@id=\"pass\"]")).SendKeys("taolabot54");
                mes.FindElement(By.XPath("//*[@id=\"loginbutton\"]")).Click();

                mes.Url = "https://m.facebook.com/messages/read/?tid=100004570840557&entrypoint=web%3Atrigger%3Ajewel_see_all_messages";
                mes.Navigate();

                content = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + "\n" + content;
                //WebDriverWait wait = new WebDriverWait(mes, TimeSpan.FromSeconds(30));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"u_0_s\"]/div/div/div[2]/span[1]/div[2]/div[2]/div[2]/div[1]/div/div[1]/div/div[1]/div/div[2]/div/div/div/div/span/br")));

                mes.FindElement(By.XPath("//*[@id=\"composerInput\"]")).SendKeys(content);
                mes.FindElement(By.XPath("//*[@id=\"u_0_1\"]/div[1]/div[3]/div[4]/button[1]")).Submit();

                mes.Close();
                mes.Dispose();
                mes.Quit();
            }
            catch (CException error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n";
                WriteBugLog(log);
                goto trysendmes;
            }
        }


        void PERFORMSTEPTO(ref ProgressBar bar, int percent)
        {
            for (int i = bar.Value; i <= percent; i++)
            {
                System.Threading.Thread.Sleep(10);
                bar.PerformStep();
            }
        }


        private void cmdStop_Click(object sender, EventArgs e)
        {
            stop = true;
            stopByError = false;
            Console.WriteLine("STOP");
            checkRun.Stop();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            START_TOOL();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

            if (txtLog.Focused == false)
            {
                currentPtxtLog = txtLog.Text.Length;
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
            else
            {
                txtLog.SelectionStart = currentPtxtLog;
                txtLog.ScrollToCaret();
            }
        }

    


        private void txtSkipLog_TextChanged(object sender, EventArgs e)
        {
            if (txtSkipLog.Focused == false)
            {
                txtSkipLog.SelectionStart = txtLog.Text.Length;
                txtSkipLog.ScrollToCaret();
            }
        }
      

        private void chkShowSkipLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSkipLog.CheckState == CheckState.Unchecked)
            {
                this.ClientSize = new System.Drawing.Size(this.ClientSize.Width,this.ClientSize.Height-209);
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(this.ClientSize.Width,this.ClientSize.Height+209);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int tm = Int32.Parse(lbltime.Text);
            tm++;
            

            if (tm== 600)
            {
                stop = true;
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                lbltime.Text = tm.ToString();
            });  
        }

        //////////////////////////////

        public void WriteBugLog(string logs)
        {                                                                            
            if (File.Exists(Application.StartupPath + "/Logs/" + "BugLogs.txt") == true)
            {
                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + "BugLogs.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
            }
            else
            {
                File.Create(Application.StartupPath + "/Logs/" + "BugLogs.txt").Dispose();

                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + "BugLogs.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countss++;
            if (countss == 2)
            {
                cmdStop.PerformClick();
                this.Close();
            }
        }

        private void checkRun_Tick(object sender, EventArgs e)
        {
            if (cmdStart.Text == "START")
            {
                START_TOOL();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            try
            {
                shop.QUITDRIVER();
            }
            catch
            { }
            try
            {
                shop.RentPubgDestructer();
            }
            catch
            { }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                infoform.Show();
            }
            else 
            {
                infoform.Hide();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowIcon = false;
                this.Hide();
                nico.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowIcon = true;
            this.Show();
            WindowState = FormWindowState.Normal;
            nico.Visible = false;
        }

        private void nico_BalloonTipClosed(object sender, EventArgs e)
        {
          
        }

        private void nico_Click(object sender, EventArgs e)
        {
            if (checkError==false)
            {
                Process killChromeDriver = new Process();
                killChromeDriver.StartInfo.Arguments = @"/c " + Application.StartupPath + "\\logs\\Error" + txtRentAccID.Text+".txt";
                killChromeDriver.StartInfo.FileName = "cmd.exe";
                killChromeDriver.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                killChromeDriver.Start();
                nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\refresh.ico");
                checkError = true;
            }
        }

        private void nico_BalloonTipClicked(object sender, EventArgs e)
        {
            if (checkError == false)
            {
                Process killChromeDriver = new Process();
                killChromeDriver.StartInfo.Arguments = @"/c " + Application.StartupPath + "\\logs\\Error" + txtRentAccID.Text + ".txt";
                killChromeDriver.StartInfo.FileName = "cmd.exe";
                killChromeDriver.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                killChromeDriver.Start();
                nico.Icon = new System.Drawing.Icon(Application.StartupPath + "\\refresh.ico");
                checkError = true;
            }
        }

        private void START_TOOL()
        {
            checkRun.Start();
            if (shop != null)
            {
                if (shop.RentPubgIsNull() == false)
                {
                    shop.QUITDRIVER();
                    shop.RentPubgDestructer();
                }
            }
            else
            {
                shop = new CShop(txtRentAccID.Text, txtRentAccPass.Text, txtEmailID.Text, txtEmailPass.Text, txtToken.Text);
            }
            stopByError = true;
            cmdStart.Text = "RUNNING";
            cmdStart.Font = cmdStop.Font;
            cmdStart.BackColor = DefaultBackColor;
            if (bwReup.IsBusy)
            {
                bwReup.CancelAsync();
            }
            else
            {
                stop = false;
                bwReup.RunWorkerAsync();
            }
        }

        private void nico_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            ctxtmnstrMenu.Show();

        }

        private void ctxtmnstrMenu_Click(object sender, EventArgs e)
        {
            if (e.ToString()=="ahi")
            {

            }
        }

        private void infoBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                infoform.Hide();
                checkBox1.Checked = false;
            }
            else
            {
                infoform.Show();
                checkBox1.Checked = true;
            }
        }

        private void updateTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                shop.QUITDRIVER();
            }
            catch
            { }
            try
            {
                shop.RentPubgDestructer();
            }
            catch
            { }
            this.Close();
        }
    }
}
