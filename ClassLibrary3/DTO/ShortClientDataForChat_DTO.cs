using System;
using System.Collections.Generic;
using System.Text;

namespace MTCrepository.DTO
{
    public class ShortClientDataForChat_DTO
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public int UnreadedMessages { get; set; }
        public bool IsOnline { get; set; }

        public string Email { get; set; }
    }
}
