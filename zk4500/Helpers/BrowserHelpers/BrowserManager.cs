using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using zk4500.Extensions;
using zk4500.Shared.Requests;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zk4500.Helpers.BrowserHelpers
{
    public class BrowserManager
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IBrowserContext context;
        private IPage page;

        public BrowserManager()
        {
           
        }

        //public BrowserManager(IPlaywright Playwright, IBrowser Browser, IBrowserContext Context, IPage Page)
        //{
        //    playwright = Playwright;
        //    browser = Browser;
        //    context = Context;
        //    page = Page;

        //    Initialize();
        //}

        public async Task Initialize()
        {
            try
            {
                playwright = await Playwright.CreateAsync();
                browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
                context = await browser.NewContextAsync();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> LoginUser(LoginRequest loginRequest)
        {
            try
            {
                string fullUrl = string.Empty;
                string apiUrl = "http://192.168.8.100/promed/verification-api.php";

                string queryString = $"id={Uri.EscapeDataString(loginRequest.PowerAppShell.ToString())}&Username={Uri.EscapeDataString(loginRequest.Username)}&ssd={Uri.EscapeDataString(loginRequest.Password)}&password={Uri.EscapeDataString(AppExtensions.CTO)}";

                fullUrl = apiUrl + "?" + queryString;

                switch (AppExtensions.ManageBrowserUsingBrowserManagerClass)
                {
                    case 4:

                        

                        if (page != null)
                        {
                            await page.GotoAsync($"{fullUrl}", new PageGotoOptions
                            {
                                WaitUntil = WaitUntilState.Commit,
                                Timeout = 0
                            });

                        }

                        return true;

                    default:
                        if (page == null)
                        {
                            await CreateNewPage();
                        }

                        await page.GotoAsync($"{fullUrl}", new PageGotoOptions
                        {
                            WaitUntil = WaitUntilState.Commit,
                            Timeout = 0
                        });

                        return true;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CreateNewPage()
        {
            try
            {
                if (browser != null)
                {
                    page = await browser.NewPageAsync();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating new browser page. {ex.Message}");
            }

            return false;
        }

        public void LogoutUser()
        {
            try
            {
                ClosePage();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void ClosePage()
        {
            try
            {
                page?.CloseAsync().Wait();
                page = null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ExitApplication()
        {
            try
            {
                if (browser != null)
                {
                    browser.CloseAsync().Wait();
                    browser = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }



    }


}
