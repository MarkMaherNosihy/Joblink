using System.ComponentModel.DataAnnotations;

namespace API.Interfaces;

public enum Field
{
    IT,
    [Display(Name = "Software Development")]

    Software_Development,
    Accounting,
    Marketing,
    [Display(Name = "UI/UX")]

    UI_UX,


}
