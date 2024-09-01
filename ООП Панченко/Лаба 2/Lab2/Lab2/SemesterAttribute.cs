using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class SemesterAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int semester)
            {
                if (!(semester == 1 || semester == 2))
                {
                    ErrorMessage = "Некорректный семестр";
                    return false;
                }
                return true;
            }
            ErrorMessage = "Некорректный семестр";
            return false;

        }
    }
}