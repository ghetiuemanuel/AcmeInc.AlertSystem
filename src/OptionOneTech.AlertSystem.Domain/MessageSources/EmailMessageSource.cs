using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace OptionOneTech.AlertSystem.MessageSources
{
    public class EmailMessageSource : FullAuditedEntity<Guid>
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  
        public string Folder { get; set; }
        public bool DeleteAfterDownload { get; set; }
        public bool Active { get; set; }

    protected EmailMessageSource()
    {
    }

    public EmailMessageSource(
        Guid id,
        string hostname,
        int port,
        bool ssl,
        string username,
        string password,
        string folder,
        bool deleteAfterDownload,
        bool active
    ) : base(id)
    {
        Hostname = hostname;
        Port = port;
        SSL = ssl;
        Username = username;
        Password = password;
        Folder = folder;
        DeleteAfterDownload = deleteAfterDownload;
        Active = active;
    }
    }
}
