using Model;
using System.Net.Mail;
using System.Net;

public class MailService
{
    public void sendEmail(Lead lead)
    {
        string host = "smtp.gmail.com";
        int port = 587;
        string username = "lead46932@gmail.com"; 
        string password = "fvrvmjzrwrhqktdb"; 

        string remetente = "igor_carmo64@hotmail.com"; 
        string destinatario = "lead46932@gmail.com"; 

        MailMessage mensagem = new MailMessage(remetente, destinatario);
        mensagem.Subject = "Novo lead adicionado";
        mensagem.Body = "<h2>Um novo lead foi adicionado.</h2>" +
                "<p><strong>Detalhes do lead:</strong></p>" +
                $"<p><strong>Id:</strong> {lead.Id}</p>" +
                $"<p><strong>Nome:</strong> {lead.FirstName}</p>" +
                $"<p><strong>Email:</strong> {lead.Email}</p>" +
                $"<p><strong>Descrição:</strong> {lead.Description}</p>" +
                $"<p><strong>Preço:</strong> {lead.Price}</p>" +
                $"<p><strong>Data:</strong> {lead.DateCreated}</p>";

        mensagem.IsBodyHtml = true;

        SmtpClient client = new SmtpClient(host, port);
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(username, password);
        client.EnableSsl = true;

        client.Send(mensagem);
    }

}
