using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Types
{
    public enum CustomFieldType : byte
    {
        Unknown = 0,

        /// <summary>
        /// Обыное текстовое поле.
        /// </summary>
        Text = 1,

        /// <summary>
        /// Текстовое поле с возможностью передавать только цифры.
        /// </summary>
        Numeric = 2,

        /// <summary>
        /// Поле обозначающее только наличие или отсутствие свойства
        /// </summary>
        Checkbox = 3,

        /// <summary>
        /// Поле типа список с возможностью выбора одного элемента.
        /// </summary>
        Select = 4,

        /// <summary>
        /// Поле типа список c возможностью выбора нескольких элементов списка.
        /// </summary>
        MultiSelect = 5,

        /// <summary>
        /// Поле типа дата возвращает и принимает значения в формате (Y-m-d H:i:s).
        /// </summary>
        Date = 6,

        /// <summary>
        /// Обычное текстовое поле предназначенное для ввода URL адресов.
        /// </summary>
        Url = 7,

        /// <summary>
        /// Поле textarea содержащее большое количество текста.
        /// </summary>
        MultiText = 8,

        /// <summary>
        /// Поле textarea содержащее большое количество текста.
        /// </summary>
        TextArea = 9,

        /// <summary>
        /// Поле типа переключатель.
        /// </summary>
        RadioButton = 10,

        /// <summary>
        /// Короткое поле адрес.
        /// </summary>
        StreetAddress = 11,

        /// <summary>
        /// Поле адрес (в интерфейсе является набором из нескольких полей).
        /// </summary>
        SmartAddress = 13,

        /// <summary>
        /// Поле типа дата поиск по которому осуществляется без учета года, значения в формате (Y-m-d H:i:s).
        /// </summary>
        Birthday = 14,

        /// <summary>
        /// Поле юридическое лицо (в интерфейсе является набором из нескольких полей).
        /// </summary>
        LegalEntity = 15,

        /// <summary>
        /// Поле состав каталога (поле доступно только в пользовательских списках).
        /// </summary>
        Items = 16,
    }
}
