using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum
{
    public class Cookie : ControllerBase
    {
        private static Cookie instance = null;
        
        private Cookie()
        {
           
        }
        public static Cookie SingleInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Cookie();
                }
                return instance;
            }
        }
        public void AppendCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(6);
            HttpContext.Response.Cookies.Append(key, value, option);
        }
        public bool CheckIfCookieExist(string key)
        {
            if (HttpContext.Request.Cookies.ContainsKey(key))
                return true;
            return false;
        }
        public void RemoveCookie(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }
        
    }
}
