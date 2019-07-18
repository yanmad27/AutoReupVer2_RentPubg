using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using EAGetMail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoReup
{
    class CAccount
    {
        public string idRentAcc;
        public string idAccount;
        private string idSteam;
        private string pwSteam;
        private string npwSteam;
        private string f5pwSteam;
        private string idEmail;
        private string pwEmail;
        private string veri_code = "";
        private MailServer oServer;
        private MailClient oClient;
        private Imap4Folder folder;
        private IWebDriver steam;
        public CAccount(string idRentAcc,string idEmail, string pwEmail)
        {
            this.idRentAcc = idRentAcc;
            this.idEmail = idEmail;
            this.pwEmail = pwEmail;
        }

        public void SetVeri_Code(string newvericode)
        {
            veri_code = newvericode;
        }

        public CAccount(CAccount acc)
        {
            this.idAccount = acc.idAccount;
            this.idSteam = acc.idSteam;
            this.pwSteam = acc.pwSteam;
            this.npwSteam = acc.npwSteam;
            this.idEmail = acc.idEmail;
            this.pwEmail = acc.pwEmail;
        }

        public void ConstructerSteam(bool showBrowser)
        {
            tryconstructer:
            try
            {
                string curPath = Directory.GetCurrentDirectory();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(curPath + "\\chromedriver","chromedriver_"+idRentAcc+"_steam.exe");
                service.HideCommandPromptWindow = true;
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("no-sandbox");
                option.AddArgument("--window-size=500,550");
                if (showBrowser != true)
                {
                    option.AddArgument("headless");
                }
                steam = new ChromeDriver(service, option);
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                goto tryconstructer;
            }
        }
        
        public string ChangePassword()
        {
            try
            {
                ConstructerSteam(true);

                string errorContent;
                errorContent = LoginSteam();
                if (errorContent == "Success")
                {
                    errorContent = SendEmail();
                    if (errorContent == "Success")
                    {
                                errorContent = FillVerificationCode();
                                if (errorContent == "Success")
                                {
                                    errorContent = FillNewPassword();
                                    if (errorContent == "Success")
                                    {
                                        steam.Close();
                                        steam.Dispose();
                                        steam.Quit();
                                        return "Success";
                                    }
                                }
                    }
                }
                steam.Close();
                steam.Dispose();
                steam.Quit();
                return errorContent;
            }
            catch (Exception error)
            {
                steam.Close();
                steam.Dispose();
                steam.Quit();
                return error.ToString();

            }
        }

        public bool GotoPageSkipMail()
        {
            steam.Url = "https://help.steampowered.com/en/wizard/Login?redir=%2Fen%2Fwizard%2FHelpChangePassword%3Fredir%3Dstore%252Faccount%252F&title=Sign%20in";
            steam.Navigate();
            try
            {
                steam.FindElement(By.Id("input_username")).SendKeys(idSteam);
            }
            catch
            {
                return true;
            }
            return false;


        }

        public string LoginSteam()
        {
            trylogin:
            try
            {
                //truy cập url đổi pass
                steam.Url = "https://help.steampowered.com/en/wizard/Login?redir=%2Fen%2Fwizard%2FHelpChangePassword%3Fredir%3Dstore%252Faccount%252F&title=Sign%20in";
                steam.Navigate();

                //Điền ID và PW
                steam.FindElement(By.Id("input_username")).SendKeys(idSteam);
                steam.FindElement(By.Id("input_password")).SendKeys(pwSteam);

                //click nút login
                steam.FindElement(By.TagName("button")).Click();


                //chờ 4s kiểm tra lỗi ID hoặc pass
                System.Threading.Thread.Sleep(4000);

                CheckLoginError(ref steam);
                WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("input_username")));

                tryrefresh:
                //System.Threading.Thread.Sleep(2000);
                //steam.Navigate().Refresh();
                //CheckRefreshFail(ref steam);

                CheckIPLoginError(ref steam);

                //try
                //{
                //    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"wizard_contents\"]/a[2]/span")));
                //    CheckLoginSuccess(ref steam);
                //}
                //catch (CException.ButtonSendMailNotVisible error)
                //{
                //    string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                //    WriteBugLog(log);
                //    //goto tryrefresh;
                //}
            }
            catch (CException.WrongIDPW error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.ChaBietBiGi error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.F5Fail error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                goto trylogin;
            }
            catch (CException.IPLoginError error)
            {
                try
                {
                    steam.Url = "https://help.steampowered.com/en/wizard/Login?redir=%2Fen%2Fwizard%2FHelpChangePassword%3Fredir%3Dstore%252Faccount%252F&title=Sign%20in";
                    steam.Navigate();
                    CheckIPLoginError(ref steam);
                }
                catch
                {
                    string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                    WriteBugLog(log);
                    return error.ToString();
                }
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                if (log.Contains("Timed out"))
                {
                    steam.Navigate().Refresh();
                    goto trylogin;
                }
                return error.ToString();
            }

            Console.WriteLine("- Đăng nhập thành công.\r\n");
            return "Success";
        }

        public string LoginSteam(string pw)
        {
            trylogin:
            try
            {
                //truy cập url đổi pass
                steam.Url = "https://help.steampowered.com/en/wizard/Login?redir=%2Fen%2Fwizard%2FHelpChangePassword%3Fredir%3Dstore%252Faccount%252F&title=Sign%20in";
                steam.Navigate();

                //Điền ID và PW
                steam.FindElement(By.Id("input_username")).SendKeys(idSteam);
                steam.FindElement(By.Id("input_password")).SendKeys(pw);

                //click nút login
                steam.FindElement(By.TagName("button")).Click();

                //chờ 4s kiểm tra lỗi ID hoặc pass
                System.Threading.Thread.Sleep(2000);
                CheckLoginError(ref steam);

                tryrefresh:
                System.Threading.Thread.Sleep(2000);
                steam.Navigate().Refresh();
                CheckRefreshFail(ref steam);

                CheckIPLoginError(ref steam);

                try
                {
                    WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"wizard_contents\"]/div/a[3]/span")));
                    CheckLoginSuccess(ref steam);
                }
                catch (CException.ButtonSendMailNotVisible error)
                {
                    string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                    WriteBugLog(log);
                    goto tryrefresh;
                }
            }
            catch (CException.WrongIDPW error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.ChaBietBiGi error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.F5Fail error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                goto trylogin;
            }
            catch (CException.IPLoginError error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }

            Console.WriteLine("- Đăng nhập thành công.\r\n");
            pwSteam = pw;
            return "Success";
        }

        public string LoginSteamByNewPassword()
        {
            trylogin:
            try
            {
                //truy cập url đổi pass
                steam.Url = "https://help.steampowered.com/en/wizard/Login?redir=%2Fen%2Fwizard%2FHelpChangePassword%3Fredir%3Dstore%252Faccount%252F&title=Sign%20in";
                steam.Navigate();

                //Điền ID và PW
                steam.FindElement(By.Id("input_username")).SendKeys(idSteam);
                steam.FindElement(By.Id("input_password")).SendKeys(pwSteam);

                //click nút login
                steam.FindElement(By.TagName("button")).Click();

                //chờ 4s kiểm tra lỗi ID hoặc pass
                System.Threading.Thread.Sleep(2000);
                CheckLoginError(ref steam);

                tryrefresh:
                System.Threading.Thread.Sleep(2000);
                steam.Navigate().Refresh();
                CheckRefreshFail(ref steam);

                CheckIPLoginError(ref steam);

                try
                {
                    WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"wizard_contents\"]/a[2]/span")));
                    CheckLoginSuccess(ref steam);
                }
                catch (CException.ButtonSendMailNotVisible error)
                {
                    string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                    WriteBugLog(log);
                    goto tryrefresh;
                }
            }
            catch (CException.WrongIDPW error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.ChaBietBiGi error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.F5Fail error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                goto trylogin;
            }
            catch (CException.IPLoginError error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                if (log.Contains("Timed out"))
                {
                    steam.Navigate().Refresh();
                    goto trylogin;
                }
                return error.ToString();
            }

            Console.WriteLine("- Đăng nhập thành công.\r\n");
            return "Success";
        }

       

        public string SkipSendMessage()
        {
            try
            {
               
                if (steam.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/div/a[2]/span")).Text.Contains("Text an account verification code to my phone number ending"))
                {
                    steam.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/div/a[3]/span")).Click();

                    System.Threading.Thread.Sleep(1000);
                    WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//*[@id=\"wizard_contents\"]/a[3]/span"), "I no longer have access to this phone number"));
                }
                return "Success";
            }
            catch (Exception error)
            {

                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
        }

        public string SendEmail()
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                steam.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/div/a[2]/span")).Click();

                //System.Threading.Thread.Sleep(3000);
                //CheckIPMailError(ref steam);

                //WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"forgot_login_code\"]")));

                //CheckSendMailSuccess(ref steam);
            }
            catch (CException.IPMailError error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (CException.InputCodeNotVisible error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }

            Console.WriteLine("- Gửi mail thành công.\r\n");
            return "Success";
        }

        

        public string FillVerificationCode()
        {
            try
            {
                steam.FindElement(By.XPath("//*[@id=\"forgot_login_code\"]")).SendKeys(veri_code);
                steam.FindElement(By.XPath("//*[@id=\"forgot_login_code_form\"]/div[3]/input")).Click();

                return WaitUntilExit(By.XPath("//*[@id=\"forgot_login_code\"]"));
                

                //WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"password_reset\"]")));
                //CheckFillCodeSuccess(ref steam);
            }
            catch (CException.InputNewPasswordNotVisible error)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"verify_password\"]")));

                    steam.FindElement(By.XPath("//*[@id=\"verify_password\"]")).SendKeys(pwSteam);
                    steam.FindElement(By.XPath("//*[@id=\"verify_password_submit\"]/input")).Click();

                    wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"password_reset\"]")));
                }
                catch
                {
                    string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                    WriteBugLog(log);
                    return error.ToString();
                }
                
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                return error.ToString();
            }
            return "Success";
        }

        

        public string FillNewPassword()
        {
            tryagain:
            try
            {

                Console.WriteLine(npwSteam);
                steam.FindElement(By.XPath("//*[@id=\"password_reset\"]")).Clear();
                steam.FindElement(By.XPath("//*[@id=\"password_reset\"]")).SendKeys(f5pwSteam);
                System.Threading.Thread.Sleep(1000);
                steam.FindElement(By.XPath("//*[@id=\"password_reset_confirm\"]")).Clear();
                steam.FindElement(By.XPath("//*[@id=\"password_reset_confirm\"]")).SendKeys(f5pwSteam);
                fixinvalid:
                System.Threading.Thread.Sleep(1000);
                steam.FindElement(By.XPath("//*[@id=\"change_password_form\"]/div[3]/input")).Click();

                //check lỗi invalid
                try
                {
                    IWebElement invalid = steam.FindElement(By.XPath("//*[@id=\"changepw_error_msg\"]"));
                    if (invalid.Displayed == true)
                        goto tryagain;
                }
                catch { }
                WebDriverWait wait = new WebDriverWait(steam, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.UrlContains("HelpWithLoginInfoComplete"));
                ////By.XPath("//*[@id=\"wizard_contents\"]/div[2]/div[1]"
            }
            catch (Exception error)
            {
                string log = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ". Error: " + error.ToString() + "\r\n" + GetInfo() + "\r\n";
                WriteBugLog(log);
                if (log.Contains("no such element") && ElementIsVisible(By.XPath("//*[@id=\"verify_password\"]"))==true)          // nếu hỏi pass cũ
                {
                    steam.FindElement(By.XPath("//*[@id=\"verify_password\"]")).SendKeys(pwSteam);
                    steam.FindElement(By.XPath("//*[@id=\"verify_password_submit\"]/input")).Click();
                    WaitUntilVisible(By.XPath("//*[@id=\"password_reset\"]"));
                    goto tryagain;
                    
                }

                return log;
            }
            return "Success";
        }

        private bool ResendMail(ref IWebDriver steam)
        {
            return true;
        }
       
        private bool ElementIsVisible(By elem)
        {
            try
            {
                steam.FindElement(elem);
            }
            catch
            {
                return false;
            }
            return true;
        }
       

        public void SetReupInfo(string idAccount, string idSteam, string pwSteam, string npwSteam)
        {
            this.idAccount = idAccount;
            this.idSteam = idSteam;
            this.pwSteam = pwSteam;
            this.npwSteam = npwSteam;
        }


        public void QUITDRIVER()
        {
            try
            {
                steam.Close();
                //steam.Dispose();
                //steam.Quit();
            }
            catch { }
            Process killChromeDriver = new Process();
            killChromeDriver.StartInfo.Arguments = @"/c TASKKILL /F /IM chromedriver_" + idRentAcc + "_steam.exe";
            killChromeDriver.StartInfo.FileName = "cmd.exe";
            killChromeDriver.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            killChromeDriver.Start();
            killChromeDriver.Close();
            killChromeDriver.Dispose();
        }



        //============================================================================
        //

        private void WaitUntilVisible(By elem)
        {
            begin:
            try
            {
                steam.FindElement(elem);
            }
            catch
            {
                System.Threading.Thread.Sleep(500);
                goto begin;
            }
        }

        private string WaitUntilExit(By elem)
        {
            begin:
            try
            {
                steam.FindElement(elem);
            }
            catch
            {
                return "Success";
            }
            System.Threading.Thread.Sleep(500);
            try
            {
                if (steam.FindElement(By.XPath("//*[@id=\"form_submit_error\"]")).Displayed == true)
                {
                    return "TryAgain";
                }
            }
            catch { }

            goto begin;                                                
        }
        //============================================================================

        public void SetF5Password(string f5pw)
        {
            f5pwSteam = f5pw;
        }

        public void SetNewPassword(string newpw)
        {

            npwSteam = newpw;
        }

        public string GetInfo()
        {
            return idAccount + "-" + idSteam + "-" + pwSteam + "-" + npwSteam + "-" + f5pwSteam;
        }
        

        public string GetIDSteam()
        {
            return idSteam;
        }

        public string GetNPWSteam()
        {
            return npwSteam;
        }

        public string GetF5PWSteam()
        {
            return f5pwSteam;
        }

        //============================================================================
        //
        //============================================================================
        void CheckLoginError(ref IWebDriver driver)
        {
            IWebElement elem_error;
            try
            {
                elem_error = 
                    driver.FindElement(By.XPath("//*[@id=\"error_display\"]"));
            }
            catch
            {
                elem_error = null;
            }
            if (elem_error != null)
            {
                if (elem_error.Displayed == false)
                {
                    return;
                }
                if (elem_error.Text.Contains("incorrect"))
                    throw new CException.WrongIDPW("WrongIDPW");
                else
                    throw new CException.ChaBietBiGi("ChaBietBiGi");
            }
        }

        void CheckRefreshFail(ref IWebDriver driver)
        {
            System.Threading.Thread.Sleep(1000);
            try
            {
                driver.FindElement(By.Id("input_username"));
            }
            catch
            {
                return;
            }
            throw new CException.F5Fail("F5 fail");
        }


        void CheckLoginSuccess(ref IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/a[2]/span"));
            }
            catch
            {
                throw new CException.ButtonSendMailNotVisible("ButtonSendMailNotVisible");
            }
        }

        void CheckSendMailSuccess(ref IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"forgot_login_code\"]"));
            }
            catch
            {
                throw new CException.InputCodeNotVisible("InputCodeNotVisible");
            }
        }

        void CheckFillCodeSuccess(ref IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"password_reset\"]"));
            }
            catch
            {
                throw new CException.InputNewPasswordNotVisible("InputNewPasswordNotVisible");
            }
        }

        void CheckIPLoginError(ref IWebDriver driver)
        {
            System.Threading.Thread.Sleep(500);
            try
            {
                if (driver.FindElement(By.XPath("//*[@id=\"error_contents\"]/div[2]/div[1]/div[1]")).Displayed == false)
                {
                    return;
                }
                throw new CException.IPLoginError("IPLoginError");
            }
            catch (Exception)
            {
                return;
            }
        }

        void CheckIPMailError(ref IWebDriver driver)
        {
            //cho mail gui ve
            System.Threading.Thread.Sleep(500);
            try
            {
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/div[2]/div[1]"));
            }
            catch
            {
                return;
            }
            throw new CException.IPMailError("IPMailError");
        }

        void CheckFillNewPasswordSuccess(ref IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//*[@id=\"wizard_contents\"]/div[2]/div[1]"));
            }
            catch
            {
                //throw new CException.UpdateNewPasswordFail;
            }
            return;
        }

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
    }
}

