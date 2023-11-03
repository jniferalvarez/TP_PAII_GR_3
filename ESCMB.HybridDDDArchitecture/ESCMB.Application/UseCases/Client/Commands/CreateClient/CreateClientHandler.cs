using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Domain.MailAdapter;

namespace ESCMB.Application.UseCases.Client.Commands.CreateClient
{
    internal class CreateClientHandler : IRequestCommandHandler<CreateClientCommand, string>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IClientRepository _clientRepository;
        public CreateClientHandler(IEventPublisher eventPublisher, IClientRepository clientRepository)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //TODO: Falta logica busqueda de cliente por CuitCuil para validar si ya esta dado de alta

            Domain.Entities.Client client = new Domain.Entities.Client(request.Apellido, request.CuitCuil, request.Email, request.Nombre);

            if (!client.IsValid)
            {
                throw new InvalidEntityDataException(client.ValidationErrors);
            }

            string id = await _clientRepository.AddOneAsync(client).ConfigureAwait(false);

            await _eventPublisher.Publish(client.To<ClientCreated>(), cancellationToken).ConfigureAwait(false);

           // Inicio de Envío mail
            /* Inicio de la parametrización del mail */
            string _fullName = $"{client.Nombre + " " + client.Apellido}";
            string _linkButton = $"http://localhost:4200/put/{id}";
            string _subject = $"{client.Nombre}, desde PayMaster queremos confirmar tu registro";
            string _body = $"<body>\r\n    <h1>¡Hola {_fullName}!</h1>\r\n    <p>Confirmá tu correo para continuar con el registro.</p>\r\n    <a href=\"{_linkButton}\" style=\"background-color: #007BFF; color: #ffffff; text-decoration: none; padding: 10px 20px; border-radius: 5px; display: inline-block;\">Confirmar</a>\r\n</body>";
            /* Fin de la parametrización del mail */
            MailClient mailClient = new MailClient(client.Email, _fullName, _subject, _body);
            mailClient.SendMail();
            // Inicio de Envío  mail
            return id;
        }
    }
}
