using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    public class AuthorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            {
                if (value is string[] authors)
                {
                    if (authors == null || authors.Length == 0)
                    {
                        return false; // массив пустой
                    }

                    foreach (var author in authors)
                    {
                        if (!IsValidAuthorFormat(author))
                        {
                            return false; // неверный формат элемента массива
                        }
                    }
                    return true; // все элементы массива прошли проверку
                }
                return false; // значение не является массивом строк
            }
        }
        private bool IsValidAuthorFormat(string author)
        {
            string regexPattern = @"^[А-Я][а-я]+\s[А-Я]\.\s[А-Я]\.$";
            return System.Text.RegularExpressions.Regex.IsMatch(author, regexPattern);
        }

    }
}