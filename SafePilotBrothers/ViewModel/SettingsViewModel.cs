using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using SafePilotBrothers.Model;

namespace SafePilotBrothers.ViewModel
{
    /// <summary>
    ///     Класс ViewModel для окна "SettingsWindow.xaml".
    /// </summary>
    public class SettingsViewModel: BindableBase, IDataErrorInfo
    {
        /// <summary>
        ///     Класс ViewModel для окна "SettingsWindow.xaml".
        /// </summary>
        public SettingsViewModel()
        {
            Errors = new Dictionary<string, string>();
        }
        
        /// <summary>
        ///     Словарь ошибок.
        /// </summary>
        public Dictionary<string, string> Errors { get; set; }

        /// <summary>
        ///     Возвращает сообщение об ошибке для свойства с заданным именем.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        public string? this[string propertyName]
        {
            get
            {
                return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;
            }
        }
        
        /// <summary>
        ///     Сообщение об ошибке.
        /// </summary>
        public string Error { get; }
        
        /// <summary>
        ///     Поле нового размера.
        /// </summary>
        private string _newSizeField;

        /// <summary>
        ///     Новый размер поля.
        /// </summary>
        public string NewSizeField
        {
            get
            {
                return _newSizeField;
            }
            set
            {
                _newSizeField = value;
                
                if(!string.IsNullOrEmpty(_newSizeField))
                {
                    if (!int.TryParse(_newSizeField, out int newSize))
                    {
                        Errors[nameof(NewSizeField)] = "Некорректный ввод.";
                    }
                    else
                    {
                        if (newSize > 10 || newSize <= 0)
                        {
                            Errors[nameof(NewSizeField)] = "Значение должно быть в диапозоне от 1 до 10.";
                        }
                        else
                        {
                            Errors[nameof(NewSizeField)] = null;
                        }
                    }
                    
                    RaisePropertyChanged(nameof(Errors));
                }
                
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Проверка команды на условия.
        /// </summary>
        public bool IsCommandValid => Errors.Values.All(value => value == null) && !string.IsNullOrEmpty(NewSizeField);
        
        /// <summary>
        ///     Команда принятия изменений.
        /// </summary>
        public ICommand Ok
        {
            get
            {
                return new DelegateCommand<Window>(settingsWindow =>
                {

                    SetSizeField(NewSizeField);
                    
                    settingsWindow.Close();
                }, IsCommandValid);
            }
        }
        
        /// <summary>
        ///     Изменить размер поля.
        /// </summary>
        /// <param name="newSize">Новый размер для поля.</param>
        private static void SetSizeField(string newSize)
        {
            var pathSettings = Directory.GetCurrentDirectory() + @"\Settings\" + "Settings.json";
            using var settingsJson = new FileStream(pathSettings, FileMode.OpenOrCreate);
            var field = new Field
            {
                Size = newSize
            };
            var optionsJson = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            JsonSerializer.Serialize(settingsJson, field, optionsJson);
        }
        
        /// <summary>
        ///     Команда отмены.
        /// </summary>
        public ICommand Cancel
        {
            get
            {
                return new DelegateCommand<Window>(settingsWindow =>
                {
                    settingsWindow.Close();
                });
            }
        }
    }
}