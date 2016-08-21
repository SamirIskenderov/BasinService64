using BasinService64.Dal;
using BasinService64.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BasinSevice64.WebPages.Model
{
    public static class SolutionHelper
    {
        public static QueriesDal QDal { get; } = new QueriesDal();

        public static void TrySendEmail(QueryDto query)
        {
            string name = "Не указано";
            string message = "Не указано";
            string phoneNumber = "Не указано";
            string email = "Не указано";

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                name = query.Name;
            }
            if (!string.IsNullOrWhiteSpace(query.Message))
            {
                message = query.Message;
            }
            if (!string.IsNullOrWhiteSpace(query.PhoneNumber))
            {
                phoneNumber = query.PhoneNumber;
            }
            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                email = query.Email;
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailerEmailFrom"]);
                mail.To.Add(new MailAddress(ConfigurationManager.AppSettings["MailerEmailTo"]));
                mail.Subject = "New BasinService Query";
                String mailbody = string.Format("Добрый день!{0}На сайте оставлен запрос от {1}.{0}Контактные данные:{0}Телефон: {2}{0}Электронная почта: {3}{0}Оставленное сообщение: {4}{0}Дата: {5}", Environment.NewLine, name, phoneNumber, email, message, query.Date);
                mail.Body = mailbody;
                SmtpClient client = new SmtpClient();
                client.Host = ConfigurationManager.AppSettings["MailerEmailHost"];
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailerEmailPort"]);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailerEmailUser"], ConfigurationManager.AppSettings["MailerEmailPass"]);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                
            }
        }
    }
}