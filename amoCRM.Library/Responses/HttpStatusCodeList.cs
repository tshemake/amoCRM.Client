using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;

namespace amoCRM.Library.Responses
{
    public class HttpStatusCodeList
    {
        public static ReadOnlyCollection<HttpStatusInfo> HttpStatusInfos;

        static HttpStatusCodeList()
        {
            HttpStatusInfos = new ReadOnlyCollection<HttpStatusInfo>(new List<HttpStatusInfo>
            {
                new HttpStatusInfo { Code = HttpStatusCode.Continue, Message = "Продолжай" },
                new HttpStatusInfo { Code = HttpStatusCode.SwitchingProtocols, Message = "Переключение протоколов" },
                new HttpStatusInfo { Code = HttpStatusCode.Processing, Message = "Идёт обработка" },
                new HttpStatusInfo { Code = HttpStatusCode.OK, Message = "Хорошо" },
                new HttpStatusInfo { Code = HttpStatusCode.Created, Message = "Создано" },
                new HttpStatusInfo { Code = HttpStatusCode.Accepted, Message = "Принято" },
                new HttpStatusInfo { Code = HttpStatusCode.NonAuthoritativeInformation, Message = "Информация не авторитетна" },
                new HttpStatusInfo { Code = HttpStatusCode.NoContent, Message = "Нет содержимого" },
                new HttpStatusInfo { Code = HttpStatusCode.ResetContent, Message = "Сбросить содержимое" },
                new HttpStatusInfo { Code = HttpStatusCode.PartialContent, Message = "Частичное содержимое" },
                new HttpStatusInfo { Code = HttpStatusCode.MultiStatus, Message = "Многостатусный" },
                new HttpStatusInfo { Code = HttpStatusCode.AlreadyReported, Message = "Уже сообщалось" },
                new HttpStatusInfo { Code = HttpStatusCode.IMUsed, Message = "Использовано IM" },
                new HttpStatusInfo { Code = HttpStatusCode.MultipleChoices, Message = "Множество выборов" },
                new HttpStatusInfo { Code = HttpStatusCode.Moved, Message = "Перемещено навсегда" },
                new HttpStatusInfo { Code = HttpStatusCode.MovedPermanently, Message = "Перемещено временно" },
                new HttpStatusInfo { Code = HttpStatusCode.Found, Message = "Найдено" },
                new HttpStatusInfo { Code = HttpStatusCode.SeeOther, Message = "Смотреть другое" },
                new HttpStatusInfo { Code = HttpStatusCode.NotModified, Message = "Не изменялось" },
                new HttpStatusInfo { Code = HttpStatusCode.UseProxy, Message = "Использовать прокси" },
                new HttpStatusInfo { Code = HttpStatusCode.Unused, Message = "Последующие запросы должны использовать указанный прокси" },
                new HttpStatusInfo { Code = HttpStatusCode.TemporaryRedirect, Message = "Временное перенаправление" },
                new HttpStatusInfo { Code = HttpStatusCode.PermanentRedirect, Message = "Постоянное перенаправление" },
                new HttpStatusInfo { Code = HttpStatusCode.BadRequest, Message = "Плохой, неверный запрос" },
                new HttpStatusInfo { Code = HttpStatusCode.Unauthorized, Message = "Не авторизован (не представился)" },
                new HttpStatusInfo { Code = HttpStatusCode.PaymentRequired, Message = "Необходима оплата" },
                new HttpStatusInfo { Code = HttpStatusCode.Forbidden, Message = "Запрещено (не уполномочен)" },
                new HttpStatusInfo { Code = HttpStatusCode.NotFound, Message = "Не найдено" },
                new HttpStatusInfo { Code = HttpStatusCode.MethodNotAllowed, Message = "Метод не поддерживается" },
                new HttpStatusInfo { Code = HttpStatusCode.NotAcceptable, Message = "Неприемлемо" },
                new HttpStatusInfo { Code = HttpStatusCode.ProxyAuthenticationRequired, Message = "Необходима аутентификация прокси" },
                new HttpStatusInfo { Code = HttpStatusCode.RequestTimeout, Message = "Истекло время ожидания" },
                new HttpStatusInfo { Code = HttpStatusCode.Conflict, Message = "Конфликт" },
                new HttpStatusInfo { Code = HttpStatusCode.Gone, Message = "Удалён" },
                new HttpStatusInfo { Code = HttpStatusCode.RequestEntityTooLarge, Message = "Полезная нагрузка слишком велика" },
                new HttpStatusInfo { Code = HttpStatusCode.RequestUriTooLong, Message = "URI слишком длинный" },
                new HttpStatusInfo { Code = HttpStatusCode.UnsupportedMediaType, Message = "Неподдерживаемый тип данных" },
                new HttpStatusInfo { Code = HttpStatusCode.RequestedRangeNotSatisfiable, Message = "Диапазон не достижим" },
                new HttpStatusInfo { Code = HttpStatusCode.ExpectationFailed, Message = "Ожидание не удалось" },
                new HttpStatusInfo { Code = HttpStatusCode.MisdirectedRequest, Message = "Запрос был перенаправлен на сервер, не способный дать ответ" },
                new HttpStatusInfo { Code = HttpStatusCode.UnprocessableEntity, Message = "Необрабатываемый экземпляр" },
                new HttpStatusInfo { Code = HttpStatusCode.Locked, Message = "Заблокировано" },
                new HttpStatusInfo { Code = HttpStatusCode.FailedDependency, Message = "Невыполненная зависимость" },
                new HttpStatusInfo { Code = HttpStatusCode.UpgradeRequired, Message = "Необходимо обновление" },
                new HttpStatusInfo { Code = HttpStatusCode.PreconditionRequired, Message = "Необходимо предусловие" },
                new HttpStatusInfo { Code = HttpStatusCode.TooManyRequests, Message = "Слишком много запросов" },
                new HttpStatusInfo { Code = HttpStatusCode.RequestHeaderFieldsTooLarge, Message = "Поля заголовка запроса слишком большие" },
                new HttpStatusInfo { Code = HttpStatusCode.UnavailableForLegalReasons, Message = "Недоступно по юридическим причинам" },
                new HttpStatusInfo { Code = HttpStatusCode.InternalServerError, Message = "Внутренняя ошибка сервера" },
                new HttpStatusInfo { Code = HttpStatusCode.NotImplemented, Message = "Не реализовано" },
                new HttpStatusInfo { Code = HttpStatusCode.BadGateway, Message = "Плохой, ошибочный шлюз" },
                new HttpStatusInfo { Code = HttpStatusCode.ServiceUnavailable, Message = "Сервис недоступен" },
                new HttpStatusInfo { Code = HttpStatusCode.GatewayTimeout, Message = "Шлюз не отвечает" },
                new HttpStatusInfo { Code = HttpStatusCode.HttpVersionNotSupported, Message = "Версия HTTP не поддерживается" },
                new HttpStatusInfo { Code = HttpStatusCode.VariantAlsoNegotiates, Message = "Вариант тоже проводит согласование" },
                new HttpStatusInfo { Code = HttpStatusCode.InsufficientStorage, Message = "Переполнение хранилища" },
                new HttpStatusInfo { Code = HttpStatusCode.LoopDetected, Message = "Обнаружено бесконечное перенаправление" },
                new HttpStatusInfo { Code = HttpStatusCode.NotExtended, Message = "Не расширено" },
                new HttpStatusInfo { Code = HttpStatusCode.NetworkAuthenticationRequired, Message = "Требуется сетевая аутентификация" },
            });
        }

        public static HttpStatusInfo GetByCode(HttpStatusCode httpStatusCode)
        {
            return HttpStatusInfos.Where(hs => hs.Code == httpStatusCode).FirstOrDefault();
        }
    }
}
