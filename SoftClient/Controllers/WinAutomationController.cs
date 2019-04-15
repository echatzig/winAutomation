using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using SoftClient.Services;

namespace SoftClient.Controllers
{
    public class WinAutomationController : ApiController
    {
        WinAutoEngine eng = new WinAutoEngine();

        //  POST http://localhost:9000/api/WinAutomation/Command 
        //     with body (as json)
        //            { "url": "http://localhost:8000" }

        //  returns:
        //     "http://localhost:8000"
        //
        [HttpPost]
        public IHttpActionResult SelectWindow([FromBody]SelectWindowParams req)
        {
            eng.SelectWindow(req.window);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SetCursor([FromBody]SetCursorParams req)
        {
            eng.SetCursor(req.x, req.y);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DoMouseClick()
        {
            eng.DoMouseClick();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult SendKeys([FromBody]SendKeysParams req)
        {
            eng.SendKeys(req.str);
            return Ok();
        }

    }
}