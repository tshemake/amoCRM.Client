using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using amoCRM.Library.Requests;

namespace amoCRM.Library.Responses
{
    public static class ErrorCodeList
    {
        public static ReadOnlyCollection<ErrorInfo> ErrorInfos;

        static ErrorCodeList()
        {
            ErrorInfos = new ReadOnlyCollection<ErrorInfo>(
                new List<ErrorInfo>
                {
                    new ErrorInfo { Code = "110", RequestType = Requests.RequestType.Authorization, Message = "Общая ошибка авторизации. Неправильный логин или пароль.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Unauthorized) },
                    new ErrorInfo { Code = "111", RequestType = Requests.RequestType.Authorization, Message = "Возникает после нескольких неудачных попыток авторизации. В этом случае нужно авторизоваться в аккаунте через браузер, введя код капчи.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Unauthorized) },
                    new ErrorInfo { Code = "112", RequestType = Requests.RequestType.Authorization, Message = "Возникает, когда пользователь выключен в настройках аккаунта \"Пользователи и права\" или не состоит в аккаунте.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Unauthorized) },
                    new ErrorInfo { Code = "113", RequestType = Requests.RequestType.Authorization, Message = "Доступ к данному аккаунту запрещён с Вашего IP адреса. Возникает, когда в настройках безопасности аккаунта включена фильтрация доступа к API по \"белому списку IP адресов\".", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Forbidden) },
                    new ErrorInfo { Code = "101", RequestType = Requests.RequestType.Authorization, Message = "Возникает в случае запроса к несуществующему аккаунту (субдомену).", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Unauthorized) },
                    new ErrorInfo { Code = "401", RequestType = Requests.RequestType.Authorization, Message = "На сервере нет данных аккаунта. Нужно сделать запрос на другой сервер по переданному IP.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Unauthorized) },
                    new ErrorInfo { Code = "101", RequestType = Requests.RequestType.Account, Message = "Аккаунт не найден." },
                    new ErrorInfo { Code = "102", RequestType = Requests.RequestType.Account, Message = "POST-параметры должны передаваться в формате JSON." },
                    new ErrorInfo { Code = "103", RequestType = Requests.RequestType.Account, Message = "Параметры не переданы." },
                    new ErrorInfo { Code = "104", RequestType = Requests.RequestType.Account, Message = "Запрашиваемый метод API не найден." },
                    new ErrorInfo { Code = "201", RequestType = Requests.RequestType.Contact, Message = "Добавление контактов: пустой массив." },
                    new ErrorInfo { Code = "202", RequestType = Requests.RequestType.Contact, Message = "Добавление контактов: нет прав." },
                    new ErrorInfo { Code = "203", RequestType = Requests.RequestType.Contact, Message = "Добавление контактов: системная ошибка при работе с дополнительными полями." },
                    new ErrorInfo { Code = "204", RequestType = Requests.RequestType.Contact, Message = "Добавление контактов: дополнительное поле не найдено." },
                    new ErrorInfo { Code = "205", RequestType = Requests.RequestType.Contact, Message = "Добавление контактов: контакт не создан." },
                    new ErrorInfo { Code = "206", RequestType = Requests.RequestType.Contact, Message = "Добавление/Обновление контактов: пустой запрос." },
                    new ErrorInfo { Code = "207", RequestType = Requests.RequestType.Contact, Message = "Добавление/Обновление контактов: неверный запрашиваемый метод." },
                    new ErrorInfo { Code = "208", RequestType = Requests.RequestType.Contact, Message = "Обновление контактов: пустой массив." },
                    new ErrorInfo { Code = "209", RequestType = Requests.RequestType.Contact, Message = "Обновление контактов: требуются параметры \"id\" и \"updated_at\"." },
                    new ErrorInfo { Code = "210", RequestType = Requests.RequestType.Contact, Message = "Обновление контактов: системная ошибка при работе с дополнительными полями." },
                    new ErrorInfo { Code = "211", RequestType = Requests.RequestType.Contact, Message = "Обновление контактов: дополнительное поле не найдено." },
                    new ErrorInfo { Code = "212", RequestType = Requests.RequestType.Contact, Message = "Обновление контактов: контакт не обновлён." },
                    new ErrorInfo { Code = "219", RequestType = Requests.RequestType.Contact, Message = "Список контактов: ошибка поиска, повторите запрос позднее." },
                    new ErrorInfo { Code = "330", RequestType = Requests.RequestType.Contact, Message = "Добавление/Обновление контактов: количество привязанных сделок слишком большое." },
                    new ErrorInfo { Code = "213", RequestType = Requests.RequestType.Lead, Message = "Добавление сделок: пустой массив." },
                    new ErrorInfo { Code = "214", RequestType = Requests.RequestType.Lead, Message = "Добавление/Обновление сделок: пустой запрос." },
                    new ErrorInfo { Code = "215", RequestType = Requests.RequestType.Lead, Message = "Добавление/Обновление сделок: неверный запрашиваемый метод." },
                    new ErrorInfo { Code = "216", RequestType = Requests.RequestType.Lead, Message = "Обновление сделок: пустой массив." },
                    new ErrorInfo { Code = "217", RequestType = Requests.RequestType.Lead, Message = "Обновление сделок: требуются параметры \"id\", \"updated_at\", \"status_id\", \"name\"." },
                    new ErrorInfo { Code = "240", RequestType = Requests.RequestType.Lead, Message = "Добавление/Обновление сделок: неверный параметр \"id\" дополнительного поля." },
                    new ErrorInfo { Code = "330", RequestType = Requests.RequestType.Lead, Message = "Добавление/Обновление сделок: количество привязанных контактов слишком большое." },
                    new ErrorInfo { Code = "218", RequestType = Requests.RequestType.Note, Message = "Добавление событий: пустой массив." },
                    new ErrorInfo { Code = "221", RequestType = Requests.RequestType.Note, Message = "Список событий: требуется тип." },
                    new ErrorInfo { Code = "226", RequestType = Requests.RequestType.Note, Message = "Добавление событий: элемент события данной сущности не найден." },
                    new ErrorInfo { Code = "244", RequestType = Requests.RequestType.Note, Message = "Добавление событий: недостаточно прав для добавления события." },
                    new ErrorInfo { Code = "222", RequestType = Requests.RequestType.Note, Message = "Добавление/Обновление событий: пустой запрос." },
                    new ErrorInfo { Code = "223", RequestType = Requests.RequestType.Note, Message = "Добавление/Обновление событий: неверный запрашиваемый метод (GET вместо POST)." },
                    new ErrorInfo { Code = "224", RequestType = Requests.RequestType.Note, Message = "Обновление событий: пустой массив." },
                    new ErrorInfo { Code = "225", RequestType = Requests.RequestType.Note, Message = "Обновление событий: события не найдены." },
                    new ErrorInfo { Code = "227", RequestType = Requests.RequestType.Task, Message = "Добавление задач: пустой массив." },
                    new ErrorInfo { Code = "228", RequestType = Requests.RequestType.Task, Message = "Добавление/Обновление задач: пустой запрос." },
                    new ErrorInfo { Code = "229", RequestType = Requests.RequestType.Task, Message = "Добавление/Обновление задач: неверный запрашиваемый метод." },
                    new ErrorInfo { Code = "230", RequestType = Requests.RequestType.Task, Message = "Обновление задач: пустой массив." },
                    new ErrorInfo { Code = "231", RequestType = Requests.RequestType.Task, Message = "Обновление задач: задачи не найдены." },
                    new ErrorInfo { Code = "232", RequestType = Requests.RequestType.Task, Message = "Добавление событий: ID элемента или тип элемента пустые либо неккоректные." },
                    new ErrorInfo { Code = "233", RequestType = Requests.RequestType.Task, Message = "Добавление событий: по данному ID элемента не найдены некоторые контакты." },
                    new ErrorInfo { Code = "234", RequestType = Requests.RequestType.Task, Message = "Добавление событий: по данному ID элемента не найдены некоторые сделки." },
                    new ErrorInfo { Code = "235", RequestType = Requests.RequestType.Task, Message = "Добавление задач: не указан тип элемента." },
                    new ErrorInfo { Code = "236", RequestType = Requests.RequestType.Task, Message = "Добавление задач: по данному ID элемента не найдены некоторые контакты." },
                    new ErrorInfo { Code = "237", RequestType = Requests.RequestType.Task, Message = "Добавление задач: по данному ID элемента не найдены некоторые сделки." },
                    new ErrorInfo { Code = "238", RequestType = Requests.RequestType.Task, Message = "Добавление контактов: отсутствует значение для дополнительного поля." },
                    new ErrorInfo { Code = "244", RequestType = Requests.RequestType.Task, Message = "Добавление сделок: нет прав." },
                    new ErrorInfo { Code = "405", RequestType = Requests.RequestType.Catalog, Message = "Метод передачи запроса неверный." },
                    new ErrorInfo { Code = "222", RequestType = Requests.RequestType.Catalog, Message = "Добавление/Обновление/Удаление каталогов: пустой запрос." },
                    new ErrorInfo { Code = "244", RequestType = Requests.RequestType.Catalog, Message = "Добавление/Обновление/Удаление каталогов: нет прав." },
                    new ErrorInfo { Code = "281", RequestType = Requests.RequestType.Catalog, Message = "Каталог не удален: внутренняя ошибка." },
                    new ErrorInfo { Code = "282", RequestType = Requests.RequestType.Catalog, Message = "Каталог не найден в аккаунте." },
                    new ErrorInfo { Code = "283", RequestType = Requests.RequestType.Catalog, Message = "Неверный запрос, данные не переданы." },
                    new ErrorInfo { Code = "284", RequestType = Requests.RequestType.Catalog, Message = "Неверный запрос, передан не массив." },
                    new ErrorInfo { Code = "285", RequestType = Requests.RequestType.Catalog, Message = "Требуемое поле не передано." },
                    new ErrorInfo { Code = "405", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Метод передачи запроса неверный." },
                    new ErrorInfo { Code = "203", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Добавление/Обновление элементов каталога: системная ошибка при работе с дополнительными полями." },
                    new ErrorInfo { Code = "204", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Добавление/Обновление элементов каталога: дополнительное поле не найдено." },
                    new ErrorInfo { Code = "222", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Добавление/Обновление/Удаление элементов каталога: пустой запрос." },
                    new ErrorInfo { Code = "244", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Добавление/Обновление/Удаление элементов каталога: нет прав." },
                    new ErrorInfo { Code = "280", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Добавление элементов каталога: элемент создан." },
                    new ErrorInfo { Code = "282", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Элемент не найден в аккаунте." },
                    new ErrorInfo { Code = "283", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Неверный запрос, данные не переданы." },
                    new ErrorInfo { Code = "284", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Неверный запрос, передан не массив." },
                    new ErrorInfo { Code = "285", RequestType = Requests.RequestType.ElementOfCatalog, Message = "Требуемое поле не передано." },
                    new ErrorInfo { Code = "288", RequestType = Requests.RequestType.Customer, Message = "Недостаточно прав. Доступ запрещен." },
                    new ErrorInfo { Code = "402", RequestType = Requests.RequestType.Customer, Message = "Необходимо оплатить функционал." },
                    new ErrorInfo { Code = "425", RequestType = Requests.RequestType.Customer, Message = "Функционал недоступен." },
                    new ErrorInfo { Code = "426", RequestType = Requests.RequestType.Customer, Message = "Функционал выключен." },
                    new ErrorInfo { Code = "400", RequestType = Requests.RequestType.Other, Message = "Неверная структура массива передаваемых данных, либо не верные идентификаторы кастомных полей." },
                    new ErrorInfo { Code = "402", RequestType = Requests.RequestType.Other, Message = "Подписка закончилась.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.PaymentRequired) },
                    new ErrorInfo { Code = "403", RequestType = Requests.RequestType.Other, Message = "Аккаунт заблокирован, за неоднократное превышение количества запросов в секунду.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.Forbidden) },
                    new ErrorInfo { Code = "429", RequestType = Requests.RequestType.Other, Message = "Превышено допустимое количество запросов в секунду.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.TooManyRequests) },
                    new ErrorInfo { Code = "2002", RequestType = Requests.RequestType.Other, Message = "По вашему запросу ничего не найдено.", HttpStatus = HttpStatusCodeList.GetByCode(HttpStatusCode.NoContent) },
                });
        }

        public static ErrorInfo Get(RequestType requestType, string errorCode, HttpStatusCode httpStatusCode)
        {
            var errorInfos = ErrorInfos.Where(info => info.RequestType == requestType && info.Code == errorCode);
            if (httpStatusCode != default)
            {
                errorInfos.Where(info => info.HttpStatus.Code == httpStatusCode);
            }
            return errorInfos.FirstOrDefault();
        }
    }
}
