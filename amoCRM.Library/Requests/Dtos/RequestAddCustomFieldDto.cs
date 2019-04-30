using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests.Dtos
{
    public class RequestAddCustomFieldDto
    {
        /// <summary>
        /// Название поля.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Тип поля.
        /// </summary>
        [JsonProperty("field_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CustomFieldType FieldType { get; set; }

        /// <summary>
        /// Тип сущности.
        /// </summary>
        [JsonProperty("element_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ModelType ElementType { get; set; }

        /// <summary>
        /// Уникальный идентификатор сервиса, по которому будет доступно удаление и изменение поля.
        /// </summary>
        [JsonProperty("origin", Required = Required.Always)]
        public string Origin { get; set; }

        [JsonProperty("is_editable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsEditable { get; set; }

        /// <summary>
        /// Массив значений для списка или мультисписка. Значения указываются строковыми переменными, через запятую.
        /// </summary>
        [JsonProperty("enums", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<string> Enums { get; set; }

        /// <summary>
        /// Уникальный идентификатор записи в клиентской программе (необязательный параметр).
        /// Информация о request_id нигде не сохраняется.
        /// </summary>
        [JsonProperty("request_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int RequestId { get; set; }

        /// <summary>
        /// Обязательность заполнения поля. Данное свойство применимо только для полей списка.
        /// </summary>
        [JsonProperty("is_required", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Возможность удалить поле в интерфейсе. Данное свойство применимо только для полей списка.
        /// </summary>
        [JsonProperty("is_deletable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsDeletable { get; set; }

        /// <summary>
        /// Видимость поля в интерфейсе. Данное свойство применимо только для полей списка.
        /// </summary>
        [JsonProperty("is_visible", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsVisible { get; set; }
    }
}
