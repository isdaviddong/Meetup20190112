using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meetup20190112.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
         string channelAccessToken = System.Configuration.ConfigurationManager.AppSettings["ChannelAccessToken"]; // "~~~~~請輸入你的請輸入你的 Channel Access Token~~~~~~~";
         string AdminUserId = System.Configuration.ConfigurationManager.AppSettings["AdminUserId"];//"~~~~~請輸入你的User Id~~~~~~~";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                        this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                else if (LineEvent.type == "postback")
                {
                    this.ReplyMessage(LineEvent.replyToken, "postback data:" + LineEvent.postback.Params.datetime);
                }
                else
                {
                    this.ReplyMessage("event:" + LineEvent.replyToken, LineEvent.type);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
