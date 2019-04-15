using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SoftSrv.Controllers
{
    public class RegisterClientController : ApiController
    {
        private readonly List<string> _clients = new List<string>();

        //  POST http://localhost:9000/api/registerclient/Register 
        //     with body (as json)
        //            { "url": "http://localhost:8000" }

        //  returns:
        //     "http://localhost:8000"
        //
        [HttpPost]
        public IHttpActionResult Register([FromBody]RequestModel req)
        {
            _clients.Add(req.url);

            Action<string> notifier = Form1.SendAppleNotifications;
            notifier.BeginInvoke( req.url, null, null);

            //var response = DoExecuteScript(req.url);

            return Ok(req.url);
        }

        public static async Task DoExecuteScript(string url, List<WinAutoParams> commands)
        {
            var srv = new WinAutomationServer(url);
            await srv.ExecuteScript(commands);
        }
    }

    public class RequestModel
    {
        public string url { get; set; }
    }

}
