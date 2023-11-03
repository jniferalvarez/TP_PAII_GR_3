using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Domain.MailAdapter
{
    public class MailClient
    {
       
            public string Host { get; private set; }
            public int Port { get; private set; }
            public bool EnableSsl { get; private set; }
            public SmtpDeliveryMethod DeliveryMethod { get; private set; }
            public bool UseDefaultCredentials { get; private set; }
            public NetworkCredential Credentials { get; private set; }

            // Atributos parametrizables
            public string AddressMail { get; private set; } // Mail del destino
            public string AddressName { get; private set; } // Nombre del destino
            public string DynamicSubject { get; private set; } // Asunto dinámico
            public string DynamicBody { get; private set; } // Cuerpo del Mail dinámico

            public MailClient(string addressMail, string addressName, string dynamicSubject, string dynamicBody)
            {
                AddressMail = addressMail;
                AddressName = addressName;
                DynamicSubject = dynamicSubject;
                DynamicBody = dynamicBody;
            }

            public void SendMail()
            {
                try
                {
                    var fromAddress = new MailAddress("andres030685@gmail.com", "PayMaster");
                    var toAddress = new MailAddress(AddressMail, AddressName);
                    const string fromPassword = "fqui gxps bdcr bfae";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = DynamicSubject,
                        Body = DynamicBody,
                        IsBodyHtml = true
                    })
                    {
                        smtp.Send(message);
                    }

                    Console.WriteLine("Correo enviado exitosamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo: " + ex.Message);
                }
            }
        }


    }

