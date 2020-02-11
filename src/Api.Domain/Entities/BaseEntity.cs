using System;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        #nullable enable
        private DateTime? _createdDate;
        #nullable enable
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = (value == null ? DateTime.UtcNow : value); }
        }
    }
}