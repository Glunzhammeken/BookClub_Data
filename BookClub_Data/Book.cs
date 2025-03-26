using System;

namespace BookClub_Data
{
    public class Book
    {
        private int _bookId;
        private string _title;
        private string _author;
        private string _description;
        private DateTime _uploadDate;
        private string _filePath;

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

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Title cannot be null or empty");
                _title = value;
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Author cannot be null or empty");
                _author = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Description cannot be null or empty");
                _description = value;
            }
        }

        public DateTime UploadDate
        {
            get => _uploadDate;
            set => _uploadDate = value;
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (string.IsNullOrEmpty(value) || !System.IO.File.Exists(value))
                    throw new ArgumentException("Invalid file path");
                _filePath = value;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
