using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using EAGetMail;

namespace AutoReup
{
    class CShop
    {
        private string idRentAcc;
        private string pwRentAcc;
        private string accessToken;
        private CAccount account;
        private string idEmail;
        private string pwEmail;
        private string linkShop;
        private MailServer oServer;
        private MailClient oClient;
        private Imap4Folder folder;
        private string veri_code;
        private List<string> idList = new List<string> { };
        private List<string> pwList = new List<string> { };
        private List<string> skipList = new List<string> { };
        private List<string> errorList = new List<string> { };
        private string total = "", banned = "", end = "", ready = "", rent = "", stop = "", error = "", revenue = "", numberOfRent = "", readyWeb = "", rentWeb = "";

        private IWebDriver rentpubg;

        public int getCountErrorList()
        {
            return errorList.Count;
        }

        public string Info()
        {
            return idRentAcc + "\r\n" + pwRentAcc + "\r\n" + idEmail + "\r\n" + pwEmail;
        }

        public CShop(string idRentAcc, string pwRentAcc, string idEmail, string pwEmail, string accessToken)
        {
            this.idRentAcc = idRentAcc;
            this.pwRentAcc = pwRentAcc;
            this.idEmail = idEmail;
            this.pwEmail = pwEmail;
            this.accessToken = accessToken;
            this.LoadingErrorList();
        }

        public void AddSkipList(string skipid)
        {
            skipList.Add(skipid);
        }



        public CAccount GetAccount()
        {
            return account;
        }

        public string GetTotal()
        {
            return total;
        }

        public string GetBanned()
        {
            return banned;
        }

        public string GetEnd()
        {
            return end;
        }

        public string GetRevenue()
        {
            return revenue;
        }

        public string GetNumberOfRent()
        {
            return numberOfRent;
        }

        public string GetReady()
        {
            return ready;
        }

        public string GetRent()
        {
            return rent;
        }

        public string GetReadyWeb()
        {
            return readyWeb;
        }

        public string GetRentWeb()
        {
            return rentWeb;
        }

        public string GetStop()
        {
            return stop;
        }

        public string GetError()
        {
            return error;
        }

        public void Changepass()
        {
            string error_content;
        tryagain:
            if (account.GotoPageSkipMail() == true)
            {
                error_content = SkipSendMessage();
                if (error_content == "Success")
                {
                    error_content = SendMail();
                    if (error_content == "Success")
                    {
                        error_content = GetVerificationCode();
                        if (error_content == "Success")
                        {
                            error_content = FillVerificationCode();
                            if (error_content == "Success")
                            {
                                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now) + "s\r\n" + GetCurrentInfo() + "\r\n";
                                WriteLog("Reup" + idRentAcc + ".txt", log);
                                error_content = FillNewPassword();
                            }
                        }
                    }
                }
                if (error_content != "Success")
                {
                    goto tryagain;
                }
            }
        }

        public void RentPubgConstructer(bool showBrowser)
        {
        tryconstructer:
            try
            {
                string curPath = Directory.GetCurrentDirectory();
                string exename = "chromedriver_" + idRentAcc + "_rentpubg.exe";
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(curPath + "\\chromedriver", exename);
                service.HideCommandPromptWindow = true;
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("no-sandbox");
                option.AddArgument("--window-size=1100,1400");
                if (showBrowser != true)
                {
                    option.AddArgument("headless");
                }
                rentpubg = new ChromeDriver(service, option);
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + "\r\n";
                WriteBugLogC(log);
                goto tryconstructer;
            }
        }

        public bool RentPubgIsNull()
        {
            return rentpubg == null;
        }

        public void RentPubgDestructer()
        {
            try
            {
                rentpubg.Close();
                //rentpubg.Dispose();
                //rentpubg.Quit();
            }
            catch { }
            try
            {
                Process killChromeDriver = new Process();
                killChromeDriver.StartInfo.Arguments = @"/c TASKKILL /F /IM chromedriver_" + idRentAcc + "_rentpubg.exe";
                killChromeDriver.StartInfo.FileName = "cmd.exe";
                killChromeDriver.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                killChromeDriver.Start();
                killChromeDriver.Close();
                killChromeDriver.Dispose();
            }
            catch { }
        }
        public void LoginRentPubg()
        {
            rentpubg.Url = "http://rentpubg.com/dang-nhap";
            rentpubg.Navigate();

            try
            {
                rentpubg.FindElement(By.XPath("//*[@id=\"modal-ads\"]/div/div/div[1]/button")).Click();
            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            rentpubg.FindElement(By.XPath("//*[@id=\"login\"]/div[1]/input")).SendKeys(idRentAcc);
            rentpubg.FindElement(By.XPath("//*[@id=\"login\"]/div[2]/input")).SendKeys(pwRentAcc);
            rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.PageDown);
            System.Threading.Thread.Sleep(500);

            /////*[@id=\"login\"]/ul/li[1]/button
            rentpubg.FindElement(By.XPath("//*[@id=\"login\"]/ul/li[1]/button")).Click();
            //chờ để login thành công(cấm xóa =)))
            System.Threading.Thread.Sleep(5000);

            rentpubg.Url = "http://rentpubg.com/shop/thong-tin-shop";
            rentpubg.Navigate();
            rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.PageDown);
            linkShop = rentpubg.FindElement(By.XPath("//*[@id=\"updateShopInfo\"]/div/div[2]/div[1]/input")).GetAttribute("value");




        }

        public void LoginRentPubgByFacebook()
        {
            rentpubg.Url = "https://facebook.com/";
            rentpubg.Navigate();

            rentpubg.FindElement(By.XPath("//*[@id=\"email\"]")).SendKeys(idRentAcc);
            //rentpubg.FindElement(By.XPath("//*[@id=\"login_form\"]/div[4]/div[1]/button")).Submit();
            //System.Threading.Thread.Sleep(1000);
            rentpubg.FindElement(By.XPath("//*[@id=\"pass\"]")).SendKeys(pwRentAcc);
            System.Threading.Thread.Sleep(1000);


            rentpubg.FindElement(By.XPath("//*[@type=\"submit\"]")).Click();
            rentpubg.Url = "http://rentpubg.com/dang-nhap";
            rentpubg.Navigate();


            try
            {
                rentpubg.FindElement(By.XPath("//*[@id=\"modal-ads\"]/div/div/div[1]/button")).Click();

            }
            catch { }
            System.Threading.Thread.Sleep(1000);
            System.Threading.Thread.Sleep(1000);

            rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div/p/a")).Click();
            System.Threading.Thread.Sleep(1000);
            System.Threading.Thread.Sleep(1000);

            System.Threading.Thread.Sleep(5000);

            rentpubg.Url = "http://rentpubg.com/shop/thong-tin-shop";
            rentpubg.Navigate();
            linkShop = rentpubg.FindElement(By.XPath("//*[@id=\"updateShopInfo\"]/div/div[2]/div[1]/input")).GetAttribute("value");

        }

        public void RefreshRentPubg()
        {
            rentpubg.Navigate().Refresh();
        }

        public void NotUpdateTotal()
        {


            rentpubg.Url = "http://rentpubg.com";
            rentpubg.Navigate();

        get4:
            try
            {
                rentpubg.Url = "http://rentpubg.com/shop";
                rentpubg.Navigate();

                for (int i = 0; i < 25; i++)
                    rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.Down);

                string[] tmp = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[1]")).Text.Split(new char[] { ' ' });
                end = tmp[0];
                string tmperror = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[2]")).Text;
                error = tmperror.Substring(0, tmperror.IndexOf(" ACC"));
            }
            catch { goto get4; }
        }

        public void UpdateTotal()
        {
            try
            {
            get1:
                try
                {
                    rentpubg.Url = "http://rentpubg.com/pubg";
                    rentpubg.Navigate();

                    //System.Threading.Thread.Sleep(100);
                    string rdw = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[1]/div[2]/div/a[1]")).Text;
                    readyWeb = rdw.Substring(rdw.IndexOf('(') + 1, rdw.IndexOf(')') - rdw.IndexOf('(') - 1);
                    try
                    {
                        readyWeb = readyWeb.Remove(readyWeb.IndexOf('.'), 1);
                    }
                    catch { }
                    string rtw = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[1]/div[2]/div/a[2]")).Text;
                    rentWeb = rtw.Substring(rtw.IndexOf('(') + 1, rtw.IndexOf(')') - rtw.IndexOf('(') - 1);
                    try
                    {
                        rentWeb = rentWeb.Remove(rentWeb.IndexOf('.'), 1);
                    }
                    catch { }
                }
                catch
                {
                    goto get1;
                }


            get2:
                try
                {
                    rentpubg.Url = "http://rentpubg.com/shop/thong-ke";
                    rentpubg.Navigate();

                    string tmpzz = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[1]")).Text;
                    revenue = tmpzz.Substring(tmpzz.IndexOf(':') + 1, tmpzz.IndexOf('-') - tmpzz.IndexOf(':') - 2);
                    numberOfRent = tmpzz.Substring(tmpzz.IndexOf('-') + 1, tmpzz.IndexOf('L') - tmpzz.IndexOf('-') - 2);

                }
                catch { goto get2; }


            get3:
                try
                {
                    rentpubg.Url = linkShop;
                    rentpubg.Navigate();


                    string rd = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[1]/div/div[2]/a[1]")).Text;
                    ready = rd.Substring(rd.IndexOf('(') + 1, rd.IndexOf(')') - rd.IndexOf('(') - 1);

                    string rt = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[1]/div/div[2]/a[2]")).Text;
                    rent = rt.Substring(rt.IndexOf('(') + 1, rt.IndexOf(')') - rt.IndexOf('(') - 1);
                }
                catch { goto get3; }

            get4:
                try
                {
                    rentpubg.Url = "http://rentpubg.com/shop";
                    rentpubg.Navigate();

                    for (int i = 0; i < 25; i++)
                        rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.Down);

                    string[] tmp = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[1]")).Text.Split(new char[] { ' ' });
                    end = tmp[0];
                    string tmperror = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[2]")).Text;
                    error = tmperror.Substring(0, tmperror.IndexOf(" ACC"));
                }
                catch { goto get4; }

            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + account.GetInfo() + "\r\n";
                WriteBugLogC(log);
            }
        }
        public void UPDATEERRORLIST()
        {
            try
            {
                if (int.Parse(error) > errorList.Count)
                {
                    for (int i = 1; i <= int.Parse(error); i++)
                    {
                        string tmpname = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[3]/table/tbody/tr[" + i.ToString() + "]/td[1]")).Text;
                        if (!errorList.Contains(tmpname))
                        {
                            errorList.Add(tmpname);
                            string log = errorList.Count.ToString() + ". " + String.Format("{0:dd/MM/yyyy HH:mm:ss} ", DateTime.Now) + "\r\n" + tmpname + "\r\n";
                            UpdateErrorList(log);
                        }
                    }
                }
            }
            catch { }
        }

        public bool GetReupInfoRentPubg()
        {
        again:
            try
            {

                System.Threading.Thread.Sleep(100);
                ///html/body
                string idAccount = "";
                string idSteam = "";
                string pwSteam = "";
                string npwSteam = "";

                string[] tmp = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/h4[1]")).Text.Split(new char[] { ' ' });
                int quantityOfReup = int.Parse(tmp[0]);


                for (int i = 1; i <= quantityOfReup; i++)
                {
                    idAccount = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[6]/button[1]")).GetAttribute("data-id").ToString();
                    idSteam = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[2]/span")).Text;
                    if (skipList.Contains(idSteam))
                    {
                        continue;
                    }

                    for (int j = 0; j < 13 * ((i - 1) / 10); j++)
                        rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.Down);

                    pwSteam = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[3]/span")).Text;
                    npwSteam = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[4]/span")).Text;

                    // nếu có pass từ list thì lấy pass từ list
                    for (int index = 0; index < idList.Count; index++)
                    {
                        if (idList[index] == idSteam)
                        {
                            pwSteam = pwList[index];
                            break;
                        }
                    }
                    account = new CAccount(idRentAcc, idEmail, pwEmail);
                    Console.WriteLine(idSteam + " " + pwSteam + " " + npwSteam);
                    account.SetReupInfo(idAccount, idSteam, pwSteam, npwSteam);
                    return true;
                }
                skipList.Clear();
                return false;
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + account.GetInfo() + "\r\n";
                WriteBugLog(log);
                goto again;
            }
        }
        public string GetPWFromLog()
        {
            string currentIDSteam = account.GetIDSteam();
            for (int i = 0; i < idList.Count; i++)
            {
                if (idList[i] == currentIDSteam)
                {
                    return pwList[i];
                }
            }
            return "abc";
        }

        public string LoginSteam(string pw)
        {
            return account.LoginSteam(pw);
        }


        List<string> GetListReup(string json)
        {
            List<string> listReup = new List<string> { };

            string[] s_listReup = json.Split(new char[] { '{', '}' });
            foreach (string s in s_listReup)
            {
                if (s.Length > 50)
                {
                    listReup.Add(s);
                }
            }

            return listReup;
        }


        public void GetTotalInfo()
        {
            int ibanned = CountAccount("banned");
            int iend = CountAccount("end");
            int iready = CountAccount("ready");
            int irent = CountAccount("rent");
            int istop = CountAccount("stop");
            int ierror = CountAccount("edit");
            int itotal = iready + irent + istop + ierror;

            banned = ibanned.ToString();
            end = iend.ToString();
            ready = iready.ToString();
            rent = (irent - iend).ToString();
            stop = istop.ToString();
            error = ierror.ToString();
            total = itotal.ToString();

        }

        private int CountAccount(string status)
        {
            WebClient client = new WebClient();
            string str = client.DownloadString("http://api.rentacc.com/accounts?fields=username,password,new_password,status&query={\"status\":\"" + status + "\",\"category\":\"PUBG\"}&access_token=" + accessToken + "&limit=1000");
            int i = 0;
            string[] arrs_banned = str.Split(new char[] { '{', '}' });
            foreach (string s in arrs_banned)
            {
                if (s.Length > 50)
                {
                    i++;
                }
            }
            client.Dispose();
            return i;
        }


        public string ConnectMail()
        {
            try
            {
                // Gmail IMAP4 server is "imap.gmail.com"
                oServer = new MailServer("imap.gmail.com",
                            idEmail, pwEmail, ServerProtocol.Imap4);
                oClient = new MailClient("TryIt");

                // Set SSL connection,
                oServer.SSLConnection = true;

                // Set 993 IMAP4 port
                oServer.Port = 993;

                oClient.Connect(oServer);

                // Lookup folder based name.
                string folderName = "Steam Account Verification";

                folder = SearchFolder(oClient.Imap4Folders, folderName);
                if (folder == null)
                {
                    //Console.WriteLine(folder.Name);
                    Console.WriteLine("Folder was not found");
                    return "FolderNotFound";
                }

                // Select folder "Account Verification"
                oClient.SelectFolder(folder);
                return "Success";
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + "\r\n";
                WriteBugLogC(log);
                return error.ToString();
            }
        }

        private static Imap4Folder SearchFolder(Imap4Folder[] folders, string name)
        {
            int count = folders.Length;
            for (int i = 0; i < count; i++)
            {
                Imap4Folder folder = folders[i];
                Console.WriteLine(folder.FullPath);
                // Folder was found.
                if (String.Compare(folder.Name, name) == 0)
                    return folder;

                folder = SearchFolder(folder.SubFolders, name);
                if (folder != null)
                    return folder;
            }
            // No folder found
            return null;
        }


        public string GetVerificationCode()
        {
            int checkCount = 0;//so lan check mail
        tryagain:
            checkCount++;
            try
            {
                oClient.SelectFolder(folder);

                MailInfo[] infos = oClient.GetMailInfos();
                int last = infos.Length - 1;

                MailInfo info = infos[last];
                Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                    info.Index, info.Size, info.UIDL);

                // Receive email from IMAP4 server
                Mail oMail = oClient.GetMail(info);

                Console.WriteLine("From: {0}", oMail.From.ToString());
                Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

                ////So sánh ID và Mail
                string steamid = account.GetIDSteam().ToLower();

                //lấy mail body
                string content = oMail.TextBody;

                int Start = content.IndexOf(steamid, 0);

                if (checkCount < 7)
                {
                    if (Start < 0)
                    {
                        goto tryagain;
                    }
                }
                else
                    return "IPMailError";

                string mailid = content.Substring(Start, steamid.Length);


                if (info.Read == false)
                {
                    //Get Verification code from email
                    Start = content.IndexOf("Your account verification code is: ", 0) + "Your account verification code is: ".Length;
                    veri_code = content.Substring(Start, 5);
                    account.SetVeri_Code(veri_code);
                    //txtVerificationCode.Text = veri_code;
                    Console.WriteLine(veri_code);

                    //MarkAsRead
                    oClient.MarkAsRead(info, true);

                    return "Success";
                }
                else
                {
                    goto tryagain;
                }
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + account.GetInfo() + "\r\n";
                WriteBugLog(log);
                if (log.Contains("Unable to write data to the transport connection"))
                {
                    ConnectMail();
                    goto tryagain;
                }
                return error.ToString();
            }
        }

        public string ChangePassword()
        {
            return account.ChangePassword();
        }

        public string LoginSteam()
        {
            return account.LoginSteam();
        }

        public string LoginSteamByNewPassword()
        {
            return account.LoginSteamByNewPassword();
        }

        public string SkipSendMessage()
        {
            return account.SkipSendMessage();
        }

        public string SendMail()
        {
            return account.SendEmail();
        }



        public string FillVerificationCode()
        {
            return account.FillVerificationCode();
        }

        public string FillNewPassword()
        {
            string idSteam, f5pwSteam;
        again:
            try
            {
                rentpubg.Navigate().Refresh();
                for (int i = 1; i <= Int32.Parse(end); i++)
                {
                    idSteam = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[2]/span")).Text;
                    if (idSteam != account.GetIDSteam())
                    {
                        continue;
                    }

                    f5pwSteam = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[4]/span")).Text;
                    account.SetF5Password(f5pwSteam);
                    break;
                }
            }
            catch { goto again; }

            UpdatePWList(account.GetIDSteam(), account.GetF5PWSteam());
            return account.FillNewPassword();
        }

        public void QUITDRIVER()
        {
            try
            {
                account.QUITDRIVER();
            }
            catch { }
        }


        public void ConstructerSteam(bool showBrowser)
        {
            account.ConstructerSteam(showBrowser);
        }



        void UpdatePWList(string id, string pw)
        {
            for (int i = 0; i < idList.Count; i++)
            {
                if (id == idList[i])
                {
                    pwList[i] = pw;
                    return;
                }
            }
            idList.Add(id);
            pwList.Add(pw);
        }


        public void ReupAccountRentPubg()
        {
        tryreup:
            int i = 1;
            bool stop = false;
            while (stop == false & i <= int.Parse(end))
            {
                IWebElement name = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[2]/span"));
                if (name.Text == account.GetIDSteam())
                {
                    IWebElement button = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[6]/button[1]"));
                    button.Click();
                    stop = true;
                }
                i++;
            }

            i--;
            System.Threading.Thread.Sleep(1000);

            //try
            //{
            //    string newname = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[2]/span")).Text;
            //    if (newname == account.GetIDSteam())
            //    {
            //        tryrefresh:
            //         try
            //        {
            //            rentpubg.Navigate().Refresh();
            //            string newpw = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[" + i.ToString() + "]/td[4]/span")).Text;
            //            account.SetPassword(newpw);
            //            goto tryreup;
            //        }
            //        catch
            //        {
            //            rentpubg.Navigate().Refresh();
            //            goto tryrefresh;
            //        }
            //    }

            //}
            //catch { }

        }


        //rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[1]/td[6]/button[1]")).Click();



        //public void StopAccountRentPubg()
        //{
        //    rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[1]/td[6]/button[2]")).Click();
        //    System.Threading.Thread.Sleep(500);
        //    rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div/div/div[2]/table/tbody/tr[1]/td[6]/button[1]")).Click();
        //}

        public void ReupAccount()
        {
            WebRequest reup = WebRequest.Create("http://api.rentacc.com/account/" + account.idAccount + "?status=ready&access_token=" + accessToken);
            reup.Method = "POST";

            //Now the real request is called here when we call the GetResponse method
            WebResponse response = reup.GetResponse();
            response.Dispose();
        }

        public void StopAccount()
        {
            WebRequest reup = WebRequest.Create("http://api.rentacc.com/account/" + account.idAccount + "?status=stop&access_token=" + accessToken);
            reup.Method = "POST";

            //Now the real request is called here when we call the GetResponse method
            WebResponse response = reup.GetResponse();
            response.Dispose();
        }


        public string GetCurrentInfo()
        {
            return account.GetInfo();
        }


        public string GetCurrentSteamID()
        {
            return account.GetIDSteam();
        }

        public string GetCurrentID()
        {
            return account.idAccount;
        }
        public void WriteLog(string fileName, string logs)
        {
            if (File.Exists(Application.StartupPath + "/Logs/" + fileName) == true)
            {
                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + fileName, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
            }
            else
            {
                File.Create(Application.StartupPath + "/Logs/" + fileName).Dispose();

                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + fileName, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
            }
        }

        public void WriteBugLog(string logs)
        {
            account.WriteBugLog(logs);
        }

        public void WriteBugLogC(string logs)
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

        private void LoadingErrorList()
        {
            if (File.Exists(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt") == true)
            {
                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(filestream);
                while (sr.EndOfStream == false)
                {
                    if (sr.ReadLine() != "")
                    {
                        string tmp = sr.ReadLine();
                        errorList.Add(tmp);
                        sr.ReadLine();
                    }
                }
                sr.Close();
                filestream.Close();
            }
        }

        private void UpdateErrorList(string logs)
        {
            if (File.Exists(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt") == true)
            {
                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
                filestream.Close();
            }
            else
            {
                File.Create(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt").Dispose();

                FileStream filestream = new FileStream(Application.StartupPath + "/Logs/" + "Error" + idRentAcc + ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(filestream);

                sw.WriteLine(logs);
                sw.Close();
                filestream.Close();
            }
        }

        public void SetGiaAccount()
        {
            int goi = 3;
        fixcode503:
            try
            {
                //lay gia hien tai
                var positionOfPrice = "10";
                var currentPrice = "";
                rentpubg.Url = "https://rentpubg.com/pubg?goi=3h";
                rentpubg.Navigate();
                currentPrice = rentpubg.FindElement(By.XPath("/html/body/div[3]/div/div[1]/div[2]/div[" + positionOfPrice + "]/div/div/div/select/option[1]")).Text;
                currentPrice = currentPrice.Remove(1, 1);//remove "."
                currentPrice = currentPrice.Substring(0, 4); //lay ra price

                rentpubg.Url = "http://rentpubg.com/shop/sua-tai-khoan/" + account.idAccount;
                rentpubg.Navigate();

                rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.PageDown);
                rentpubg.FindElement(By.XPath("/html/body")).SendKeys(OpenQA.Selenium.Keys.PageDown);

                ////*[@id="updateAcc"]/div/div[2]/div[6]/input           1h
                ////*[@id="updateAcc"]/div/div[2]/div[5]/input           3h

                if (goi == 1)
                {
                    //*[@id="updateAcc"]/div/div[2]/div[5]/label/span/i
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[6]/input")).Clear();
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[6]/input")).SendKeys("2000");
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[5]/label/span/i")).Click();
                }
                else
                {
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[5]/input")).Clear();
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[5]/input")).SendKeys(currentPrice);
                    rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[5]/label/span")).Click();
                }

                var beCheck = rentpubg.FindElement(By.XPath("//*[@id=\"updateAcc\"]/div/div[2]/div[5]/label/input")).Selected;
                if (beCheck == true)
                {
                    rentpubg.FindElement(By.XPath("//*[@type=\"submit\"]")).Click();
                }
                Console.WriteLine("ChangePriceOfAccount");
                System.Threading.Thread.Sleep(2000);

                return;
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + account.GetInfo() + "\r\n";
                WriteBugLog(log);
                rentpubg.Navigate().Refresh();
                goto fixcode503;
            }
        }
    }
}
