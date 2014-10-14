﻿using ERAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ERAWeb.Controllers
{
    public class EscolaController : Controller
    {
        // GET: Escola
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ambientes()
        {
            return View();
        }

        public ActionResult Equipe()
        {
            return View();
        }

        public ActionResult Galeria()
        {
            return View();
        }

        public ActionResult Visita()
        {
            return View();
        }

        public ActionResult Local()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Contato(MailModel _objModelMail)
       {
           SmtpClient smtpClient = new SmtpClient();
           NetworkCredential basicCredential =
               new NetworkCredential("contato@escolareginaaltman.com.br", "escola2014");
           MailMessage message = new MailMessage();
           MailAddress fromAddress = new MailAddress(_objModelMail.Email);

           smtpClient.Host = "mail.escolareginaaltman.com.br";
           smtpClient.UseDefaultCredentials = false;
           smtpClient.EnableSsl = true;
           smtpClient.Credentials = basicCredential;

           message.From = fromAddress;
           message.Subject = _objModelMail.Assunto;
           //Set IsBodyHtml to true means you can send HTML email.
           message.IsBodyHtml = true;
           string body = _objModelMail.Mensagem;
           body = "E-mail de " + _objModelMail.Nome + " (Tel: " + _objModelMail.Telefone + ") <br /><br />Mensagem:<br />" + body;
           message.Body = body;
           message.To.Add("coordenacao@escolareginaaltman.com.br");

           try
           {
               smtpClient.Send(message);
           }
           catch (Exception ex)
           {
               //Error, could not send the message
               Response.Write(ex.Message);
           }

           return View();
        }
    }
}