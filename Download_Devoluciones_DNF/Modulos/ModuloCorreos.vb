Imports System.Net
Imports System.Net.Mail

Module ModuloCorreos

    Public Function EnviarCorreo(ByVal Mensaje As String) As String

        Try

            Dim smtp As New SmtpClient(My.Settings.ServidorCorreoSMTP)
            smtp.Port = My.Settings.Puerto
            smtp.EnableSsl = My.Settings.Ssl
            smtp.Credentials = New NetworkCredential(My.Settings.UsuarioMail, My.Settings.PassMail)

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.Timeout = 30000

            Dim fromAddress As New MailAddress(My.Settings.CorreoRemitente, "Notificacion Download")
            Dim subject As String = "Notificacion Download"
            Dim body As String = " <br> Mensaje: " & Mensaje

            Dim message As New MailMessage()
            message.To.Add(My.Settings.strDestinatarios)
            message.From = fromAddress
            message.Subject = subject
            message.Body = body
            message.IsBodyHtml = True

            smtp.Send(message)
            Return "Envio correcto"
        Catch ex As Exception
            Return "Error al enviar el correo : " & ex.Message
        End Try

    End Function


End Module
