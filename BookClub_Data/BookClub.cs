using System;
using System.Collections.Generic;

namespace BookClub_Data
{
    public class BookClub
    {
        private int _bookClubId;
        private int _bookId;
        private string _clubName;
        private int _creatorUserId;

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

        public int BookId
        {
            get => _bookId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("BookId must be higher than 0");
                _bookId = value;
            }
        }

        public string ClubName
        {
            get => _clubName;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("ClubName cannot be null or empty");
                _clubName = value;
            }
        }

        public int CreatorUserId
        {
            get => _creatorUserId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("CreatorUserId must be higher than 0");
                _creatorUserId = value;
            }
        }

        public Book Book { get; set; } // Relation til Book
        public User Creator { get; set; } // Relation til User
        public ICollection<Message> Messages { get; set; } // Samling af beskeder
        public ICollection<User> Members { get; set; } // Samling af medlemmer

        public BookClub()
        {
            Messages = new List<Message>();
            Members = new List<User>();
        }
    }
}
