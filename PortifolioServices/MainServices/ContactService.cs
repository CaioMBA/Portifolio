using PortifolioCore.Auxiliary;
using PortifolioCore.Entities.Models.ContactModels;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.APIs.RestfulRepository;
using PortifolioInfrastructure.Data.DataBases.SqlServer;

namespace PortifolioServices.MainServices
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _repository;
        private readonly NotifyDAO _notify;
        private readonly Utils _utils;
        public ContactService(ContactRepository repository, Utils utils, NotifyDAO notify)
        {
            _repository = repository;
            _utils = utils;
            _notify = notify;
        }

        public void SendMail(string toMailAddress, string name, string fromMailAddress, string subject, string message)
        {
            string mailBody = "<!DOCTYPE html>                                <html lang=\"en\">                                <head>                                    <meta charset=\"UTF-8\">                                    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">                                    <style>                                        body {                                            font-family: 'Arial', sans-serif;                                            background-color: var(--black-color, #050505);                                            color: var(--white-color, #F8F9FA);                                            margin: 0;                                            padding: 20px;                                        }                                        .email-container {                                            background-color: var(--navbar-black-color, #1a1a1a);                                            border-radius: 8px;                                            padding: 20px;                                            max-width: 600px;                                            margin: 0 auto;                                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);                                        }                                        .header {                                            text-align: center;                                            padding-bottom: 10px;                                            border-bottom: 2px solid var(--primary-color, #9B30FF);                                        }                                        .header h1 {                                            color: var(--primary-color, #9B30FF);                                            font-size: 28px;                                            margin: 0;                                        }                                        .email-content {                                            margin: 20px 0;                                        }                                        .email-content p {                                            line-height: 1.6;                                            color: var(--light-grey-color, #D3D3D3);                                        }                                        .email-content a {                                            color: var(--secondary-color, #FFD700);                                            text-decoration: none;                                            font-weight: bold;                                        }                                        .email-content a:hover {                                            color: var(--accent-color, #FF6347);                                        }                                        .footer {                                            text-align: center;                                            padding-top: 10px;                                            border-top: 2px solid var(--primary-color, #9B30FF);                                            color: var(--dark-grey-color, #2C2C2C);                                        }                                        .footer p {                                            margin: 0;                                            font-size: 14px;                                        }                                    </style>                                </head>                                <body>                                    <div class=\"email-container\">                                        <div class=\"header\">                                            <h1>You've got a message!</h1>                                        </div>                                        <div class=\"email-content\">                                            <p><strong>From:</strong> <span style=\"color: var(--secondary-color, #FFD700);\">$REPLACE_FROM_NAME$</span></p>                                            <p><strong>Email:</strong> <a href=\"mailto:$REPLACE_FROM_MAIL$\">$REPLACE_FROM_MAIL$</a></p>                                            <p><strong>Message:</strong></p>                                            <p>$REPLACE_MESSAGE$</p>                                        </div>                                        <div class=\"footer\">                                            <p>&copy; $REPLACE_YEAR$ Caio Manoel Bezerra de Araujo</p>                                        </div>                                    </div>                                </body>                                </html>";

            mailBody = mailBody.Replace("$REPLACE_FROM_NAME$", name);
            mailBody = mailBody.Replace("$REPLACE_FROM_MAIL$", fromMailAddress);
            mailBody = mailBody.Replace("$REPLACE_MESSAGE$", message);
            mailBody = mailBody.Replace("$REPLACE_YEAR$", DateTime.Now.Year.ToString());
            mailBody = mailBody.Replace("\n", "");
            mailBody = mailBody.Replace("\r", "");
            mailBody = mailBody.Replace("\\&", "");

            MailModel mail = new MailModel()
            {
                mailDestinations = new List<string>() { toMailAddress },
                subject = subject,
                msg = mailBody,
                attachments = null
            };

            NotificationRequestModel request = new NotificationRequestModel()
            {
                mails = new List<MailModel>() { mail },
                phones = new List<PhoneModel>()
            };

            var response = _notify.sendNotification(request);

            Console.WriteLine(response);
        }
    }
}
