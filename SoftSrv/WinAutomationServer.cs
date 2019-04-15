using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSrv
{
    class WinAutomationServer
    {
        WebApp.RestClient _restclient = null;

        public WinAutomationServer(string url)
        {
            _restclient = new WebApp.RestClient(url);
        }

        public async Task ExecuteScript(List<WinAutoParams> commands)
        {
            foreach (var cmd in commands) {
                if (cmd is SelectWindowParams) { var c = (SelectWindowParams)(cmd); await SelectWindow(c.window); }
                if (cmd is SetCursorParams)    { var c = (SetCursorParams)(cmd);    await SetCursor(c.x, c.y);    }
                if (cmd is MouseClickParams)   { var c = (MouseClickParams)(cmd);   await DoMouseClick(); }
                if (cmd is SendKeysParams)     { var c = (SendKeysParams)(cmd);     await SendKeys(c.str); }
            }

            //await SelectWindow("Google - Mozilla Firefox");
            //await SetCursor(560, 417);
            //await DoMouseClick();
            //await SendKeys("today in wikipedia");
            //await SetCursor(560, 694); // 487);
            //await DoMouseClick();

        }

        private async Task SelectWindow(string window)
        {
            // object initializer syntax
            string response = await _restclient.Post<string, SelectWindowParams>(
                        "/api/WinAutomation/SelectWindow", new SelectWindowParams() { window = window }
                );
        }

        private async Task SetCursor(int x, int y)
        {
            // object initializer syntax
            string response = await _restclient.Post<string, SetCursorParams>(
                        "/api/WinAutomation/SetCursor", new SetCursorParams() { x = x, y = y }
                );
        }

        private async Task SendKeys(string str)
        {
            // object initializer syntax
            string response = await _restclient.Post<string, SendKeysParams>(
                        "/api/WinAutomation/SendKeys", new SendKeysParams() { str = str }
                );
        }

        
        private async Task DoMouseClick()
        {
            // object initializer syntax
            string response = await _restclient.Post<string, object>(
                        "/api/WinAutomation/DoMouseClick", null
                );
        }

    }
}
