using BookClub_Data.Interfaces;
using System;

namespace BookClub_Data
{
    public class Message : IIdentifiable
    {
        private int _messageId;
        private int _bookClubId;
        private int _userId;
        private string _messageContent;
        private DateTime _timestamp;

        public int Id
        {
            get => _messageId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("MessageId must be higher than 0");
                _messageId = value;
            }
        }

        public int BookClubId
        {
            get => _bookClubId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("BookClubId must be higher than 0");
                _bookClubId = value;
            }
        }

        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("UserId must be higher than 0");
                _userId = value;
            }
        }

        public string MessageContent
        {
            get => _messageContent;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("MessageContent cannot be null or empty");
                _messageContent = value;
            }
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set => _timestamp = value;
        }

        public BookClub BookClub { get; set; } // Relation til BookClub
        public User User { get; set; } // Relation til User
    }
}