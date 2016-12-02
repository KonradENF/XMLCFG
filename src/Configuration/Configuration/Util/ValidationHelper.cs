using System.Globalization;


namespace XC.Configuration.Util
{
    /// <summary>
    /// Helper-Methods for importing data.
    /// </summary>
    class ValidationHelper
    {

        public static int? GetInt(string value)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            int parsed;
            if (!int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsed))
            {
                return null;
            }

            return parsed;
        }

        //public static ValidationResult IsDouble(string value)
        //{
        //    return null;// return GetDouble(value).HasValue ? new ValidationResult(true, null) : new ValidationResult(false, "Please enter a floating-point number.");
        //}
    }
}
