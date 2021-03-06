﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using TranscendenceChatServer.Models;
using Westwind.Web.Mvc;

namespace TranscendenceChatServer.Core.EmailNotifications
{
    public class LinkUserViaEmailConfirmation : EmailNotification
    {
        public User User { get; }

        public string Email { get; }

        public HttpControllerContext Context { get; }

        public LinkUserViaEmailConfirmation(User user, string email, HttpControllerContext context)
        {
            User = user;
            Email = email;
            Context = context;
        }
        internal override void GenerateMessage()
        {
            MailAddress[] list = { new MailAddress(Email, "Transcendence User") };
            Message.To = list;
            Message.Subject = "Link your Transcendence Chat account.";
            Message.Html = ViewRenderer.RenderView("~/views/templates/LinkUser.cshtml", User);
        }


    }
}
