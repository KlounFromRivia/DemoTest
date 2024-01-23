﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToursProject.Context.Models
{
    public class HotelComment
    {
        public int Id { get; set; }

        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        [Required]
        public string Text { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTimeOffset CreationDate { get; set; }
    }
}
