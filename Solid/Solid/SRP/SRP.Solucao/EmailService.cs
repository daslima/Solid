﻿using System.Net.Mail;

namespace Solid.SRP.SRP.Solucao
{
    class EmailService
    {
        public static void Enviar(string de, string para, string assunto, string mensagem)
        {
            //Enviando Email
            var mail = new MailMessage(de, para);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = mensagem;
            client.Send(mail);

        }
    }
}
