using System;
using System.Net;
using System.Net.Mail;

class Email
{
    public void EnviarEmail(string destinario, string tipoDeMensagem)
    {
        try
        {
            // Configurações do e-mail
            string fromEmail = "logsystem00@gmail.com";
            string toEmail = destinario;
            string assunto = "Este é um email de teste";
            string corpoEmail = "";
            
            switch(tipoDeMensagem)
            {
                case "error": corpoEmail = "Tem um erro crítico no seu programa"; assunto = "Erro no seu sistema";
                break;
                case "warning": corpoEmail = "Tem 20 novos avisos no seu programa"; assunto = "Aviso!";
                break;
                case "debug": corpoEmail = "Tem 12 novos avisos de depuração no seu programa"; assunto = "Depuração";
                break;
                case "info": corpoEmail = "Tem 15 informações novas no seu programa"; assunto = "Informação";
                break;
            }

            // Configuração do servidor SMTP do Gmail
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("logsystem00@gmail.com", "petercarlascarmona"),
                EnableSsl = true,
            };

            // Criar a mensagem de e-mail
            MailMessage mailMessage = new MailMessage(fromEmail, toEmail, assunto, corpoEmail);

            // Enviar o e-mail
            smtpClient.Send(mailMessage);

            Console.WriteLine("E-mail enviado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao enviar o e-mail: " + ex.Message);
        }
    }
}
