using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Meetup20190112
{
    public partial class QuickReply : System.Web.UI.Page
    {
        //請輸入你的 Channel Access Token
        string ChannelAccessToken =System.Configuration.ConfigurationManager.AppSettings["ChannelAccessToken"] ; // "~~~~~請輸入你的請輸入你的 Channel Access Token~~~~~~~";
        //請輸入你的User Id
        string AdminUserId = System.Configuration.ConfigurationManager.AppSettings["AdminUserId"];//"~~~~~請輸入你的User Id~~~~~~~";

        //icon位置
        const string IconUrl = "https://arock.blob.core.windows.net/blogdata201809/1337594581_package_edutainment.png";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //建立一個TextMessage物件
            isRock.LineBot.TextMessage m =
             new isRock.LineBot.TextMessage("請在底下選擇一個選項");

            //在TextMessage物件的quickReply屬性中加入items
            m.quickReply.items.Add(
                 new isRock.LineBot.QuickReplyMessageAction(
                     $"一般標籤", "點選後顯示的text文字"));
            m.quickReply.items.Add(
             new isRock.LineBot.QuickReplyMessageAction(
                 $"有圖示的標籤", "點選後顯示的text文字", new Uri(IconUrl)));
            //加入QuickReplyDatetimePickerAction
            m.quickReply.items.Add(
             new isRock.LineBot.QuickReplyDatetimePickerAction(
                 "選時間", "選時間", isRock.LineBot.DatetimePickerModes.datetime, new Uri(IconUrl)));
            //加入QuickReplyLocationAction
            m.quickReply.items.Add(
               new isRock.LineBot.QuickReplyLocationAction(
                   "選地點", new Uri(IconUrl)));
            //加入QuickReplyCameraAction
            m.quickReply.items.Add(
                new isRock.LineBot.QuickReplyCameraAction(
                "Show Camera", new Uri(IconUrl)));
            //加入QuickReplyCamerarollAction
            m.quickReply.items.Add(
                new isRock.LineBot.QuickReplyCamerarollAction(
                "Show Cameraroll", new Uri(IconUrl)));
            //建立bot instance
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelAccessToken);
            //透過Push發送訊息
            bot.PushMessage(AdminUserId, m);
        }
    }
}