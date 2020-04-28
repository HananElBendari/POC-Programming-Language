﻿using System;

namespace POC.Programming.Domain
{
    public class IEntity
    {
        public int Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
