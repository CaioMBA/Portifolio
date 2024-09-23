namespace PortifolioCore.Entities.Models.ContactModels
{
    public class NotificationRequestModel
    {
        public List<MailModel>? mails;
        public List<PhoneModel>? phones;
    }

    public class MailModel
    {
        public required List<string> mailDestinations { get; set; }
        public required string subject { get; set; }
        public required string msg { get; set; }
        public List<AttachmentModel>? attachments { get; set; }
    }

    public class AttachmentModel
    {
        public string? fileName { get; set; }
        public string? base64File { get; set; }
    }

    public class PhoneModel
    {
        public string? phoneNumber { get; set; }
    }
}
