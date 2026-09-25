using System.ComponentModel.DataAnnotations;

namespace DTBLesson06Models.Models
{
    public class Dtb_Login
    {
        public string DtbUserName { get; set; } = "";

        [DataType(DataType.Password)]
        public string DtbPassword { get; set; } = "";
    }
}
