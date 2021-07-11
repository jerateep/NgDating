﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }

        public int AppUserId { get; set; }

    }
}