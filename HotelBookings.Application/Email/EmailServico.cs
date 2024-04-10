using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookings.Application.Email
{
    public class EmailServico : IEmailServico
    {
        private readonly IConfiguration _configuration;

        public EmailServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> EnviarEmail(string email, string assunto, string mensagem)
        {
            try
            {
                string applicationName = "Gerenciador do Gmail";
                string[] scopes = { GmailService.Scope.GmailSend };

                UserCredential credential;
                using (var stream = new FileStream("credentialEmail.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "tokenEmail.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.FromStream(stream).Secrets,
                            scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)
                    );
                }


                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName
                });


                var gmailMessage = new Google.Apis.Gmail.v1.Data.Message
                {
                    Raw = Base64UrlEncode(CreateMessage(email, assunto, mensagem))
                };


                var result = await service.Users.Messages.Send(gmailMessage, "me").ExecuteAsync();

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro ao enviar o e-mail!");
                return false;
            }
        }

        private string CreateMessage(string email, string subject, string message)
        {
            var msg = new StringBuilder();
            msg.AppendLine("From: Gym <fabricio@gmail.com>");
            msg.AppendLine($"To: Teste <{email}>");
            msg.AppendLine($"Subject: {subject}");
            msg.AppendLine("Content-Type: text/html; charset=utf-8");
            msg.AppendLine();
            msg.AppendLine(message);

            return msg.ToString();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}
    

