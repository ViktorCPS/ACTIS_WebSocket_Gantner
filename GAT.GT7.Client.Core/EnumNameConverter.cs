using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Data;

namespace GAT.GT7.Client.Core
{
    public class EnumNameConverter : IValueConverter
    {
        #region Public Methods

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum enumValue;
            string retVal = "";
            DisplayAttribute attribute;
            FieldInfo fieldInfo;

            enumValue = value as Enum;

            if (enumValue != null)
            {
                fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

                if (fieldInfo != null)
                {
                    attribute = (DisplayAttribute)fieldInfo.GetCustomAttributes().SingleOrDefault(x => x.GetType() == typeof(DisplayAttribute));

                    if (attribute != null)
                    {
                        retVal = attribute.GetName();
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
