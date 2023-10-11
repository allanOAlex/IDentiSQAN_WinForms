using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zk4500.Shared.Requests;

namespace zk4500.Helpers.BrowserHelpers
{
    public class BrowserManager
    {
        private IPlaywright playwright;
        private IBrowser browser;
        private IPage page;

        public BrowserManager()
        {
                
        }


        public async Task Initialize()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        }

        public async Task CreateNewPage()
        {
            page = await browser.NewPageAsync();
        }

        public void ClosePage()
        {
            page?.CloseAsync().Wait();
            page = null;
        }

        public async Task LoginUser(LoginRequest loginRequest)
        {
            if (page != null)
            {
                // Use currentPage to perform web interactions
                await page.GotoAsync("https://www.google.com/");
            }
        }

        public void LogoutUser()
        {
            ClosePage();
        }

        public void ExitApplication()
        {
            if (browser != null)
            {
                browser.CloseAsync().Wait();
                browser = null;
            }
        }

    }
}
