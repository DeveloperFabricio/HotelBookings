using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using HotelBookings.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace HotelBookings.Application.Calendary
{
    public class GoogleCalendarioServico
    {
        const string CALENDAR = "primary";

        public GoogleCalendarioServico(IConfiguration _configuration) { }

        private static async Task<CalendarService> ConnectGoogleAgenda(string[] scopes)
        {
            try
            {
                string applicationName = "HotelBookings";
                UserCredential credential;
                using (var stream = new FileStream("CredentialGoogleCalendario.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.FromStream(stream).Secrets,
                            scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)
                    );
                }


                var services = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName
                });

                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Event> CreateQuickEventGoogleCalendar(string description)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR}/events/quickAdd" };
            var services = await ConnectGoogleAgenda(scopes);

            var requestCreate = services.Events.QuickAdd(CALENDAR, description).Execute();
            return requestCreate;
        }

        public static async Task<Event> CreateGoogleCalendar(GoogleCalendario request, string? emailPaciente)
        {
            string[] scopes = { "https://www.googleapis.com/auth/calendar " };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = new Event()
            {
                Summary = request.Resumo,
                Location = request.Localizacao,
                Start = new EventDateTime
                {
                    DateTime = request.Inicio.ToUniversalTime(),
                    TimeZone = "Santo André/São Paulo"
                },
                End = new EventDateTime
                {
                    DateTime = request.Fim.ToUniversalTime(),
                    TimeZone = "Santo André/São Paulo"
                },
                Description = request.Descricao,
            };
            eventCalendar.Attendees = new List<EventAttendee>
            {
                new EventAttendee { Email = emailPaciente}
            };

            var eventRequest = services.Events.Insert(eventCalendar, CALENDAR);
            var requestCreate = await eventRequest.ExecuteAsync();
            return requestCreate;
        }

        public static async Task<IList<Event>> GetEventsGoogleCalendar()
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = services.Events.List(CALENDAR).Execute();
            return events.Items;
        }

        public static async Task<Event> GetEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Get(CALENDAR, eventId).ExecuteAsync();

            return events;
        }

        public static async Task<string> DeleteEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Delete(CALENDAR, eventId).ExecuteAsync();
            return events;
        }

        public static async Task<Event> UpdateEventGoogleCalendar(string eventId, string title, DateTime start, DateTime end)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = await GetEventGoogleCalendar(eventId);

            eventCalendar.Summary = title;

            eventCalendar.Start = new EventDateTime
            {
                DateTime = start.ToUniversalTime(),
                TimeZone = "Santo André/São Paulo"
            };

            eventCalendar.End = new EventDateTime
            {
                DateTime = end.ToUniversalTime(),
                TimeZone = "Santo André/São Paulo"
            };

            var events = await services.Events.Update(eventCalendar, CALENDAR, eventId).ExecuteAsync();
            return events;
        }

        public async Task<List<Event>> GetEventsOnDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            try
            {
                UserCredential credential;
                using (var stream = new FileStream("CredentialGoogleCalendario.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { CalendarService.Scope.CalendarReadonly },
                        "user",
                        cancellationToken,
                        new FileDataStore(credPath, true)
                    );
                }

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Calendario API"
                });


                var startTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
                var endTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, DateTimeKind.Utc);

                var request = service.Events.List(CALENDAR);
                request.TimeMin = startTime;
                request.TimeMax = endTime;
                request.SingleEvents = true;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                var eventsResult = await request.ExecuteAsync(cancellationToken);

                return eventsResult.Items.ToList();
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro ao buscar eventos do Google Calendar.");
                return new List<Event>();
            }
        }
    }
}
