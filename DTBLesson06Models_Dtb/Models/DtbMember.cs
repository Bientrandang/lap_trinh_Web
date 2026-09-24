namespace DTBLesson06Models.Models
{
    public class DtbMember
    {
        public Guid DtbMemberId { get; set; }
        public string DtbMemberUserName { get; set; } = "";
        public string DtbMemberPassword { get; set; } = "";
        public string DtbMemberEmail { get; set; } = "";
        public string DtbMemberFullName { get; set; } = "";
    }
}