using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BikeFactory1.WebUI
{
    public class StaticMethods
    {
        public static void DisplayMessage(string message, Page myPage)
        {
            message = message.Replace("'", "");
            Type myType = myPage.GetType();
            myPage.ClientScript.RegisterClientScriptBlock(myType, "ScriptFromBackend", $"<script>alert('{message}')</script>");

        }
    }
}