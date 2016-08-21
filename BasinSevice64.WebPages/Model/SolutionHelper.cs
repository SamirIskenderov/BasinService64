using BasinService64.Dal;
using BasinService64.Dtos;
using System;
using System.Collections.Generic;
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
            if (string.IsNullOrWhiteSpace(query.Name))
            {
                query.Name = "Не указано.";
            }
            if (string.IsNullOrWhiteSpace(query.Message))
            {
                query.Message = "Не указано.";
            }
            if (string.IsNullOrWhiteSpace(query.Email))
            {
                query.Email = "Не указано.";
            }
            if (string.IsNullOrWhiteSpace(query.PhoneNumber))
            {
                query.PhoneNumber = "Не указано.";
            }

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("socnet.iskenderov.epam@gmail.com");
                mail.To.Add(new MailAddress("pr0gy@bk.ru"));
                mail.Subject = "New BasinService Query";
                String mailbody = string.Format("Добрый день!{0}На сайте оставлен запрос от {1}.{0}Контактные данные:{0}Телефон: {2}{0}Электронная почта: {3}{0}Оставленное сообщение: {4}{0}Дата: {5}", Environment.NewLine, query.Name, query.PhoneNumber, query.Email, query.Message, query.Date);
                mail.Body = mailbody;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("socnet.iskenderov.epam", "d8gg9Hr7TH64K");
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