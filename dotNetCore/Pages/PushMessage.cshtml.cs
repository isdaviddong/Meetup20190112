using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dotNetCore.Pages
{
    public class PushMessageModel : PageModel
    {
        //請輸入你的 Channel Access Token
        string ChannelAccessToken = ""; // "~~~~~請輸入你的請輸入你的 Channel Access Token~~~~~~~";
        //請輸入你的User Id
        string AdminUserId = ""; //"~~~~~請輸入你的User Id~~~~~~~";
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var bot = new isRock.LineBot.Bot(ChannelAccessToken);
            var msg = new isRock.LineBot.TextMessage("Hello World");
            bot.PushMessage(AdminUserId, msg);

            return Page();
        }
    }
}