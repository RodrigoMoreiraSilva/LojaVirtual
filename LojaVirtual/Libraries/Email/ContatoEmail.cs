using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //SMTP
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("appsiga@damasio.edu.br", "*****");
            smtp.EnableSsl = true;

            //Corpo do E-mail

            string corpoMsg = string.Format("<h2>Contato - Loja Virtual</h2></br>" +
                "<b>Nome: </b>{0}</br>" +
                "<b>E-mail: </b>{1}</br>" +
                "<b>Texto: </b>{2}</br>" +
                "E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,contato.Email,contato.Texto
                );

            MailMessage mensagem = new MailMessage();

            mensagem.From = new MailAddress("appsiga@damasio.edu.br");
            mensagem.To.Add(new MailAddress(contato.Email));
            mensagem.Subject = "Contato Loja Virtual - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar mensagem
            smtp.Send(mensagem);
        }
    }
}
