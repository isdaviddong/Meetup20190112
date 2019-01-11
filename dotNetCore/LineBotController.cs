using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotNetCore
{
    [Route("api/LineBot")]
    public class LineBotController : Controller
    {
        [HttpPost]
        public StatusCodeResult OnPost()
        {
            var ReceivedMsg = isRock.LineBot.Bot.ParsingReceivedMessage(Request.Body);
            if (ReceivedMsg.events[0].replyToken == "00000000000000000000000000000000")
                return Ok();

            //var touserId = "";
            var token = "";
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(token);

            isRock.LineBot.TextMessage msg;
            if (ReceivedMsg.events.Count > 0 && ReceivedMsg.events[0].message != null && !string.IsNullOrEmpty(ReceivedMsg.events[0].message.text))
            {

                msg = new isRock.LineBot.TextMessage("you said : " + ReceivedMsg.events[0].message.text);
            }
            else
            {
                msg = new isRock.LineBot.TextMessage("test");
            }
            bot.ReplyMessage(ReceivedMsg.events[0].replyToken, msg);

            return Ok();
        }
    }
}
